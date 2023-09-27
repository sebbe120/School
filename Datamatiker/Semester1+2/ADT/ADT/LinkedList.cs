using System;

namespace ADT
{
    public class LinkedList : ILinkedList
    {
        private Node head;
        private int count;
        private object first;
        private object last;

        public int Count
        {
            get { return count; }
        }

        public object First
        {
            get { return first; }
        }

        public object Last
        {
            get { return last; }
        }

        private class Node
        {
            public object Data { get; set; }

            public Node Next { get; set; }

            public override string ToString()
            {
                return Data.ToString();
            }
        }

        public void InsertAt(int index, object o)
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

        public void Prepend(object o)
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

            count += 1;
        }

        public void Append(object o)
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
            if (head == null)
            {
                return;
            }

            if (index >= Count)
            {
                return;
            }

            if (index == 0)
            {
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

            currentNode.Next = currentNode.Next.Next;
            count -= 1;
        }

        public object ItemAt(int index)
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
            str += currentNode.ToString();
            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
                str += "\n" + currentNode.ToString();
            }

            return str;
        }
    }
}
