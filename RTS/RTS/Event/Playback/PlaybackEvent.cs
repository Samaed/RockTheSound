using RTS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTS.Event.Playback
{
    public abstract class PlaybackEvent : Event
    {
        public enum PlaybackAction
        {
            PLAY,
            PAUSE,
            RESUME,
            STOP,
            END,
            LOOP,
            UNLOOP
        }

        private PlaybackAction _action;
        private Sound _sound;

        public PlaybackEvent(object source, PlaybackAction action, Sound sound)
            : base(source, PlaybackEvent.stringify(action, sound))
        {
            this._action = action;
            this._sound = sound;
        }

        public PlaybackAction Action
        {
            get { return _action; }
        }

        public Sound Sound
        {
            get { return _sound; }
        }

        private static string stringify(PlaybackAction action, Sound sound)
        {
            return action.ToString() + " " + sound.ToString();
        }
    }
}
