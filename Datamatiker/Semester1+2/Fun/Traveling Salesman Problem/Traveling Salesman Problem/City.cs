using System;
using System.Collections.Generic;
using System.Text;

namespace Traveling_Salesman_Problem
{
    class City
    {
        private string name;
        private double x;
        private double y;

        public City(string name, double x, double y)
        {
            this.name = name;
            this.x = x;
            this.y = y;
        }
        public string GetName()
        {
            return name;
        }

        public double Getx()
        {
            return x;
        }

        public double Gety()
        {
            return y;
        }

        public override string ToString()
        {
            return $"{name,-5}{x,-10}{y,-10}";
        }
    }
}
