namespace RTS.View.Controls
{
    partial class SoundLibrary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SoundLibrary));
            this.btnAdd = new System.Windows.Forms.Button();
            this.soundsList = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnEffect = new System.Windows.Forms.Button();
            this.lbEffects = new System.Windows.Forms.CheckedListBox();
            this.btnValidateEffects = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.BackgroundImage = global::RTS.Properties.Resources.add;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAdd.Location = new System.Drawing.Point(3, 300);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(53, 49);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.AddFile);
            // 
            // soundsList
            // 
            this.soundsList.BackColor = System.Drawing.Color.Black;
            this.soundsList.ForeColor = System.Drawing.Color.GreenYellow;
            this.soundsList.FormattingEnabled = true;
            this.soundsList.ItemHeight = 16;
            this.soundsList.Location = new System.Drawing.Point(3, 2);
            this.soundsList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.soundsList.Name = "soundsList";
            this.soundsList.Size = new System.Drawing.Size(288, 292);
            this.soundsList.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(120, 300);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 49);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.PlaySelected);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = global::RTS.Properties.Resources.delete;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.Cursor = System.Windows.Forms.Cursors.Default;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(61, 300);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(53, 49);
            this.button2.TabIndex = 5;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.RemoveFile);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::RTS.Properties.Resources.shortcut21;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Location = new System.Drawing.Point(239, 302);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(53, 49);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.Shortcut);
            // 
            // btnEffect
            // 
            this.btnEffect.BackColor = System.Drawing.Color.Transparent;
            this.btnEffect.BackgroundImage = global::RTS.Properties.Resources.effect;
            this.btnEffect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEffect.FlatAppearance.BorderSize = 0;
            this.btnEffect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEffect.Location = new System.Drawing.Point(179, 300);
            this.btnEffect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEffect.Name = "btnEffect";
            this.btnEffect.Size = new System.Drawing.Size(53, 49);
            this.btnEffect.TabIndex = 8;
            this.btnEffect.UseVisualStyleBackColor = false;
            this.btnEffect.Click += new System.EventHandler(this.Effect);
            // 
            // lbEffects
            // 
            this.lbEffects.BackColor = System.Drawing.Color.Black;
            this.lbEffects.ForeColor = System.Drawing.Color.Green;
            this.lbEffects.FormattingEnabled = true;
            this.lbEffects.Location = new System.Drawing.Point(3, 2);
            this.lbEffects.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbEffects.Name = "lbEffects";
            this.lbEffects.Size = new System.Drawing.Size(288, 344);
            this.lbEffects.TabIndex = 9;
            this.lbEffects.Visible = false;
            // 
            // btnValidateEffects
            // 
            this.btnValidateEffects.BackColor = System.Drawing.Color.Transparent;
            this.btnValidateEffects.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnValidateEffects.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnValidateEffects.Location = new System.Drawing.Point(61, 308);
            this.btnValidateEffects.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnValidateEffects.Name = "btnValidateEffects";
            this.btnValidateEffects.Size = new System.Drawing.Size(171, 34);
            this.btnValidateEffects.TabIndex = 10;
            this.btnValidateEffects.Text = "OK";
            this.btnValidateEffects.UseVisualStyleBackColor = false;
            this.btnValidateEffects.Visible = false;
            this.btnValidateEffects.Click += new System.EventHandler(this.ValidateEffects);
            // 
            // SoundLibrary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnValidateEffects);
            this.Controls.Add(this.lbEffects);
            this.Controls.Add(this.btnEffect);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.soundsList);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "SoundLibrary";
            this.Size = new System.Drawing.Size(304, 372);
            this.Load += new System.EventHandler(this.SoundLibrary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox soundsList;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnEffect;
        private System.Windows.Forms.CheckedListBox lbEffects;
        private System.Windows.Forms.Button btnValidateEffects;
    }
}
