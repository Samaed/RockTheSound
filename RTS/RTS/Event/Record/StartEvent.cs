using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTS.Event.Record
{
    public class StartEvent : SequenceEvent
    {
        public StartEvent(object source)
            : base(source, RecordAction.START)
        {
        }
    }
}
