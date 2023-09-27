using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Studiestartsprøve
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        double operationNumber = 0; // The saved number the operation uses
        char operation = 'n'; // The type of operation. n:= no operation ongoing

        private void Button_Number(object sender, RoutedEventArgs e)
        {
            string val = ((Button)sender).Name.Substring(((Button)sender).Name.Length - 1);

            if (txtDialog.Text == "0" && val == "0" || txtDialog.Text == "0" && val != "0")
            {
                txtDialog.Text = val;
            }

            else
            {
                txtDialog.Text += val;
            }
        }

        private void Button_Square(object sender, RoutedEventArgs e)
        {
            if (txtDialog.Text == "0")
            {
                return;
            }
            double val = double.Parse(txtDialog.Text);
            txtDialog.Text = (val * val).ToString();
        }


        private void Button_Root(object sender, RoutedEventArgs e)
        {
            if (txtDialog.Text == "0")
            {
                return;
            }

            double val = double.Parse(txtDialog.Text);
            txtDialog.Text = (Math.Sqrt(val)).ToString();
        }

        private void Button_Divide(object sender, RoutedEventArgs e)
        {
            operation = '/';
            operationNumber = double.Parse(txtDialog.Text);
            ClearEntry();
        }

        private void Button_Multiply(object sender, RoutedEventArgs e)
        {
            operation = '*';
            operationNumber = double.Parse(txtDialog.Text);
            ClearEntry();
        }

        private void Button_Subtract(object sender, RoutedEventArgs e)
        {
            operation = '-';
            operationNumber = double.Parse(txtDialog.Text);
            ClearEntry();
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            operation = '+';
            operationNumber = double.Parse(txtDialog.Text);
            ClearEntry();
        }

        private void ClearEntry()
        {
            txtDialog.Text = "0";
        }

        private void Button_Clear(object sender, RoutedEventArgs e)
        {
            operationNumber = 0;
            operation = 'n';
            txtDialog.Text = "0";
        }
        private void Button_Final(object sender, RoutedEventArgs e)
        {
            double val = double.Parse(txtDialog.Text);
            switch (operation)
            {
                case '+':
                    txtDialog.Text = (operationNumber + val).ToString();
                    break;
                case '-':
                    txtDialog.Text = (operationNumber - val).ToString();
                    break;
                case '*':
                    txtDialog.Text = (operationNumber * val).ToString();
                    break;
                case '/':
                    txtDialog.Text = (operationNumber / val).ToString();
                    break;
                default:
                    break;
            }

            operation = 'n';
            operationNumber = 0;
        }

        private void Button_ChangeSign(object sender, RoutedEventArgs e)
        {
            if (txtDialog.Text == "0")
            {
                return;
            }

            double val = double.Parse(txtDialog.Text);
            txtDialog.Text = (val * -1).ToString();
        }

        private void Button_Inverse(object sender, RoutedEventArgs e)
        {
            if (txtDialog.Text == "0")
            {
                return;
            }

            double val = double.Parse(txtDialog.Text);
            txtDialog.Text = (1 / val).ToString();
        }

        private void Button_Sin(object sender, RoutedEventArgs e)
        {
            if (txtDialog.Text == "0")
            {
                return;
            }

            double val = double.Parse(txtDialog.Text);
            txtDialog.Text = (Math.Sin(val)).ToString();
        }

        private void Button_Cos(object sender, RoutedEventArgs e)
        {
            if (txtDialog.Text == "0")
            {
                return;
            }

            double val = double.Parse(txtDialog.Text);
            txtDialog.Text = (Math.Cos(val)).ToString();
        }
    }
}
