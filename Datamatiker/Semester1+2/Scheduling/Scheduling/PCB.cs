using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduling
{
    public class PCB
    {
        public string ProcessName { get; set; }

        public int ProcessPriority { get; set; }

        public override string ToString()
        {
            return $"{ProcessName}({ProcessPriority})";
        }
    }
}
