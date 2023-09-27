using System;

namespace RSA_Encryption
{
    class Program
    {        
        private int _phiN = default;
        private int _e = default;
        private int _d = default;

        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
        }

        public void Run()
        {
            int p1 = 43;
            int p2 = 59;
            int N = p1 * p2;
            _e = 11;
            _phiN = phi(N);

            _d = FindD(_phiN, _e);
            if (_d >= 0)
            {
                Console.Write($"Found a valid d-value: {_d} so that: ");
                Console.WriteLine($"({_d} * {_e}) modulus {_phiN} =  1");
            }
            else
            {
                Console.Write("Sorry - no valid value found within limit!");
            }
        }

        private int FindD(int phiN, int e)
        {
            int k = 0;
            const int MAX = 99999;
            bool goOn = true;
            int result = default;
            while (goOn)
            {
                double guess = (k * phiN + 1.0) / e;

                if (guess == Math.Truncate(guess)) // integer value?
                {
                    goOn = false;
                    result = (int)guess;
                }
                else
                { // not integer, keep searching
                    k++;
                    if (k == MAX) // but not for ever...
                    {
                        goOn = false;
                        result = -1;
                    }
                }
            }
            return result;
        }

        // A simple method to evaluate
        // Euler Totient Function
        static int phi(int n)
        {
            int result = 1;
            for (int i = 2; i < n; i++)
                if (gcd(i, n) == 1)
                    result++;
            return result;
        }

        // Function to return GCD of a and b
        static int gcd(int a, int b)
        {
            if (a == 0)
                return b;
            return gcd(b % a, a);
        }
    }
}

