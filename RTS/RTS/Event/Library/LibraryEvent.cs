using RTS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTS.Event.Library
{
    public class LibraryEvent : Event
    {
        public enum LibraryAction
        {
            ADD,
            REMOVE
        }

        private LibraryAction _action;
        private Sound _sound;

        public LibraryEvent(object source, LibraryAction action, Sound s)
            : base(source, action.ToString())
        {
            this._action = action;
            this._sound = s;
        }

        public Sound Sound
        {
            get { return this._sound; }
        }

        public LibraryAction Action
        {
            get { return this._action; }
        }

        public override string ToString()
        {
            return "Library " + Action.ToString();
        }
    }
}
