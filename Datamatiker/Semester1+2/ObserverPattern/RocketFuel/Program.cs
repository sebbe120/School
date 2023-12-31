﻿using System;

namespace RocketFuel
{
    class Program
    {
        static void Main(string[] args)
        {
            var rocketFuel = new GasCompany { BasePrice = 90.0 };

            var gs1 = new GasStation(rocketFuel, RegionEnum.Sjælland, "København");
            var gs2 = new GasStation(rocketFuel, RegionEnum.Fyn, "Odense");
            var gs3 = new GasStation(rocketFuel, RegionEnum.Jylland, "Århus");

            rocketFuel.Attach(gs1);
            rocketFuel.Attach(gs2);
            rocketFuel.Attach(gs3);

            var pb1 = new PriceBoard(gs1);
            var pb2 = new PriceBoard(gs2);
            var pb3 = new PriceBoard(gs3);

            Console.WriteLine("Tilknyt lysskilt til tankstation:");
            gs1.Attach(pb1);
            Console.WriteLine();
            Console.WriteLine("Tilknyt lysskilt til tankstation:");
            gs2.Attach(pb2);
            Console.WriteLine();
            Console.WriteLine("Tilknyt lysskilt til tankstation:");
            gs3.Attach(pb3);
            Console.WriteLine();

            Console.WriteLine($"Opdatér selskabets basispris til {100} kr:");
            rocketFuel.BasePrice = 100;
            Console.WriteLine();
            Console.WriteLine($"Opdatér selskabets basispris til {105} kr:");
            rocketFuel.BasePrice = 105;
            Console.WriteLine();
            Console.WriteLine($"Opdatér selskabets basispris til {95} kr:");
            rocketFuel.BasePrice = 95;
            Console.WriteLine();

            Console.WriteLine($"Sæt rabat på tankstation i {gs2.City}:");
            gs2.Discount = true;
            Console.WriteLine();

            Console.WriteLine($"Opdatér selskabets basispris til {100} kr:");
            rocketFuel.BasePrice = 100;
            Console.WriteLine();

            Console.WriteLine($"Fjern rabat på tankstation i {gs2.City}:");
            gs2.Discount = false;
            Console.WriteLine();

            var gp1 = new GasPump(gs1, 1);
            var gp2 = new GasPump(gs1, 2);
            var gp3 = new GasPump(gs1, 3);

            Console.WriteLine("Tilknyt stander 1 til tankstation:");
            gs1.Attach(gp1);
            Console.WriteLine();
            Console.WriteLine("Tilknyt stander 2 til tankstation:");
            gs1.Attach(gp2);
            Console.WriteLine();
            Console.WriteLine("Tilknyt stander 3 til tankstation:");
            gs1.Attach(gp3);
            Console.WriteLine();

            var ct = new CardTerminal();
            Console.WriteLine("Tilknyt stander 1 til betalingsautomat:");
            gp1.Attach(ct);
            Console.WriteLine();
            Console.WriteLine("Tilknyt stander 2 til betalingsautomat:");
            gp2.Attach(ct);
            Console.WriteLine();
            Console.WriteLine("Tilknyt stander 3 til betalingsautomat:");
            gp3.Attach(ct);
            Console.WriteLine();

            Console.WriteLine($"Vælg AlcoOxygen på stander 1 og tank 45 liter:");
            gp1.SelectFuel(FuelType.AlcoOxygen);
            gp1.Pump(45.0);
            Console.WriteLine();

            Console.WriteLine($"Opdatér selskabets basispris til {110} kr:");
            rocketFuel.BasePrice = 110;
            Console.WriteLine();

            Console.WriteLine($"Vælg HydroOxygen på stander 3 og tank 32 liter:");
            gp3.SelectFuel(FuelType.HydroOxygen);
            gp3.Pump(32.0);
            Console.WriteLine();

            Console.WriteLine($"Betal regning på stander 1:");
            gp1.PayFilling();
            Console.WriteLine();

            Console.WriteLine($"Betal regning på stander 3:");
            gp3.PayFilling();
            Console.WriteLine();

        }
    }
}
