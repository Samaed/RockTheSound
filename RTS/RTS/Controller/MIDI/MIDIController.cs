using NAudio.Midi;
using RTS.Event;
using RTS.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTS.Controller
{
    // Le MIDIController gère l'acquisition des notes MIDI et les périphériques MIDI
    public class MIDIController
    {
        // On définit une instance statique de MIDIController (pattern singleton)
        private static MIDIController INSTANCE;

        // On va stocker l'ensemble des périphériques MidiIn (NAudio)
        private MidiIn[] _devices;

        // Constructeur sans argument
        private MIDIController()
        {
            // On initialise le tableau de périphériques en récupérant le nombre de périphériques via NAudio
            this._devices = new MidiIn[MidiIn.NumberOfDevices];
        }

        // On fournit une fonction statique afin de récupérer l'instance. Si elle n'existe pas on la crée. Elle sera donc unique.
        public static MIDIController GetInstance()
        {
            if (INSTANCE == null)
            {
                INSTANCE = new MIDIController();
            }
            return INSTANCE;
        }

        // On retourne le nombre de périphériques MIDI connectés
        public int DevicesCount
        {
            get { return this._devices.Length; }
        }

        // On débute l'écoute sur le périphérique à l'index index
        public void StartRecording(int index)
        {
            // On ne fait rien si l'index n'est pas bon
            if (!checkIndex(index))
                return;

            // Si le périphérique n'a pas encore été utilisé, on l'ajoute au tableau
            if (this._devices[index] == null)
            {
                this._devices[index] = new MidiIn(index);
            }

            // On débute l'écoute
            this._devices[index].Start();
        }

        // On arrete l'écoute sur le périphérique à l'index index
        public void StopRecording(int index)
        {
            // On ne fait rien si l'index n'est pas bon
            if (!checkIndex(index))
                return;

            if (this._devices[index] != null)
            {
                // On débute l'écoute si le périphérique existait bien
                this._devices[index].Stop();
            }
        }

        // On peut ajouter des écouteurs sur les évènements MIDI des périphériques
        public void AddMessageReceivedHandler(int index, EventHandler<MidiInMessageEventArgs> handler)
        {
            // On ne fait rien si l'index n'est pas bon
            if (!checkIndex(index))
                return;

            // On ajoute l'écouteur sur la réception de message MIDI du périphérique à l'index index
            this._devices[index].MessageReceived += handler;
        }

        // On peut retirer des écouteurs sur les évènements MIDI des périphériques        
        public void RemoveMessageReceivedHandler(int index, EventHandler<MidiInMessageEventArgs> handler)
        {
            // On ne fait rien si l'index n'est pas bon
            if (!checkIndex(index))
                return;

            // On retire l'écouteur sur la réception de message MIDI du périphérique à l'index index
            this._devices[index].MessageReceived -= handler;
        }

        // Un index n'est pas bon s'il n'est pas entre 0 et le nombre de périphériques moins un
        public bool checkIndex(int index)
        {
            return (index >= 0 && index < this._devices.Length);
        }
    }
}
