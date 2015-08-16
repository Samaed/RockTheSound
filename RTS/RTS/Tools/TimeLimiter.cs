using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTS.Tools
{
    public class TimeLimiter<T>
    {
        private DateTime _lasttime = DateTime.MinValue;
        private TimeSpan _timespan;

        public TimeLimiter(TimeSpan waiting)
        {
            this._timespan = waiting;
        }

        public TimeLimiter(long milliseconds)
        {
            this._timespan = new TimeSpan(milliseconds * 10000);
        }

        public DateTime LastTime
        {
            get { return _lasttime; }
            set { _lasttime = value; }
        }

        public TimeSpan WaitingTime
        {
            get { return _timespan; }
            set { _timespan = value; }
        }

        public TimeSpan RestingTime
        {
            get { return WaitingTime - (DateTime.Now - _lasttime); }
        }

        public T push(T value)
        {
            if (RestingTime <= TimeSpan.Zero)
            {
                this._lasttime = DateTime.Now;
                return value;
            }
            else
            {
                return default(T);
            }
        }
    }
}
