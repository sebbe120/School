using System;
using System.Collections.Generic;
using System.Text;

namespace ADT
{
    public class DoublyLinkedListOfT<T>
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

            public Node Prev { get; set; }

            public override string ToString()
            {
                return Data.ToString();
            }
        }

        // Insert element at the first location
        public void InsertFirst(T o)
        {
            Node newNode = new Node{ Data = o };
            
            newNode.Next = head;
            newNode.Prev = null;

            if (head != null)
                head.Prev = newNode;

            head = newNode;
            first = newNode.Data;

            if (count == 0)
                last = head.Data;

            count += 1;
        }

        // Insert element at the last location
        public void InsertLast(T o)
        {
            if (head == null)
            {
                InsertFirst(o);
                return;
            }

            Node newNode = new Node { Data = o };

            Node currentNode = head;
            while(currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }

            currentNode.Next = newNode;
            newNode.Prev = currentNode;
            newNode.Next = null;
            last = newNode.Data;

            count += 1;
        }

        // Insert element at the node before the index
        public void InsertBefore(T o, int index)
        {
            throw new NotImplementedException();
        }

        // Insert element at the node after the index
        public void InsertAfter(T o, int index)
        {
            throw new NotImplementedException();
        }

        public T ItemAt(int index)
        {
            if (head == null || index > count || index < 0)
                return default;

            else if (index == 0)
                return first;

            else if (index == count)
                return Last;

            Node currentNode = head;
            for (int i = 0; i < index; i++)
            {
                currentNode = currentNode.Next;
            }

            return currentNode.Data;
        }

        public void DeleteFirst()
        {
            if (head == null)
                return;

            if (Count == 1)
            {
                head = null;
                return;
            }

            head = head.Next;
            first = head.Data;
            head.Next.Prev = head;
            count -= 1;
        }

        public void DeleteLast()
        {
            if (head == null)
                return;

            Node currentNode = head;
            for (int i = 0; i < Count - 1; i++)
            {
                currentNode = currentNode.Next;
            }

            currentNode.Next = null;
            last = currentNode.Data;
            count -= 1;
        }

        public void DeleteAt(int index)
        {
            if (head == null)
                return;

            if (index == 0)
            {
                DeleteFirst();
                return;
            }

            if (index == Count)
            {
                DeleteLast();
                return;
            }

            Node currentNode = head;
            for (int i = 0; i < index - 1; i++)
            {
                currentNode = currentNode.Next;
            }

            currentNode.Next = currentNode.Next.Next;

            count -= 1;

            if (currentNode.Next == null)
            {
                return;
            }

            currentNode.Next.Prev = currentNode;
        }

        public string RoundtripString()
        {
            Node currentNode = head;
            string trip = currentNode + "";

            // First to Last
            for (int i = 0; i < Count - 1; i++)
            {
                currentNode = currentNode.Next;
                trip += "\n" + currentNode;
            }

            // Last to first
            for (int i = 0; i < Count - 1; i++)
            {
                currentNode = currentNode.Prev;
                trip += "\n" +  currentNode;
            }

            return trip;
        }

        public void Reverse()
        {
            Node tempNode = null;
            Node currentNode = head;

            while (currentNode != null)
            {
                tempNode = currentNode.Prev;
                currentNode.Prev = currentNode.Next;
                currentNode.Next = tempNode;
                currentNode = currentNode.Prev;
            }

            if (tempNode != null)
            {
                head = tempNode.Prev;
            }
        }

        public void Swap(int index)
        {
            if (index >= Count - 1)
            {
                return;
            }

            // Get the i'th node
            Node currentNode = head;
            for (int i = 0; i < index; i++)
            {
                currentNode = currentNode.Next;
            }

            // Swap the nodes
            Node tempNode;
            if (index == 0)
            {
                // If the node is the first
                tempNode = currentNode.Next;
                currentNode.Next = currentNode.Next.Next;
                currentNode.Prev = tempNode;
                tempNode.Next = currentNode;
                tempNode.Prev = null;
                head = tempNode;
                first = tempNode.Data;
            }

            else if (index == count - 2)
            {
                // If the node is the second to last
                tempNode = currentNode.Next;
                currentNode.Next = null;
                currentNode.Prev.Next = tempNode;
                tempNode.Prev = currentNode.Prev;
                currentNode.Prev = tempNode;
                tempNode.Next = currentNode;
                last = currentNode.Data;
            }

            else
            {
                // If the node is in the middle
                throw new NotImplementedException();
            }
        }

        public override string ToString()
        {
            if (Count == 1)
            {
                return head.ToString();
            }

            string str = "";

            Node currentNode = head;
            str += currentNode.ToString() + "\n";
            while (currentNode.Next.Next != null)
            {
                currentNode = currentNode.Next;
                str += currentNode.ToString() + "\n";
            }

            str += currentNode.Next.ToString();

            return str;
        }
    }
}