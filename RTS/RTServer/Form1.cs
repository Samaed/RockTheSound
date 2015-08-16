using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTServer
{
    public partial class ServerMainFrame : Form
    {
        public int UDPSent { get { return _udpSent; } set { _udpSent = value; } }
        private int _udpSent = 0;
        private ParametersForm _parameters = new ParametersForm();
        private AboutForm _about = new AboutForm();
        private Server.Modes mode = Server.Modes.SYNCHRO;
        private bool _reload = true;
        private bool _logChanged = true;
        public bool Reload
        {
            get { return _reload; }
            set { _reload = value; }
        }

        private static ServerMainFrame _instance;
        private string logs = "";
        private ServerMainFrame()
        {
            InitializeComponent();
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 100;
            timer.Tick += new EventHandler(refresh);
            timer.Start();

            System.Windows.Forms.Timer serverTimer = new System.Windows.Forms.Timer();
            serverTimer.Interval = 1000;
            serverTimer.Tick += new EventHandler(ServerTick);
            serverTimer.Start();

            System.Windows.Forms.Timer discoveringTimer = new System.Windows.Forms.Timer();
            discoveringTimer.Interval = 5000;
            discoveringTimer.Tick += new EventHandler(sendHello);
            discoveringTimer.Start();
        }

        private void sendHello(object sender, EventArgs e)
        {
            Server.GetInstance().SayYouAreThere();
        }

        private void ServerTick(object sender, EventArgs e)
        {
            Server.GetInstance().Tick();
        }

        private void refresh(object sender, EventArgs e)
        {
            this.udpByteSent.Text = string.Format("{0}", this._udpSent);
            if (_logChanged)
            {
                this.logTextBox.Text = logs;

                if (logs.Length > 0)
                {
                    this.logTextBox.SelectionStart = logs.Length - 1;
                    this.logTextBox.ScrollToCaret();
                }
                _logChanged = false;
            }

            if (Server.GetInstance().ClientMove)
            {
                Server.GetInstance().ClientMove = false;
                List<Client> list = Server.GetInstance().ClientList;
                this.clientList.Items.Clear();
                foreach (Client cl in list)
                {
                    if (!this.clientList.Items.Contains(cl.ToString()))
                    {
                        this.clientList.Items.Add(cl.ToString());
                    }
                }
            }
            if (Server.GetInstance().Mode != this.mode)
            {
                this.mode = Server.GetInstance().Mode;
                if (this.mode == Server.Modes.PLAY)
                {
                    this.switchbutton.BackgroundImage = global::RTServer.Properties.Resources.switch1;
                }
                else
                {
                    this.switchbutton.BackgroundImage = global::RTServer.Properties.Resources.switch2;
                }
            }
            if (_reload)
            {
                _reload = false;
                IPList.Text = "";
                IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
                foreach (IPAddress ipAdress in localIPs)
                {
                    if (ipAdress.AddressFamily != AddressFamily.InterNetworkV6)
                    {
                        IPList.Text += ipAdress + "\n";
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public void addLog(string log)
        {
            this._logChanged = true;
            logs = logs + "\n" + DateTime.Now.ToString("HH:mm:ss") + " - " + log;
        }

        private void sendPlaySample_Click(object sender, EventArgs e)
        {
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


        public static ServerMainFrame GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ServerMainFrame();
            }
            return _instance;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.mode == Server.Modes.PLAY)
            {
                Server.GetInstance().Mode = Server.Modes.SYNCHRO;
            }
            else
            {
                Server.GetInstance().Mode = Server.Modes.PLAY;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Server.GetInstance().Mode = Server.Modes.SYNCHRO;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Server.GetInstance().Mode = Server.Modes.PLAY;
        }

        private void kickbutton_Click(object sender, EventArgs e)
        {
            try
            {
                Server.GetInstance().ClientList[clientList.SelectedIndex].Send("disconnect");
            }
            catch (Exception) { }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _about.ShowDialog();
        }

        private void reloadServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Server.GetInstance().Reload();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _parameters.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (Server.GetInstance().ClientList[clientList.SelectedIndex].Mute)
                {
                    Server.GetInstance().ClientList[clientList.SelectedIndex].Mute = false;
                }
                else
                {
                    Server.GetInstance().ClientList[clientList.SelectedIndex].Mute = true;
                }
                Server.GetInstance().ClientMove = true;
            }
            catch (Exception) { }
        }

        private void IPList_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
