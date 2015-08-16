using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTS.Event
{
    public class VolumeEvent : Event
    {
        private float _value;

        public VolumeEvent(object source, float value)
            : base(source, value.ToString())
        {
            this._value = value;
        }

        public float Volume
        {
            get { return _value; }
        }

        public override string ToString()
        {
            return "Volume " + (this.Volume * 100).ToString() + "%";
        }
    }
}
