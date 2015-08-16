using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;
using RTS.Model;
using System.Diagnostics;
using System.Threading;

namespace RTServer
{
    public class Client
    {
        //Watch pour l'envoi de fichiers
        private Stopwatch _watch;

        private bool _mute = false;
        public bool Mute { get { return _mute; } set { _mute = value; } }

        //Is a sending process active
        private bool _sending = false;
        private static int currentId = 0;
        private int _id;
        private Socket _soc;
        //List des samples dispos chez le client
        private List<string> _samplesIds;

        //Is a checking in progress
        private bool _checkListServSide = false;
        public bool ClientReadyToReceive { get { return this._clientReadyToReceive; } set { _clientReadyToReceive = value; } }
        //Is the client ready to receive a file
        private bool _clientReadyToReceive = true;

        public bool CheckListServSide
        {
            get { return _checkListServSide; }
            set { _checkListServSide = value; }
        }
        private bool _checkListClientSide = false;

        public bool CheckListClientSide
        {
            get { return _checkListClientSide; }
            set { _checkListClientSide = value; }
        }

        public List<string> SampleIds { get { return _samplesIds; } set { _samplesIds = value; } }

        public Socket Socket
        {
            get { return _soc; }
            set { _soc = value; }
        }


        public int Id
        {
            get { return _id; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }



        public Client()
        {
            this._id = currentId++;
            _samplesIds = new List<string>();
        }

        private delegate string ReadLineDelegate();//Delegate de timeout
        //send a TCP message to the client
        public void Send(string message, bool askAnswer = true)
        {
            try
            {
                Stream s = new NetworkStream(this._soc);
                StreamReader sr = new StreamReader(s);
                StreamWriter sw = new StreamWriter(s);
                sw.AutoFlush = true;
                sw.WriteLine(message);
                if (askAnswer)
                {
                    ReadLineDelegate d = sr.ReadLine;
                    IAsyncResult result = d.BeginInvoke(null, null);
                    result.AsyncWaitHandle.WaitOne(200);//timeout 200ms pour l'attente d'une réponse client
                    string response = "";
                    if (result.IsCompleted)
                    {
                        response = d.EndInvoke(result);
                    }
                }
                s.Close();
            }
            catch (Exception e)//si déconnexion pour une raison inconnue
            {
                ServerMainFrame.GetInstance().addLog(this._id + " : " + e.Message);
            }

        }
        //Send a sound to the client
        public bool SendSound(Sound sound)
        {
            if (!_sending)
            {
                try
                {
                    ServerMainFrame.GetInstance().addLog("Try to send " + sound.Name + " to " + this.Name);
                    NetworkStream netstream = new NetworkStream(this._soc);
                    StreamWriter sw = new StreamWriter(netstream);
                    sw.AutoFlush = true;

                    sw.WriteLine(NetworkParser.getCode(NetworkParser.Operation.GIVE_FILE) + ";" + sound.ID + ";" + sound.Name + ";" + sound.FileSize);//envoie du nom et id du fichier (et la taille pour comparaison)
                    this._sending = true;
                    this._watch = new Stopwatch();//Création d'une stopwatch pour réenvoyer l'instruction au bout de 3sec si pas de réponse (client busy)
                    this._watch.Start();
                    this.PendingSendSound(sound);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception in Sound sending : " + e);
                }
            }
            return true;
        }
        //Permet d'attendre que le client soit prêt et de rééssayer régulièrement
        private void PendingSendSound(Sound sound)
        {
            while (this._watch.IsRunning)
            {
                if (this._watch.ElapsedMilliseconds > 3000)//Si le client n'a pas répondu dans les 3sec, on renvoit l'instruction
                {
                    this._sending = false;
                    this.SendSound(sound);
                    break;
                }
            }
        }

        public void SetSampleList(string[] words)
        {
            _checkListServSide = true;
            this._samplesIds = new List<string>();
            foreach (string word in words)
            {
                if (!word.Equals(NetworkParser.getCode(NetworkParser.Operation.SAMPLE_LIST)))
                {
                    this._samplesIds.Add(word);
                }
            }
            this.GetNextServerSideNeededSample();
        }

        public void GetNextServerSideNeededSample()
        {
            this._checkListServSide = true;
            foreach (string sampleId in _samplesIds)
            {
                if (!ServerSoundLibrary.GetInstance().Data.SoundsDictionary.ContainsKey(sampleId))
                {
                    if (!sampleId.Equals(""))
                    {
                        this.Send(NetworkParser.getCode(NetworkParser.Operation.ASK_FILE) + ";" + sampleId, false);
                        return;
                    }
                }
            }
            this._checkListServSide = false;
        }

        public bool SendNextClientSideNeededSample()
        {
            this._checkListClientSide = true;
            foreach (string sampleId in ServerSoundLibrary.GetInstance().Data.SoundsDictionary.Keys)
            {
                if (!this._samplesIds.Contains(sampleId))
                {
                    Thread sendingThread = new Thread(new ParameterizedThreadStart(ThreadSendSound));//Création d'un thread pour le process d'envoi de sample
                    sendingThread.IsBackground = true;
                    sendingThread.Start(sampleId);
                    return true;
                }
            }
            this._checkListClientSide = false;
            return false;
        }

        private void ThreadSendSound(object id)
        {
            this.SendSound(ServerSoundLibrary.GetInstance().Data.GetSoundByID((string)id));
        }



        public void ClientReadySendSound(string p)//Est appelée quand le client est prêt à recevoir un sample
        {
            this._watch.Stop();
            Sound sound = ServerSoundLibrary.GetInstance().Data.GetSoundByID(p);
            _sending = true;
            byte[] SendingBuffer = null;
            NetworkStream netstream = null;
            int BufferSize = 1000;//1000 octets par envoi
            try
            {
                ServerMainFrame.GetInstance().addLog("Sending " + sound.Name + " to " + this.Name);
                netstream = new NetworkStream(this._soc);
                StreamWriter sw = new StreamWriter(netstream);
                sw.AutoFlush = true;

                sw.WriteLine("go");//Préviens le client qu'au prochain paquet le fichier commence

                FileStream Fs = new FileStream(sound.File, FileMode.Open, FileAccess.Read);
                SendingBuffer = new byte[Fs.Length];
                Fs.Read(SendingBuffer, 0, (int)Fs.Length);//Chargement du fichier en mémoire sur le serveur

                int NoOfPackets = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Fs.Length) / Convert.ToDouble(BufferSize)));//Calcul du nombre total de paquets à envoyer
                int TotalLength = (int)Fs.Length, CurrentPacketLength;
                for (int i = 0; i < NoOfPackets; i++)//Envoi des paquets
                {
                    if (TotalLength > BufferSize)//Cas du dernier paquet, pour éviter d'envoyer des 0 on diminue la taille du buffer
                    {
                        CurrentPacketLength = BufferSize;
                        TotalLength = TotalLength - CurrentPacketLength;
                    }
                    else
                    {
                        CurrentPacketLength = TotalLength;
                    }
                    netstream.Write(SendingBuffer, BufferSize * i, CurrentPacketLength);//Envoi du paquet

                }
                System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                Byte[] bytes = encoding.GetBytes(" ");//Envoie d'un message vide pour éventuelement satisfaire la dernière boucle de reception du client
                netstream.Write(bytes, 0, bytes.Length);

                this.SampleIds.Add(sound.ID);
                //On ajoute le sample à la liste de samples du client, en espérant que le transfert s'est bien passé
                //Si ce n'est pas le cas, le client redemandera le sample ultérieurement
                ServerMainFrame.GetInstance().addLog("Sended " + sound.Name + " to " + this.Name);
                Fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("sendfile : " + ex.Message);
            }
            _sending = false;
        }

        public override string ToString()
        {
            if (Mute)
            {
                return this.Name + " (muted)";
            }
            return this.Name;
        }
    }
}
