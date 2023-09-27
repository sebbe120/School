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

namespace TusindfrydWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<FlowerSort> flowerSorts;

        public MainWindow()
        {
            InitializeComponent();

            flowerSorts = new List<FlowerSort>();
        }

        public static void AddFlower(FlowerSort flower)
        {
            if (((MainWindow)Application.Current.MainWindow).txtFlowerList.Text == "Ingen blomstersort tilføjet")
                ((MainWindow)Application.Current.MainWindow).txtFlowerList.Text = "";

            ((MainWindow)Application.Current.MainWindow).flowerSorts.Add(flower);
            ((MainWindow)Application.Current.MainWindow).txtFlowerList.Text += flower + "\n";
        }

        private void Button_CreateFlowerSort(object sender, RoutedEventArgs e)
        {
            CreateFlowerSortDialog winDialog = new CreateFlowerSortDialog();
            winDialog.ShowDialog();
        }


    }
}
