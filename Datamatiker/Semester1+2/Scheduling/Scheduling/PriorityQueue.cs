using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduling
{
    public class PriorityQueue
    {
        List<PCB> queue = new List<PCB>();

        public void Enqueue(PCB pcb)
        {
            // Insert if the queue is empty
            if (queue.Count == 0)
            {
                queue.Add(pcb);
            }

            // Check if an item with the same name already exists
            foreach (PCB item in queue)
            {
                if (item.ProcessName == pcb.ProcessName)
                {
                    return;
                }
            }

            // Logic for inserting at the right place
            int i;
            for (i = 0; i < queue.Count; i++)
            {
                if (queue[i].ProcessPriority > pcb.ProcessPriority)
                {
                    queue.Insert(i, pcb);
                    break;
                }
            }

            if (i == queue.Count)
            {
                queue.Add(pcb);
            }
        }

        public PCB Dequeue()
        {
            PCB pcb = queue[0];
            queue.Remove(queue[0]);

            return pcb;
        }

        public void Reprioritize(string processName, int newPriority)
        {
            foreach (PCB pcb in queue)
            {
                if (pcb.ProcessName == processName)
                {
                    pcb.ProcessPriority = newPriority;

                    queue.Remove(pcb);
                    PCB tempPCB = pcb;
                    Enqueue(tempPCB);
                    break;
                }
            }
        }

        public override string ToString()
        {
            string str = "{";

            foreach (PCB pcb in queue)
            {
                str += pcb.ToString() + ",";
            }

            if (str.Length > 1)
            {
                str = str.Remove(str.Length - 1);
            }

            str += "}";

            return str;
        }
    }
}
