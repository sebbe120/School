using System;
using System.Collections.Generic;
using System.Text;

namespace ADT
{
    public class LinkedListOfT<T> : ILinkedListOfT<T>
    {
        private Node head;
        private int count;
        private T first;
        private T last;

        public int Count
        {
            get { return count; }
        }

        public T First
        {
            get { return first; }
        }

        public T Last
        {
            get { return last; }
        }

        private class Node
        {
            public T Data { get; set; }

            public Node Next { get; set; }

            public override string ToString()
            {
                return Data.ToString();
            }
        }

        public void InsertAt(int index, T o)
        {
            if (index == 0 || head == null)
            {
                Prepend(o);
                return;
            }

            else if (index >= Count)
            {
                Append(o);
                return;
            }

            else
            {
                Node newNode = new Node
                {
                    Data = o
                };

                Node currentNode = head;
                for (int i = 0; i < index - 1; i++)
                {
                    currentNode = currentNode.Next;
                }

                newNode.Next = currentNode.Next;
                currentNode.Next = newNode;

                count += 1;
            }
        }

        public void Prepend(T o)
        {
            Node newNode = new Node
            {
                Data = o,
                Next = head
            };

            head = newNode;

            first = newNode.Data;

            if (head == null)
                last = newNode.Data;

            else if (Count == 1)
                last = head.Next.Data;

            count += 1;
        }

        public void Append(T o)
        {
            if (head == null)
            {
                Prepend(o);
                return;
            }

            Node newNode = new Node
            {
                Data = o
            };

            last = newNode.Data;

            Node currentNode = head;
            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }
            currentNode.Next = newNode;

            count += 1;
        }

        public void DeleteAt(int index)
        {
            if (head == null || index > Count)
            {
                return;
            }

            if (index == 0)
            {
                if (count == 1)
                {
                    head = null;
                    count -= 1;
                    return;
                }

                head = head.Next;
                first = head.Data;
                count -= 1;
                return;
            }

            Node currentNode = head;
            for (int i = 0; i < index - 1; i++)
            {
                currentNode = currentNode.Next;
            }

            if (index == Count)
                currentNode.Next = null;

            else
                currentNode.Next = currentNode.Next.Next;

            count -= 1;
        }

        public T ItemAt(int index)
        {
            if (index == 0)
                return First;

            else if (index == Count)
                return Last;

            else
            {
                Node currentNode = head;
                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.Next;
                }

                return currentNode.Data;
            }
        }

        public override string ToString()
        {
            string str = "";

            Node currentNode = head;
            str += currentNode.ToString() + "\n";
            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
                str += currentNode.ToString() + "\n";
            }

            return str;
        }
    }
}
