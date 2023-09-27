using System;
using System.Collections.Generic;
using System.Text;

namespace Academy
{
    public class Organization
    {
        private string name;
        private string address;

        public Organization(string name, string address)
        {
            this.name = name;
            this.address = address;
        }

        public string Name
        {
            get { return name; }
        }
    }
}
