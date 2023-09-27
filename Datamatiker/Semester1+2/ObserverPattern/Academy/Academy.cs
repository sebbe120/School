using System;
using System.Collections.Generic;
using System.Text;

namespace Academy
{
    public class Academy : Organization, INotifyMessageChanged
    {
        private string message;
        public event EventHandler MessageChanged;

        public Academy(string name, string address) : base(name, address)
        {
        }

        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                OnMessageChanged();
            }
        }

        public void OnMessageChanged()
        {
            MessageChanged(this, null);
        }
    }
}
