using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RTS.Observer
{
    public abstract class Observable<E> where E : RTS.Event.Event
    {
        private List<Observer<E>> _obs;

        public Observable()
        {
            this._obs = new List<Observer<E>>();
        }

        public void AddObserver(Observer<E> obs)
        {
            this._obs.Add(obs);
        }

        public void RemoveObserver(Observer<E> obs)
        {
            this._obs.Remove(obs);
        }

        public void NotifyObservers(E e) {
            Thread refreshThread = new Thread(new ParameterizedThreadStart(this.notifyThreadAction));
            refreshThread.Start(e);
        }

        private void notifyThreadAction(object obj)
        {
            E e = (E)obj;
            foreach (Observer<E> obs in this._obs)
            {
                obs.Refresh(e);
            }
        }
    }
}
