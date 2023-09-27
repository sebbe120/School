using System;
using System.Collections.Generic;
using System.Text;

namespace TusindfrydWPF
{
    public class FlowerSort
    {
        private string name;
        private string picturePath;
        private int productionTime;
        private int halfLifeTime;
        private int size;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string PicturePath
        {
            get { return picturePath; }
            set { picturePath = value; }
        }

        public int ProductionTime
        {
            get { return productionTime; }
            set { productionTime = value; }
        }

        public int HalfLifeTime
        {
            get { return halfLifeTime; }
            set { halfLifeTime = value; }
        }

        public int Size
        {
            get { return size; }
            set { size = value; }
        }

        public override string ToString()
        {
            return this.Name + ": " + this.ProductionTime + ", " + this.HalfLifeTime + ", " + this.Size;
        }
    }
}
