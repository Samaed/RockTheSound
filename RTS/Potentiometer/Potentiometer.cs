using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Potentiometer
{
    public delegate void ValueChangedEventHandler(object sender, ValueChangedEventArgs e);

    public partial class Potentiometer : UserControl
    {
        private bool _mousedown = false;
        private float _minangle = 0;
        private float _maxangle = 360;
        private float _value;

        public Potentiometer()
        {
            InitializeComponent();
        }

        [Description("Value of the button"), Category("Data")]
        public float Value
        {
            get { return _value; }
            set { _value = value; }
        }

        [Description("Minimum angle of the button"), Category("Data")]
        public float MinAngle
        {
            get { return this._minangle; }
            set { this._minangle = value; }
        }

        [Description("Maximum angle of the button"), Category("Data")]
        public float MaxAngle
        {
            get { return this._maxangle; }
            set { this._maxangle = value; }
        }

        // Declare an event
        [Description("Fires when the value is changed"), Category("Property Changed")]
        public event ValueChangedEventHandler ValueChanged;

        private void Potentiometer_MouseDown(object sender, MouseEventArgs e)
        {
            this._mousedown = true;
        }

        private void Potentiometer_MouseMove(object sender, MouseEventArgs e)
        {
            if (this._mousedown)
            {
                double angle;
                double deltaX = (e.Location.X - (ClientSize.Width / 2));
                double deltaY = (e.Location.Y - (ClientSize.Height / 2));

                angle = -Math.Atan2(deltaX, deltaY);
                angle = (((deltaX < 0) ? angle : 2 * Math.PI + angle) * 180 / Math.PI);

                if (angle >= this.MinAngle && angle <= this.MaxAngle)
                {
                    this.Value = ((float)angle - this.MinAngle) / (this.MaxAngle - this.MinAngle);
                    OnValueChanged(new ValueChangedEventArgs(this.Value));
                    this.Refresh();
                }
            }
        }

        private void Potentiometer_MouseUp(object sender, MouseEventArgs e)
        {
            this._mousedown = false;
            this.Refresh();
        }

        private void Potentiometer_MouseLeave(object sender, EventArgs e)
        {
            this._mousedown = false;
            this.Refresh();
        }

        private void Potentiometer_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath p = new GraphicsPath();
            p.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            this.Region = new Region(p);
            p.Dispose();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Create a new empty bitmap to hold rotated image
            Bitmap rotatedBmp = new Bitmap(this.BackgroundImage.Width, this.BackgroundImage.Height);
            rotatedBmp.SetResolution(this.BackgroundImage.HorizontalResolution, this.BackgroundImage.VerticalResolution);

            // Make a graphics object from the empty bitmap
            Graphics g = Graphics.FromImage(rotatedBmp);

            g.TranslateTransform((rotatedBmp.Size.Width + 1) / 2, (rotatedBmp.Size.Height + 1) / 2);
            g.RotateTransform((this.Value * (this.MaxAngle - this.MinAngle)) + this.MinAngle);
            g.TranslateTransform(-(rotatedBmp.Size.Width + 1) / 2, -(rotatedBmp.Size.Height + 1) / 2);
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;

            g.DrawImage(this.BackgroundImage, new PointF(0, 0));

            e.Graphics.DrawImage((Image)rotatedBmp, new Rectangle(new Point(0, 0), ClientSize), new Rectangle(new Point(0, 0), rotatedBmp.Size), GraphicsUnit.Pixel);
        }

        protected virtual void OnValueChanged(ValueChangedEventArgs e)
        {
            if (ValueChanged != null)
                ValueChanged(this, e);
        }
    }
}