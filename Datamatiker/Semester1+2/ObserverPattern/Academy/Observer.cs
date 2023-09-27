using System;
using System.Collections.Generic;
using System.Text;

namespace Academy
{
    public interface IObserver
    {
        void Update(object sender, EventArgs e);
    }
}
