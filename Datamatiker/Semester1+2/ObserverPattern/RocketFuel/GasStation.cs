using System;
using System.Collections.Generic;
using System.Text;

namespace RocketFuel
{
    public class GasStation : ISubject, IObserver
    {
        private string city;
        private RegionEnum region;
        private GasCompany subject;

        private List<IObserver> observers = new List<IObserver>();

        private double alcoOxygen = 0;
        private double keroOxygen = 0;
        private double hydroOxygen = 0;
        private bool discount;

        public GasStation(GasCompany subject, RegionEnum region, string city, bool hasDiscount = false)
        {
            this.subject = subject;
            this.city = city;
            this.region = region;

            Discount = hasDiscount;
            Update();
        }

        public bool Discount
        {
            get { return discount; }
            set
            {
                discount = value;
                Update();
            }
        }

        public string City
        {
            get { return city; }
        }

        public RegionEnum Region
        {
            get { return region; }
        }

        public double AlcoOxygen
        {
            get { return alcoOxygen; }
        }

        public double KeroOxygen
        {
            get { return keroOxygen; }
        }

        public double HydroOxygen
        {
            get { return hydroOxygen; }
        }

        public void Update()
        {
            double scale;

            if (region == RegionEnum.Jylland)
                scale = 1;

            else if (region == RegionEnum.Fyn)
                scale = 0.95;

            else
                scale = 1.05;

            if (Discount)
                keroOxygen = subject.BasePrice * scale * 0.90;

            else
                keroOxygen = subject.BasePrice * scale;
            
            alcoOxygen = keroOxygen * 0.90;
            hydroOxygen = keroOxygen * 1.10;

            Notify();
        }

        public void Attach(IObserver o)
        {
            observers.Add(o);
            o.Update();
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
