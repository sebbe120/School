using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFAndMVVM2.Views
{
    /// <summary>
    /// Interaction logic for PersonDialog.xaml
    /// </summary>
    public partial class PersonDialog : Window
    {
        public PersonDialog()
        {
            InitializeComponent();
            DataContext = this;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (FirstName != null && LastName != null && Phone != null && Age >= 0)
            {
                DialogResult = true;
            }

            else
            {
                MessageBox.Show("Udfyld alle felter korrekt!");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

    }
}
