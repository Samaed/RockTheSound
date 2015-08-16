using RTS.Event.Playback;
using RTS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTS.Controller.Record
{
    // Un son daté est comparable à un autre son daté
    public class DatedSounds : IComparable<DatedSounds>
    {
        // On stocke l'id de l'évènement qui s'est produit
        private long _id;
        // On stocke le laps de temps entre le début de l'enregistrement et le son
        private TimeSpan _date;
        // On stocke le son qui doit être utilisé
        private Sound _sound;
        // On stocke l'action à effectuer sur le son
        private PlaybackEvent.PlaybackAction _action;

        // On peut récupérer l'id de l'évènement qui s'est produit
        public long EventID
        {
            get { return _id; }
        }

        // On peut récupérer et modifier la date à laquelle l'action se produit (TimeLine)
        public TimeSpan Date
        {
            get { return _date; }
            set { _date = value; }
        }

        // On peut récupérer l'action qui s'est produite
        public PlaybackEvent.PlaybackAction Action
        {
            get { return _action; }
        }
        
        // On peut récupérer le son qui a été affecté
        public Sound Sound
        {
            get { return this._sound; }
        }

        // Constructeur à 4 arguments
        public DatedSounds(long eventId, TimeSpan date, PlaybackEvent.PlaybackAction action, Sound sound)
        {
            this._id = eventId;
            this._date = date;
            this._action = action;
            this._sound = sound;
        }

        // On compare les sons datés par leur date et s'il y a égalité on les départage par l'id de l'évènement qui s'est produit (auto-incrémenté)
        public int CompareTo(DatedSounds other)
        {
            if (this._date == other._date)
            {
                return this._id.CompareTo(other._id);
            }
            return this._date.CompareTo(other._date);
        }
    }
}
