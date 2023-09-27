using System;
using System.Collections.Generic;
using System.Text;

namespace BonusApp
{
    public class Product
    {
        private string name;
        private double price;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}
