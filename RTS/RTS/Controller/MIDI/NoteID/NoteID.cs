using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTS.Controller.MIDI.NoteID
{
    // La NoteID encapsule un entier correspondant à la note jouée
    public class NoteID
    {
        // On définit un comparateur publique statique
        public static NoteIDComparer Comparer = new NoteIDComparer();
        // On va utiliser un entier comme id privé
        private int _id;

        // On peut récupérer l'id
        public int ID
        {
            get { return _id; }
        }

        // Constructeur à un argument
        public NoteID(int id)
        {
            this._id = id;
        }

        // Deux NoteID sont égaux si leurs ids sont égaux
        public override bool Equals(object obj)
        {
            if (obj is NoteID)
            {
                return ((NoteID)obj).ID == this.ID;
            }
            else
            {
                return base.Equals(obj);
            }
        }

        // Le HashCode d'un NoteID est son id lui-même
        public override int GetHashCode()
        {
            return this.ID;
        }

        public override string ToString()
        {
            return this.ID.ToString();
        }
    }
}
