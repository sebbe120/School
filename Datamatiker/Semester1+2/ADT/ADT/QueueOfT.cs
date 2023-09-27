using System;
using System.Collections.Generic;
using System.Text;

namespace ADT
{
    public class QueueOfT<T>
    {
        private LinkedListOfT<T> queue = new LinkedListOfT<T>();
        private int count;
        private bool isEmpty;

        public int Count
        {
            get { return count; }
        }

        public bool IsEmpty
        {
            get { return isEmpty; }
        }
        
        public void Enqueue(T o)
        {
            queue.Append(o);
            isEmpty = false;
            count += 1;
        }

        public T Dequeue()
        {
            T item = queue.First;
            queue.DeleteAt(0);
            count -= 1;

            if (count == 0)
                isEmpty = true;

            return item;
        }
    }
}
