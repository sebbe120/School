using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverPattern
{
    public class ConcreteObserver : Observer
    {
        private ConcreteSubject subject;
        private int state;

        public int State
        {
            get { return state; }
            set { state = value; }
        }

        public ConcreteObserver(ConcreteSubject subject)
        {
            this.subject = subject;
        }

        public override void Update()
        {
            State = subject.State;
        }

    }
}
