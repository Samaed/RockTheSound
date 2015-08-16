using IrrKlang;
using RTS.Controller;
using RTS.Model;
using RTS.Controller.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using RTS.Controller.Export;
using RTS.View.Controls;
using RTS.Controller.Record;
using System.Xml.Linq;
using NAudio.Midi;
using RTS.Controller.MIDI.NoteID;
using RTS.Event;

namespace RTS.View
{
    public partial class MainFrame : Form
    {
        private SoundCloudExporter _scUpload = new SoundCloudExporter();
        private ConfigurationForm _settings = new ConfigurationForm();
        private Dictionary<Keys, bool> _keyDownFirstTime;

        public MainFrame()
        {
            InitializeComponent();
            this._keyDownFirstTime = new Dictionary<Keys, bool>();
        }

        private void MainFrame_Load(object sender, EventArgs e)
        {
            // Attach console to models
            Model.Model.GetInstance().AddObserver(this.console);
            Model.Model.GetInstance().Metronome.AddObserver(this.console);

            // Attach console to controllers
            ExportController.GetInstance().AddObserver(this.console);
            SequenceController.GetInstance().AddObserver(this.console);
            NetworkConnection.GetInstance().AddObserver(this.console);

            // Add Tooltips
            ToolTip tooltip;
            foreach (Control c in this.Controls)
            {

                if (c.Tag != null)
                {
                    tooltip = new ToolTip();
                    tooltip.AutoPopDelay = 2000;
                    tooltip.InitialDelay = 1000;
                    tooltip.ReshowDelay = 500;

                    tooltip.ShowAlways = true;

                    tooltip.SetToolTip(c, c.Tag.ToString());
                }
            }

            PadView p;
            List<PadView> pads = new List<PadView>();
            List<PictureBox> pictures = new List<PictureBox>();

            // Init the pads
            foreach (Control c in this.Controls)
            {
                if (c is PadView)
                {
                    pads.Add((PadView)c);
                    p = (PadView)c;

                    if (p.Data == null)
                    {
                        p.Data = "0";
                    }

                    Model.Model.GetInstance().AddObserver(p);
                }
                else if (c is PictureBox)
                {
                    pictures.Add((PictureBox)c);
                }
            }

            // Init the pictureboxes
            for (int i = 0; i < pictures.Count; i++)
            {
                pictures[i].Tag = pads[i];
            }

            // Init the network
            networkNameTextBox.Text = ConfigurationManager.AppSettings["name"];
            this.ipTextBox.Text = ConfigurationManager.AppSettings["serverIP"];

            // Start the MIDI listening
            MIDIController midiController = MIDIController.GetInstance();
            if (midiController.DevicesCount == 1)
            {
                midiController.StartRecording(0);
                midiController.AddMessageReceivedHandler(0, new EventHandler<MidiInMessageEventArgs>(this.MIDIMessageReceived));
            }

            this.ActiveControl = this.volumePotentiometer;



          addMouseEventHandlers(this);
        }

        private void MainFrame_MouseDown(object sender, MouseEventArgs e)
        {
            // ActiveControl looses focus
            this.ActiveControl = null;
        }

        private void MainFrame_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(this.ActiveControl is TextBoxBase))
            {
                if (!this._keyDownFirstTime.ContainsKey(e.KeyCode))
                {
                    this._keyDownFirstTime.Add(e.KeyCode, true);
                }

                if (!this._keyDownFirstTime[e.KeyCode]) return;

                this._keyDownFirstTime[e.KeyCode] = false;

                Sound s = ShortcutManager<Keys>.GetInstance().GetSound(e.KeyCode);
                if (s != null)
                {
                    if (NetworkConnection.GetInstance().Connected)
                    {
                        NetworkConnection.GetInstance().PlayOnServer(s.ID);
                    }
                    else
                    {
                        Model.Model.GetInstance().PlaySound(s);
                    }
                }
            }
        }

        private void MainFrame_KeyUp(object sender, KeyEventArgs e)
        {
            this._keyDownFirstTime[e.KeyCode] = true;
        }

        delegate void MIDIMessageCallback(object sender, MidiInMessageEventArgs e);
        private void MIDIMessageReceived(object sender, MidiInMessageEventArgs e)
        {
            try
            {
                MIDIMessageCallback callback = new MIDIMessageCallback(MIDICallback);
                this.Invoke(callback, new object[] { sender, e });
            }
            catch (Exception)
            {
                // This catch an exception on form closing
            }
        }

        private void MIDICallback(object sender, MidiInMessageEventArgs e)
        {

            if (this != Form.ActiveForm) return;

            if (e.MidiEvent is NoteEvent)
            {
                NoteEvent noteEvent = (NoteEvent)e.MidiEvent;
                NoteID id = new NoteID(noteEvent.NoteNumber + 1);

                Sound s = ShortcutManager<NoteID>.GetInstance(NoteID.Comparer).GetSound(id);

                if (s != null)
                {
                    if (noteEvent.Velocity != 0) // KeyDown and not KeyUp
                    {
                        if (NetworkConnection.GetInstance().Connected)
                        {
                            NetworkConnection.GetInstance().PlayOnServer(s.ID);
                        }
                        else
                        {
                            Model.Model.GetInstance().PlaySound(s);
                        }
                    }
                }
            }
        }

        private void Sound_ValueChanged(object sender, Potentiometer.ValueChangedEventArgs e)
        {
            Model.Model.GetInstance().GlobalSoundVolume = e.Value;
        }

        private void Metronome_ValueChanged(object sender, Potentiometer.ValueChangedEventArgs e)
        {
            Model.Model.GetInstance().Metronome.Speed = e.Value;
        }

        private void ToggleMetronome(object sender, EventArgs e)
        {
            Model.Model.GetInstance().Metronome.SwitchMetronome();
            ((TwoStateButton.TwoStateButton)sender).Active = Model.Model.GetInstance().Metronome.Running;
        }

        private void ToggleConnection(object sender, EventArgs e)
        {
            if (NetworkConnection.GetInstance().Connected)
            {
                NetworkConnection.GetInstance().Disconnect();
            }
            else
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings.Remove("name");
                config.AppSettings.Settings.Add("name", networkNameTextBox.Text);
                config.AppSettings.Settings.Remove("serverIP");
                config.AppSettings.Settings.Add("serverIP", this.ipTextBox.Text);
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                NetworkConnection.GetInstance().Connect(ipTextBox.Text, networkNameTextBox.Text);
            }
        }
        
        private void Pad_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                SoundLibraryExplorer s = new SoundLibraryExplorer();
                s.ShowDialog();
                if (s.SelectedSound != null)
                {
                    ((TwoStateButton.TwoStateButton)sender).Data = s.SelectedSound.ID;

                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                TwoStateButton.TwoStateButton p = (TwoStateButton.TwoStateButton)sender;
                if (NetworkConnection.GetInstance().Connected)
                {
                    NetworkConnection.GetInstance().PlayOnServer((string)p.Data);
                }
                else
                {
                    Sound s = Model.Model.GetInstance().SoundLibrary.GetSoundByID((string)p.Data);
                    Model.Model.GetInstance().PlaySound(s);
                }
            }
        }
        
        private void Record(object sender, EventArgs e)
        {
            ExportController c = Controller.Export.ExportController.GetInstance();
            if (c.Recording)
            {
                c.StopRecording();
            }
            else
            {
                c.StartRecording();
            }
            ((TwoStateButton.TwoStateButton)sender).Active = c.Recording;
        }
        
        private void Quit(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainFrame_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                if (Tools.FileAccessor.IsSoundFile(file))
                {
                    try
                    {
                        Model.Model.GetInstance().SoundLibrary.AddSound(file);
                    }
                    catch (Exception)
                    {
                    }
                    Tools.FileAccessor.SaveLibrary();
                }
            }
        }

        private void MainFrame_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                bool ok = true;
                foreach (string file in files)
                {
                    if (!Tools.FileAccessor.IsSoundFile(file))
                    {
                        ok = false;
                    }
                }
                if (ok)
                    e.Effect = DragDropEffects.Copy;
            }
        }

        private void pad_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                if (Tools.FileAccessor.IsSoundFile(file))
                {
                    try
                    {
                        Model.Model.GetInstance().SoundLibrary.AddSound(file);
                    }
                    catch (Exception)
                    {
                    }
                    Tools.FileAccessor.SaveLibrary();
                    ((TwoStateButton.TwoStateButton)sender).Data = SoundLibraryModel.GenerateID(file);
                }
            }
        }

        private void pad_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                bool ok = true;
                foreach (string file in files)
                {
                    if (!Tools.FileAccessor.IsSoundFile(file))
                    {
                        ok = false;
                    }
                }
                if (ok)
                {
                    ((TwoStateButton.TwoStateButton)sender).Active = true;
                    e.Effect = DragDropEffects.Link;
                }
            }
        }

        private void pad_DragLeave(object sender, EventArgs e)
        {
            ((TwoStateButton.TwoStateButton)sender).Active = false;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _settings.ShowDialog();
        }

        private void TwoStateButton_MouseDown(object sender, MouseEventArgs e)
        {
            ((TwoStateButton.TwoStateButton)sender).Active = true;
        }

        private void TwoStateButton_MouseUp(object sender, MouseEventArgs e)
        {
            ((TwoStateButton.TwoStateButton)sender).Active = false;
        }

        private void loopButton_Click(object sender, EventArgs e)
        {
            SequenceController.GetInstance().ToggleRecord();
            ((TwoStateButton.TwoStateButton)sender).Active = SequenceController.GetInstance().Recording;
        }

        private void playButton_MouseUp(object sender, MouseEventArgs e)
        {
            SequenceController.GetInstance().TogglePlay();
            ((TwoStateButton.TwoStateButton)sender).Active = SequenceController.GetInstance().Playing;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.SaveFileDialog dialog = new
               System.Windows.Forms.SaveFileDialog();

            dialog.Filter = "Recorded loop (*.rtsloop)|*.rtsloop";
            dialog.FilterIndex = 0;

            if (dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    string filename = dialog.FileName;
                    string name = filename.Substring(filename.LastIndexOf("\\") + 1);
                    string[] parts = name.Split(new char[] { '.' });
                    if (!parts[parts.Length - 1].Equals("rtsloop"))
                    {
                        filename = filename + ".rtsloop";
                    }
                    XDocument XDoc = new XDocument(SequenceController.GetInstance().ToXML());
                    XDoc.Save(filename);
                }
                catch (Exception)
                {
                    this.console.Refresh(new ErrorEvent(this, "saving loop into file"));
                }
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog dialog = new
               System.Windows.Forms.OpenFileDialog() { Multiselect = false };

            dialog.Filter = "Recorded loop (*.rtsloop)|*.rtsloop";
            dialog.FilterIndex = 0;

            if (dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    XDocument doc = XDocument.Load(dialog.FileName);
                    SequenceController.GetInstance().LoadXML(doc);
                }
                catch (Exception)
                {
                    this.console.Refresh(new ErrorEvent(this, "loading loop from file"));
                }

                
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SoundLibraryExplorer s = new SoundLibraryExplorer();
            s.ShowDialog();
            if (s.SelectedSound != null)
            {
                ((TwoStateButton.TwoStateButton)((Control)sender).Tag).Data = s.SelectedSound.ID;
            }
        }

        private void looperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.timeLine1.Open();
        }

        private void looperToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.timeLine1.Open();
        }

        private void MainFrame_FormClosing(object sender, FormClosingEventArgs e)
        {
            MIDIController.GetInstance().StopRecording(0);
            PadsManager.GetInstance().Save();
            XMLShortcutManager.GetInstance().Save();
        }


        /******** Drag & Drop   */
        /////same logic as in TimeLine.cs (did not have time for factorisation)
        private Point _mouseLocation;
        private Sound _selectedSound;
        private bool _mouseDown;
        private Control _draggedElement;

        private void Element_MouseMove(object sender, MouseEventArgs e)//Drag&Drop Handling
        {


            int x = e.X;
            int y = e.Y;
            Control source = (Control)sender;
            while (!(source is MainFrame))
            {
               x += source.Location.X;
                y += source.Location.Y;
                 source = source.Parent;
            }
           

            
           
            if (((Control)sender) is ListBox && _draggedElement == null && _mouseDown && soundLibrary1.SelectedSound != null)//if drag from the library =>display sound and move it
            { 

            

                this._selectedSound = this.soundLibrary1.SelectedSound; 
                _draggedElement = new Label() { BackColor = Color.Gray, Text = _selectedSound.Name, Location = this._mouseLocation };//add the listeners to record mouvements 
                _draggedElement.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Element_MouseUp);// at the end of drag&drop 
                this.Controls.Add(_draggedElement);
                this.Controls.SetChildIndex(_draggedElement, 0);
            }
            if (_draggedElement != null)
            {
                //just an update of the mouse position
                this._mouseLocation.X = x;
                this._mouseLocation.Y = y;
                _draggedElement.Location = _mouseLocation;
            }


        }

        private void Element_MouseDown(object sender, MouseEventArgs e)
        {
            this._mouseDown = true;
        }

        private void Element_MouseUp(object sender, MouseEventArgs e)//end of drag&drop
        {
            Point m = _mouseLocation;
            Point p;
            foreach (Control c in this.Controls)
            {
                p = c.Location;
               
                if (c is PadView && _selectedSound != null && m.X > p.X && m.Y > p.Y && m.X < p.X + c.Height && m.Y < p.Y + c.Width)  //check if mouse is over a pad
                {
                        ((TwoStateButton.TwoStateButton)c).Data = _selectedSound.ID;
                }
            }

          
             p = this.timeLine1.Location;
            if (_selectedSound != null && m.X > p.X && m.Y > p.Y && m.X < p.X + timeLine1.Width && m.Y < p.Y + timeLine1.Height)  //check if mouse is over the timeLine
            {
                this.timeLine1.pnlTrack_draggSoundIn(_selectedSound,m.X -p.X, m.Y-p.Y);//delegate handling to the sequencer with coordinates within the sequencer
                this._selectedSound = null;
            }
           
            this.Controls.Remove(_draggedElement);      //after mouseUp , reset selected event
            this._mouseDown = false;
            this._draggedElement = null;
            this._selectedSound = null;
        }
        
        public void addMouseEventHandlers(Control c) //add handler recursively to all controls (to know position)
        {
            c.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Element_MouseDown);
            c.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Element_MouseMove);
            c.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Element_MouseUp);
            foreach (Control control in c.Controls)
            {
                addMouseEventHandlers(control);
            }
        }

        private void uploadOnSoundCloudToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _scUpload.ShowDialog();
        }
    }
}

