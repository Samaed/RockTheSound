using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTS.Event.Record
{
    public class SequenceEvent : Event
    {
        public enum RecordAction
        {
            START,
            STOP,
            UPDATE
        }

        private RecordAction _action;

        public SequenceEvent(object source, RecordAction action)
            : base(source, action.ToString())
        {
            this._action = action;
        }

        public RecordAction Action
        {
            get { return _action; }
        }

        public override string ToString()
        {
            return "Record " + Action.ToString();
        }
    }
}
