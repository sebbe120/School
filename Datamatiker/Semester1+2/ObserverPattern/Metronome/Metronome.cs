using System;
using System.Collections.Generic;
using System.Text;

namespace Metronome
{
    public class Metronome
    {
        public event EventHandler Tick;

        public Metronome()
        {
            OnTick();
        }

        public void OnTick()
        {
            for (int i = 0; i < 5; i++)
            {
                System.Threading.Thread.Sleep(3000);
                TickListener.Listen();
            }
        }

    }
}
