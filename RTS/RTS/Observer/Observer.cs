using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTS.Observer
{
    public interface Observer<E> where E : RTS.Event.Event
    {
        void Refresh(E e);
    }
}
