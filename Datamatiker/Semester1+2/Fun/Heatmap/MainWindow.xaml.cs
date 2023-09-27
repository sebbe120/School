using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Heatmap
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RouteSimulator routeSimulator;
        public MainWindow()
        {
            InitializeComponent();
            routeSimulator = new RouteSimulator(10);
            txtPoints.Text = routeSimulator.GetRouteString();
            DrawRoute();
        }

        public void DrawRoute()
        {
            List<Point> route = routeSimulator.GetRoutePoints();
            Line l;
            for (int i = 0; i < routeSimulator.length - 1; i++)
            {
                l = new Line();
                l.X1 = route[i].X;
                l.X2 = route[i + 1].X;
                l.Y1 = route[i].Y;
                l.Y2 = route[i + 1].Y;

                double speedRatio = Pythagoras(l.X1, l.X2, l.Y1, l.Y2) / routeSimulator.timeInterval;
                //txtPoints.Text += "\n" + speedRatio;

                l.StrokeThickness = 5.0;
                l.Stroke = GetSegmentColor(speedRatio);
                myCanvas.Children.Add(l);
            }
        }

        public double Pythagoras(double x1, double x2, double y1, double y2)
        {
            return Math.Sqrt(Math.Pow(x1-x2, 2) + Math.Pow(y1 - y2, 2));
        }

        public SolidColorBrush GetSegmentColor(double speedRatio)
        {
            SolidColorBrush color;

            if (speedRatio < 10)
            {
                color = new SolidColorBrush(Color.FromRgb(255, 255, 0));
            }

            else if (speedRatio < 20)
            {
                color = new SolidColorBrush(Color.FromRgb(255, 235, 0));
            }

            else if (speedRatio < 30)
            {
                color = new SolidColorBrush(Color.FromRgb(255, 215, 0));
            }

            else if (speedRatio < 40)
            {
                color = new SolidColorBrush(Color.FromRgb(255, 195, 0));
            }

            else if (speedRatio < 50)
            {
                color = new SolidColorBrush(Color.FromRgb(255, 175, 0));
            }

            else if (speedRatio < 60)
            {
                color = new SolidColorBrush(Color.FromRgb(255, 155, 0));
            }

            else if (speedRatio < 70)
            {
                color = new SolidColorBrush(Color.FromRgb(255, 135, 0));
            }

            else if (speedRatio < 80)
            {
                color = new SolidColorBrush(Color.FromRgb(255, 115, 0));
            }

            else if (speedRatio < 90)
            {
                color = new SolidColorBrush(Color.FromRgb(255, 95, 0));
            }

            else if (speedRatio < 100)
            {
                color = new SolidColorBrush(Color.FromRgb(255, 75, 0));
            }

            else
            {
                color = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            }

            return color;
        }

        private void btnRestart_Click(object sender, RoutedEventArgs e)
        {
            myCanvas.Children.Clear();
            routeSimulator = new RouteSimulator(10);
            txtPoints.Text = routeSimulator.GetRouteString();
            DrawRoute();
        }

        private void btnNewPoint_Click(object sender, RoutedEventArgs e)
        {
            int x;
            int y;
            try
            {
                x = int.Parse(txtPointX.Text);
                y = int.Parse(txtPointY.Text);
                routeSimulator.AddPoint(x, y);
                DrawRoute();
            }
            catch (Exception)
            {

                MessageBox.Show("Invalid input"); ;
            }
        }

        // Adjust the colors when the walkin speed is more realistic
        // 
    }
}