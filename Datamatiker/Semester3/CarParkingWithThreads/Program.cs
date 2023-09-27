using System;
using System.Collections.Generic;

namespace CarParkingWithThreads
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a queue full of cars
            Queue<Car> carQueue = new Queue<Car>();
            for (int i = 0; i < 20; i++)
            {
                carQueue.Enqueue(new Car());
            }

            Car[] tempArr = carQueue.ToArray();
            for (int i = 0; i < tempArr.Length; i++)
            {
                Console.WriteLine(tempArr[i]);
            }

            // Initialize the parking lot
            Car[] parking = new Car[10];

            // A dumb non-threaded version of the parking simulator
            while (carQueue.Count != 0 || isArrayEmpty(parking))
            {
                Console.WriteLine("\n\n\n");
                InsertCar(parking, carQueue);
                DecreaseLifeTime(parking);
            }

            Console.WriteLine("Goodbye!");
        }

        static void InsertCar(Car[] parking, Queue<Car> queue)
        {
            if (isArrayFull(parking) || queue.Count == 0)
            {
                return;
            }

            // Else put 1 car from the queue into the parking array
            for (int i = 0; i < parking.Length; i++)
            {
                if (parking[i] == null)
                {
                    parking[i] = queue.Dequeue();
                    break;
                }
            }
        }

        static void DecreaseLifeTime(Car[] parking)
        {
            for (int i = 0; i < parking.Length; i++)
            {
                if (parking[i] == null)
                {
                    continue;
                }

                if (parking[i].LifeTime > 0)
                {
                    parking[i].DecreaseLifeTime();
                    Console.WriteLine(parking[i]);
                }

                if (parking[i].LifeTime == 0)
                {
                    parking[i] = null;
                }
            }
        }

        static bool isArrayFull(Car[] arr)
        {
            bool isFull = true;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == null)
                {
                    isFull = false;
                    break;
                }
            }

            return isFull;
        }

        static bool isArrayEmpty(Car[] arr)
        {
            bool isEmpty = true;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != null)
                {
                    isEmpty = false;
                    break;
                }
            }

            return isEmpty;
        }
    }

    public class Car
    {
        Random r = new Random();
        public Car()
        {
            LifeTime = r.Next(1, 20);
        }

        private int lifeTime;

        public int LifeTime
        {
            get { return lifeTime; }
            set { lifeTime = value; }
        }

        public void DecreaseLifeTime()
        {
            LifeTime -= 1;
        }

        public override string ToString()
        {
            return DateTime.Now.ToString("HH:mm:ss") + $"     {LifeTime}";
        }
    }
}
