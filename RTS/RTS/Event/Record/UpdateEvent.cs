using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTS.Event.Record
{
    public class UpdateEvent : SequenceEvent
    {
        public UpdateEvent(object source)
            : base(source, RecordAction.UPDATE)
        {
        }
    }
}
