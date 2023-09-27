using System;

namespace Morgengry
{
    class Program
    {
        static void Main(string[] args)
        {
            Book b1 = new Book("1", "HCA", 199.99);
            Book b2 = new Book("3", "Spirits in the Night", 123.55);

            Controller.ValuableRepository ValuableRepo = new Controller.ValuableRepository();
            ValuableRepo.AddValuable(b1);
            ValuableRepo.AddValuable(b2);
            Console.WriteLine(ValuableRepo.GetTotalValue());


            Amulet a3 = new Amulet("13", Level.low, "Capricorn");
            Amulet a2 = new Amulet("12", Level.high);
            ValuableRepo.AddValuable(a2);
            ValuableRepo.AddValuable(a3);
            Console.WriteLine(ValuableRepo.GetTotalValue());

            Course c1 = new Course("Eufori med røg");
            Course c2 = new Course("Nuru Massage using Chia Oil", 1);
            Course c3 = new Course("Mit møde med mig", 157);
            ValuableRepo.AddValuable(c1);
            ValuableRepo.AddValuable(c2);
            ValuableRepo.AddValuable(c3);
            Console.WriteLine(ValuableRepo.GetTotalValue());

            Console.WriteLine(ValuableRepo.Count());
            Console.WriteLine(ValuableRepo.GetValuable("13"));

            ValuableRepo.Save();
            ValuableRepo.Load();
            ValuableRepo.Save();

        }
    }
}
