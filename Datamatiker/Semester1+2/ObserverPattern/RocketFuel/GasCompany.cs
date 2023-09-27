using System;
using System.Collections.Generic;
using System.Text;

namespace RocketFuel
{
    public class GasCompany : ISubject
    {
        private double basePrice;

        private List<IObserver> observers = new List<IObserver>();

        public double BasePrice
        {
            get { return basePrice; }
            set
            {
                basePrice = value;
                Notify();
            }
        }

        public void Attach(IObserver o)
        {
            observers.Add(o);
        }

        public void Detach(IObserver o)
        {
            observers.Remove(o);
        }

        public void Notify()
        {
            foreach (IObserver observer in observers)
            {
                observer.Update();
            }
        }
    }
}
