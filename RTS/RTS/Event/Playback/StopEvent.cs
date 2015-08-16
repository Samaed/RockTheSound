using RTS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTS.Event.Playback
{
    public class StopEvent : PlaybackEvent
    {
        public StopEvent(object source, Sound sound)
            : base(source, PlaybackEvent.PlaybackAction.STOP, sound)
        {
        }
    }
}
