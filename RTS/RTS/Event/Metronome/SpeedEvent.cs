using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTS.Event.Metronome
{
    class SpeedEvent : MetronomeEvent
    {
        private float _speed;

        public SpeedEvent(object source, float speed)
            : base(source, MetronomeAction.SPEED)
        {
            this._speed = speed;
        }

        public float Speed
        {
            get { return _speed; }
        }

        public override string ToString()
        {
            return "Metronome " + Action.ToString() + " " + this.Speed.ToString();
        }
    }
}
