using RTS.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RTServer
{
    class Server
    {
        public enum Modes
        {
            PLAY, SYNCHRO
        }
        //Path of the sended samples
        private string _samplesPath;
        public string SamplesPath { get { return _samplesPath; } }
        //Mode actuel
        private Modes _mode = Modes.SYNCHRO;
        //Instance du serveur (pattern singleton)
        private static Server INSTANCE;

        private TcpListener _listener;
        private Socket _udpSocket;
        private IPEndPoint _broadcast_end_point;
        private bool _udpConnected = false;
        //Nombre de connections TCP autorisées (nombre max de joueurs)
        public const int MAXCLIENT = 10;
        private int _portTCP;
        private int _portUDP;
        public int PortTCP { get { return _portTCP; } }
        public int PortUDP { get { return _portUDP; } }
        private bool _connected = false;
        public bool Connected { get { return _connected && _udpConnected; } }
        //Préviens la vue si la liste des clients à changé
        private bool _clientMove;
        public bool ClientMove { get { return _clientMove; } set { _clientMove = value; } }

        public Modes Mode { get { return _mode; } set { _mode = value; } }
        //Liste des clients connectés
        private List<Client> _clientList = new List<Client>();
        public List<Client> ClientList { get { return _clientList; } set { _clientList = value; } }

        //Constructeur privé (pattern singleton)
        private Server()
        {
            _portTCP = int.Parse(ConfigurationManager.AppSettings["TCPPort"]);
            _portUDP = int.Parse(ConfigurationManager.AppSettings["UDPPort"]);
            _samplesPath = ConfigurationManager.AppSettings["SamplesPath"];
        }
        //Obtenir l'instance du serveur
        public static Server GetInstance()
        {
            if (INSTANCE == null)
            {
                INSTANCE = new Server();
            }
            return INSTANCE;
        }
        //Démarre le serveur
        public void Start()
        {
            if (!_connected)
            {
                ServerMainFrame.GetInstance().addLog("STARTING SERVER");
                _connected = true;
                _udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                _udpSocket.EnableBroadcast = true;

                _broadcast_end_point = new IPEndPoint(IPAddress.Broadcast, _portUDP);
                _udpSocket.Connect(_broadcast_end_point);

                _listener = new TcpListener(IPAddress.Any, _portTCP);
                _listener.Start();


                for (int i = 0; i < MAXCLIENT; i++)//Lance n threads pour recevoir n clients (ici 10)
                {
                    Thread t = new Thread(new ThreadStart(TcpService));
                    t.IsBackground = true;
                    t.Start();
                }
                ServerMainFrame.GetInstance().addLog("SERVER STARTED");
            }
        }
        //Service d'écoute TCP ( 1 client )
        public void TcpService()
        {
            while (true)//Boucle de connexion à un client
            {
                try
                {
                    Socket soc = _listener.AcceptSocket();
                    ServerMainFrame.GetInstance().addLog("Connected: " + soc.RemoteEndPoint);
                    Client client = new Client();//création d'un compte client
                    try
                    {
                        Stream s = new NetworkStream(soc);
                        StreamReader sr = new StreamReader(s);
                        StreamWriter sw = new StreamWriter(s);
                        sw.AutoFlush = true;
                        int nbOK = 0;
                        sw.WriteLine("Welcome to me ! What's your name?");//Seems legit
                        string name = sr.ReadLine();//demande du nom

                        ServerMainFrame.GetInstance().addLog("id " + client.Id + " is " + name);
                        client.Name = name;
                        client.Socket = soc;

                        _clientList.Add(client);//je l'ajoute à la liste des clients connectés
                        ClientMove = true;
                        sw.WriteLine(NetworkParser.getCode(NetworkParser.Operation.HELLO) + name + ";" + client.Id);//Pour lui envoyer son id
                        sendNewClient(client);
                        foreach (Client cl in _clientList)
                        {
                            if (cl != client)
                            {
                                //Envoi de la liste des clients connectés
                                sw.WriteLine(NetworkParser.getCode(NetworkParser.Operation.NEW_MEMBER) + ";" + cl.Id + ";" + cl.Name);
                                sr.ReadLine();
                            }
                        }
                        while (true)
                        {

                            string received = sr.ReadLine();//On attends un envoie du client
                            if (received == NetworkParser.getCode(NetworkParser.Operation.DISCONNECT))
                            {//le client veut se déconnecter
                                break;
                            }

                            if (received == "" || received == null)
                            {
                                sw.WriteLine(NetworkParser.getCode(NetworkParser.Operation.NONE));//Qestion vide : réponse vide
                            }
                            else if (received == NetworkParser.getCode(NetworkParser.Operation.OK) && nbOK++ >= 3)
                            {
                                nbOK = 0;
                            }
                            else
                            {
                                if (received != NetworkParser.getCode(NetworkParser.Operation.OK))
                                {
                                    nbOK = 0;
                                }
                                Handle(client, received);
                                sw.WriteLine(NetworkParser.getCode(NetworkParser.Operation.OK));
                            }

                        }
                        s.Close();
                    }
                    catch (Exception e)//si déconnection pour une raison inconnue
                    {
                        ServerMainFrame.GetInstance().addLog(client.Id + " : " + e.Message);
                    }
                    ServerMainFrame.GetInstance().addLog(client.Id + "-" + client.Name + " disconnected (" + soc.RemoteEndPoint + ")");
                    soc.Close();
                    sendRemoveClient(client);
                    _clientList.Remove(client);
                    ClientMove = true;
                }
                catch (Exception) { }
            }
        }

        //Gère une réception
        private void Handle(Client client, string received)
        {
            string[] words = received.Split(new char[] { ';' });
            NetworkParser.Operation toDo = NetworkParser.getOperation(words[0]);
            switch (toDo)
            {
                case NetworkParser.Operation.GIVE_FILE:
                    receiveFile(words, client);
                    break;
                case NetworkParser.Operation.SAMPLE_LIST:
                    client.SetSampleList(words);
                    break;
                case NetworkParser.Operation.READY:
                    client.ClientReadyToReceive = true;
                    break;
                case NetworkParser.Operation.READY_TO_RECEIVE:
                    client.ClientReadySendSound(words[1]);
                    break;
            }
        }

        //Reception d'un fichier
        private void receiveFile(string[] words, Client client)
        {
            ServerMainFrame.GetInstance().addLog(client.Id + "-" + client.Name + " receiving file : " + words[2]);
            int BufferSize = 1000;
            byte[] RecData = new byte[BufferSize];
            int RecBytes;

            NetworkStream netstream = null;
            try
            {
                netstream = new NetworkStream(client.Socket);
                string folderPath = ConfigurationManager.AppSettings["SamplesPath"];
                bool isExists = System.IO.Directory.Exists(folderPath);
                if (!isExists)
                    System.IO.Directory.CreateDirectory(folderPath);

                words[2] = words[2].Substring(words[2].LastIndexOf("\\") + 1);

                int fileNonOverrideIndex = 0;
                string[] fileNameSplitted = words[2].Split(new char[] { '.' });
                string saveFileName = folderPath + "\\" + words[2];

                while (System.IO.File.Exists(saveFileName))
                {
                    fileNonOverrideIndex++;
                    saveFileName = folderPath + "\\";

                    for (int i = 0; i < fileNameSplitted.Length - 1; i++)
                    {
                        saveFileName += fileNameSplitted[i];
                    }

                    saveFileName += "(" + fileNonOverrideIndex + ")." + fileNameSplitted[fileNameSplitted.Length - 1];
                }

                if (saveFileName != string.Empty)
                {
                    int totalrecbytes = 0;
                    FileStream Fs = new FileStream(saveFileName, FileMode.OpenOrCreate, FileAccess.Write);
                    bool stop = false;
                    while ((RecBytes = netstream.Read(RecData, 0, RecData.Length)) > 4 && !stop)
                    {
                        Fs.Write(RecData, 0, RecBytes);
                        totalrecbytes += RecBytes;
                        stop = RecBytes < 999;
                    }
                    Console.WriteLine(totalrecbytes);
                    Fs.Close();
                }
                netstream.Close();
                Sound newSound = new RTS.Model.Sound(words[1], words[2], saveFileName, new byte[1]);
                if (Math.Abs(newSound.FileSize - long.Parse(words[3])) < 250)
                {
                    ServerSoundLibrary.GetInstance().AddSound(newSound);
                    ServerMainFrame.GetInstance().addLog(client.Id + "-" + client.Name + " file received : " + words[2]);
                }
                else
                {
                    System.IO.File.Delete(saveFileName);
                    ServerMainFrame.GetInstance().addLog(client.Id + "-" + client.Name + " error on file size : " + words[2] + " (orig : " + words[3] + ",received :" + newSound.FileSize + ")");
                }
                client.GetNextServerSideNeededSample();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        //Préviens qu'un client vient d'arriver
        private void sendNewClient(Client client)
        {
            foreach (Client cl in _clientList)
            {
                if (cl.Id != client.Id)
                {
                    cl.Send(NetworkParser.getCode(NetworkParser.Operation.NEW_MEMBER) + ";" + client.Id + ";" + client.Name);
                }
            }
        }
        //Préviens le départ d'un client
        private void sendRemoveClient(Client client)
        {
            foreach (Client cl in _clientList)
            {
                if (cl.Id != client.Id)
                {
                    cl.Send(NetworkParser.getCode(NetworkParser.Operation.REMOVE_MEMBER) + ";" + client.Id);
                }
            }
        }
        //envoi un message udp
        public void sendUdp(string msg)
        {
            if (_connected)
            {
                try
                {
                    byte[] bytes = Encoding.ASCII.GetBytes(msg);
                    ServerMainFrame.GetInstance().UDPSent += _udpSocket.Send(bytes);
                }
                catch (Exception send_exception)
                {
                    Console.WriteLine(" Exception {0}", send_exception.Message);
                }
            }
        }
        //Toutes les secondes permet de vérifier les modifs sur les bibliothèques de samples
        public void Tick()
        {
            if (this._mode == Modes.SYNCHRO)
            {
                try
                {
                    foreach (Client cl in this._clientList)
                    {
                        if (!cl.CheckListServSide)
                        {
                            if (!cl.SendNextClientSideNeededSample())
                            {
                                cl.Send("sl", false);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("It seems a client has been disconnected at the wrong time");
                }
            }
        }
        //Rechargement du serveur
        public void Reload()
        {
            ServerMainFrame.GetInstance().addLog("RELOADING SERVER");
            Client[] clList = new Client[_clientList.Count];
            int i = 0;
            foreach (Client cl in _clientList)//Utile car beaucoup de traitements asynchrones
            {
                clList[i++] = cl;
            }
            foreach (Client cl in clList)
            {
                cl.Send("disconnect");
            }
            this._listener.Stop();
            this._udpSocket.Close();
            this._connected = false;
            this._clientList = new List<Client>();
            this._clientMove = true;
            _portTCP = int.Parse(ConfigurationManager.AppSettings["TCPPort"]);
            _portUDP = int.Parse(ConfigurationManager.AppSettings["UDPPort"]);
            _samplesPath = ConfigurationManager.AppSettings["SamplesPath"];
            this.Start();

        }

        //Envoi d'un paquet UDP à tous les réseaux pour dire qu'un serveur est connecté
        public void SayYouAreThere()
        {
            IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
            string ips = "server;127.0.0.1";
            foreach (IPAddress ipAdress in localIPs)
            {
                if (ipAdress.AddressFamily != AddressFamily.InterNetworkV6)
                {
                    ips += ";" + ipAdress;
                }
            }
            this.sendUdp(ips);
        }
        }
}
