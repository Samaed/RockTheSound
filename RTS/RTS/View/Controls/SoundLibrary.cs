using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RTS.Model;
using IrrKlang;
using System.Xml.Linq;
using RTS.Controller;
using RTS.Controller.MIDI.NoteID;


namespace RTS.View.Controls
{
    public partial class SoundLibrary : UserControl
    {
        public SoundLibrary()
        {
            InitializeComponent();
        }

        private void SoundLibrary_Load(object sender, EventArgs e)
        {
            this.soundsList.DataSource = null;
           
            this.lbEffects.CheckOnClick = true;
            
            //timer for network update
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(TimerRefreshView);
            timer.Start();
        }

        private void PlaySelected(object sender, EventArgs e)
        {
            Model.Model.GetInstance().PlaySound((Sound)this.soundsList.SelectedItem);
        }

        private void AddFile(object sender, EventArgs e)
        { //prompt popup to select file(s)
            System.Windows.Forms.OpenFileDialog dialog = new
                System.Windows.Forms.OpenFileDialog() { Multiselect = true };

            dialog.Filter = "All playable files (*.mp3;*.ogg;*.wav;*.mod;*.it;*.xm;*.it;*.s3d,*.flac)|*.mp3;*.ogg;*.wav;*.mod;*.it;*.xm;*.it;*.s3d;*.flac";
            dialog.FilterIndex = 0;

            if (dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                foreach (String item in dialog.FileNames)
                {
                    try
                    {
                        Model.Model.GetInstance().SoundLibrary.AddSound(item);//add sound to library
                    }
                    catch (Exception)
                    {
                    }
                }

                Model.Model.GetInstance().SoundLibrary.Modified = true;

                this.soundsList.Items.Clear();
                this.soundsList.Items.AddRange(Model.Model.GetInstance().SoundLibrary.Sounds.ToArray());

                Tools.FileAccessor.SaveLibrary();
            }
        }

        private void RemoveFile(object sender, EventArgs e)
        {
            Sound s = (Sound)this.soundsList.SelectedItem;
            if (s != null)
                Model.Model.GetInstance().SoundLibrary.RemoveSound(s.ID);
            Model.Model.GetInstance().SoundLibrary.Modified = true;
            Tools.FileAccessor.SaveLibrary();
        }

        private void Shortcut(object sender, EventArgs e)//set key shorcut to play sound
        {
            Sound sound = (Sound)this.soundsList.SelectedItem;
            if (sound != null)
            {
                ShortcutPopup popup = new ShortcutPopup();
                popup.Text = sound.ToString() + " Shortcut";
                popup.Key = ShortcutManager<Keys>.GetInstance().GetShortcut(sound);
                popup.Note = ShortcutManager<NoteID>.GetInstance(NoteID.Comparer).GetShortcut(sound);
                popup.ShowDialog();

                ShortcutManager<Keys>.GetInstance().SetShortcut(sound, popup.Key);
                ShortcutManager<NoteID>.GetInstance(NoteID.Comparer).SetShortcut(sound, popup.Note);
            }
        }

        private void Effect(object sender, EventArgs e)
        {
            if (this.soundsList.SelectedItem == null)
            {
                return;
            }
           
            AffectedSound s = (AffectedSound)this.soundsList.SelectedItem;
            btnValidateEffects.Visible = true;//make OK button and effect selector visible 
            lbEffects.Visible = true;
            lbEffects.Controls.Clear();
          
            lbEffects.Items.Clear();
            Color color;
            int y = 5;
            int height = 35;
            foreach (KeyValuePair<string, bool> a in s.Effect)//set selector for each effect
            {
                if (a.Value)
                {
                    color = Color.White;
                }
                else
                {
                    color = Color.Black;
                }
                CheckBox c = new CheckBox() { Text = a.Key, Checked = a.Value, Appearance = System.Windows.Forms.Appearance.Button ,Location = new System.Drawing.Point(50, y),BackColor =color,Height= height,ForeColor = Color.Black};
                c.Font = new Font(c.Font.Name, 13);
                c.ForeColor = Color.LawnGreen;
                c.TextAlign = ContentAlignment.MiddleCenter;   

                c.CheckedChanged += new System.EventHandler(this.effectClicked);
               
                this.lbEffects.Controls.Add(c);
                
                lbEffects.PerformLayout();
            y+= height + 5;
            }

           
            


            //  Model.Model.GetInstance().PlaySound(s);
        }

        private void ValidateEffects(object sender, EventArgs e)
        {

            foreach (var item in this.lbEffects.Controls) //apply effect selection to the Model
            {
                CheckBox c;
                if (item is CheckBox)
                {
                    c = (CheckBox)item;
                    AffectedSound s = (AffectedSound)Model.Model.GetInstance().SoundLibrary.GetSoundByID(((Sound)this.soundsList.SelectedItem).ID);

                    s.Effect[c.Text] = c.Checked ;
                }
                
            }

            btnValidateEffects.Visible = false;
            lbEffects.Visible = false;
        }

        public void RefreshView()
        {
            if (Model.Model.GetInstance().SoundLibrary.Modified)
            {
                Model.Model.GetInstance().SoundLibrary.Modified = false;

                int selected = this.soundsList.SelectedIndex;

                this.soundsList.Items.Clear();

                Sound[] list = Model.Model.GetInstance().SoundLibrary.Sounds.ToArray();
                Array.Sort(list, new Comparison<Sound>((x, y) => string.Compare(x.Name, y.Name)));
                this.soundsList.Items.AddRange(list);

                if (this.soundsList.Items.Count != 0 && selected < this.soundsList.Items.Count)
                {
                    this.soundsList.SelectedIndex = selected;
                }
                else if (this.soundsList.Items.Count != 0)
                {
                    this.soundsList.SelectedIndex = this.soundsList.Items.Count - 1;
                    
                }
            }
        }

        private void TimerRefreshView(object sender, EventArgs e)
        {
            try
            {
                this.RefreshView();
            }
            catch (Exception)
            {
            }
        }

        private void effectClicked(object sender, EventArgs e)//change effect representation look
        {
            CheckBox c = (CheckBox)sender;
            if (c.Checked)
            {
                c.BackColor = Color.Transparent;
                c.ForeColor = Color.Black;
            }
            else {
                c.BackColor = Color.Black;
                c.ForeColor = Color.LawnGreen;
            }

        }

        public Sound SelectedSound { get { return(Sound) this.soundsList.SelectedItem; } }

        
    }
}
