using System;
using System.Collections.Generic;
using System.Text;

namespace ADT
{
    public class StackOfT<T>
    {
        private LinkedList<T> stack = new LinkedList<T>();
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

        public void Push(T o)
        {
            stack.AddLast(o);
            isEmpty = false;
            count += 1;
        }

        public T Pop()
        {
            T item = stack.Last.Value;
            stack.RemoveLast();

            count -= 1;

            if (Count == 0)
                isEmpty = true;

            return item;
        }

        public T Peek()
        {
            return stack.Last.Value;
        }
    }
}
