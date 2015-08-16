namespace RTS.View
{
    partial class SoundLibraryExplorer
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
            this.applyButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SoundLibrary = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // applyButton
            // 
            this.applyButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.applyButton.Location = new System.Drawing.Point(12, 227);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(115, 23);
            this.applyButton.TabIndex = 0;
            this.applyButton.Text = "Validate";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.Validate);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(157, 227);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(115, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.Cancel);
            // 
            // SoundLibrary
            // 
            this.SoundLibrary.FormattingEnabled = true;
            this.SoundLibrary.Location = new System.Drawing.Point(12, 13);
            this.SoundLibrary.Name = "SoundLibrary";
            this.SoundLibrary.Size = new System.Drawing.Size(260, 199);
            this.SoundLibrary.TabIndex = 2;
            // 
            // SoundLibraryExplorer
            // 
            this.AcceptButton = this.applyButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.ControlBox = false;
            this.Controls.Add(this.SoundLibrary);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.applyButton);
            this.Name = "SoundLibraryExplorer";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Sound Library";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SoundLibraryExplorer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ListBox SoundLibrary;
    }
}