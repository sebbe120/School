using System;
using System.Collections.Generic;
using System.Text;

namespace Academy
{
    public interface INotifyMessageChanged
    {
        public delegate void EventHandler(object sender, EventArgs e);
    }
}
