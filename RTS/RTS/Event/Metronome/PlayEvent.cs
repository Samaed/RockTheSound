using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTS.Event.Metronome
{
    public class PlayEvent : MetronomeEvent
    {
        public PlayEvent(object source)
            : base(source, MetronomeAction.PLAY)
        {
        }
    }
}
