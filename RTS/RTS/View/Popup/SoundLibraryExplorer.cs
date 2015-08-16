using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RTS.Model;

namespace RTS.View
{
    public partial class SoundLibraryExplorer : Form
    {
        private Sound _sound = null;
        
        public SoundLibraryExplorer()
        {
            InitializeComponent();
        }

        public Sound SelectedSound
        {
            get { return _sound; }
        }

        private void SoundLibraryExplorer_Load(object sender, EventArgs e)
        {
            this.SoundLibrary.DataSource = Model.Model.GetInstance().SoundLibrary.Sounds;
        }

        private void Validate(object sender, EventArgs e)
        {
            this._sound = (Sound)this.SoundLibrary.Items[this.SoundLibrary.SelectedIndex];
            this.Close();
        }

        private void Cancel(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
