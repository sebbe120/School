using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Heatmap
{
    public class RouteSimulator
    {
        List<Point> route;
        public readonly int length;
        public readonly double timeInterval = 10; // seconds pr. measurement

        public RouteSimulator(int numberOfPoints)
        {
            //route = GenerateRoutePoints(numberOfPoints);

            route = new List<Point>()
            {
                new Point(150, 200),
                new Point(120, 300),
                new Point(170, 400),
                new Point(190, 500),
                new Point(300, 600),
                new Point(350, 700),
                new Point(390, 800),
                new Point(430, 900),
                new Point(1400, 500),
                new Point(800, 300),
                new Point(400, 600),
                new Point(440, 300),
                new Point(510, 310),
                new Point(1000, 150),
                new Point(1000, 270),
                new Point(1300, 300),
            };

            length = route.Count;
        }

        public List<Point> GenerateRoutePoints(int numberOfPoints)
        {
            List<Point> points = new List<Point>();
            Random r = new Random();
            Point temp;

            for (int i = 0; i < numberOfPoints; i++)
            {
                temp = new Point(
                    r.Next(200, (int)SystemParameters.MaximizedPrimaryScreenWidth - 200),
                    r.Next(200, (int)SystemParameters.MaximizedPrimaryScreenHeight - 200));
                points.Add(temp);
            }

            return points;
        }

        public void AddPoint(int x, int y)
        {
            try
            {
                route.Add(new Point(x, y));
            }
            catch
            {

                throw;
            }
        }

        public List<Point> GetRoutePoints()
        {
            return route;
        }

        public string GetRouteString()
        {
            string str = "";
            str += "Max Width: " + SystemParameters.MaximizedPrimaryScreenWidth + "\n";
            str += "Max Height: " + SystemParameters.MaximizedPrimaryScreenHeight + "\n\n";
            str += "Points:\n";

            foreach (Point point in route)
            {
                str += $"{point.X}, {point.Y}\n";
            }

            return str;
        }
    }
}
