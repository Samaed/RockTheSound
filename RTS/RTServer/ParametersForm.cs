using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RTServer
{
    public partial class ParametersForm : Form
    {
        public ParametersForm()
        {
            InitializeComponent();
            initValues();
        }
        public void initValues()
        {
            this.relativePath.Text = ConfigurationManager.AppSettings["SamplesPath"];
            this.tcpPort.Text = ConfigurationManager.AppSettings["TCPPort"];
            this.udpPort.Text = ConfigurationManager.AppSettings["UDPPort"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove("SamplesPath");
            config.AppSettings.Settings.Add("SamplesPath", relativePath.Text);
            config.AppSettings.Settings.Remove("TCPPort");
            config.AppSettings.Settings.Add("TCPPort", this.tcpPort.Text);
            config.AppSettings.Settings.Remove("UDPPort");
            config.AppSettings.Settings.Add("UDPPort", this.udpPort.Text);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            Server.GetInstance().Reload();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            initValues();
            this.Close();
        }
    }
}
