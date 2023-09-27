using System;

namespace PrimeChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            for (uint i = 2; i < 100; i++)
            {
                IsPrime(i);
                Console.Write($"{i}, ");
            }
        }

        public static bool IsPrime(uint n)
        {
            bool isPrime = true;

            for (int i = 2; i < Math.Ceiling(Math.Sqrt(n)) + 1; i++)
            {
                if (n % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            return isPrime;
        }
    }
}
