using System;
using System.Collections.Generic;
using System.Text;

namespace WPFAndMVVM2.ViewModels
{
    public class PersonEventArgs : EventArgs
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Phone { get; set; }
    }
}
