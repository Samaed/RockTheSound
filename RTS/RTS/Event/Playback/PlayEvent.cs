using RTS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTS.Event.Playback
{
    public class PlayEvent : PlaybackEvent
    {
        public PlayEvent(object source, Sound sound)
            : base(source, PlaybackEvent.PlaybackAction.PLAY, sound)
        {
        }
    }
}
