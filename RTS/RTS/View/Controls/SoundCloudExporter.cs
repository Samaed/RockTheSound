using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RTS.View.Controls
{
    public partial class SoundCloudExporter : Form
    {
        public SoundCloudExporter()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SoundCloudUpload sc = new SoundCloudUpload();
            if (!textBox1.Text.Equals(String.Empty) && !textBox2.Text.Equals(String.Empty) && !textBox3.Text.Equals(String.Empty) && !textBox4.Text.Equals(String.Empty) && !maskedTextBox1.Text.Equals(String.Empty))
            {
                sc.SoundCloudUploadFile(textBox1.Text, maskedTextBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                Process p = new Process();
                p.StartInfo.FileName = "https://soundcloud.com/stream";
                p.Start();
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "https://soundcloud.com/stream";
            p.Start();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog dialog = new
                System.Windows.Forms.OpenFileDialog() { Multiselect = false };

            dialog.Filter = "All playable files (*.mp3;*.ogg;*.wav;*.mod;*.it;*.xm;*.it;*.s3d,*.flac)|*.mp3;*.ogg;*.wav;*.mod;*.it;*.xm;*.it;*.s3d;*.flac";
            dialog.FilterIndex = 0;

            if (dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                textBox2.Text = dialog.FileName;
            }
        }
    }
}
