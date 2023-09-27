using System;
using System.Collections.Generic;
using System.Text;

namespace ClassPresentation
{
    public abstract class Person
    {
        private string name;

        public Person(string name)
        {
            Name = name;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public override string ToString()
        {
            return $"Name: {Name}";
        }
    }

    public class Guest : Person
    {
        public Guest(string name) : base(name) { }

        private string Company;
    }

    public class Employee : Person
    {
        public Employee(string name) : base(name) { }

        private string phoneNumber;
    }
}
