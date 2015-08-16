using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTS.Event.Metronome
{
    public abstract class MetronomeEvent : Event
    {
        public enum MetronomeAction
        {
            PLAY,
            STOP,
            SPEED
        }

        private MetronomeAction _action;

        public MetronomeEvent(object source, MetronomeAction action)
            : base(source, action.ToString())
        {
            this._action = action;
        }

        public MetronomeAction Action
        {
            get { return this._action; }
        }

        public override string ToString()
        {
            return "Metronome " + Action.ToString();
        }
    }
}
