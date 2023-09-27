using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TicTacToe_WPF
{
    public partial class MainWindow : Window
    {
        private Tokens[,] board;
        
        private bool player1Turn;

        private bool GameEnded;

        public MainWindow()
        {
            InitializeComponent();

            NewGame();
        }

        //Starts a new game and clears all values back to the start
        private void NewGame()
        {
            // Create a new blank array of free cells
            board = new Tokens[3, 3];

            // Make sure Player 1 starts the game
            player1Turn = true;

            // Reset all buttons on the board
            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                // Change background, foreground and content to default values
                button.Content = string.Empty;
                button.Background = Brushes.White;
                button.Foreground = Brushes.Blue;
            });

            // Make sure the game hasn't finished
            GameEnded = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Start a new game on the click after it finished
            if (GameEnded)
            {
                NewGame();
                return;
            }

            // Cast the sender to a button
            Button button = (Button)sender;

            // Find the buttons position in the array
            int column = Grid.GetColumn(button);
            int row = Grid.GetRow(button);

            // Don't do anything if the cell already has a value in it
            if (board[column, row] != Tokens.Free)
                return;

            // Set the cell value based on which players turn it is
            board[column, row] = player1Turn ? Tokens.Cross : Tokens.Nought;

            // Set button text to the result
            button.Content = player1Turn ? "X" : "O";

            // Change noughts to red
            if (!player1Turn)
                button.Foreground = Brushes.Red;

            // Change player
            player1Turn = !player1Turn;

            // Check for a winner
            CheckForWinner();
        }


        private void CheckForWinner()
        {
            #region Horizontal Wins

            // Check for horizontal wins
            //
            //  - Row 0
            //
            if (board[0, 0] != Tokens.Free && (board[0, 0] & board[0, 1] & board[0, 2]) == board[0, 0])
            {
                // Game ends
                GameEnded = true;

                // Highlight winning cells in green
                
                Button0_0.Background = Button0_1.Background = Button0_2.Background = Brushes.Green;
            }
            //
            //  - Row 1
            //
            if (board[1, 0] != Tokens.Free && (board[1, 0] & board[1, 1] & board[1, 2]) == board[1, 0])
            {
                // Game ends
                GameEnded = true;

                // Highlight winning cells in green
                Button1_0.Background = Button1_1.Background = Button1_2.Background = Brushes.Green;
            }
            //
            //  - Row 2
            //
            if (board[2, 0] != Tokens.Free && (board[2, 0] & board[2, 1] & board[2, 2]) == board[2, 0])
            {
                // Game ends
                GameEnded = true;

                // Highlight winning cells in green
                Button2_0.Background = Button2_1.Background = Button2_2.Background = Brushes.Green;
            }

            #endregion

            #region Vertical Wins

            // Check for vertical wins
            //
            //  - Column 0
            //
            if (board[0, 0] != Tokens.Free && (board[0, 0] & board[1, 0] & board[2, 0]) == board[0, 0])
            {
                // Game ends
                GameEnded = true;

                // Highlight winning cells in green
                Button0_0.Background = Button1_0.Background = Button2_0.Background = Brushes.Green;
            }
            //
            //  - Column 1
            //
            if (board[0, 1] != Tokens.Free && (board[0, 1] & board[1, 1] & board[2, 1]) == board[0, 1])
            {
                // Game ends
                GameEnded = true;

                // Highlight winning cells in green
                Button0_1.Background = Button1_1.Background = Button2_1.Background = Brushes.Green;
            }
            //
            //  - Column 2
            //
            if (board[0, 2] != Tokens.Free && (board[0, 2] & board[1, 2] & board[2, 2]) == board[0, 2])
            {
                // Game ends
                GameEnded = true;

                // Highlight winning cells in green
                Button0_2.Background = Button1_2.Background = Button2_2.Background = Brushes.Green;
            }

            #endregion

            #region Diagonal Wins

            // Check for diagonal wins
            //
            //  - Top Left Bottom Right
            //
            if (board[0, 0] != Tokens.Free && (board[0, 0] & board[1, 1] & board[2, 2]) == board[0, 0])
            {
                // Game ends
                GameEnded = true;

                // Highlight winning cells in green
                Button0_0.Background = Button1_1.Background = Button2_2.Background = Brushes.Green;
            }
            //
            //  - Top Right Bottom Left
            //
            if (board[2, 0] != Tokens.Free && (board[2, 0] & board[1, 1] & board[0, 2]) == board[2, 0])
            {
                // Game ends
                GameEnded = true;

                // Highlight winning cells in green
                Button2_0.Background = Button1_1.Background = Button0_2.Background = Brushes.Green;
            }

            #endregion

            if (GameEnded)
                return;

            // Check if the board is full

            bool isFull = false;

            foreach(Tokens token in board)
            {
                if (token == Tokens.Free)
                {
                    isFull = true;
                    break;
                }
            }

            // If the board is full, the game is a Tie
            if (!isFull)
            {
                // Game ended
                GameEnded = true;

                // Turn all cells gray
                Container.Children.Cast<Button>().ToList().ForEach(button =>
                {
                    button.Background = Brushes.Gray;
                });
            }
        }
    }
}