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
using System.IO;

namespace Connect_Four_WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ButtonMatrix();
            NewGame();
        }

        private Tokens[,] board;

        private bool player1Turn;

        private bool GameEnded;

        int[] movesLeftArray;

        // Brushes used to draw the Board and Tokens
        ImageBrush BoardGrid = new ImageBrush();
        ImageBrush RedToken = new ImageBrush();
        ImageBrush YellowToken = new ImageBrush();
        ImageBrush BoardGridWonRed = new ImageBrush();
        ImageBrush BoardGridWonYellow = new ImageBrush();
        ImageBrush BoardGridTieRed = new ImageBrush();
        ImageBrush BoardGridTieYellow = new ImageBrush();

        // Path to the directory where the images are
        string path = System.IO.Path.GetFullPath(System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\..\"));

        private void NewGame()
        {
            // Create a new blank array of free cells
            board = new Tokens[Container.RowDefinitions.Count, Container.ColumnDefinitions.Count];

            // Number of moves left in each column
            movesLeftArray = new int[7] { 5, 5, 5, 5, 5, 5, 5 };

            // Make sure Player 1 starts the game
            player1Turn = true;

            // Change brushes to the corresponding PNG-file
            BoardGrid.ImageSource = new BitmapImage(new Uri(System.IO.Path.Combine(path, "Grid.png"), UriKind.Relative));
            RedToken.ImageSource = new BitmapImage(new Uri(System.IO.Path.Combine(path, "RedToken.png"), UriKind.Relative));
            YellowToken.ImageSource = new BitmapImage(new Uri(System.IO.Path.Combine(path, "YellowToken.png"), UriKind.Relative));
            BoardGridWonRed.ImageSource = new BitmapImage(new Uri(System.IO.Path.Combine(path, "GridWonRed.png"), UriKind.Relative));
            BoardGridWonYellow.ImageSource = new BitmapImage(new Uri(System.IO.Path.Combine(path, "GridWonYellow.png"), UriKind.Relative));
            BoardGridTieRed.ImageSource = new BitmapImage(new Uri(System.IO.Path.Combine(path, "GridTieRed.png"), UriKind.Relative));
            BoardGridTieYellow.ImageSource = new BitmapImage(new Uri(System.IO.Path.Combine(path, "GridTieYellow.png"), UriKind.Relative));

            // Reset all buttons on the board
            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                // Change background to the default value
                button.Background = BoardGrid;
            });

            // Make sure the game hasn't finished
            GameEnded = false;
        }

        // Initialize all buttons
        private void ButtonMatrix()
        {            
            for (int row = 0; row < Container.RowDefinitions.Count; row++)
            {
                for (int column = 0; column < Container.ColumnDefinitions.Count; column++)
                {
                    Button button = new Button
                    {
                        Name = "Button" + row + "_" + column,

                        Height = 100,

                        Width = 100,

                        Tag = column,

                        BorderThickness = new Thickness(0.0),
                    };

                    button.SetValue(Grid.ColumnProperty, column);
                    button.SetValue(Grid.RowProperty, row);

                    button.Click += new RoutedEventHandler(button_Click);
                    Container.Children.Add(button);
                }
            }
        }

        void button_Click(object sender, RoutedEventArgs e)
        {
            // Start a new game, if the game has ended
            if (GameEnded)
            {
                NewGame();
                return;
            }

            // Cast the sender to a button
            Button button = (Button)sender;

            int column = (int)button.Tag;
            int row = movesLeftArray[column];

            // Don't do anything if the column is full
            if (row == -1)
                return;

            // Set the cell value based on which players turn it is
            board[row, column] = player1Turn ? Tokens.Red : Tokens.Yellow;

            // Decrement the amount of moves left in the column
            movesLeftArray[column] -= 1;

            
            //button.Background = player1Turn ? RedToken : YellowToken;

            // Set the lowest row in a collumn
            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                if(button.Name == ("Button" + row + "_" + column))
                    button.Background = player1Turn ? RedToken : YellowToken;
            });            

            CheckForWinner();

            // Change player
            player1Turn = !player1Turn;

        }

        private void CheckForWinner()
        {
            // Check row
            for (int row = 0; row < Container.RowDefinitions.Count; row++)
            {
                for (int column = 0; column < Container.ColumnDefinitions.Count - 3; column++)
                {
                    if (board[row, column] != Tokens.Free && (board[row, column] & board[row, column + 1] & board[row, column + 2] & board[row, column + 3]) == board[row, column])
                    {
                        Container.Children.Cast<Button>().ToList().ForEach(button =>
                        {
                            if (button.Name == ("Button" + row + "_" + column))
                                button.Background = player1Turn ? BoardGridWonRed : BoardGridWonYellow;

                            if (button.Name == ("Button" + row + "_" + (column + 1)))
                                button.Background = player1Turn ? BoardGridWonRed : BoardGridWonYellow;

                            if (button.Name == ("Button" + row + "_" + (column + 2)))
                                button.Background = player1Turn ? BoardGridWonRed : BoardGridWonYellow;

                            if (button.Name == ("Button" + row + "_" + (column + 3)))
                                button.Background = player1Turn ? BoardGridWonRed : BoardGridWonYellow;
                        });

                        GameEnded = true;
                        return;
                    }

                }
            }

            // Check column
            for (int row = 0; row < Container.RowDefinitions.Count - 3; row++)
            {
                for (int column = 0; column < Container.ColumnDefinitions.Count; column++)
                {
                    if (board[row, column] != Tokens.Free && (board[row, column] & board[row + 1, column] & board[row + 2, column] & board[row + 3, column]) == board[row, column])
                    {
                        Container.Children.Cast<Button>().ToList().ForEach(button =>
                        {
                            if (button.Name == ("Button" + row + "_" + column))
                                button.Background = player1Turn ? BoardGridWonRed : BoardGridWonYellow;

                            if (button.Name == ("Button" + (row + 1) + "_" + column))
                                button.Background = player1Turn ? BoardGridWonRed : BoardGridWonYellow;

                            if (button.Name == ("Button" + (row + 2) + "_" + column))
                                button.Background = player1Turn ? BoardGridWonRed : BoardGridWonYellow;

                            if (button.Name == ("Button" + (row + 3) + "_" + column))
                                button.Background = player1Turn ? BoardGridWonRed : BoardGridWonYellow;
                        });

                        GameEnded = true;
                        return;
                    }

                }
            }

            // Check diagonal (TopLeft - BottomRight)
            for (int row = 0; row < Container.RowDefinitions.Count - 3; row++)
            {
                for (int column = 0; column < Container.ColumnDefinitions.Count - 3; column++)
                {
                    if (board[row, column] != Tokens.Free && (board[row, column] & board[row + 1, column + 1] & board[row + 2, column + 2] & board[row + 3, column + 3]) == board[row, column])
                    {
                        Container.Children.Cast<Button>().ToList().ForEach(button =>
                        {
                            if (button.Name == ("Button" + row + "_" + column))
                                button.Background = player1Turn ? BoardGridWonRed : BoardGridWonYellow;

                            if (button.Name == ("Button" + (row + 1) + "_" + (column + 1)))
                                button.Background = player1Turn ? BoardGridWonRed : BoardGridWonYellow;

                            if (button.Name == ("Button" + (row + 2) + "_" + (column + 2)))
                                button.Background = player1Turn ? BoardGridWonRed : BoardGridWonYellow;

                            if (button.Name == ("Button" + (row + 3) + "_" + (column + 3)))
                                button.Background = player1Turn ? BoardGridWonRed : BoardGridWonYellow;
                        });

                        GameEnded = true;
                        return;
                    }

                }
            }

            // Check diagonal (BottomLeft - TopRight)
            for (int row = Container.RowDefinitions.Count - 1; row > 2; row--)
            {
                for (int column = 0; column < Container.ColumnDefinitions.Count - 3; column++)
                {
                    if (board[row, column] != Tokens.Free && (board[row, column] & board[row - 1, column + 1] & board[row - 2, column + 2] & board[row - 3, column + 3]) == board[row, column])
                    {
                        Container.Children.Cast<Button>().ToList().ForEach(button =>
                        {
                            if (button.Name == ("Button" + row + "_" + column))
                                button.Background = player1Turn ? BoardGridWonRed : BoardGridWonYellow;

                            if (button.Name == ("Button" + (row - 1) + "_" + (column + 1)))
                                button.Background = player1Turn ? BoardGridWonRed : BoardGridWonYellow;

                            if (button.Name == ("Button" + (row - 2) + "_" + (column + 2)))
                                button.Background = player1Turn ? BoardGridWonRed : BoardGridWonYellow;

                            if (button.Name == ("Button" + (row - 3) + "_" + (column + 3)))
                                button.Background = player1Turn ? BoardGridWonRed : BoardGridWonYellow;
                        });

                        GameEnded = true;
                        return;
                    }

                }
            }

            // Check Tie
            for (int row = 0; row < Container.RowDefinitions.Count; row++)
            {
                for (int column = 0; column < Container.ColumnDefinitions.Count; column++)
                {
                    if (board[row, column] == Tokens.Free)
                    {

                        GameEnded = false;
                        return;
                    }
                    GameEnded = true;
                }
            }
            if (GameEnded)
            {
                Container.Children.Cast<Button>().ToList().ForEach(button =>
                {
                    if (button.Background == RedToken)
                        button.Background = BoardGridTieRed;
                    else if (button.Background == YellowToken)
                        button.Background = BoardGridTieYellow;
                });
            }
        }

        // TO DO:
        //
        // Remove Mouse Hover image change
    }
}
