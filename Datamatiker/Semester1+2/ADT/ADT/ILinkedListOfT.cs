using System;
using System.Collections.Generic;
using System.Text;

namespace ADT
{
    public interface ILinkedListOfT<T>
    {
        public int Count
        {
            get;
        }

        public T First
        {
            get;
        }

        public T Last
        {
            get;
        }

        public void InsertAt(int index, T o);

        public void Prepend(T o);

        public void Append(T o);

        public void DeleteAt(int index);

        public T ItemAt(int index);
    }
}
