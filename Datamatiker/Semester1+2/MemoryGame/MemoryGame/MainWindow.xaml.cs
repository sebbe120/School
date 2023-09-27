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

namespace MemoryGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            int boardsize = 6;
            InitializeButtons(boardsize);
        }

        private bool GameEnded;
        private Button selectedElement;

        public void InitializeButtons(int size)
        {
            // Check if the grid has an odd size
            if ((size % 2) != 0)
                throw new ArgumentException();

            for (int i = 0; i < size; i++)
            {
                // Add grid
                Container.ColumnDefinitions.Add(new ColumnDefinition());
                Container.RowDefinitions.Add(new RowDefinition());
            }

            // Add content for the buttons
            List<string> content = new List<string>();

            for (int i = 0; i < (size * size / 2); i++)
            {
                content.Add(i.ToString());
                content.Add(i.ToString());
            }

            content = Shuffle(content);

            for (int row = 0; row < Container.RowDefinitions.Count; row++)
            {
                for (int column = 0; column < Container.ColumnDefinitions.Count; column++)
                {
                    Button button = new Button
                    {
                        Name = "Btn" + row + "_" + column,
                        BorderThickness = new Thickness(1.0),
                    };

                    button.FontSize = 50;
                    button.Background = Brushes.LightGray;
                    button.Content = content.First();
                    button.Tag = content.First();
                    content.RemoveAt(0);

                    button.SetValue(Grid.ColumnProperty, column);
                    button.SetValue(Grid.RowProperty, row);

                    button.Click += new RoutedEventHandler(button_Click);
                    Container.Children.Add(button);
                }
            }
        }

        // Shuffles the pieces on the board
        private List<T> Shuffle<T>(List<T> list)
        {
            Random r = new Random();
            for (int i = 0; i < list.Count*2; i++)
            {
                int indexA = r.Next(0, list.Count);
                int indexB = r.Next(0, list.Count);

                if (indexA == indexB)
                    continue;

                T tmp = list[indexA];
                list[indexA] = list[indexB];
                list[indexB] = tmp;
            }
            return list;
        }
        
        private void button_Click(object sender, RoutedEventArgs e)
        {
            // Select piece if none is selected
            if (selectedElement == null || (Button)sender == selectedElement)
            {
                selectedElement = (Button)sender;
                selectedElement.Background = Brushes.Gray;
                //selectedElement.Content = selectedElement.Tag;
                return;
            }

            // Check if the pieces are the same
            if (((Button)sender).Tag == selectedElement.Tag)
            {
                ((Button)sender).IsEnabled = false;
                selectedElement.IsEnabled = false;
            }

            else
            {
                ((Button)sender).Content = ((Button)sender).Tag;
                
                selectedElement.Background = Brushes.LightGray;
            }
            
            selectedElement = null;

            return;
        }

        // To do:
        // Alle tal over 10 kan ikke vendes
    }
}
