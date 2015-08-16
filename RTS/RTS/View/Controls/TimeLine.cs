using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RTS.Model;
using RTS.Controller.Record;
using System.Xml;
using System.Xml.Linq;
using RTS.Observer;
using System.Threading;
using RTS.Event.Record;



namespace RTS.View
{
    public partial class TimeLine : UserControl, Observer<SequenceEvent>
    {
        private static int _falseID = 0;

        private SequenceController _record = SequenceController.GetInstance();
        private double _ratio = 0; //   ratio between time(ms) and size&positions in pixels on X axis
        private Control _selected;  //selected countroll modelling a Sound
        private List<DatedSounds> _sounds; //local copy of the recorder list
        private const int TOPOFFSET = 12;//   image top band in pixels
       
        private const int BANDHEIGHT = 32; //Constants for the display of sound views
        private const int SOUNDHEIGHT = 28;  //
        private const int IMAGEWIDTH = 480; ///
        private  Color DEFAULTCOLOR = Color.SteelBlue;
        private  Color SELECTEDCOLOR = Color.Aquamarine;
        private int _mouseX;//values for drag&drop
        private int _mouseY;
        private bool _mouseDown = false;



        public TimeLine()
        {
            InitializeComponent();
        }

        /********** EVENT LISTENERS ******************************************************/
     
        //During drag&drop in this timeline  the sender is always a Control representint a sound
        private void soundControl_MouseUp(object sender, MouseEventArgs e)//end of drag&drop
        {
            this._mouseDown = false;
            Control c = (Control)sender;
            this.moveSound(this.pnlTrack.Controls.IndexOf(_selected), c.Location.X);//move element 
        }

        private void soundControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (this._selected == null)
            {
                return;
            }
            

            //Calculating the mouse position in the timeline
            this._mouseX = (this._selected.Location.X + e.X);
            this._mouseY = this._selected.Location.Y + e.Y;
            

            if (this._mouseDown)//move the control without going out of the timeline
            {
                int maxX =( pnlTrack.Width );
                int y = (int)Math.Floor((double)(_mouseY / BANDHEIGHT)) * BANDHEIGHT + TOPOFFSET   ; //getting good Y value
                this._selected.Location = new Point(Math.Min(Math.Max(0, _mouseX),maxX), Math.Min(y, 5*BANDHEIGHT + TOPOFFSET));
            }
            this.txtbxInfos.Text = this.getInfo(); //refresh description

        }

        private void soundControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (this._selected != null)
            { this._selected.BackColor = DEFAULTCOLOR; } //previously selected element set back to defaultColor

            this._mouseDown = true;
            this._selected = (Control)sender;
            this._selected.BackColor = SELECTEDCOLOR;
            this.txtbxInfos.Text = this.getInfo();  //refresh console display
            
        }

        private void soundControl_DoubleClick(object sender, MouseEventArgs e)
        {
            if (this._selected != null)
            { this._selected.BackColor = Color.Black; }            
            this._selected = (Control)sender;
            this._selected.BackColor = Color.Aquamarine;
            this.AddSound(getSelectedSound().Sound, getSelectedSound().Date.TotalMilliseconds); //duplicate sound

        }
    
        private void pnlTrack_MouseUp(object sender, MouseEventArgs e)
        {
            this._mouseDown = false;
            // this._selected.Tag.
        }

        private void pnlTrack_MouseMove(object sender, MouseEventArgs e)
        {

            this._mouseX = e.X;
            this._mouseY = e.Y;


            //this.textBox1.AppendText(e.Location);
        }

        private void pnlTrack_MouseDown(object sender, MouseEventArgs e)
        {
            if (this._selected == null)
            {
                return;
            }
            this._selected.BackColor = Color.SteelBlue;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SoundLibraryExplorer exp = new SoundLibraryExplorer();
            exp.ShowDialog();
            if (exp.SelectedSound != null)
            {
                this.AddSound(exp.SelectedSound);

            }
        }

        private void play_Click(object sender, EventArgs e)
        {
            _record.Sounds.Clear();
            _record.Sounds.AddRange(this._sounds);

            _record.TogglePlay();
            ((TwoStateButton.TwoStateButton)sender).Active = _record.Playing;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            this.removeSound();
        }

        public void pnlTrack_draggSoundIn(Sound sound,int x , int y)
        {
            
         
            x = x - pnlTrack.Location.X;
            y = y - pnlTrack.Location.Y;
            if (x > pnlTrack.Width || y > pnlTrack.Height) //if mouse out of the timeline
            { return; }

            this.txtbxInfos.Text = ((int)Math.Floor((double)(y / BANDHEIGHT))).ToString();
            this.AddSound(sound, x * _ratio, (int)Math.Floor((double)((y-TOPOFFSET)/BANDHEIGHT)));
            
         
        }
        private void pnlTrack_Enter(object sender, EventArgs e)
        {
            this.txtbxInfos.Text = "enter";
        }

        /********** END OF LISTENERS ******************************************************/

       


        public void DisplaySound(DatedSounds s, int index,int tab = 0)
        {
            Model.Model.GetInstance().SoundEngine.AddSoundSourceFromMemory(s.Sound.Bytes, s.Sound.Name);
            uint length = Model.Model.GetInstance().SoundEngine.GetSoundSource(s.Sound.Name).PlayLength;

            Label pict = new Label()
            {
                Text = s.Sound.Name,
                ForeColor = Color.Black,
                BackColor = Color.SteelBlue,
                Tag = index,
                Width = (int)(length/_ratio),
                Height = SOUNDHEIGHT,
                Location = new Point((int)(s.Date.TotalMilliseconds / _ratio),TOPOFFSET + tab*BANDHEIGHT),
                BorderStyle = BorderStyle.Fixed3D,
             
            };
          

            pict.MouseUp += new System.Windows.Forms.MouseEventHandler(this.soundControl_MouseUp);
            pict.MouseDown += new System.Windows.Forms.MouseEventHandler(this.soundControl_MouseDown);
            pict.MouseMove += new System.Windows.Forms.MouseEventHandler(this.soundControl_MouseMove);
            pict.MouseDoubleClick += new MouseEventHandler(this.soundControl_DoubleClick);

            this.pnlTrack.Controls.Add(pict);
            this.pnlTrack.Refresh();
            
        }

        public void moveSound(int index, int x)
        {

            this._sounds[index].Date = TimeSpan.FromMilliseconds(x * _ratio);

            // x * _ratio;

        }


        public void RefreshTimeLine()
        {
            this.pnlTrack.Controls.Clear();
            this._sounds.Clear();
            this._sounds.AddRange(_record.Sounds);
            this.txtbxInfos.Text = this._sounds.Count.ToString();
            int i = 0;
            int line = 0;
            int maxLine = 0;
            Dictionary<Sound,int> lines = new Dictionary<Sound,int>();//to put all similar sound on same line
            this._ratio = _record.Duration.TotalMilliseconds / this.pnlTrack.Width;
           
            foreach (DatedSounds datedSound in this._sounds)
            {
                
                if(lines.ContainsKey(datedSound.Sound))
                {
                    line = lines[datedSound.Sound];
                }
                
                
            else{
            lines.Add(datedSound.Sound,maxLine);
            line = maxLine;
                if(++maxLine >5)
                {
                    maxLine = 0;
                }

            }
                this.DisplaySound(datedSound, i, line);

                i++;
            }

        }

        

        private void TimeLine_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            this._sounds = new List<DatedSounds>();
            SequenceController.GetInstance().AddObserver(this);
        }

        private void AddSound(Sound s, double time = 0, int tab = 2)
        {
            DatedSounds ds = new DatedSounds(_falseID++, TimeSpan.FromMilliseconds(time), Event.Playback.PlaybackEvent.PlaybackAction.PLAY, s);
           this._sounds.Add(ds);
           Model.Model.GetInstance().PlaySound(s);
            this.DisplaySound(ds,this._sounds.IndexOf(ds),tab);

        }

        public void Open()
        {

            
            if (_record.Duration == null || _record.Duration.TotalMilliseconds <= 1 )  // if record is null or has changed => refresh
            {
                txtbxInfos.Text = "new";
                _record.Duration = TimeSpan.FromMilliseconds(4000);
                  this._sounds = new List<DatedSounds>();
                  this.pnlTrack.Controls.Clear();
                this.RefreshTimeLine();
            }
            if (!this._sounds.Equals(_record.Sounds))
            {
                this._sounds = new List<DatedSounds>();
                this.pnlTrack.Controls.Clear();
                this.RefreshTimeLine();
            }
            this._ratio = _record.Duration.TotalMilliseconds / this.pnlTrack.Width;
            this.Visible = true; ;
            this.ctrResize.Value = Decimal.Round((decimal)(_record.Duration.TotalMilliseconds / 1000), 2);
           

        }

        public void Close()
        {
            if (_record.Playing)
            {
                _record.TogglePlay();

            }
            _record.Sounds.Clear();
            _record.Sounds.AddRange(this._sounds);
            this.Visible = false;

        }

       

      
        
        private void removeSound(Control soundRepresentation= null)
        {
            if(soundRepresentation == null && _selected ==null)
            {
                return;
            }
            if(_selected == null)
            {
                _selected = soundRepresentation;
                    

            }
           this._sounds.Remove(this.getSelectedSound());
            this.pnlTrack.Controls.Remove(this._selected);
            this._selected = null;

        }

        private void changeLength(double length) {
            double newRatio = (length / this.pnlTrack.Width);
            double changeRatio = _ratio/ newRatio ;//changing ratio
            this._record.Duration = TimeSpan.FromMilliseconds(length);
            foreach (Control soundView in this.pnlTrack.Controls)
            {
                if((soundView.Location.X ) *newRatio >length -10)
                {
                    this.removeSound(soundView);
                }
                else
                {
                   
                  
                    soundView.Width = (int)(soundView.Width * changeRatio);  //changing Control width
                    this._selected = soundView;
                    this.getSelectedSound().Date = TimeSpan.FromMilliseconds(getSelectedSound().Date.TotalMilliseconds / changeRatio); //changig sound date to keep the same beat 

                                        
                }
                


                this._ratio = newRatio; 
                this._selected = null;
            }
        
        
        
        }

        private void pnlTrack_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            
            if (e.KeyData == Keys.Delete)
            {
                this.pnlTrack.Controls.Remove(this._selected);
            }
        }



        private  DatedSounds getSelectedSound()
        {
            if(this._selected == null)
            { return null; };

            try
            {
                return this._sounds[(this.pnlTrack.Controls.IndexOf(_selected))];
            }
            catch (Exception)
            {
                return (this._sounds[0]);
            }
        }

        private string getInfo()   //return a string containing infos on the selected sound : name and begining date
        {
            if (this._selected != null)
            { 
                DatedSounds s = this.getSelectedSound();
                DecimalConverter converter = new DecimalConverter();

                return String.Format("{0}  {1} {2} s \n ", s.Sound.Name, Environment.NewLine,(Decimal.Round((decimal)(_selected.Location.X * _ratio / 1000), 2)));
            }
            return "";
        
        }

        private int getTab(Control s)
        {
            return  (int)((s.Location.Y - TOPOFFSET) / BANDHEIGHT) ;
            
        }

        private void ctrResize_ValueChanged(object sender, EventArgs e)
        {
            this.changeLength(((double)((NumericUpDown)sender).Value)*1000);
        }       

        delegate void RefreshTimeLineCallback();
        public void Refresh(SequenceEvent e)
        {
            if (e is UpdateEvent)
            {
                RefreshTimeLineCallback callback = new RefreshTimeLineCallback(RefreshTimeLine);
                this.Invoke(callback);
            }
        }
    }
}
