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

namespace WPFSimpleGUI
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

        private void Button_Clear(object sender, RoutedEventArgs e)
        {
            txt1.Clear();
            txt2.Clear();
            txt3.Clear();
            txt4.Clear();
        }

        private void Button_Scroll_Up(object sender, RoutedEventArgs e)
        {
            string temp1 = txt1.Text;
            string temp2 = txt2.Text;
            string temp3 = txt3.Text;
            string temp4 = txt4.Text;

            txt1.Text = temp2;
            txt2.Text = temp3;
            txt3.Text = temp4;
            txt4.Text = temp1;
        }

        private void Button_Scroll_Down(object sender, RoutedEventArgs e)
        {
            string temp1 = txt1.Text;
            string temp2 = txt2.Text;
            string temp3 = txt3.Text;
            string temp4 = txt4.Text;

            txt1.Text = temp4;
            txt2.Text = temp1;
            txt3.Text = temp2;
            txt4.Text = temp3;
        }
    }
}
