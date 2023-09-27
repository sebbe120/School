using System;
using System.Collections.Generic;
using System.Text;

namespace LocationCalculator
{
    public class DistanceViewModel
    {
        private DistanceModel dm = new DistanceModel();

        /// <summary>
        /// Uses the haversine formula to calculate the distance between two points, given their latitude and longitude
        /// </summary>
        /// <param name="lat1">The latitude of the first point in degrees.</param>
        /// <param name="long1">The longitude of the first point in degrees.</param>
        /// <param name="lat2">The latitude of the second point in degrees.</param>
        /// <param name="long2">The longitude of the second point in degrees.</param>
        /// /// <returns>Returns the distance in meters.</returns>
        public double DistanceCalculator(double lat1, double long1, double lat2, double long2)
        {
            return dm.DistanceCalculator(lat1, long1, lat2, long2);
        }

        /// <summary>
        /// Calculates the length of a path from a list of points.
        /// </summary>
        /// <param name="points"> A list of points ordered by the time the point was logged.</param>
        /// <returns> The length of the path in meters.</returns>
        public double PathDistanceCalculator(List<(double, double)> points)
        {
            double total = 0;

            for (int i = 0; i < points.Count - 1; i++)
            {
                total += dm.DistanceCalculator(points[i].Item1, points[i].Item2, points[i + 1].Item1, points[i + 1].Item2);
            }

            return total;
        }
    }
}
