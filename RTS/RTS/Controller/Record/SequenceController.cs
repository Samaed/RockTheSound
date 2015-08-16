using RTS.Controller.Network;
using RTS.Event.Playback;
using RTS.Event.Record;
using RTS.Model;
using RTS.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Linq;

namespace RTS.Controller.Record
{
    // Le SequenceController reçoit les évènements de lecture (Play) et envoie des évènement sur son état
    public class SequenceController : Observable<SequenceEvent>, Observer<Event.Event>
    {
        // On définit une instance statique de SequenceController (pattern singleton)
        private static SequenceController INSTANCE;

        // On aura besoin de la date de début d'enregistrement
        private DateTime _recordOrigin;
        // On stockera une liste de sons datés
        private List<DatedSounds> _sounds;
        // On aura un processus de lecture
        private Thread _readThread;
        // Une séquence aura une durée
        private TimeSpan _duration;

        private bool _recording;
        private bool _playing;

        // On fournit une fonction statique afin de récupérer l'instance. Si elle n'existe pas on la crée. Elle sera donc unique.
        public static SequenceController GetInstance()
        {
            if (INSTANCE == null)
            {
                INSTANCE = new SequenceController();
            }
            return INSTANCE;
        }

        // Constructeur sans arguments
        private SequenceController()
        {
            // On s'ajoute en tant qu'observateur du modèle pour récupérer les évènements sur les sons
            Model.Model.GetInstance().AddObserver(this);

            // On initilise les membres (on enregistre pas encore, on ne lit pas non plus)
            this._sounds = new List<DatedSounds>();
            this._recording = false;
            this._playing = false;

        }

        // On indique si on est en train de lire ou non
        public bool Playing
        {
            get { return this._playing; }
        }

        // On indique si on est en train d'enregistrer ou non
        public bool Recording
        {
            get { return this._recording; }
        }

        // On change l'état de la lecture
        public void TogglePlay()
        {
            // Si on lisait, on arrête
            if (this._playing)
            {
                this._playing = false;
            }
            // Sinon on va lancer la lecture
            else
            {
                // S'il n'y a pas de sons enregistrés, on ne fait rien
                if (this._sounds.Count == 0) return;

                this._playing = true;

                // On crée les arguments que l'on va passer à l'enregistrement
                RecordThreadParameters p = new RecordThreadParameters();
                // On aura une durée égale à ce qu'on a enregistré
                p.Duration = this._duration;
                // On passe les sons qu'on a enregistré en les copiant
                p.Sounds = new List<DatedSounds>();
                p.Sounds.AddRange(this._sounds);

                // On lance la lecture dans un thread séparé via StartPlayThread
                this._readThread = new Thread(new ParameterizedThreadStart(this.StartPlayThread));
                this._readThread.Start(p);
            }
        }

        // On change l'état de l'enregistrement
        public void ToggleRecord()
        {
            // Si on enregistrait, on arrête
            if (this._recording)
            {
                this._recording = false;
                // On met à jour la durée de l'enregistrement (maintenant - quand on a lancé)
                this._duration = DateTime.Now - this._recordOrigin;
                // On prévient nos observateurs de l'arrêt d'enregistrement
                this.NotifyObservers(new Event.Record.StopEvent(this));
            }
            // Sinon on réinitialise les membres
            else
            {
                // On efface les sons précédents
                this._sounds.Clear();
                // L'enregistrement commence maintenant
                this._recordOrigin = DateTime.Now;
                this._recording = true;
                // On prévient nos observateurs du début d'enregistrement
                this.NotifyObservers(new Event.Record.StartEvent(this));
            }
        }

        // Boucle de lecture
        private void StartPlayThread(object obj)
        {
            // On trie la liste de sons datés pour qu'ils soient dans le bon ordre (au cas où)
            RecordThreadParameters parameters = (RecordThreadParameters)obj;
            parameters.Sounds.Sort();

            // On initialise l'origine des temps à maintenant
            DateTime origin = DateTime.Now;
            TimeSpan elapsed;
            Sound sound;
            int index = 0;

            // Tant qu'on doit jouer
            while (this.Playing)
            {
                // On calcule le temps écoulé depuis le début de la lecture
                elapsed = DateTime.Now - origin;

                // Si l'index a dépassé le nombre de sons (on a fait un tour de boucle)
                if (index >= parameters.Sounds.Count)
                {
                    // On attend jusqu'à la fin de la durée de la séquence
                    while (DateTime.Now - origin < parameters.Duration) { }

                    // On se remet à zéro
                    index = 0;
                    origin = DateTime.Now;
                    elapsed = TimeSpan.Zero;
                }

                // Si le son doit être joué (on est au bon moment ou un tick en retard)
                if (parameters.Sounds[index].Date <= elapsed)
                {
                    // On récupère le son associé
                    sound = parameters.Sounds[index].Sound;
                    // Si on est en réseau, on observe l'action et on joue côté serveur le cas échéant
                    if (NetworkConnection.GetInstance().Connected)
                    {
                        switch (parameters.Sounds[index].Action)
                        {
                            case PlaybackEvent.PlaybackAction.PLAY:
                                NetworkConnection.GetInstance().PlayOnServer(sound.ID);
                                break;
                        }
                    }
                    else
                    // Sinon on joue côté client
                    {
                        switch (parameters.Sounds[index].Action)
                        {
                            case PlaybackEvent.PlaybackAction.PLAY:
                                Model.Model.GetInstance().PlaySound(sound);
                                break;
                        }
                    }
                    // On incrémente l'index
                    index++;
                }
            }
        }

        // On se rafraîchit à la réception d'un évènement
        public void Refresh(Event.Event e)
        {
            // Si on enregistre
            if (this.Recording)
            {
                // S'il s'agit d'un son à jouer
                if (e is PlayEvent)
                {
                    // On ajoute le son daté correspondant
                    this._sounds.Add(new DatedSounds(e.UID, e.Date - this._recordOrigin, ((PlaybackEvent)e).Action, ((PlaybackEvent)e).Sound));
                }
            }
        }

        // On sérialise en XElement les sons du contrôleur
        public XElement ToXML()
        {
            // On initialise un tableau d'XElement de la taille du nombre de sons
            XElement[] XSounds = new XElement[_sounds.Count];
            int i = 0;
            // On ajoute la durée sous forme de ticks (100nanoseconds)
            XElement XDuration = new XElement("Duration", this._duration.Ticks);
            // Pour chaque son daté, on l'ajoute en créant les balises <DatedSound><soundID></soundID><action></action><time></time><eventID></eventID></DatedSounds>
            foreach (DatedSounds sound in _sounds)
            {
                XSounds[i++] = new XElement("DatedSound", new XElement("soundId", sound.Sound.ID), new XElement("action", sound.Action), new XElement("time", sound.Date.Ticks), new XElement("eventID",sound.EventID));
            }

            // On retourne le XElement qu'on a créé
            return new XElement("Loop", XDuration, XSounds);
        }

        // On charge le contrôleur avec le document sérialisé XDocument
        public void LoadXML(XDocument xdoc)
        {
            // On récupère la racine du document
            XElement root = xdoc.Root;
            // On initialise la liste de sons datés
            this._sounds = new List<DatedSounds>();

            // On initialise une liste des balises filles de DatedSound
            IEnumerable<XElement> list = root.Descendants("DatedSound");
            // On récupère la durée à partir de la valeur de la balise <Duration></Duration>
            this._duration = new TimeSpan(long.Parse(root.Element("Duration").Value));
            // Pour chaque fille de DatedSound
            foreach (XElement item in list)
            {
                // On récupère les valeurs de soundId, time, action, eventID et le son associé à partir de soundId
                string soundId = item.Element("soundId").Value;
                string time = item.Element("time").Value;
                string action = item.Element("action").Value;
                string eventID = item.Element("eventID").Value;
                Sound s = Model.Model.GetInstance().SoundLibrary.GetSoundByID(soundId);
                if (s != null)
                {
                    // Si le son existe, on crée le son daté à partir des éléments qu'on a
                    DatedSounds ds = new DatedSounds(long.Parse(eventID), new TimeSpan(long.Parse(time)), (PlaybackEvent.PlaybackAction)Enum.Parse(typeof(PlaybackEvent.PlaybackAction),action), s);
                    // On ajoute le son daté à la liste de sons datés
                    this._sounds.Add(ds);
                }
            }

            this.NotifyObservers(new UpdateEvent(this));
        }

        // On peut récupérer les sons
        public List<DatedSounds> Sounds
        {
            get { return this._sounds; }
            set { this._sounds = value; }
        }

        // On peut récupérer la durée de la séquence
        public TimeSpan Duration
        {
            get { return this._duration; }
            set { this._duration = value; }
        }
    }
}