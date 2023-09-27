using System;
using System.Collections.Generic;

namespace PrimeFactors
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> primes = GeneratePrimes(37000);
            Console.WriteLine(primes[^1]);

            int n = 437231;

            int i = 0;

            bool isPrime = true;
            while (primes[i] < Math.Ceiling((double) n / 2))
            {
                if (n % primes[i] == 0)
                {
                    isPrime = false;
                    Console.Write(primes[i] + ", ");
                }

                i += 1;
            }

            if (isPrime)
            {
                Console.WriteLine(n);
            }

        }

        // Generate a list of n=limit primes
        static List<int> GeneratePrimes(int limit)
        {
            List<int> primes = new() { 2 };

            int number = 3;

            while (primes.Count < limit)
            {
                bool isPrime = true;
                for (int i = 0; i < primes.Count; i++)
                {
                    if (number % primes[i] == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    primes.Add(number);
                }

                number += 2;
            }

            return primes;
        }
    }
}
