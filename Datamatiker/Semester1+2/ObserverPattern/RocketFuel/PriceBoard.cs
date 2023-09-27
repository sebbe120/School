using System;
using System.Collections.Generic;
using System.Text;

namespace RocketFuel
{
    public class PriceBoard : IObserver
    {
        private GasStation subject;

        public PriceBoard(GasStation subject)
        {
            this.subject = subject;
        }

        public void Update()
        {
            Console.WriteLine($"  Lysskilt på tankstation i {subject.City} ({subject.Region}):");
            Console.WriteLine($"    HydroOxygen: {subject.HydroOxygen} kr/liter");
            Console.WriteLine($"    KeroOxygen: {subject.KeroOxygen} kr/liter");
            Console.WriteLine($"    AlcoOxygen: {subject.AlcoOxygen} kr/liter");
        }
    }
}
