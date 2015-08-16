using RTS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTS.Controller.Record
{
    public struct RecordThreadParameters
    {
        public List<DatedSounds> Sounds;
        public TimeSpan Duration;
    }
}
