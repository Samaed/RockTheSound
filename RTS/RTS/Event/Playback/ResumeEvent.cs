using RTS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTS.Event.Playback
{
    public class ResumeEvent : PlaybackEvent
    {
        public ResumeEvent(object source, Sound sound)
            : base(source, PlaybackEvent.PlaybackAction.RESUME, sound)
        {
        }
    }
}
