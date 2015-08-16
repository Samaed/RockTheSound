using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTS.Event.Export
{
    public class StopEvent : ExportEvent
    {
        public StopEvent(object source)
            : base(source, ExportAction.STOP)
        {
        }
    }
}
