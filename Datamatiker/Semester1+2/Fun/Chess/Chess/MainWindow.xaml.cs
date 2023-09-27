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
using Chess.ChessPieces;

namespace Chess
{
    public partial class MainWindow : Window
    {
        ChessBoard board;
        Button SelectedButton;

        public MainWindow()
        {
            InitializeComponent();
            board = new ChessBoard();
            InitializeBoard();
        }

        public void InitializeBoard()
        {
            for (int row = 0; row < Container.RowDefinitions.Count; row++)
            {
                for (int column = 0; column < Container.ColumnDefinitions.Count; column++)
                {
                    Button button = new Button
                    {
                        Name = "btn" + row + "_" + column,

                        // The tag is used to identify if the square is brown or white: 2n => white, 2n+1 => brown
                        Tag = row + column,

                        BorderThickness = new Thickness(0.0),

                        FontSize = 30
                    };

                    // Set the background of the buttons on the board
                    SetDefaultButtonBackground(button);

                    // Add the pieces to the board
                    if (board.GetChessBoard()[row, column] != null)
                    {
                        SetButtonForeground(button, board.GetChessBoard()[row, column]);
                    }

                    // Add the button to the grid
                    button.SetValue(Grid.ColumnProperty, column);
                    button.SetValue(Grid.RowProperty, row);
                    button.Click += new RoutedEventHandler(Button_Click);
                    Container.Children.Add(button);
                }
            }
        }

        // Sets the buttons background to the corrosponding piece
        public void SetDefaultButtonBackground(Button btn)
        {
            if ((int)btn.Tag % 2 == 0)
            {
                btn.Background = new BrushConverter().ConvertFromString("#FFE1AA") as SolidColorBrush; ;
            }

            else
            {
                btn.Background = Brushes.SaddleBrown;
            }
        }

        // Sets the buttons background to the corrosponding piece
        public void SetButtonForeground(Button btn, ChessPiece piece)
        {
            piece.GetForegroundText(btn);
        }

        void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
        }
    }
}
