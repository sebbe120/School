using System;
using System.Collections.Generic;
using System.Text;

namespace OrangeTreeSim
{
    public class OrangeTree
    {
        private int age;
        private int height;
        private bool treeAlive;
        private int numOranges;
        private int orangesEaten;

        public void SetAge(int n)
        {
            this.age = n;
        }

        public int GetAge()
        {
            return this.age;
        }

        public void SetHeight(int n)
        {
            this.height = n;
        }

        public int GetHeight()
        {
            return this.height;
        }

        public void SetTreeAlive(bool b)
        {
            this.treeAlive = b;
        }

        public bool GetTreeAlive()
        {
            return this.treeAlive;
        }

        public int GetNumOranges()
        {
            return this.numOranges;
        }

        public int GetOrangesEaten()
        {
            return this.orangesEaten;
        }


        public void OneYearPasses()
        {

            this.age = this.age + 1;

            if (this.age < 80)
                this.height = this.height + 2;

            if (this.age >= 80)
            {
                SetTreeAlive(false);
                this.numOranges = 0;
                return;
            }

            if (this.age > 1)
                this.numOranges = (this.age - 1) * 5;

            this.orangesEaten = 0;
        }

        public void EatOrange(int count)
        {
            if (count > GetNumOranges())
            {
                this.orangesEaten = GetNumOranges();
            }
            else
            {
                this.orangesEaten = this.orangesEaten + count;
            }
        }

        /*
        public int Age
        {
            get { return age; }   // get method
            set { age = value; }  // set method
        }

        public int Height
        {
            get { return height; }   // get method
            set { height = value; }  // set method
        }

        public bool TreeAlive
        {
            set { treeAlive = value; }  // set method
            get { return treeAlive; }   // get method
        }

        public int NumOranges
        {
            get { return numOranges; }   // get method
        }

        public int OrangesEaten
        {
            get { return orangesEaten; }   // get method
        }

        */
    }
}
