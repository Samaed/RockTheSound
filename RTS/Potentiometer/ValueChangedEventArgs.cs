using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Potentiometer
{
    public class ValueChangedEventArgs : EventArgs
    {
        private float _value;

        public ValueChangedEventArgs(float value)
        {
            this._value = value;
        }

        public float Value
        {
            get { return _value; }
        }
    }
}
