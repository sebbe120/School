using System;
using System.Diagnostics;

namespace Encryption
{
    class Program
    {
        static void Main(string[] args)
        {
            Vault vault = new Vault(4321, "HEJ");

            Console.WriteLine(vault.EncryptedMessage + "\n");

            Brute b = new() { Vault = vault};

            Stopwatch sw = new Stopwatch();
            sw.Start();
            b.Dive("", 0);
            sw.Stop();

            Console.WriteLine($"Total time: {sw.Elapsed}");
        }
    }

    public class Brute
    {
        int maxlength = 3;
        string ValidChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^-'";
        public Vault Vault { get; set; }
        public void Dive(string prefix, int level)
        {
            level += 1;
            foreach (char c in ValidChars)
            {
                if (Vault.IsCorrect(prefix + c))
                {
                    Console.WriteLine(prefix + c);
                    return;
                }

                //Console.WriteLine(prefix + c);
                if (level < maxlength)
                {
                    Dive(prefix + c, level);
                }
            }
        }
    }
}
