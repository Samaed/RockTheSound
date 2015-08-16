using IrrKlang;
using RTS.Event;
using RTS.Event.Playback;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Threading;
using RTS.Tools;
using System.Reflection;
using RTS.Observer;

// On délège une procédure alterEffect pour la gestion des effets;
delegate void alterEffect();
namespace RTS.Model
{
    // Le modèle émet des évènements il est donc Observable.
    // Le modèle récupère les évènement de fin de son.
    public class Model : RTS.Observer.Observable<RTS.Event.Event>, ISoundStopEventReceiver
    {
        // On définit une instance statique de Model (pattern singleton)
        private static Model INSTANCE;

        // On aura besoin d'un engin son
        private ISoundEngine _soundEngine;
        // On garde les ISound pour pouvoir les modifier pendant la lecture
        private BiDictionary<Sound, ISound> _iSounds;
        // On aura une bibliothèque de sons utilisables
        private SoundLibraryModel _library;

        // Le modèle encapsule un métronome
        private Metronome _metronome;

        // On fournit une fonction statique afin de récupérer l'instance. Si elle n'existe pas on la crée. Elle sera donc unique.
        public static Model GetInstance()
        {
            if (INSTANCE == null)
            {
                INSTANCE = new Model();
            }
            return INSTANCE;
        }

        // Constructeur sans argument
        private Model()
        {
            // On initialise les membres à leur valeur par défaut
            this._soundEngine = new ISoundEngine();
            this._iSounds = new BiDictionary<Sound, ISound>();
            this._metronome = new Metronome();
            this._library = new SoundLibraryModel();
        }

        // On pourra accéder à la bibliothèque de sons et la modifier
        public SoundLibraryModel SoundLibrary
        {
            get { return _library; }
            set { _library = value; }
        }

        // On pourra accéder au métronome
        public Metronome Metronome
        {
            get { return _metronome; }
        }

        // On peut récupérer et mettre le volume principal.
        // Le volume du métronome est modifié pour rester supérieur au volume global jusqu'à 85% de celui-ci
        public float GlobalSoundVolume
        {
            get { return this._soundEngine.SoundVolume; }
            set { this._soundEngine.SoundVolume = value; this.Metronome.GlobalSoundVolume = value + 0.15f; this.NotifyObservers(new VolumeEvent(this, this.GlobalSoundVolume)); }
        }

        // On peut jouer un son
        public void PlaySound(Sound s)
        {
            if (s == null) return;

            ISound iSound;

            // Si le son n'a pas déjà été joué on utilise les octets fournis dans Sound
            if (!this._iSounds.ContainsKey(s))
            {
                this._soundEngine.AddSoundSourceFromMemory(s.Bytes, s.Name);
            }
            else
            // Sinon on efface le son de l'engin son précédent
            {
                this._iSounds.TryRemoveByFirst(s);
            }

            // Si le son est altéré, on le joue en activant les effets
            if (s is AffectedSound)
            {
                iSound = this._soundEngine.Play2D(this._soundEngine.GetSoundSource(s.Name), s.AutoLoop, !s.AutoPlay, true);
                this.setEffects(iSound, (AffectedSound)s);
            }
            else
            // Sinon on le joue sans effet
            {
                iSound = this._soundEngine.Play2D(this._soundEngine.GetSoundSource(s.Name), s.AutoLoop, !s.AutoPlay, false);
            }

            // Si le son a bien été joué
            if (iSound != null)
            {
                // On lui ajoute le modèle comme receveur d'évènement de fin de lecture
                iSound.setSoundStopEventReceiver(this);
                // On l'ajoute ensuite dans le dictionnaire pour pouvoir le remodifier ensuite
                try
                {
                    this._iSounds.Add(s, iSound);
                }
                catch (Exception)
                {
                    // Catch an exception on BiDictionary when using loop
                }
            }

            // On notifie les observateurs de la lecture du son
            this.NotifyObservers(new PlayEvent(this, s));
        }

        // On peut mettre un son en pause
        public void PauseSound(Sound s)
        {
            if (s == null) return;

            ISound iSound;
            // On essaie de récupérer le iSound associé et si on l'obtient, on le met en pause et on notifie les observateurs de la pause
            if (this._iSounds.TryGetByFirst(s, out iSound))
            {
                iSound.Paused = true;
                this.NotifyObservers(new PauseEvent(this, s));
            }
        }

        // On indique si le son choisi est en pause ou non
        public bool IsPausedSound(Sound s)
        {
            ISound iSound;
            // On essaie de récupérer le iSound associé et si on l'obtient, on retourne son état, sinon on estime qu'il n'est pas en pause
            if (s != null && this._iSounds.TryGetByFirst(s, out iSound))
            {
                return iSound.Paused;
            }
            return false;
        }

        // On souhaite déboucler un son
        public void UnLoopSound(Sound s)
        {
            if (s != null) return;

            ISound iSound;
            // On essaie de récupérer le iSound associé et si on l'obtient, on désactive la boucle et on notifie les observateurs
            if (this._iSounds.TryGetByFirst(s, out iSound))
            {
                iSound.Looped = false;
                this.NotifyObservers(new UnLoopEvent(this, s));
            }
        }

        // On indique si le son choisi est bouclé ou non
        public bool IsLoopedSound(Sound s)
        {
            ISound iSound;
            // On essaie de récupérer le iSound associé et si on l'obtient, on retourne son état, sinon on estime qu'il n'est pas bouclé
            if (s != null && this._iSounds.TryGetByFirst(s, out iSound))
            {
                return iSound.Looped;
            }
            return false;
        }

        // On peut mettre un son en pause
        public void ResumeSound(Sound s)
        {
            if (s == null) return;

            ISound iSound;
            // On essaie de récupérer le iSound associé et si on l'obtient, on le sort de pause et on notifie les observateurs de la sortie de pause
            if (this._iSounds.TryGetByFirst(s, out iSound))
            {
                iSound.Paused = false;
                this.NotifyObservers(new ResumeEvent(this, s));
            }
        }

        // On peut arrêter un son
        public void StopSound(Sound s)
        {
            if (s == null) return;

            ISound iSound;
            // On essaie de récupérer le iSound associé et si on l'obtient, on l'arrête et on notifie les observateurs de l'arrêt
            if (this._iSounds.TryGetByFirst(s, out iSound))
            {
                iSound.Stop();
                this.NotifyObservers(new ResumeEvent(this, s));
            }
        }

        // On peut supprimer un son
        public void RemoveSound(Sound s)
        {
            if (s == null) return;

            // On arrête le son et on supprime la source de son associée
            this.StopSound(s);
            this._soundEngine.RemoveSoundSource(s.Name);
        }

        // On peut arrêter tous les sons
        public void StopAllSounds()
        {
            this._soundEngine.StopAllSounds();
        }

        // On peut récupérer l'engin son contenu dans le modèle
        public ISoundEngine SoundEngine
        {
            get { return this._soundEngine; }
        }

        // Quand un son s'arrête (ISoundStopEventReceiver)
        public void OnSoundStopped(ISound sound, StopEventCause reason, object userData)
        {
            Sound s;
            // On récupère le Sound associé et on notifie les observateurs de la fin de lecture du son (utile pour éteindre les pads par exemple)
            if (this._iSounds.TryGetBySecond(sound, out s))
            {
                this.NotifyObservers(new EndEvent(this, s));
            }
        }

        // On ajoute un effet sur un iSound
        private void setEffects(ISound iSound, AffectedSound aSound)
        {
            if (iSound == null || aSound == null) return;

            ISoundEffectControl control = iSound.SoundEffectControl;
            Type t = control.GetType();
            MethodInfo method;
            string methodName;

            foreach (KeyValuePair<string, bool> effect in aSound.Effect)
            {

                if (effect.Value == true)
                {
                    methodName = string.Format("Enable{0}SoundEffect", effect.Key);
                }
                else { methodName = string.Format("Disable{0}SoundEffect", effect.Key); }

                method = t.GetMethod(methodName, Type.EmptyTypes);
                method.Invoke(control, null);
            }
            ISoundEffectControl i = iSound.SoundEffectControl;
        }
    }
}
