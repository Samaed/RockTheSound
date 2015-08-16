using System.Windows.Forms;
using RTS.View.Controls;

namespace RTS.View
{
    partial class MainFrame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrame));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadOnSoundCloudToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.looperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fichierToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.quitterToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chargerUnSampleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.modifierUnSampleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seConnecterÀUneAutreMPCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.synchroniserLaBilbilothèqueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paramètresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.networkNameTextBox = new System.Windows.Forms.RichTextBox();
            this.ipTextBox = new System.Windows.Forms.TextBox();
            this.metronomePotentiometer = new Potentiometer.Potentiometer();
            this.volumePotentiometer = new Potentiometer.Potentiometer();
            this.playButton = new TwoStateButton.TwoStateButton();
            this.metronomeButton = new TwoStateButton.TwoStateButton();
            this.connectButton = new TwoStateButton.TwoStateButton();
            this.loopButton = new TwoStateButton.TwoStateButton();
            this.recordButton = new TwoStateButton.TwoStateButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.timeLine1 = new RTS.View.TimeLine();
            this.soundLibrary1 = new RTS.View.Controls.SoundLibrary();
            this.pad12 = new RTS.View.Controls.PadView();
            this.pad11 = new RTS.View.Controls.PadView();
            this.pad10 = new RTS.View.Controls.PadView();
            this.pad9 = new RTS.View.Controls.PadView();
            this.pad8 = new RTS.View.Controls.PadView();
            this.pad7 = new RTS.View.Controls.PadView();
            this.pad6 = new RTS.View.Controls.PadView();
            this.pad5 = new RTS.View.Controls.PadView();
            this.pad4 = new RTS.View.Controls.PadView();
            this.pad3 = new RTS.View.Controls.PadView();
            this.pad2 = new RTS.View.Controls.PadView();
            this.pad1 = new RTS.View.Controls.PadView();
            this.console = new RTS.View.Controls.ConsoleView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1013, 24);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uploadOnSoundCloudToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.loopToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // uploadOnSoundCloudToolStripMenuItem
            // 
            this.uploadOnSoundCloudToolStripMenuItem.Name = "uploadOnSoundCloudToolStripMenuItem";
            this.uploadOnSoundCloudToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.uploadOnSoundCloudToolStripMenuItem.Text = "Upload on SoundCloud";
            this.uploadOnSoundCloudToolStripMenuItem.Click += new System.EventHandler(this.uploadOnSoundCloudToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // loopToolStripMenuItem
            // 
            this.loopToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.loopToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.looperToolStripMenuItem});
            this.loopToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.loopToolStripMenuItem.Name = "loopToolStripMenuItem";
            this.loopToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.loopToolStripMenuItem.Text = "Loop";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // looperToolStripMenuItem
            // 
            this.looperToolStripMenuItem.Name = "looperToolStripMenuItem";
            this.looperToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.looperToolStripMenuItem.Text = "Looper";
            this.looperToolStripMenuItem.Click += new System.EventHandler(this.looperToolStripMenuItem_Click_1);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.Quit);
            // 
            // fichierToolStripMenuItem1
            // 
            this.fichierToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitterToolStripMenuItem1});
            this.fichierToolStripMenuItem1.Name = "fichierToolStripMenuItem1";
            this.fichierToolStripMenuItem1.Size = new System.Drawing.Size(54, 20);
            this.fichierToolStripMenuItem1.Text = "Fichier";
            // 
            // quitterToolStripMenuItem1
            // 
            this.quitterToolStripMenuItem1.Name = "quitterToolStripMenuItem1";
            this.quitterToolStripMenuItem1.Size = new System.Drawing.Size(111, 22);
            this.quitterToolStripMenuItem1.Text = "Quitter";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chargerUnSampleToolStripMenuItem,
            this.modifierUnSampleToolStripMenuItem,
            this.seConnecterÀUneAutreMPCToolStripMenuItem,
            this.synchroniserLaBilbilothèqueToolStripMenuItem,
            this.paramètresToolStripMenuItem});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.fichierToolStripMenuItem.Text = "Options";
            // 
            // chargerUnSampleToolStripMenuItem
            // 
            this.chargerUnSampleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox1});
            this.chargerUnSampleToolStripMenuItem.Name = "chargerUnSampleToolStripMenuItem";
            this.chargerUnSampleToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.chargerUnSampleToolStripMenuItem.Text = "Charger un sample";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.toolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox1.Items.AddRange(new object[] {
            "Pad 1",
            "Pad 2",
            "Pad 3",
            "Pad 4",
            "Pad 5",
            "Pad 6",
            "Pad 7",
            "Pad 8",
            "Pad 9",
            "Pad 10",
            "Pad 11",
            "Pad 12"});
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 23);
            // 
            // modifierUnSampleToolStripMenuItem
            // 
            this.modifierUnSampleToolStripMenuItem.Name = "modifierUnSampleToolStripMenuItem";
            this.modifierUnSampleToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.modifierUnSampleToolStripMenuItem.Text = "Modifier un sample";
            // 
            // seConnecterÀUneAutreMPCToolStripMenuItem
            // 
            this.seConnecterÀUneAutreMPCToolStripMenuItem.Name = "seConnecterÀUneAutreMPCToolStripMenuItem";
            this.seConnecterÀUneAutreMPCToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.seConnecterÀUneAutreMPCToolStripMenuItem.Text = "Se connecter à une autre MPC";
            // 
            // synchroniserLaBilbilothèqueToolStripMenuItem
            // 
            this.synchroniserLaBilbilothèqueToolStripMenuItem.Name = "synchroniserLaBilbilothèqueToolStripMenuItem";
            this.synchroniserLaBilbilothèqueToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.synchroniserLaBilbilothèqueToolStripMenuItem.Text = "Synchroniser la bilbilothèque";
            // 
            // paramètresToolStripMenuItem
            // 
            this.paramètresToolStripMenuItem.Name = "paramètresToolStripMenuItem";
            this.paramètresToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.paramètresToolStripMenuItem.Text = "Paramètres";
            // 
            // networkNameTextBox
            // 
            this.networkNameTextBox.Location = new System.Drawing.Point(556, 237);
            this.networkNameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.networkNameTextBox.Name = "networkNameTextBox";
            this.networkNameTextBox.Size = new System.Drawing.Size(126, 18);
            this.networkNameTextBox.TabIndex = 21;
            this.networkNameTextBox.Text = "";
            // 
            // ipTextBox
            // 
            this.ipTextBox.Location = new System.Drawing.Point(556, 198);
            this.ipTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.ipTextBox.Name = "ipTextBox";
            this.ipTextBox.Size = new System.Drawing.Size(126, 20);
            this.ipTextBox.TabIndex = 24;
            this.ipTextBox.Text = "127.0.0.1";
            // 
            // metronomePotentiometer
            // 
            this.metronomePotentiometer.BackColor = System.Drawing.Color.Black;
            this.metronomePotentiometer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("metronomePotentiometer.BackgroundImage")));
            this.metronomePotentiometer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.metronomePotentiometer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metronomePotentiometer.Location = new System.Drawing.Point(561, 309);
            this.metronomePotentiometer.Margin = new System.Windows.Forms.Padding(4);
            this.metronomePotentiometer.MaxAngle = 320F;
            this.metronomePotentiometer.MinAngle = 40F;
            this.metronomePotentiometer.Name = "metronomePotentiometer";
            this.metronomePotentiometer.Size = new System.Drawing.Size(82, 82);
            this.metronomePotentiometer.TabIndex = 41;
            this.metronomePotentiometer.Value = 0.5F;
            this.metronomePotentiometer.ValueChanged += new Potentiometer.ValueChangedEventHandler(this.Metronome_ValueChanged);
            // 
            // volumePotentiometer
            // 
            this.volumePotentiometer.BackColor = System.Drawing.Color.Black;
            this.volumePotentiometer.BackgroundImage = global::RTS.Properties.Resources.potentiometer;
            this.volumePotentiometer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.volumePotentiometer.Location = new System.Drawing.Point(300, 43);
            this.volumePotentiometer.Margin = new System.Windows.Forms.Padding(4);
            this.volumePotentiometer.MaxAngle = 315F;
            this.volumePotentiometer.MinAngle = 45F;
            this.volumePotentiometer.Name = "volumePotentiometer";
            this.volumePotentiometer.Size = new System.Drawing.Size(88, 88);
            this.volumePotentiometer.TabIndex = 22;
            this.volumePotentiometer.Value = 0.5F;
            this.volumePotentiometer.ValueChanged += new Potentiometer.ValueChangedEventHandler(this.Sound_ValueChanged);
            // 
            // playButton
            // 
            this.playButton.Active = false;
            this.playButton.BackColor = System.Drawing.Color.Transparent;
            this.playButton.BackgroundImage = global::RTS.Properties.Resources.play;
            this.playButton.BackgroundImageActive = global::RTS.Properties.Resources.play2;
            this.playButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.playButton.Data = null;
            this.playButton.Location = new System.Drawing.Point(12, 44);
            this.playButton.Margin = new System.Windows.Forms.Padding(4);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(88, 88);
            this.playButton.TabIndex = 62;
            this.playButton.Tag = "Listening what you have just record.";
            this.playButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TwoStateButton_MouseDown);
            this.playButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.playButton_MouseUp);
            // 
            // metronomeButton
            // 
            this.metronomeButton.Active = false;
            this.metronomeButton.BackColor = System.Drawing.Color.Transparent;
            this.metronomeButton.BackgroundImage = global::RTS.Properties.Resources.metronome;
            this.metronomeButton.BackgroundImageActive = global::RTS.Properties.Resources.metronome2;
            this.metronomeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.metronomeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metronomeButton.Data = null;
            this.metronomeButton.Location = new System.Drawing.Point(430, 309);
            this.metronomeButton.Margin = new System.Windows.Forms.Padding(4);
            this.metronomeButton.Name = "metronomeButton";
            this.metronomeButton.Size = new System.Drawing.Size(120, 82);
            this.metronomeButton.TabIndex = 40;
            this.metronomeButton.Tag = "Metronome";
            this.metronomeButton.Click += new System.EventHandler(this.ToggleMetronome);
            // 
            // connectButton
            // 
            this.connectButton.Active = false;
            this.connectButton.BackColor = System.Drawing.Color.Transparent;
            this.connectButton.BackgroundImage = global::RTS.Properties.Resources.connect;
            this.connectButton.BackgroundImageActive = global::RTS.Properties.Resources.connect2;
            this.connectButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.connectButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.connectButton.Data = null;
            this.connectButton.Location = new System.Drawing.Point(430, 179);
            this.connectButton.Margin = new System.Windows.Forms.Padding(4);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(120, 82);
            this.connectButton.TabIndex = 39;
            this.connectButton.Tag = "Connect to server.";
            this.connectButton.Click += new System.EventHandler(this.ToggleConnection);
            this.connectButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TwoStateButton_MouseDown);
            this.connectButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TwoStateButton_MouseUp);
            // 
            // loopButton
            // 
            this.loopButton.Active = false;
            this.loopButton.BackColor = System.Drawing.Color.Transparent;
            this.loopButton.BackgroundImage = global::RTS.Properties.Resources.loop;
            this.loopButton.BackgroundImageActive = global::RTS.Properties.Resources.loop2;
            this.loopButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.loopButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loopButton.Data = null;
            this.loopButton.Location = new System.Drawing.Point(106, 44);
            this.loopButton.Margin = new System.Windows.Forms.Padding(4);
            this.loopButton.Name = "loopButton";
            this.loopButton.Size = new System.Drawing.Size(88, 88);
            this.loopButton.TabIndex = 38;
            this.loopButton.Tag = "Launch the loop mode.";
            this.loopButton.Click += new System.EventHandler(this.loopButton_Click);
            // 
            // recordButton
            // 
            this.recordButton.Active = false;
            this.recordButton.BackColor = System.Drawing.Color.Transparent;
            this.recordButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("recordButton.BackgroundImage")));
            this.recordButton.BackgroundImageActive = global::RTS.Properties.Resources.save2;
            this.recordButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.recordButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.recordButton.Data = null;
            this.recordButton.Location = new System.Drawing.Point(204, 44);
            this.recordButton.Margin = new System.Windows.Forms.Padding(4);
            this.recordButton.Name = "recordButton";
            this.recordButton.Size = new System.Drawing.Size(88, 88);
            this.recordButton.TabIndex = 37;
            this.recordButton.Tag = "Start the record.";
            this.recordButton.Click += new System.EventHandler(this.Record);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(74, 202);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.TabIndex = 63;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(168, 202);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 20);
            this.pictureBox2.TabIndex = 64;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.Location = new System.Drawing.Point(263, 202);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(20, 20);
            this.pictureBox3.TabIndex = 65;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.BackgroundImage")));
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox4.Location = new System.Drawing.Point(358, 202);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(20, 20);
            this.pictureBox4.TabIndex = 66;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox5.BackgroundImage")));
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox5.Location = new System.Drawing.Point(74, 315);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(20, 20);
            this.pictureBox5.TabIndex = 67;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox6.BackgroundImage")));
            this.pictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox6.Location = new System.Drawing.Point(168, 315);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(20, 20);
            this.pictureBox6.TabIndex = 68;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox7.BackgroundImage")));
            this.pictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox7.Location = new System.Drawing.Point(263, 315);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(20, 20);
            this.pictureBox7.TabIndex = 69;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox8.BackgroundImage")));
            this.pictureBox8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox8.Location = new System.Drawing.Point(358, 315);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(20, 20);
            this.pictureBox8.TabIndex = 70;
            this.pictureBox8.TabStop = false;
            this.pictureBox8.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox9
            // 
            this.pictureBox9.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox9.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox9.BackgroundImage")));
            this.pictureBox9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox9.Location = new System.Drawing.Point(74, 430);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(20, 20);
            this.pictureBox9.TabIndex = 71;
            this.pictureBox9.TabStop = false;
            this.pictureBox9.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox10
            // 
            this.pictureBox10.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox10.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox10.BackgroundImage")));
            this.pictureBox10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox10.Location = new System.Drawing.Point(168, 430);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(20, 20);
            this.pictureBox10.TabIndex = 72;
            this.pictureBox10.TabStop = false;
            this.pictureBox10.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox11
            // 
            this.pictureBox11.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox11.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox11.BackgroundImage")));
            this.pictureBox11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox11.Location = new System.Drawing.Point(263, 430);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(20, 20);
            this.pictureBox11.TabIndex = 73;
            this.pictureBox11.TabStop = false;
            this.pictureBox11.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox12
            // 
            this.pictureBox12.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox12.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox12.BackgroundImage")));
            this.pictureBox12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox12.Location = new System.Drawing.Point(358, 430);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new System.Drawing.Size(20, 20);
            this.pictureBox12.TabIndex = 74;
            this.pictureBox12.TabStop = false;
            this.pictureBox12.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(303, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 15);
            this.label1.TabIndex = 76;
            this.label1.Text = "Main Volume";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(221, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 15);
            this.label2.TabIndex = 77;
            this.label2.Text = "Record";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(130, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 78;
            this.label3.Text = "Loop";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(38, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 15);
            this.label4.TabIndex = 79;
            this.label4.Text = "Play";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(824, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 15);
            this.label5.TabIndex = 80;
            this.label5.Text = "Samples Library";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(537, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 15);
            this.label6.TabIndex = 81;
            this.label6.Text = "Control Panel";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(556, 181);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 15);
            this.label7.TabIndex = 82;
            this.label7.Text = "Server IP";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(556, 220);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 15);
            this.label8.TabIndex = 83;
            this.label8.Text = "Pseudo";
            // 
            // timeLine1
            // 
            this.timeLine1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("timeLine1.BackgroundImage")));
            this.timeLine1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.timeLine1.Location = new System.Drawing.Point(9, 41);
            this.timeLine1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.timeLine1.MaximumSize = new System.Drawing.Size(825, 246);
            this.timeLine1.Name = "timeLine1";
            this.timeLine1.Size = new System.Drawing.Size(622, 210);
            this.timeLine1.TabIndex = 84;
            // 
            // soundLibrary1
            // 
            this.soundLibrary1.AllowDrop = true;
            this.soundLibrary1.BackColor = System.Drawing.Color.Transparent;
            this.soundLibrary1.Location = new System.Drawing.Point(774, 47);
            this.soundLibrary1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.soundLibrary1.Name = "soundLibrary1";
            this.soundLibrary1.Size = new System.Drawing.Size(224, 306);
            this.soundLibrary1.TabIndex = 58;
            this.soundLibrary1.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainFrame_DragDrop);
            this.soundLibrary1.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainFrame_DragEnter);
            // 
            // pad12
            // 
            this.pad12.Active = false;
            this.pad12.AllowDrop = true;
            this.pad12.BackColor = System.Drawing.Color.Transparent;
            this.pad12.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pad12.BackgroundImage")));
            this.pad12.BackgroundImageActive = ((System.Drawing.Image)(resources.GetObject("pad12.BackgroundImageActive")));
            this.pad12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pad12.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pad12.Data = null;
            this.pad12.Location = new System.Drawing.Point(300, 371);
            this.pad12.Margin = new System.Windows.Forms.Padding(4);
            this.pad12.Name = "pad12";
            this.pad12.Size = new System.Drawing.Size(88, 88);
            this.pad12.TabIndex = 44;
            this.pad12.DragDrop += new System.Windows.Forms.DragEventHandler(this.pad_DragDrop);
            this.pad12.DragEnter += new System.Windows.Forms.DragEventHandler(this.pad_DragEnter);
            this.pad12.DragLeave += new System.EventHandler(this.pad_DragLeave);
            this.pad12.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pad_MouseDown);
            // 
            // pad11
            // 
            this.pad11.Active = false;
            this.pad11.AllowDrop = true;
            this.pad11.BackColor = System.Drawing.Color.Transparent;
            this.pad11.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pad11.BackgroundImage")));
            this.pad11.BackgroundImageActive = ((System.Drawing.Image)(resources.GetObject("pad11.BackgroundImageActive")));
            this.pad11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pad11.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pad11.Data = null;
            this.pad11.Location = new System.Drawing.Point(204, 371);
            this.pad11.Margin = new System.Windows.Forms.Padding(4);
            this.pad11.Name = "pad11";
            this.pad11.Size = new System.Drawing.Size(88, 88);
            this.pad11.TabIndex = 43;
            this.pad11.DragDrop += new System.Windows.Forms.DragEventHandler(this.pad_DragDrop);
            this.pad11.DragEnter += new System.Windows.Forms.DragEventHandler(this.pad_DragEnter);
            this.pad11.DragLeave += new System.EventHandler(this.pad_DragLeave);
            this.pad11.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pad_MouseDown);
            // 
            // pad10
            // 
            this.pad10.Active = false;
            this.pad10.AllowDrop = true;
            this.pad10.BackColor = System.Drawing.Color.Transparent;
            this.pad10.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pad10.BackgroundImage")));
            this.pad10.BackgroundImageActive = ((System.Drawing.Image)(resources.GetObject("pad10.BackgroundImageActive")));
            this.pad10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pad10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pad10.Data = null;
            this.pad10.Location = new System.Drawing.Point(108, 371);
            this.pad10.Margin = new System.Windows.Forms.Padding(4);
            this.pad10.Name = "pad10";
            this.pad10.Size = new System.Drawing.Size(88, 88);
            this.pad10.TabIndex = 42;
            this.pad10.DragDrop += new System.Windows.Forms.DragEventHandler(this.pad_DragDrop);
            this.pad10.DragEnter += new System.Windows.Forms.DragEventHandler(this.pad_DragEnter);
            this.pad10.DragLeave += new System.EventHandler(this.pad_DragLeave);
            this.pad10.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pad_MouseDown);
            // 
            // pad9
            // 
            this.pad9.Active = false;
            this.pad9.AllowDrop = true;
            this.pad9.BackColor = System.Drawing.Color.Transparent;
            this.pad9.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pad9.BackgroundImage")));
            this.pad9.BackgroundImageActive = ((System.Drawing.Image)(resources.GetObject("pad9.BackgroundImageActive")));
            this.pad9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pad9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pad9.Data = null;
            this.pad9.Location = new System.Drawing.Point(12, 371);
            this.pad9.Margin = new System.Windows.Forms.Padding(4);
            this.pad9.Name = "pad9";
            this.pad9.Size = new System.Drawing.Size(88, 88);
            this.pad9.TabIndex = 33;
            this.pad9.DragDrop += new System.Windows.Forms.DragEventHandler(this.pad_DragDrop);
            this.pad9.DragEnter += new System.Windows.Forms.DragEventHandler(this.pad_DragEnter);
            this.pad9.DragLeave += new System.EventHandler(this.pad_DragLeave);
            this.pad9.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pad_MouseDown);
            // 
            // pad8
            // 
            this.pad8.Active = false;
            this.pad8.AllowDrop = true;
            this.pad8.BackColor = System.Drawing.Color.Transparent;
            this.pad8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pad8.BackgroundImage")));
            this.pad8.BackgroundImageActive = ((System.Drawing.Image)(resources.GetObject("pad8.BackgroundImageActive")));
            this.pad8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pad8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pad8.Data = null;
            this.pad8.Location = new System.Drawing.Point(300, 255);
            this.pad8.Margin = new System.Windows.Forms.Padding(4);
            this.pad8.Name = "pad8";
            this.pad8.Size = new System.Drawing.Size(88, 88);
            this.pad8.TabIndex = 32;
            this.pad8.DragDrop += new System.Windows.Forms.DragEventHandler(this.pad_DragDrop);
            this.pad8.DragEnter += new System.Windows.Forms.DragEventHandler(this.pad_DragEnter);
            this.pad8.DragLeave += new System.EventHandler(this.pad_DragLeave);
            this.pad8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pad_MouseDown);
            // 
            // pad7
            // 
            this.pad7.Active = false;
            this.pad7.AllowDrop = true;
            this.pad7.BackColor = System.Drawing.Color.Transparent;
            this.pad7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pad7.BackgroundImage")));
            this.pad7.BackgroundImageActive = ((System.Drawing.Image)(resources.GetObject("pad7.BackgroundImageActive")));
            this.pad7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pad7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pad7.Data = null;
            this.pad7.Location = new System.Drawing.Point(204, 255);
            this.pad7.Margin = new System.Windows.Forms.Padding(4);
            this.pad7.Name = "pad7";
            this.pad7.Size = new System.Drawing.Size(88, 88);
            this.pad7.TabIndex = 31;
            this.pad7.DragDrop += new System.Windows.Forms.DragEventHandler(this.pad_DragDrop);
            this.pad7.DragEnter += new System.Windows.Forms.DragEventHandler(this.pad_DragEnter);
            this.pad7.DragLeave += new System.EventHandler(this.pad_DragLeave);
            this.pad7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pad_MouseDown);
            // 
            // pad6
            // 
            this.pad6.Active = false;
            this.pad6.AllowDrop = true;
            this.pad6.BackColor = System.Drawing.Color.Transparent;
            this.pad6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pad6.BackgroundImage")));
            this.pad6.BackgroundImageActive = ((System.Drawing.Image)(resources.GetObject("pad6.BackgroundImageActive")));
            this.pad6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pad6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pad6.Data = null;
            this.pad6.Location = new System.Drawing.Point(108, 255);
            this.pad6.Margin = new System.Windows.Forms.Padding(4);
            this.pad6.Name = "pad6";
            this.pad6.Size = new System.Drawing.Size(88, 88);
            this.pad6.TabIndex = 30;
            this.pad6.DragDrop += new System.Windows.Forms.DragEventHandler(this.pad_DragDrop);
            this.pad6.DragEnter += new System.Windows.Forms.DragEventHandler(this.pad_DragEnter);
            this.pad6.DragLeave += new System.EventHandler(this.pad_DragLeave);
            this.pad6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pad_MouseDown);
            // 
            // pad5
            // 
            this.pad5.Active = false;
            this.pad5.AllowDrop = true;
            this.pad5.BackColor = System.Drawing.Color.Transparent;
            this.pad5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pad5.BackgroundImage")));
            this.pad5.BackgroundImageActive = ((System.Drawing.Image)(resources.GetObject("pad5.BackgroundImageActive")));
            this.pad5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pad5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pad5.Data = null;
            this.pad5.Location = new System.Drawing.Point(12, 255);
            this.pad5.Margin = new System.Windows.Forms.Padding(4);
            this.pad5.Name = "pad5";
            this.pad5.Size = new System.Drawing.Size(88, 88);
            this.pad5.TabIndex = 29;
            this.pad5.DragDrop += new System.Windows.Forms.DragEventHandler(this.pad_DragDrop);
            this.pad5.DragEnter += new System.Windows.Forms.DragEventHandler(this.pad_DragEnter);
            this.pad5.DragLeave += new System.EventHandler(this.pad_DragLeave);
            this.pad5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pad_MouseDown);
            // 
            // pad4
            // 
            this.pad4.Active = false;
            this.pad4.AllowDrop = true;
            this.pad4.BackColor = System.Drawing.Color.Transparent;
            this.pad4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pad4.BackgroundImage")));
            this.pad4.BackgroundImageActive = ((System.Drawing.Image)(resources.GetObject("pad4.BackgroundImageActive")));
            this.pad4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pad4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pad4.Data = null;
            this.pad4.Location = new System.Drawing.Point(300, 139);
            this.pad4.Margin = new System.Windows.Forms.Padding(4);
            this.pad4.Name = "pad4";
            this.pad4.Size = new System.Drawing.Size(88, 88);
            this.pad4.TabIndex = 28;
            this.pad4.DragDrop += new System.Windows.Forms.DragEventHandler(this.pad_DragDrop);
            this.pad4.DragEnter += new System.Windows.Forms.DragEventHandler(this.pad_DragEnter);
            this.pad4.DragLeave += new System.EventHandler(this.pad_DragLeave);
            this.pad4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pad_MouseDown);
            // 
            // pad3
            // 
            this.pad3.Active = false;
            this.pad3.AllowDrop = true;
            this.pad3.BackColor = System.Drawing.Color.Transparent;
            this.pad3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pad3.BackgroundImage")));
            this.pad3.BackgroundImageActive = ((System.Drawing.Image)(resources.GetObject("pad3.BackgroundImageActive")));
            this.pad3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pad3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pad3.Data = null;
            this.pad3.Location = new System.Drawing.Point(204, 139);
            this.pad3.Margin = new System.Windows.Forms.Padding(4);
            this.pad3.Name = "pad3";
            this.pad3.Size = new System.Drawing.Size(88, 88);
            this.pad3.TabIndex = 27;
            this.pad3.DragDrop += new System.Windows.Forms.DragEventHandler(this.pad_DragDrop);
            this.pad3.DragEnter += new System.Windows.Forms.DragEventHandler(this.pad_DragEnter);
            this.pad3.DragLeave += new System.EventHandler(this.pad_DragLeave);
            this.pad3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pad_MouseDown);
            // 
            // pad2
            // 
            this.pad2.Active = false;
            this.pad2.AllowDrop = true;
            this.pad2.BackColor = System.Drawing.Color.Transparent;
            this.pad2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pad2.BackgroundImage")));
            this.pad2.BackgroundImageActive = ((System.Drawing.Image)(resources.GetObject("pad2.BackgroundImageActive")));
            this.pad2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pad2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pad2.Data = null;
            this.pad2.Location = new System.Drawing.Point(108, 139);
            this.pad2.Margin = new System.Windows.Forms.Padding(4);
            this.pad2.Name = "pad2";
            this.pad2.Size = new System.Drawing.Size(88, 88);
            this.pad2.TabIndex = 26;
            this.pad2.DragDrop += new System.Windows.Forms.DragEventHandler(this.pad_DragDrop);
            this.pad2.DragEnter += new System.Windows.Forms.DragEventHandler(this.pad_DragEnter);
            this.pad2.DragLeave += new System.EventHandler(this.pad_DragLeave);
            this.pad2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pad_MouseDown);
            // 
            // pad1
            // 
            this.pad1.Active = false;
            this.pad1.AllowDrop = true;
            this.pad1.BackColor = System.Drawing.Color.Transparent;
            this.pad1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pad1.BackgroundImage")));
            this.pad1.BackgroundImageActive = ((System.Drawing.Image)(resources.GetObject("pad1.BackgroundImageActive")));
            this.pad1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pad1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pad1.Data = null;
            this.pad1.Location = new System.Drawing.Point(12, 139);
            this.pad1.Margin = new System.Windows.Forms.Padding(4);
            this.pad1.Name = "pad1";
            this.pad1.Size = new System.Drawing.Size(88, 88);
            this.pad1.TabIndex = 25;
            this.pad1.DragDrop += new System.Windows.Forms.DragEventHandler(this.pad_DragDrop);
            this.pad1.DragEnter += new System.Windows.Forms.DragEventHandler(this.pad_DragEnter);
            this.pad1.DragLeave += new System.EventHandler(this.pad_DragLeave);
            this.pad1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pad_MouseDown);
            // 
            // console
            // 
            this.console.BackColor = System.Drawing.Color.Black;
            this.console.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.console.ForeColor = System.Drawing.Color.GreenYellow;
            this.console.Location = new System.Drawing.Point(430, 47);
            this.console.Name = "console";
            this.console.ReadOnly = true;
            this.console.Size = new System.Drawing.Size(321, 125);
            this.console.TabIndex = 12;
            this.console.Text = "";
            // 
            // MainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1013, 499);
            this.Controls.Add(this.timeLine1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox12);
            this.Controls.Add(this.pictureBox11);
            this.Controls.Add(this.pictureBox10);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.soundLibrary1);
            this.Controls.Add(this.metronomePotentiometer);
            this.Controls.Add(this.metronomeButton);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.loopButton);
            this.Controls.Add(this.recordButton);
            this.Controls.Add(this.pad12);
            this.Controls.Add(this.pad11);
            this.Controls.Add(this.pad10);
            this.Controls.Add(this.pad9);
            this.Controls.Add(this.pad8);
            this.Controls.Add(this.pad7);
            this.Controls.Add(this.pad6);
            this.Controls.Add(this.pad5);
            this.Controls.Add(this.pad4);
            this.Controls.Add(this.pad3);
            this.Controls.Add(this.pad2);
            this.Controls.Add(this.pad1);
            this.Controls.Add(this.ipTextBox);
            this.Controls.Add(this.volumePotentiometer);
            this.Controls.Add(this.networkNameTextBox);
            this.Controls.Add(this.console);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainFrame";
            this.Text = "Rock the Sound";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFrame_FormClosing);
            this.Load += new System.EventHandler(this.MainFrame_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainFrame_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainFrame_DragEnter);
            this.DragLeave += new System.EventHandler(this.pad_DragLeave);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainFrame_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainFrame_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainFrame_MouseDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ConsoleView console;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chargerUnSampleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifierUnSampleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seConnecterÀUneAutreMPCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem synchroniserLaBilbilothèqueToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripMenuItem paramètresToolStripMenuItem;
        private System.Windows.Forms.RichTextBox networkNameTextBox;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem1;
        private Potentiometer.Potentiometer volumePotentiometer;
        private System.Windows.Forms.TextBox ipTextBox;

        private PadView pad1;
        private PadView pad2;
        private PadView pad3;
        private PadView pad4;
        private PadView pad5;
        private PadView pad6;
        private PadView pad7;
        private PadView pad8;
        private PadView pad9;
        private PadView pad10;
        private PadView pad11;
        private PadView pad12;

        private TwoStateButton.TwoStateButton playButton;
        private TwoStateButton.TwoStateButton loopButton;
        private TwoStateButton.TwoStateButton recordButton;
        private TwoStateButton.TwoStateButton connectButton;
        private TwoStateButton.TwoStateButton metronomeButton;

        private Potentiometer.Potentiometer metronomePotentiometer;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private SoundLibrary soundLibrary1;
        private System.Windows.Forms.ToolStripMenuItem loopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;
        private PictureBox pictureBox7;
        private PictureBox pictureBox8;
        private PictureBox pictureBox9;
        private PictureBox pictureBox10;
        private PictureBox pictureBox11;
        private PictureBox pictureBox12;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private ToolStripMenuItem looperToolStripMenuItem;
        private TimeLine timeLine1;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private Label label7;
        private Label label8;
        private ToolStripMenuItem uploadOnSoundCloudToolStripMenuItem;
    }
}