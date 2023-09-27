using System;
using System.Collections.Generic;
using System.Text;

namespace Academy
{
    public class Person
    {
        private string name;

        public Person(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
        }
    }
}
