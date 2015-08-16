using RTS.Event.Network;
using RTS.Model;
using RTS.Model.Network;
using RTS.Observer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace RTS.Controller.Network
{
    // Le contrôleur réseau envoie des évènements NetworkEvent donc il est Observable.
    public class NetworkConnection : Observable<NetworkEvent>
    {
        // On définit une instance statique de NetworkConnection (pattern singleton)
        private static NetworkConnection INSTANCE;

        // On aura une liste d'amis pour la communication TCP
        private List<Friend> _friends;
        // On aura un TcpClient pour envoyer les messages TCP
        private TcpClient _tcpClient;
        // On aura un UdpClient pour envoyer les messages UDP
        private UdpClient _udpClient;
        // On utilisera un IPEndPoint pour le broadcast
        private IPEndPoint _broadcast_end_point;
        // On voudra savoir si on est connecté ou non (TCP/UDP)
        private bool _tcpConnected = false;
        private bool _udpConnected = false;
        // Chaque client a un nom et chaque server un id
        private string _name = "john";
        private int _serverId;

        // On peut récupérer tous les amis
        public List<Friend> Friends { get { return _friends; } }

        // On fournit une fonction statique afin de récupérer l'instance. Si elle n'existe pas on la crée. Elle sera donc unique.
        public static NetworkConnection GetInstance()
        {
            if (INSTANCE == null)
            {
                INSTANCE = new NetworkConnection();
            }
            return INSTANCE;
        }

        // Constructeur sans arguments privé (pattern Singleton oblige, car classe d'accès à une ressource unique)
        private NetworkConnection()
        {
            // On initialise la liste d'amis vide
            _friends = new List<Friend>();

            // On démarre un processus pour se connecter en UDP en tâche de fond
            Thread UdpT = new Thread(new ParameterizedThreadStart(ConnectUDP));
            UdpT.IsBackground = true;
            UdpT.Start("");
        }

        // Dit si on est connecté ou non en TCP
        public bool TCPConnected
        {
            get { return _tcpConnected; }
        }

        // Dit si on est connecté ou non en UDP
        public bool UDPConnected
        {
            get { return _udpConnected; }
        }

        // Dit si on est connecté ou non (TCP && UDP)
        public bool Connected
        {
            get { return _tcpConnected && _udpConnected; }
        }

        // Retourne l'id du serveur
        public int ServerID
        {
            get { return _serverId; }
        }

        // On peut définir et récupérer le nom du client
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        // Connexion à l'adresse ip ip selon le nom de client name
        public void Connect(string ip, string name)
        {
            this._name = name;
            // On démarre un processus pour se connecter en TCP à l'ip indiquée en tâche de fond
            Thread TcpT = new Thread(new ParameterizedThreadStart(ConnectTCP));
            TcpT.IsBackground = true;
            TcpT.Start(ip);

        }

        // Boucle d'écoute TCP
        public void ConnectTCP(object data)
        {
            string ip = (string)data;
            // Si déjà connecté, pas la peine de se reconnecter
            if (!this._tcpConnected)
            {
                try
                {
                    // On ouvre un Socket TCP sur l'ip avec le port indiqué dans la configuration de l'application
                    
                    this._tcpClient = new TcpClient(ip, int.Parse(ConfigurationManager.AppSettings["TCPPort"]));
                    
                    // On indique qu'on est connecté à nos observateurs
                    this._tcpConnected = true;
                    this.NotifyObservers(new NetworkEvent(data, NetworkEvent.NetworkAction.CONNECT));

                    try
                    {
                        // On tente de récupérer un flux depuis le Socket TCP
                        Stream s = _tcpClient.GetStream();

                        //Création des flux de lecture et d'écriture
                        StreamReader sr = new StreamReader(s);
                        StreamWriter sw = new StreamWriter(s);
                        sw.AutoFlush = true;

                        sr.ReadLine();//Lire une ligne (appel du serveur)

                        sw.WriteLine(_name);//On indique au serveur son nom

                        string msg = sr.ReadLine();//Le serveur renvoie l'ID
                        string[] words = msg.Split(new char[] { ';' });

                        _serverId = int.Parse(words[1]);

                        string sampleIds = Model.Model.GetInstance().SoundLibrary.GetStringSampleList();//Récupération de la liste de samples
                        sw.WriteLine("sl;" + sampleIds);//ENvoi de la liste

                        while (!msg.Equals("disconnect"))//Tant que le serveur ne demande pas la déconnection
                        {

                            msg = sr.ReadLine();//lecture d'un mesage
                            
                            string response = "ok";//Réponse pour le serveur
                            if (msg == null)
                                break;

                            string[] parts = msg.Split(new char[] { ';' });
                            switch (parts[0])
                            {
                                case "nm":
                                    //Cas d'un nouveau membre
                                    this.NotifyObservers(new NetworkEvent(parts[2], NetworkEvent.NetworkAction.WELCOME));
                                    _friends.Add(new Friend(int.Parse(parts[1]), parts[2]));
                                    break;
                                case "rm":
                                    //Cas d'un membre déconnecté

                                    foreach (Friend friend in _friends)
                                    {
                                        if (friend.Id == int.Parse(parts[1]))
                                        {
                                            this.NotifyObservers(new NetworkEvent(friend.Name, NetworkEvent.NetworkAction.GOODBYE));
                                            _friends.Remove(friend);
                                            break;
                                        }
                                    }
                                    break;
                                case "sl":
                                    //Le serveur demande la liste des samples
                                    sampleIds = Model.Model.GetInstance().SoundLibrary.GetStringSampleList();
                                    response = "sl;" + sampleIds;
                                    break;
                                case "gf":
                                    //Le serveur veut envoyer un fichier 
                                    ReceiveFile(parts, sw, sr);
                                    break;
                                case "af":
                                    //Le serveur veut recevoir un fichier
                                    SendSound(Model.Model.GetInstance().SoundLibrary.GetSoundByID(parts[1]));
                                    break;
                                case "disconnect"://obvious
                                    response = "disconnect";//Confirmation envoyée au serveur
                                    break;
                            }

                            sw.WriteLine(response);//Réponse
                        }

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("TCP2 : " + e);
                    }
                    finally
                    {
                        _tcpClient.Close();//Déconnection en dernier lieu
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("TCP1 : " + e);
                    this.NotifyObservers(new NetworkEvent(data, NetworkEvent.NetworkAction.NO_SERVER_FOUND));
                }
                finally
                {
                    _tcpConnected = false;
                    this.NotifyObservers(new NetworkEvent(data, NetworkEvent.NetworkAction.DISCONNECT));//Préviens de la déconnection
                }
            }
        }

        public void ConnectUDP(object data)//a appeler dans un background thread, Boucle d'écoute UDP
        {
            string ip = (string)data;
            if (!this._udpConnected)
            {
                try
                {
                    //Création du client UDP d'envoi/reception
                    //IPEndPoint de reception
                    IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, int.Parse(ConfigurationManager.AppSettings["UDPPort"]));
                    _udpClient = new UdpClient();
                    _udpClient.EnableBroadcast = true;

                    //EndPoint d'envoi
                    _broadcast_end_point = new IPEndPoint(IPAddress.Broadcast, int.Parse(ConfigurationManager.AppSettings["UDPPort"]));
                    this._udpConnected = true;

                    //Bind de l'endpoint de réception
                    _udpClient.Client.Bind(groupEP);

                    try
                    {
                        string msg = "";
                        while (!msg.Equals("disconnect"))//Boucle de réception
                        {
                            //Reception d'un message UDP
                            msg = Encoding.ASCII.GetString(_udpClient.Receive(ref groupEP));
                            
                            if (msg == null)
                                break;

                            string[] parts = msg.Split(new char[] { ';' });
                            switch (parts[0])
                            {
                                case "p"://Quelqu'un demande de jouer un son
                                    if (this._tcpConnected)//Si le serveur est toujours connecté
                                    {
                                        //Jouons le son
                                        Model.Model.GetInstance().PlaySound(Model.Model.GetInstance().SoundLibrary.GetSoundByID(parts[1]));
                                    }
                                    break;
                                case "server"://Un serveur sauvage apparait !
                                    for (int i = 1; i < parts.Length - 1; i++)
                                    {
                                        if (this.TryTCPConnect(parts[i]))//Essayons de nous connecter à l'IP qu'il annonce
                                            break;
                                    }
                                    break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("UDP1" + e.Message);
                    }
                    finally
                    {
                        _tcpClient.Close();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("UDP2" + e.Message);
                }
                finally
                {
                    this._udpConnected = false;
                }
            }
        }

        private bool TryTCPConnect(string ip)
        {
            try
            {
                if (this._tcpConnected)//Si le serveur est déjà connecté, rien à faire
                    return true;

                //Tentative de connection (vérification de l'IP)
                this._tcpClient = new TcpClient(ip, int.Parse(ConfigurationManager.AppSettings["TCPPort"]));

                //Si tout se passe bien, création du thread de connection TCP
                Thread TcpT = new Thread(new ParameterizedThreadStart(ConnectTCP));
                TcpT.IsBackground = true;
                TcpT.Start(ip);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private delegate string ReadLineDelegate();//Délegate de timeout pour ne pas attendre trop longtemps la réponse serveur

        public string AskServer(string message, bool needResponse = true)
        //Demande quelquechose au serveur et retourne la réponse
        {
            string response = "Not connected";//Construction du string de réponse
            if (this._tcpConnected)
            {
                Stream s = _tcpClient.GetStream();

                try
                {
                    StreamReader sr = new StreamReader(s);
                    StreamWriter sw = new StreamWriter(s);
                    sw.AutoFlush = true;

                    sw.WriteLine(message);//envoi du message
                    response = "No response";
                    if (needResponse)//Si une réponse est demandée
                    {
                        ReadLineDelegate d = sr.ReadLine;
                        IAsyncResult result = d.BeginInvoke(null, null);
                        result.AsyncWaitHandle.WaitOne(200);//timeout de 200ms pour attendre la réponse (évite de freeze si la réponse est chopée par le StreamReader principal)
                        response = "";
                        if (result.IsCompleted)
                        {
                            response = d.EndInvoke(result);
                        }
                    }

                    
                }
                catch (Exception e)//si déconnexion pour une raison inconnue
                {
                    Console.WriteLine(e.Message);
                }
            }
            return response;
        }

        //Envoyer au serveur une nouvelle liste de samples
        public void SendNewList()
        {
            string sampleIds = Model.Model.GetInstance().SoundLibrary.GetStringSampleList();
            this.AskServer("sl;" + sampleIds, false);
        }

        //Envoi d'un son au serveur
        public bool SendSound(Sound sound)
        {
            if (Connected)
            {
                byte[] SendingBuffer = null;
                NetworkStream netstream = null;
                int BufferSize = 1000;//Buffer de 1000octets
                try
                {
                    //Afficher dans la console envoi d'un fichier
                    this.NotifyObservers(new NetworkEvent(sound.Name, NetworkEvent.NetworkAction.SENDING_FILE));
                    //Récupération du stream tcp
                    netstream = _tcpClient.GetStream();
                    //Création d'un stream d'écriture
                    StreamWriter sw = new StreamWriter(netstream);
                    sw.AutoFlush = true;
                    //Préviens le serveur que j'envoi un son
                    sw.WriteLine("gf;" + sound.ID + ";" + sound.File + ";" + sound.FileSize);//envoie du nom, id, et taille de fichier
                    //Stream de lecture du fichier
                    FileStream Fs = new FileStream(sound.File, FileMode.Open, FileAccess.Read);
                    //Nombre de paquets à recevoir
                    int NoOfPackets = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Fs.Length) / Convert.ToDouble(BufferSize)));
                    //Taille total du fichier
                    int TotalLength = (int)Fs.Length, CurrentPacketLength;
                    
                    SendingBuffer = new byte[Fs.Length];
                    //Mise en mémoire du fichier
                    Fs.Read(SendingBuffer, 0, (int)Fs.Length);

                    //Boucle d'envoi du fichier
                    for (int i = 0; i < NoOfPackets; i++)
                    {
                        if (TotalLength > BufferSize)
                        {
                            CurrentPacketLength = BufferSize;
                            TotalLength = TotalLength - CurrentPacketLength;
                        }
                        else
                        {
                            CurrentPacketLength = TotalLength;
                        }
                        //Envoi d'un paquet de bytes
                        netstream.Write(SendingBuffer, i * BufferSize, CurrentPacketLength);
                    }
                    //Envoi d'un paquet vide pour satisfaire le serveur
                    netstream.Write(new byte[0], 0, 0);

                    this.NotifyObservers(new NetworkEvent(sound.Name, NetworkEvent.NetworkAction.FILE_SENT));
                    Fs.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("sendfile : " + ex.Message);
                }
                finally
                {
                }
            }

            return true;
        }
        //Jouer un son chez les autres joueurs
        public void PlayOnServer(string id)
        {
            byte[] bytes = Encoding.ASCII.GetBytes("p;" + id + ";" + this._serverId);
            //Asks everyone to play this sound
            _udpClient.Send(bytes, bytes.Length, _broadcast_end_point);
        }

        public void Disconnect()
        {
            this.AskServer("disconnect");
        }

        //Reception d'un fichier
        private void ReceiveFile(string[] words, StreamWriter sw, StreamReader sr)
        {
            this.NotifyObservers(new NetworkEvent(words[2], NetworkEvent.NetworkAction.RECEIVING_FILE));
            int BufferSize = 1000;
            byte[] RecData = new byte[BufferSize];
            int RecBytes;

            //Préviens le serveur que je suis prêt à recevoir
            sw.WriteLine("ready2receive;" + words[1]);
            //Réception du "go" serveur
            sr.ReadLine();
            NetworkStream netstream = null;
            try
            {
                //Création d'un netstream
                netstream = this._tcpClient.GetStream();
             
                //Création du dossier de samples si nécessaire
                bool isExists = System.IO.Directory.Exists("Samples");
                if (!isExists)
                    System.IO.Directory.CreateDirectory("Samples");

                int fileNonOverrideIndex = 0;
                string[] fileNameSplitted = words[2].Split(new char[] { '.' });
                string saveFileName = "Samples\\" + words[2];

                while (System.IO.File.Exists(saveFileName))//Vérification et renomme en cas de fichier existant
                {
                    fileNonOverrideIndex++;
                    saveFileName = "Samples\\";

                    for (int i = 0; i < fileNameSplitted.Length-1; i++)
                    {
                        saveFileName += fileNameSplitted[i];
                    }

                    saveFileName += "("+fileNonOverrideIndex+")."+fileNameSplitted[fileNameSplitted.Length-1];
                }

                System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                if (saveFileName != string.Empty)
                {
                    int totalrecbytes = 0;
                    FileStream Fs = new FileStream(saveFileName, FileMode.OpenOrCreate, FileAccess.Write);
                    bool stop = false;
                    while ((RecBytes = netstream.Read(RecData, 0, RecData.Length)) > 6 && !stop)
                    {
                        Fs.Write(RecData, 0, RecBytes);
                        totalrecbytes += RecBytes;
                        stop = RecBytes < 1000;
                    }
                    Fs.Close();
                }
                
                FileInfo infos = new FileInfo(saveFileName);
                if (Math.Abs(infos.Length - long.Parse(words[3])) < 250)//vérification de la taille du fichier reçu pour être sur
                {
                    Model.Model.GetInstance().SoundLibrary.AddSound(saveFileName);
                    Model.Model.GetInstance().SoundLibrary.Modified = true;
                    Tools.FileAccessor.SaveLibrary();
                    this.NotifyObservers(new NetworkEvent(words[2], NetworkEvent.NetworkAction.FILE_RECEIVED));
                }
                else
                {
                    System.IO.File.Delete(saveFileName);
                    this.NotifyObservers(new NetworkEvent(words[2] + " received :" + infos.Length + " initial size : " + words[3], NetworkEvent.NetworkAction.ERROR_FILE_SIZE));
                }
                this.AskServer("ready", false);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
