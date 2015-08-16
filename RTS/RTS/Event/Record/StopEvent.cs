using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTS.Event.Record
{
    public class StopEvent : SequenceEvent
    {
        public StopEvent(object source)
            : base(source, RecordAction.STOP)
        {
        }
    }
}
