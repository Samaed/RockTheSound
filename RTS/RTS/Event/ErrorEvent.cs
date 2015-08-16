using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTS.Event
{
    public class ErrorEvent : Event
    {
        public ErrorEvent(object source, string text)
            : base(source, text)
        {
        }

        public override string ToString()
        {
            return "Error " + this.Text;
        }
    }
}
