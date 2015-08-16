using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwoStateButton
{
    public partial class TwoStateButton: UserControl
    {
        private object _data;
        private Image _defaultbg;
        private Image _activebg;
        private bool _active;

        public TwoStateButton()
        {
            InitializeComponent();
        }

        [Category("Appearance")]
        [Description("Image when active")]
        public Image BackgroundImageActive
        {
            get { return _activebg; }
            set { _activebg = value; }
        }

        [Category("Data")]
        [Description("Sound associated with the button")]
        public object Data
        {
            get { return _data; }
            set { _data = value; }
        }

        [Category("Data")]
        [Description("State of the Pad")]
        public bool Active
        {
            get { return _active; }
            set { _active = value; this.UpdateBackground(); }
        }

        private void Pad_Load(object sender, EventArgs e)
        {
            this._defaultbg = this.BackgroundImage;
        }

        private void UpdateBackground()
        {
            if (this.Active && this.BackgroundImageActive != null)
            {
                this.BackgroundImage = this.BackgroundImageActive;
            }
            else
            {
                this.BackgroundImage = this._defaultbg;
            }
        }
    }
}
