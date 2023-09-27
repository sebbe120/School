using System;

namespace QuickHash
{
    class Program
    {
        static void Main(string[] args)
        {
            string Str = "skattekronen";
            Console.Write(GetHashValue(Str));
            Console.WriteLine(", " + GetAsciiHashValue(Str));
        }

        static int GetHashValue(string password)
        {
            string charStr = "abcdefghijklmnopqrstuvxyz ,.!?0123456789";
            password = password.ToLower();
            int value = 0;

            for (int i = 0; i < password.Length; i++)
            {
                value += charStr.IndexOf(password[i]);
            }


            return value % 100;
        }

        static int GetAsciiHashValue(string password)
        {
            int value = 0;

            for (int i = 0; i < password.Length; i++)
            {
                value += password[i];
            }

            return value % 100;
        }
    }
}
