using System;
using System.Collections.Generic;
using System.Text;

namespace LocationCalculator
{
    public class DistanceModel
    {
        // The mean radius of the Earth in meters
        const int radiusEarth = 6731000;

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
            // Convert all values to radians
            double lat1Radians = lat1 * Math.PI / 180;
            double lat2Radians = lat2 * Math.PI / 180;
            double deltaLat = (lat2 - lat1) * Math.PI / 180;
            double deltaLong = (long2 - long1) * Math.PI / 180;

            double a = Math.Pow(Math.Sin(deltaLat / 2), 2) + Math.Cos(lat1Radians) * Math.Cos(lat2Radians)
                     * Math.Pow(Math.Sin(deltaLong / 2), 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return Math.Round(radiusEarth * c, 2, MidpointRounding.ToZero);
        }
        /* Site which has the haversine formulas:
         * https://www.movable-type.co.uk/scripts/latlong.html
         * 
         * Site used to compare the distance:
         * https://www.meridianoutpost.com/resources/etools/calculators/calculator-latitude-longitude-distance.php?
         * https://www.geodatasource.com/distance-calculator
         * https://www.movable-type.co.uk/scripts/latlong.html
         * The two first links are close to this methods result.
         * The last links result is 5% lower than this methods result.
         */
    }
}
