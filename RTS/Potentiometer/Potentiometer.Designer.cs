﻿namespace Potentiometer
{
    partial class Potentiometer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Potentiometer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Potentiometer.Properties.Resources.button;
            this.Name = "Potentiometer";
            this.Size = new System.Drawing.Size(64, 64);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Potentiometer_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Potentiometer_MouseDown);
            this.MouseLeave += new System.EventHandler(this.Potentiometer_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Potentiometer_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Potentiometer_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
