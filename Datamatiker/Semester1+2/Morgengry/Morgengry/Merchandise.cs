using System;
using System.Collections.Generic;
using System.Text;
using static Morgengry.Controller;

namespace Morgengry
{
    public abstract class Merchandise : IValueable
    {

        public string ItemId { get; set; }

        public abstract double GetValue();

        public abstract override string ToString();
    }
}
