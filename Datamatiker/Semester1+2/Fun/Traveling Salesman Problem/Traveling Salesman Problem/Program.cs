using System;
using System.Collections.Generic;

namespace Traveling_Salesman_Problem
{
    public class Program
    {
        public static void Main()
        {
            // Initialize list of city-objects,
            Methods method = new Methods();
            string filepath = @"C:\Users\Sebastian\source\repos\UCL\Projects\Traveling Salesman Problem\Traveling Salesman Problem\Cities.txt";
            List<City> cities = method.LoadCities(filepath);

            // Set the default path
            City[] bestPath = new City[cities.Count];            
            cities.CopyTo(bestPath);
            double bestCost = method.PathDistance(bestPath);


            // Values used in the TSP Algorithm
            double Temperature = 1000;
            int N_stop = 500;
            int N_dec = 50;
            bool verbose = false;


            // The Algoritm
            City[] currentPath;
            double currentCost;
            int iterations = 0;
            int N_stop_index = 0;
            int N_dec_index = 0;

            while (N_stop_index < N_stop)
            {
                // Choose mutation
                int mutation = method.r.Next(0, 2);
                if (mutation == 0)
                {
                    currentPath = method.ReversePath(bestPath);
                    currentCost = method.PathDistance(currentPath);
                }
                else
                {
                    currentPath = method.TransportPath(bestPath);
                    currentCost = method.PathDistance(currentPath);
                }


                if (currentCost - bestCost < 0)
                {
                    if (verbose)
                        PrintPath(currentPath, currentCost);
                    bestPath = currentPath;
                    bestCost = currentCost;

                    // Decrease the temperature if the solution is changed N_dec times
                    N_dec_index += 1;
                    if (N_dec_index == N_dec)
                    {
                        Temperature = Temperature * 0.9;

                        if (verbose)
                            Console.WriteLine("\nTemperature decreased to: " + Temperature + "\n");

                        N_dec_index = 0;
                    }

                    N_stop_index = 0;
                }
                else
                {
                    double r = method.r.NextDouble();
                    if (r < Math.Exp((-1 * (currentCost - bestCost)) / Temperature))
                    {
                        if (verbose)
                            PrintPath(currentPath, currentCost);
                        bestPath = currentPath;
                        bestCost = currentCost;


                        // Decrease the temperature if the solution is changed N_dec times
                        N_dec_index += 1;
                        if (N_dec_index == N_dec)
                        {
                            Temperature = Temperature * 0.9;

                            if (verbose)
                                Console.WriteLine("\nTemperature decreased to: " + Temperature + "\n");

                            N_dec_index = 0;
                        }

                        N_stop_index = 0;
                    }
                }

                N_stop_index += 1;
                iterations += 1;
            }

            // Prints the results
            if (verbose)
                Console.WriteLine("\n\n");
            PrintPath(bestPath, bestCost, "Best path: [");
            Console.WriteLine("Number of iterations: " + iterations);


            // Creates lists of values for drawing the points
            double[] xValues = new double[cities.Count + 1];
            double[] yValues = new double[cities.Count + 1];            
            for (int i = 0; i < cities.Count; i++)
            {
                xValues[i] = cities[i].Getx();
                yValues[i] = cities[i].Gety();
            }
            xValues[cities.Count] = cities[0].Getx();
            yValues[cities.Count] = cities[0].Gety();

        }

        static void PrintPath(City[] cities, double cost = 0.0, string Str = "New path:  [")
        {
            string str = Str;
            for (int i = 0; i < cities.Length; i++)
            {
                if (cities[i] == null)
                {
                    str += "Null, ";
                    continue;
                }
                str += cities[i].GetName() + ", ";
            }
            str = str.Substring(0, str.Length - 2);
            str += "] with the cost: " + String.Format("{0:0.0000000000}", cost);
            Console.WriteLine(str);
        }
    }
}
