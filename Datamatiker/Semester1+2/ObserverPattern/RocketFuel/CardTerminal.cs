using System;
using System.Collections.Generic;
using System.Text;

namespace RocketFuel
{
    public class CardTerminal : IObserver
    {
        private GasPump subject;

        public GasPump Subject
        {
            get { return subject; }
            set { subject = value; }
        }


        public void Update()
        {
            Console.WriteLine("  Betalingsautomat:");
            if (subject is null)
            {
                Console.WriteLine("    Alt betalt.");
            }

            else
            {
                Console.WriteLine( "    Ubetalte standere:");
                Console.WriteLine($"      Stander {subject.GetNumber()}: {subject.GetAmountOfFuel()} liter {subject.Fuel} til {subject.GetAmountOfFuel() * subject.GetFuelPrice()} kr.");
                Console.WriteLine( "    Vælg stander og betal.");

            }
            
        }
    }
}
