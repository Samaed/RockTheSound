using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTS.Controller.MIDI.NoteID
{
    // On définit un comparateur de NoteID pour les IDictionary en respectant l'interface IEqualityComparer<>
    public class NoteIDComparer : IEqualityComparer<NoteID>
    {
        // Deux NoteID sont égaux si leurs ids sont égaux
        public bool Equals(NoteID x, NoteID y)
        {
            return x.ID == y.ID;
        }

        // Le HashCode d'un NoteID est son id lui-même
        public int GetHashCode(NoteID obj)
        {
            return obj.ID;
        }
    }
}
