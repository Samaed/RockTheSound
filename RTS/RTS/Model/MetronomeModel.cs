using IrrKlang;
using RTS.Event.Metronome;
using RTS.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RTS.Model
{
    // Le Métronome est émet des évènements MetronomeEvent donc c'est un observable
    public class Metronome : Observable<MetronomeEvent>
    {
        // On aura un son à jouer
        private Sound _mSound;
        // On utilisera une certaine vitesse d'émission
        private int _metronomeSpeed = 0;
        // Un métronome est actif ou inactif
        private bool _active;
        // On aura besoin d'un processus indépendant dans lequel faire tourner la boucle
        private Thread _thread;
        // On aura un engin son séparé pour être indépendant de celui du modèle
        private ISoundEngine _engine;

        // Constructeur sans arguments
        public Metronome()
        {
            // On n'est pas encore actif
            this._active = false;
            // On charge le son à partir de la ressource "toc.wav" via la fonction GetTocBytes
            this._mSound = new Sound("0", "toc", "toc.wav", this.GetTocBytes());
            // On initialise un nouvel engin son dans lequel on ajoute une source son depuis la mémoire avec le son précédemment chargé
            this._engine = new ISoundEngine();
            this._engine.AddSoundSourceFromMemory(_mSound.Bytes, _mSound.Name);
        }

        // On inverse l'état du métronome
        public void SwitchMetronome()
        {
            // Si il tournait
            if (this.Running)
            {
                // On arrête les sons de l'engin son et on notifie les observateurs de l'arrêt du métronome
                this._active = false;
                this._engine.StopAllSounds();
                this.NotifyObservers(new StopEvent(this));
            }
            else
            // Sinon s'il ne tournait pas
            {
                // On arrête un éventuel thread en cours
                if (this._thread != null)
                {
                    this._thread.Abort();
                }

                // On crée un nouveau thread suivant la routine du métronome
                this._active = true;
                this._thread = new Thread(this.MetronomeRoutine);
                this._thread.IsBackground = true;
                this._thread.Start();
                // On notifie les observateurs du départ du métronome
                this.NotifyObservers(new PlayEvent(this));
            }
        }

        // Boucle du métronome
        private void MetronomeRoutine()
        {
            // Tant que le métronome tourne
            while (this.Running)
            {
                // On joue le son du métronome sans boucler et en autodépart et sans effet
                this._engine.Play2D(this._engine.GetSoundSource(_mSound.Name), this._mSound.AutoLoop, !this._mSound.AutoPlay, false);
                // On attend un intervale calculé en fonction de la vitesse
                Thread.Sleep(1000 - this._metronomeSpeed); // _metronomeSpeed entre -700 et + 700
            }
        }

        // On indique si le métronome tourne ou non
        public bool Running
        {
            get { return this._active; }
        }

        // On retourne la vitesse en BPM
        // On l'assigne avec un flottant entre 0 et 1
        public float Speed
        {
            get { return (60000 / (1000 - this._metronomeSpeed)); }
            set { this._metronomeSpeed = (int)((value - 0.5) * 1400); this.NotifyObservers(new SpeedEvent(this, this.Speed)); }
        }

        // On charge en mémoire les octets du son
        private byte[] GetTocBytes()
        {
            // On utilise un flux sur la ressource "toc"
            using (var stream = Properties.Resources.toc)
            {
                // On initialise un buffer de la taille du flux et on copie le flux dedans puis le retourne
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                return buffer;
            }
        }

        // On peut indiquer le volume global du métronome ou le récupérer
        public float GlobalSoundVolume
        {
            get { return this._engine.SoundVolume; }
            set { this._engine.SoundVolume = value; }
        }
    }
}
