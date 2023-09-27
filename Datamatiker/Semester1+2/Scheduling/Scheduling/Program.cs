using System;

namespace Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue pq = new PriorityQueue();
            // Arrange
            PCB pcbA = new PCB { ProcessName = "A", ProcessPriority = 2 };
            PCB pcbB = new PCB { ProcessName = "B", ProcessPriority = 3 };
            PCB pcbC = new PCB { ProcessName = "C", ProcessPriority = 3 };
            PCB pcbD = new PCB { ProcessName = "D", ProcessPriority = 1 };
            PCB pcbE = new PCB { ProcessName = "E", ProcessPriority = 3 };

            // Act
            pq.Enqueue(pcbA);
            pq.Enqueue(pcbB);
            pq.Enqueue(pcbC);
            pq.Enqueue(pcbD);
            pq.Enqueue(pcbE);

            Console.WriteLine(pq);

            pq.Reprioritize("C",1);

            Console.WriteLine(pq);
        }
    }
}
