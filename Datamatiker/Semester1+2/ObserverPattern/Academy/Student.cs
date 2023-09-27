using System;
using System.Collections.Generic;
using System.Text;

namespace Academy
{
    public class Student : Person, IObserver
    {
        private string message;

        public Student(string name) : base(name)
        {
        }

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public void Update(object sender, EventArgs e)
        {
            Console.WriteLine($"{Name} modtog nyheden '{((Academy)sender).Message}' fra akademiet {((Academy)sender).Name}");
        }
    }
}
