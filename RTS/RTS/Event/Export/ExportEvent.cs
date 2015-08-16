using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTS.Event.Export
{
    public class ExportEvent : Event
    {
        public enum ExportAction {
            START,
            STOP
        }

        private ExportAction _action;

        public ExportEvent(object source, ExportAction action)
            : base(source, action.ToString())
        {
            this._action = action;
        }

        public ExportAction Action
        {
            get { return _action; }
        }

        public override string ToString()
        {
            return "Export " + Action.ToString();
        }
    }
}
