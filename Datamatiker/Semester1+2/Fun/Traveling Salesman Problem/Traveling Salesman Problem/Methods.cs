using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Traveling_Salesman_Problem
{
    class Methods
    {
        public Random r = new Random();

        // Reads from the Cities.txt file, and initializes a list, cities, of type City.
        public List<City> LoadCities(string filepath)
        {
            List<City> cities = new List<City>();
            StreamReader reader = new StreamReader(filepath);

            string row;
            do
            {

                string[] splitRow;
                row = reader.ReadLine();
                if (row != null)
                {
                    splitRow = row.Split(" ");
                    cities.Add(new City(splitRow[0], double.Parse(splitRow[1], CultureInfo.InvariantCulture), double.Parse(splitRow[2], CultureInfo.InvariantCulture)));
                }

            } while (row != null);

            reader.Close();
            return cities;
        }

        // Calculates the euclidian distance between two cities
        public double Distance(City city1, City city2)
        {
            double deltaX = Math.Abs(city1.Getx() - city2.Getx());
            double deltaY = Math.Abs(city1.Gety() - city2.Gety());
            double dis = Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
            return dis;
        }

        // Calculates the total distance of the given path
        public double PathDistance(City[] path)
        {
            double total = 0.0;

            for (int i = 0; i < path.Length - 1; i++)
            {
                total += Distance(path[i], path[i + 1]);
            }
            total += Distance(path[path.Length - 1], path[0]);

            return total;
        }

        // Reverses a part of the path
        public City[] ReversePath(City[] cities)
        {
            // Range
            int min = r.Next(cities.Length - 1);
            int max = r.Next(min + 1, cities.Length);
            //Console.WriteLine("Range: " + min + ":" + max);

            City[] NewPath = new City[cities.Length];
            City temp;

            for (int i = 0; i < cities.Length; i++)
            {
                NewPath[i] = cities[i];
            }

            // Swap cities
            for (int i = min; i < max; i++,max--)
            {
                temp = NewPath[i];
                NewPath[i] = NewPath[max];
                NewPath[max] = temp;
            }

            return NewPath;
        }

        // Transports a part of the path to another place in the array
        public City[] TransportPath(City[] cities)
        {
            // Range
            int min = r.Next(1, cities.Length - 1);
            int max = r.Next(min + 1, cities.Length);
            int transportIndex = r.Next(1, min);
            //Console.WriteLine("Range: [" + min + ":" + max + "], transport: " + transportIndex + " places");

            // Append cities before the transported part
            City[] NewPath = new City[cities.Length];
            for (int i = 0; i < min - transportIndex; i++)
            {
                NewPath[i] = cities[i];
            }

            // Append transported cities
            for (int i = min - transportIndex; i < max - transportIndex; i++)
            {
                NewPath[i] = cities[i + transportIndex];
            }

            // Index used to count how many cities that were transported
            int tempIndex = transportIndex;
            // Append cities after the transported part
            for (int i = max - transportIndex; i < cities.Length; i++)
            {
                if (tempIndex == 0)
                    NewPath[i] = cities[i];
                else
                {
                    NewPath[i] = cities[min - tempIndex];
                    tempIndex -= 1;
                }
            }

            return NewPath;
        }
    }
}
