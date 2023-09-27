using System;

namespace ClassPresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            //Person person1 = new Person("Lars");
            //person1.Name = "Kasper";
            //Console.WriteLine(person1.ToString());

            //Guest guest1 = new Guest("Karl");
            //Console.WriteLine(guest1.Name);



            Console.WriteLine(Times2(2));
            Console.WriteLine(Times2(2.0));
        }

        static int Times2(int n)
        {
            return n * 2;
        }

        static double Times2(double n)
        {
            return n * 2;
        }
    }
}
