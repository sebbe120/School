using System;
using System.Collections.Generic;
using System.Text;

namespace Academy
{
    public interface ISubject
    {
        public void Attach(IObserver o);

        public void Detach(IObserver o);

        public void Notify();
    }
}
