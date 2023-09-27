using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048_WPF
{
    public class Piece
    {
        private int value;

        public int Value
        {
            get { return value; }
            private set { this.value = value; }
        }


        /// <summary>
        /// Creates a piece with a given value (power of 2)
        /// </summary>
        /// <param name="value"></param>
        public Piece(int value = 0)
        {
            if (value == 0)
            {
                Value = GetRandomStartValue();
            }

            else
            {
                Value = value;
            }
        }

        /// <summary>
        /// 80% - 2,
        /// 20% - 4
        /// </summary>
        /// <returns></returns>
        private int GetRandomStartValue()
        {
            Random r = new Random();
            int val;

            if (r.NextDouble() < 0.80)
            {
                val = 2;
            }

            else
            {
                val = 4;
            }

            return val;
        }

        /// <summary>
        /// Is called when two pieces of the same value collide
        /// </summary>
        public void Upgrade()
        {
            Value *= 2;
        }
    }
}
