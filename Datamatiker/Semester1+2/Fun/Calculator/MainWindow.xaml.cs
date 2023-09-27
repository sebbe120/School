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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double TotalNumber = 0; // The total
        double OperationNumber = 0; // The number the operations uses
        char operation = 'n'; // n:= no operation ongoing

        public MainWindow()
        {
            InitializeComponent();
        }

        // Convert dialog text to a double
        private void convertTotalNumber()
        {
            TotalNumber = double.Parse(txtDialog.Text);
        }

        // Convert dialog text to a double
        private void convertCurrentNumber()
        {
            OperationNumber = double.Parse(txtDialog.Text);
        }

        // Calculates a % of the total number
        private void Button_Percent(object sender, RoutedEventArgs e)
        {
            operation = '%';
            txtDialog.Text = OperationNumber.ToString();
        }

        // Clears the current number
        private void Button_ClearEntry(object sender, RoutedEventArgs e)
        {
            OperationNumber = 0;
            txtDialog.Text = "0";
        }

        private void Button_Clear(object sender, RoutedEventArgs e)
        {
            txtDialog.Text = "0";
            convertTotalNumber();
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            if (txtDialog.Text.Length > 1)
            {
                txtDialog.Text = txtDialog.Text.Substring(0, txtDialog.Text.Length - 1);
                convertTotalNumber();
            }
        }

        private void Button_Inverse(object sender, RoutedEventArgs e)
        {
            if (txtDialog.Text == "0")
            {
                return;
            }
            
            TotalNumber = 1 / TotalNumber;
            string inverse = TotalNumber.ToString();

            if (inverse.Length > 10 && inverse.Substring(0, 10).Contains(","))
            {
                if (inverse[9] == ',')
                {
                    inverse = inverse.Substring(0, 9);
                }
                else
                {
                    inverse = inverse.Substring(0, 10);
                }
            }

            txtDialog.Text = inverse;
        }

        private void Button_ChangeSign(object sender, RoutedEventArgs e)
        {
            if(txtDialog.Text[0] == '-')
            {
                txtDialog.Text = txtDialog.Text.Substring(1);
            }

            else
            {
                txtDialog.Text = "-" + txtDialog.Text;
            }

            convertTotalNumber();
        }

        private void Button_Square(object sender, RoutedEventArgs e)
        {
            if (txtDialog.Text == "0")
            {
                return;
            }

            convertTotalNumber();

            TotalNumber *= TotalNumber;

            string square = TotalNumber.ToString();

            if (square.Length > 10 && square.Substring(0,10).Contains(","))
            {
                if (square[9] == ','){
                    square = square.Substring(0, 9);
                }
                else
                {
                    square = square.Substring(0, 10);
                }                
            }

            txtDialog.Text = square;
        }

        private void Button_Root(object sender, RoutedEventArgs e)
        {
            if (txtDialog.Text == "0")
            {
                return;
            }

            convertTotalNumber();

            TotalNumber = Math.Sqrt(TotalNumber);

            string root = TotalNumber.ToString();

            if (root.Length > 10 && root.Substring(0, 10).Contains(","))
            {
                if (root[9] == ',')
                {
                    root = root.Substring(0, 9);
                }
                else
                {
                    root = root.Substring(0, 10);
                }
            }

            txtDialog.Text = root;
        }

        private void Button_Divide(object sender, RoutedEventArgs e)
        {
            operation = '/';
            txtDialog.Text = OperationNumber.ToString();
        }

        private void Button_Multiply(object sender, RoutedEventArgs e)
        {
            operation = '*';
            txtDialog.Text = OperationNumber.ToString();
        }

        private void Button_Subtract(object sender, RoutedEventArgs e)
        {
            operation = '-';
            txtDialog.Text = OperationNumber.ToString();
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            operation = '+';
            txtDialog.Text = OperationNumber.ToString();
        }

        // Works assuming that the user inputs a number afterwards, before using other functions
        private void Button_Comma(object sender, RoutedEventArgs e)
        {
            txtDialog.Text += ",";
        }

        // Peforms the chosen operation
        private void Button_Final(object sender, RoutedEventArgs e)
        {
            switch (operation)
            {
                case '+':
                    TotalNumber += OperationNumber;
                    break;

                case '-':
                    TotalNumber -= OperationNumber;
                    break;

                case '*':
                    TotalNumber *= OperationNumber;
                    break;

                case '/':
                    TotalNumber /= OperationNumber;
                    break;

                case '%':
                    TotalNumber = TotalNumber * (OperationNumber / 100);
                    break;

                default:
                    break;
            }

            txtDialog.Text = TotalNumber.ToString();

            OperationNumber = 0;
            operation = 'n';
        }

        // Add number to text
        private void Button_Number(object sender, RoutedEventArgs e)
        {
            if (txtDialog.Text == "0")
                txtDialog.Text = ((Button)sender).Name.Substring(((Button)sender).Name.Length - 1);

            else
            {
                txtDialog.Text += ((Button)sender).Name.Substring(((Button)sender).Name.Length - 1);
            }

            if (operation == 'n')
            {
                convertTotalNumber();
            }

            else
            {
                convertCurrentNumber();
            }            
        }
    }
}
