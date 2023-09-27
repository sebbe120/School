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

namespace WPFInteractiveGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Controller controller;
        public MainWindow()
        {
            InitializeComponent();

            controller = new Controller();
        }

        private void Button_NewPerson(object sender, RoutedEventArgs e)
        {
            // Enable all buttons
            if (controller.PersonCount == 0)
            {                
                txtFirstName.IsEnabled = true;
                txtLastName.IsEnabled = true;
                txtAge.IsEnabled = true;
                txtTelephoneNo.IsEnabled = true;
                btnDeletePerson.IsEnabled = true;
                btnUp.IsEnabled = true;
                btnDown.IsEnabled = true;
            }

            txtFirstName.Clear();
            txtLastName.Clear();
            txtAge.Clear();
            txtTelephoneNo.Clear();

            controller.AddPerson();
            btnSubmit.IsEnabled = true;

        }

        private void Button_DeletePerson(object sender, RoutedEventArgs e)
        {
            controller.DeletePerson();
        }

        private void Button_Up(object sender, RoutedEventArgs e)
        {
            controller.NextPerson();
            txtFirstName.Text = controller.CurrentPerson.FirstName;
            txtLastName.Text = controller.CurrentPerson.LastName;
            txtAge.Text = controller.CurrentPerson.Age.ToString();
            txtTelephoneNo.Text = controller.CurrentPerson.TelephoneNo;
            lblIndex.Content = "Index " + (controller.PersonIndex);
        }

        private void Button_Down(object sender, RoutedEventArgs e)
        {
            controller.PrevPerson();
            txtFirstName.Text = controller.CurrentPerson.FirstName;
            txtLastName.Text = controller.CurrentPerson.LastName;
            txtAge.Text = controller.CurrentPerson.Age.ToString();
            txtTelephoneNo.Text = controller.CurrentPerson.TelephoneNo;
            lblIndex.Content = "Index " + (controller.PersonIndex);
        }

        private void Button_Submit(object sender, RoutedEventArgs e)
        {
            // Set current Persons data
            if (txtFirstName.Text != "" && txtLastName.Text != "" && txtAge.Text != "" && txtTelephoneNo.Text != "")
            {
                controller.CurrentPerson.FirstName = txtFirstName.Text;
                controller.CurrentPerson.LastName = txtLastName.Text;
                controller.CurrentPerson.Age = int.Parse(txtAge.Text);
                controller.CurrentPerson.TelephoneNo = txtTelephoneNo.Text;
                lblCount.Content = "Person Count " + controller.PersonCount;
                btnSubmit.Content = "Submit";
            }
            else
            {
                btnSubmit.Content = "Fill all boxes!";
            }
        }
    }
}
