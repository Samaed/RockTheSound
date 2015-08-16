using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTS.Event.Export
{
    public class StartEvent : ExportEvent
    {
        public StartEvent(object source)
            : base(source, ExportAction.START)
        {
        }
    }
}
