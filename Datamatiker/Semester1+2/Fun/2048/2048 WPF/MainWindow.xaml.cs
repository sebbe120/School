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

namespace _2048_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Board board;
        public MainWindow()
        {
            InitializeComponent();
            board = new Board(BoardGrid.RowDefinitions.Count, BoardGrid.ColumnDefinitions.Count);
            LabelMatrix();
            RefreshWindow();
        }

        /// <summary>
        /// Shows the values from the board
        /// </summary>
        void LabelMatrix()
        {
            for (int row = 0; row < BoardGrid.RowDefinitions.Count; row++)
            {
                for (int column = 0; column < BoardGrid.ColumnDefinitions.Count; column++)
                {
                    Label label = new Label
                    {
                        Name = $"label{row}_{column}",

                        HorizontalContentAlignment = HorizontalAlignment.Center,

                        VerticalContentAlignment = VerticalAlignment.Center,

                        Background = Brushes.WhiteSmoke,

                        BorderBrush = Brushes.Black,

                        BorderThickness = new Thickness(0.5)
                    };

                    label.SetValue(Grid.ColumnProperty, column);
                    label.SetValue(Grid.RowProperty, row);

                    BoardGrid.Children.Add(label);
                }
            }
        }

        /// <summary>
        /// Refreshes the window with values from the board
        /// </summary>
        void RefreshWindow()
        {
            int row;
            int column;

            BoardGrid.Children.Cast<Label>().ToList().ForEach(label =>
            {
                string substring = label.Name.Substring(5);
                string[] indexes = substring.Split('_');
                row = int.Parse(indexes[0]);
                column = int.Parse(indexes[1]);

                if (board[row, column] != null)
                {
                    label.Content = board[row, column].Value;
                    label.Background = GetLabelBackground(board[row, column].Value);
                    label.FontSize = GetFontSize(board[row, column].Value);
                }

                else
                {
                    label.Content = null;
                    label.Background = GetLabelBackground(0);
                }
            });

            // Update Scoreboard
            lblScoreboard.Content = "Score: " + board.Score;
        }

        private SolidColorBrush GetLabelBackground(int value)
        {
            SolidColorBrush color = Brushes.WhiteSmoke;

            // max value = 131072 (2^17)
            switch (value)
            {
                case 2:
                    color = Brushes.AliceBlue;
                    break;
                case 4:
                    color = Brushes.LightGreen;
                    break;
                case 8:
                    color = Brushes.LightPink;
                    break;
                case 16:
                    color = Brushes.LightCyan;
                    break;
                case 32:
                    color = Brushes.LightSalmon;
                    break;
                case 64:
                    color = Brushes.LightSteelBlue;
                    break;
                case 128:
                    color = Brushes.LightGoldenrodYellow;
                    break;
                case 256:
                    color = Brushes.LightSeaGreen;
                    break;
                case 512:
                    color = Brushes.PaleGoldenrod;
                    break;
                case 1024:
                    color = Brushes.PaleGreen;
                    break;
                case 2048:
                    color = Brushes.PaleTurquoise;
                    break;
                case 4096:
                    color = Brushes.PaleVioletRed;
                    break;
                case 8192:
                    color = Brushes.LavenderBlush;
                    break;
                case 16384:
                    color = Brushes.FloralWhite;
                    break;
                case 32768:
                    color = Brushes.Wheat;
                    break;
                case 65536:
                    color = Brushes.LemonChiffon;
                    break;
                case 131072:
                    color = Brushes.Moccasin;
                    break;
                default:
                    break;
            }

            return color;
        }

        private int GetFontSize(int value)
        {
            int fontSize = 20;

            // max value = 131072 (2^17)
            if (value < 1024)
            {
                fontSize = 100;
            }

            else if (value < 16384)
            {
                fontSize = 80;
            }

            else if (value < 131072)
            {
                fontSize = 60;
            }

            else if (value == 131072)
            {
                fontSize = 50;
            }

            return fontSize;
        }

        private void btnMovePieces(object sender, RoutedEventArgs e)
        {
            string moveDirection = ((Button)sender).Content.ToString();

            board.MovePieces(moveDirection);

            try
            {
                board.SpawnNewPiece();
            }
            catch (Exception)
            {
                MessageBox.Show("No more moves left!");
            }

            RefreshWindow();
        }

        private void btnRestartGame(object sender, RoutedEventArgs e)
        {
            board = new Board(BoardGrid.RowDefinitions.Count, BoardGrid.ColumnDefinitions.Count);
            RefreshWindow();
        }



        /* Bugs / to do
         * Combo effect: if you have a row with 2-2-4-8 and move the pieces to the left, the 2's will combine to a 4
         *   (4-4-8-null), then the 4's will combine to an 8 (8-8-null-null) and finally, the 8's will combine to 16
         *   (16-null-null-null)
         * 
         * A better randomizer, as this one spawns all the first pieces with the same value
         * 
         * Force a move to be made before spawning a new piece
         */
    }
}
