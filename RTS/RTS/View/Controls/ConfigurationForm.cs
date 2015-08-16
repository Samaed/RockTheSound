using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RTS.View.Controls
{
    public partial class ConfigurationForm : Form
    {
        public ConfigurationForm()
        {
            InitializeComponent();
            initValues();
        }
        public void initValues()
        {
            this.sample.Text = ConfigurationManager.AppSettings["SamplesPath"];
            this.tcpPort.Text = ConfigurationManager.AppSettings["TCPPort"];
            this.udpPort.Text = ConfigurationManager.AppSettings["UDPPort"];
            this.name.Text = ConfigurationManager.AppSettings["Name"];
        }

        private void Validate(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove("SamplesPath");
            config.AppSettings.Settings.Add("SamplesPath", sample.Text);
            config.AppSettings.Settings.Remove("TCPPort");
            config.AppSettings.Settings.Add("TCPPort", this.tcpPort.Text);
            config.AppSettings.Settings.Remove("UDPPort");
            config.AppSettings.Settings.Add("UDPPort", this.udpPort.Text);
            config.AppSettings.Settings.Remove("name");
            config.AppSettings.Settings.Add("name", this.name.Text);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            
            this.Close();
        }

        private void Cancel(object sender, EventArgs e)
        {
            initValues();
            this.Close();
        }
    }
}
