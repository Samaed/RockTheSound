using IrrKlang;
using NAudio.Wave;
using RTS.Event;
using RTS.Event.Export;
using RTS.Observer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RTS.Controller.Export
{
    // ExportController est un contrôleur qui envoie des évènements, il est donc Observable.
    public class ExportController : Observable<Event.Event>
    {
        // On définit une instance statique d'ExportController (pattern singleton)
        private static ExportController INSTANCE;

        // La boucle WasapiLoopbackCapure permet de récupérer le son des hauts parleurs
        private WasapiLoopbackCapture _loop;
        // On aura besoin d'un MemoryStream pour stocker les données le temps de la capture
        private MemoryStream _memoryStream;
        // On va vouloir savoir si le contrôleur enregistre ou non
        private bool _recording;

        // On fournit une fonction statique afin de récupérer l'instance. Si elle n'existe pas on la crée. Elle sera donc unique.
        public static ExportController GetInstance()
        {
            if (INSTANCE == null)
            {
                INSTANCE = new ExportController();
            }
            return INSTANCE;
        }

        // Constructeur sans argument
        private ExportController()
        {
            // On enregistre pas encore
            this._recording = false;
            this._memoryStream = new MemoryStream();
            this._loop = new WasapiLoopbackCapture();

            // Dès que des données seront capturées, elle seront envoyées à la fonction DataAvailable
            this._loop.DataAvailable += new EventHandler<WaveInEventArgs>(this.DataAvailable);
            // Quand la capture sera arrêtée, la fonction RecordingStopped se déclenchera
            this._loop.RecordingStopped += new EventHandler<StoppedEventArgs>(this.RecordingStopped);
        }

        // Retourne si on enregistre ou non
        public bool Recording
        {
            get { return this._recording; }
        }

        // Démarrage de l'enregistrement
        public void StartRecording()
        {
            // Si on enregistre pas encore
            if (!this.Recording)
            {
                // Si un MemoryStream existe déjà, on le ferme (précédent enregistrement)
                if (this._memoryStream != null)
                {
                    this._memoryStream.Close();
                }

                // On initialise un nouveau MemoryStream
                this._memoryStream = new MemoryStream();
                // On ordonne à la boucle WasapiLoopbackCapture de commencer à recevoir les données
                this._loop.StartRecording();
                // On indique qu'on enregistre à nos observateurs
                this._recording = true;
                this.NotifyObservers(new StartEvent(this));
            }
        }

        // Arrêt de l'enregistrement
        public void StopRecording()
        {
            // Si on enregistrait
            if (this.Recording)
            {
                // On ordonne à la boucle WasapiLoopbackCapture d'arrêter la réception de données
                this._loop.StopRecording();
                // On indique qu'on arrête d'enregistrer à nos observateurs
                this._recording = false;
                this.NotifyObservers(new StopEvent(this));

                // On ouvre une fenêtre pour enregistrer le fichier .wav
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Filter = "Wave File (*.wav) | *.wav";

                // Si on a choisi un fichier et validé
                if (savedialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // On essaie de copier le fichier temporaire dans le fichier sélectionné avec possibilité d'écrire au dessus (overwrite)
                        System.IO.File.Copy("tmp", savedialog.FileName, true);
                    }
                    catch (Exception)
                    {
                        // On prévient les observateurs que la copie n'a pas fonctionné le cas échéant
                        this.NotifyObservers(new ErrorEvent(this, "copying temporary export file to user selected file"));
                    }
                }

                try
                {
                    // On essaie de supprimer le fichier temporaire
                    System.IO.File.Delete("tmp");
                }
                catch (Exception)
                {
                    // On prévient les observateurs que la suppression n'a pas fonctionné le cas échéant
                    this.NotifyObservers(new ErrorEvent(this, "deleting temporary export file"));
                }
            }
        }

        // Des données ont été capturé
        private void DataAvailable(object sender, WaveInEventArgs e)
        {
            // On les ajoute au MemoryStream (e.Buffer est le tableau d'octets enregisté et e.BytesRecorded sa longueur)
            this._memoryStream.Write(e.Buffer, 0, e.BytesRecorded);
        }

        // On a arrêté l'enregistrement
        private void RecordingStopped(object sender, StoppedEventArgs e)
        {
            try
            {
                // On essaie d'ouvrir un flux vers le fichier temporaire
                FileStream f = new FileStream("tmp", FileMode.Create);
                // On ouvrir un écriveur de fichier wave NAudio qui utilise le format des données de la boucle WasapiLoopbackCapture
                NAudio.Wave.WaveFileWriter w = new WaveFileWriter(f, this._loop.WaveFormat);

                // On initialise un tableau d'octets de la longueur du flux
                byte[] bytes = new byte[this._memoryStream.Length];
                // On se met au début du stream
                this._memoryStream.Seek(0, SeekOrigin.Begin);
                // On copie le flux mémoire dans le tableau d'octets
                this._memoryStream.Read(bytes, 0, (int)this._memoryStream.Length);
                // On copie le tableau d'octets dans l'écriveur NAudio (qui crée l'entête automatiquement)
                w.Write(bytes, 0, (int)this._memoryStream.Length);

                // On ferme l'écriveur de fichier et le flux vers le fichier
                w.Close();
                f.Close();
            }
            catch (Exception)
            {
                // On prévient les observateurs que l'écriture n'a pas fonctionné le cas échéant
                this.NotifyObservers(new ErrorEvent(this, "writing temporary export file"));
            }
        }
    }
}
