using ADT;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestQueue
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void TestQueue()
        {
            // Standard queue implemented by .NET
            System.Collections.Generic.Queue<int> stdQueue = new System.Collections.Generic.Queue<int>();
            // Your manually implemented ADT queue
            QueueOfT<int> yourQueue = new QueueOfT<int>();

            // Test generates 100 random integers and adds to both queues
            Random r = new Random();
            for (int i = 0; i < 100; i++)
            {
                int randVal = r.Next();
                stdQueue.Enqueue(randVal);
                yourQueue.Enqueue(randVal);
            }

            // Test reading back half the added integers
            for (int i = 0; i < 50; i++)
            {
                Assert.AreEqual(stdQueue.Dequeue(), yourQueue.Dequeue());
                Assert.AreEqual(stdQueue.Count, yourQueue.Count);
            }

            // Test adding 50 more random integers
            for (int i = 0; i < 50; i++)
            {
                int randVal = r.Next();
                stdQueue.Enqueue(randVal);
                yourQueue.Enqueue(randVal);
            }

            // Test reading back all the remaining values
            for (int i = 0; i < 100; i++)
            {
                Assert.AreEqual(stdQueue.Dequeue(), yourQueue.Dequeue());
                Assert.AreEqual(stdQueue.Count, yourQueue.Count);
            }

            // Test queue is empty now
            Assert.AreEqual(true, yourQueue.IsEmpty);
        }
    }
}
