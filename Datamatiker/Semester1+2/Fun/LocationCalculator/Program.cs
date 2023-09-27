using System;
using System.Collections.Generic;

namespace LocationCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double lat1 = 55.419309;
            double long1 = 10.327458;
            double lat2 = 55.418237;
            double long2 = 10.328102;

            DistanceViewModel dvm = new DistanceViewModel();

            Console.WriteLine(dvm.DistanceCalculator(lat1, long1, lat2, long2));
        }

        //// Test for distance: my place to the nearest Rema1000 results:
        //// Google: 900m, my method: 899,34
        //List<(double, double)> points = new List<(double, double)>()
        //    {
        //        (55.419317, 10.327511),
        //        (55.418232, 10.328155),
        //        (55.417651, 10.325197),
        //        (55.417384, 10.323831),
        //        (55.416984, 10.322632),
        //        (55.416359, 10.321381),
        //        (55.415175, 10.319886),
        //        (55.414856, 10.319446),
        //        (55.415020, 10.318968)
        //    };
    }
}
