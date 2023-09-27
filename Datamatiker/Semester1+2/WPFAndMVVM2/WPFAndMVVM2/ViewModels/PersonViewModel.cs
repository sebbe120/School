using System;
using System.Collections.Generic;
using System.Text;
using WPFAndMVVM2.Models;

namespace WPFAndMVVM2.ViewModels
{
    public class PersonViewModel
    {
        private Person person;
        private string firstName;
        private string lastName;
        private int age;
        private string phone;

        public PersonViewModel(Person person)
        {
            this.person = person;
            FirstName = person.FirstName;
            LastName = person.LastName;
            Age = person.Age;
            Phone = person.Phone;
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
    }
}
