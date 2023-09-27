using System;
using System.Collections.Generic;
using System.Text;

namespace RocketFuel
{
    public class GasPump : ISubject, IObserver
    {
        private GasStation subject;
        private int number;
        private FuelType fuel;
        private double amountOfFuel;
        private bool readyForUse = true;

        private List<IObserver> observers = new List<IObserver>();

        public GasPump(GasStation subject, int number)
        {
            this.subject = subject;
            this.number = number;
        }

        public FuelType Fuel
        {
            get { return fuel; }
            set { fuel = value; }
        }

        public double GetFuelPrice()
        {
            double price;
            if (Fuel == FuelType.HydroOxygen)
                price = subject.HydroOxygen;

            else if (Fuel == FuelType.KeroOxygen)
                price = subject.KeroOxygen;

            else
                price = subject.AlcoOxygen;

            return price;
        }

        public int GetNumber()
        {
            return number;
        }

        public double GetAmountOfFuel()
        {
            return amountOfFuel;
        }

        public void SelectFuel(FuelType fuel)
        {
            this.fuel = fuel;
        }

        public void Pump(double liters)
        {
            this.amountOfFuel = liters;
            readyForUse = false;
            Update();
            Notify();
        }
        
        public void PayFilling()
        {
            amountOfFuel = 0;
            readyForUse = true;
            Update();
            Notify();
        }

        public void Update()
        {
            Console.WriteLine($"  Stander {this.number} på tankstation i {subject.City} ({subject.Region}):");
            Console.WriteLine($"    Valgt brændstof:   {Fuel}");
            Console.WriteLine($"    Liter:             {amountOfFuel} liter");
            Console.WriteLine($"    Pris:              {amountOfFuel * this.GetFuelPrice()} kr");

            if (readyForUse)
                Console.WriteLine($"    Status:            Klar til brug");
            else
                Console.WriteLine($"    Status:            Betal påfyldning");

            Console.WriteLine($"    HydroOxygen:       {subject.HydroOxygen} kr/liter");
            Console.WriteLine($"    KeroOxygen:        {subject.KeroOxygen} kr/liter");
            Console.WriteLine($"    AlcoOxygen:        {subject.AlcoOxygen} kr/liter");
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
                if (!readyForUse)
                    ((CardTerminal)observer).Subject = this;
                else
                    ((CardTerminal)observer).Subject = null;

                observer.Update();
            }
        }
    }

    public enum FuelType
    {
        HydroOxygen,
        KeroOxygen,
        AlcoOxygen
    }
}
