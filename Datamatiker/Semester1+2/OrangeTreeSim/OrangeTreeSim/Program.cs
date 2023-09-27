using System;

namespace OrangeTreeSim
{
    class Program
    {
        static void Main(string[] args)
        {
            OrangeTree orangeTree = new OrangeTree();

            for (int i = 1; i <= 80; i++)
            {
                orangeTree.OneYearPasses();
            }
            orangeTree.OneYearPasses();
            
        }
    }
}
