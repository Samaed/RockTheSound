using RTS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTS.Event.Playback
{
    public class LoopEvent : PlaybackEvent
    {
        public LoopEvent(object source, Sound sound)
            : base(source, PlaybackEvent.PlaybackAction.LOOP, sound)
        {
        }
    }
}
