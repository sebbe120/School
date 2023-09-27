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

namespace TusindfrydWPF
{
    /// <summary>
    /// Interaction logic for CreateFlowerSortDialog.xaml
    /// </summary>
    public partial class CreateFlowerSortDialog : Window
    {
        public CreateFlowerSortDialog()
        {
            InitializeComponent();
        }

        private void Button_Ok(object sender, RoutedEventArgs e)
        {
            if (txtName.Text != "" && txtPicture.Text != "" && txtProduction.Text != "" && txtHalfLife.Text != "" && txtSize.Text != "")
            {
                if (int.TryParse(txtProduction.Text, out _) && int.TryParse(txtHalfLife.Text, out _) && int.TryParse(txtSize.Text, out _))
                {
                    FlowerSort flower = new FlowerSort();
                    flower.Name = txtName.Text;
                    flower.PicturePath = txtPicture.Text;
                    flower.ProductionTime = int.Parse(txtProduction.Text);
                    flower.HalfLifeTime = int.Parse(txtHalfLife.Text);
                    flower.Size = int.Parse(txtSize.Text);

                    MainWindow.AddFlower(flower);

                    this.Close();
                }

                else
                    btnOk.Content = "Invalid type!";
            }

            else
            {
                btnOk.Content = "Fill all boxes!";
            }
        }

        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void textChangedEventHandler(object sender, TextChangedEventArgs e)
        {
            if (txtPicture.Text != "")
                try
                {
                    string path = txtPicture.Text;
                    imgPicture.Source = new BitmapImage(new Uri(path));
                }
                catch
                {
                    return;
                }
                

            if (txtName.Text != "" && txtPicture.Text != "" && txtProduction.Text != "" && txtHalfLife.Text != "" && txtSize.Text != "")
            {
                btnOk.IsEnabled = true;
            }
        }
    }
}
