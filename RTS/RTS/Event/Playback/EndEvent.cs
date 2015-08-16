using RTS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTS.Event.Playback
{
    public class EndEvent : PlaybackEvent
    {
        public EndEvent(object source, Sound s)
            : base(source, PlaybackAction.END, s)
        {
        }
    }
}
