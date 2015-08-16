namespace RTS
{
    partial class ShortcutPopup
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.KeyBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.PitchBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Validate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Close);
            // 
            // KeyBox
            // 
            this.KeyBox.AcceptsReturn = true;
            this.KeyBox.AcceptsTab = true;
            this.KeyBox.Location = new System.Drawing.Point(13, 13);
            this.KeyBox.MaxLength = 5;
            this.KeyBox.Name = "KeyBox";
            this.KeyBox.ReadOnly = true;
            this.KeyBox.Size = new System.Drawing.Size(85, 20);
            this.KeyBox.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(104, 50);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Close);
            // 
            // PitchBox
            // 
            this.PitchBox.AcceptsReturn = true;
            this.PitchBox.AcceptsTab = true;
            this.PitchBox.Location = new System.Drawing.Point(104, 13);
            this.PitchBox.MaxLength = 1;
            this.PitchBox.Name = "PitchBox";
            this.PitchBox.ReadOnly = true;
            this.PitchBox.Size = new System.Drawing.Size(85, 20);
            this.PitchBox.TabIndex = 4;
            // 
            // ShortcutPopup
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(203, 85);
            this.ControlBox = false;
            this.Controls.Add(this.PitchBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.KeyBox);
            this.Controls.Add(this.button1);
            this.KeyPreview = true;
            this.Name = "ShortcutPopup";
            this.Text = "ShortcutPopup";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShortcutPopup_FormClosing);
            this.Load += new System.EventHandler(this.ShortcutPopup_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ShortcutBox_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox KeyBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox PitchBox;



    }
}