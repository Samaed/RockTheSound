using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTS.Event
{
    public class Event
    {
        private static long _nextUID = 0;

        private long _UID;
        private object _source;
        private string _text;
        private DateTime _date;

        public long UID
        {
            get { return _UID; }
        }

        public object Source
        {
            get { return _source; }
        }

        public string Text
        {
            get { return _text; }
        }

        public DateTime Date
        {
            get { return _date; }
        }

        public Event() : this(null, string.Empty)
        {
        }

        public Event(object source) : this(source, source.ToString())
        {
        }

        public Event(object source, string text)
        {
            this._source = source;
            this._text = text;
            this._date = DateTime.Now;
            this._UID = Event._nextUID++;
        }

        public override string ToString()
        {
            return this.Text;
        }
    }
}
