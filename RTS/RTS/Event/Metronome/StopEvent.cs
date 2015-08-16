using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTS.Event.Metronome
{
    public class StopEvent : MetronomeEvent
    {
        public StopEvent(object source)
            : base(source, MetronomeAction.STOP)
        {
        }
    }
}
