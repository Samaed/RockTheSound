namespace RTS.View
{
    partial class TimeLine
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
            this.txtbxInfos = new System.Windows.Forms.TextBox();
            this.pnlTrack = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.play = new TwoStateButton.TwoStateButton();
            this.button2 = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.ctrResize = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ctrResize)).BeginInit();
            this.SuspendLayout();
            // 
            // txtbxInfos
            // 
            this.txtbxInfos.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtbxInfos.ForeColor = System.Drawing.Color.GreenYellow;
            this.txtbxInfos.Location = new System.Drawing.Point(7, 133);
            this.txtbxInfos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtbxInfos.Multiline = true;
            this.txtbxInfos.Name = "txtbxInfos";
            this.txtbxInfos.ReadOnly = true;
            this.txtbxInfos.Size = new System.Drawing.Size(127, 56);
            this.txtbxInfos.TabIndex = 2;
            // 
            // pnlTrack
            // 
            this.pnlTrack.BackColor = System.Drawing.Color.Black;
            this.pnlTrack.BackgroundImage = global::RTS.Properties.Resources.Sequencer1;
            this.pnlTrack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlTrack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlTrack.Location = new System.Drawing.Point(140, 4);
            this.pnlTrack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlTrack.Name = "pnlTrack";
            this.pnlTrack.Size = new System.Drawing.Size(483, 208);
            this.pnlTrack.TabIndex = 4;
            this.pnlTrack.Tag = "\"timeLine\"";
            this.pnlTrack.Enter += new System.EventHandler(this.pnlTrack_Enter);
            this.pnlTrack.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTrack_MouseDown);
            this.pnlTrack.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlTrack_MouseMove);
            this.pnlTrack.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlTrack_MouseUp);
            this.pnlTrack.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.pnlTrack_PreviewKeyDown);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.BackgroundImage = global::RTS.Properties.Resources.add;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAdd.Location = new System.Drawing.Point(83, 90);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(43, 39);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // play
            // 
            this.play.Active = false;
            this.play.BackColor = System.Drawing.Color.Transparent;
            this.play.BackgroundImage = global::RTS.Properties.Resources.play;
            this.play.BackgroundImageActive = global::RTS.Properties.Resources.play2;
            this.play.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.play.Data = null;
            this.play.Location = new System.Drawing.Point(-2, 4);
            this.play.Margin = new System.Windows.Forms.Padding(5);
            this.play.Name = "play";
            this.play.Size = new System.Drawing.Size(128, 79);
            this.play.TabIndex = 5;
            this.play.Click += new System.EventHandler(this.play_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = global::RTS.Properties.Resources.delete;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.Cursor = System.Windows.Forms.Cursors.Default;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(629, 4);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(27, 25);
            this.button2.TabIndex = 6;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.BackgroundImage = global::RTS.Properties.Resources.delete;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(7, 90);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(43, 39);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ctrResize
            // 
            this.ctrResize.BackColor = System.Drawing.SystemColors.InfoText;
            this.ctrResize.DecimalPlaces = 3;
            this.ctrResize.ForeColor = System.Drawing.Color.GreenYellow;
            this.ctrResize.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.ctrResize.Location = new System.Drawing.Point(3, 215);
            this.ctrResize.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.ctrResize.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.ctrResize.Name = "ctrResize";
            this.ctrResize.Size = new System.Drawing.Size(87, 22);
            this.ctrResize.TabIndex = 7;
            this.ctrResize.ThousandsSeparator = true;
            this.ctrResize.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.ctrResize.ValueChanged += new System.EventHandler(this.ctrResize_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Location = new System.Drawing.Point(7, 195);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Duree de boucle:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label2.Location = new System.Drawing.Point(96, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "s";
            // 
            // TimeLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::RTS.Properties.Resources.metal;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrResize);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.play);
            this.Controls.Add(this.pnlTrack);
            this.Controls.Add(this.txtbxInfos);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(825, 246);
            this.Name = "TimeLine";
            this.Size = new System.Drawing.Size(821, 240);
            this.Load += new System.EventHandler(this.TimeLine_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ctrResize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbxInfos;
        private System.Windows.Forms.Panel pnlTrack;
        private System.Windows.Forms.Button btnAdd;
        private TwoStateButton.TwoStateButton play;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.NumericUpDown ctrResize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

    }
}
