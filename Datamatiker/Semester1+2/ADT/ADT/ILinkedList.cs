using System;

namespace ADT
{
    public interface ILinkedList
    {
        public int Count
        {
            get;
        }

        public object First
        {
            get;
        }

        public object Last
        {
            get;
        }

        public void InsertAt(int index, object o);

        public void Prepend(object o);

        public void Append(object o);

        public void DeleteAt(int index);

        public object ItemAt(int index);
    }
}
