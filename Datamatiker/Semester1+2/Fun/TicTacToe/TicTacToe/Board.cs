using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks.Dataflow;

namespace TicTacToe
{
    public class Board
    {
        public int length;
        public int[,] board; // Matrix with the tokens
        public bool player = true; // true = Player 1, false = Player 2
        public int[] SelectedPlace;
        // Values on the board: 0: No values assigned, 1: Player 1, 2: Player 2
        public Board(int length)
        {
            this.length = length;
            // Sets all values of the board to 0 (No Player)
            board = new int[length, length];
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    board[i, j] = 0;
                }
            }
        }

        // Sets a value of the Board
        public void SetValue()
        {
            // Get Player
            int token = 1;
            if (!player)
                token = 2;

            board[SelectedPlace[0], SelectedPlace[1]] = token;
            CheckWin();
        }

        public int GetValue()
        {
            return board[SelectedPlace[0], SelectedPlace[1]];
        }

        // Select place on board
        public void SelectPlace(int row, int column)
        {
            // Check if the position is on the board
            if (row < 0 || row > length)
            {
                SelectedPlace = null;
                return;
            }
            if (column < 0 || column > length)
            {
                SelectedPlace = null;
                return;
            }

            SelectedPlace = new int[] { row, column };

            // Check if a place already has a player token
            if (this.GetValue() == 1 || this.GetValue() == 2)
            {
                Console.WriteLine("This place already has a player");
                SelectedPlace = null;
                return;
            }
        }

        // Checks the board to see if a person has won
        public void CheckWin()
        {
            bool won = false;

            // Get Player
            int token = 1;
            if (!player)
                token = 2;

            // Rows
            for (int i = 0; i < length; i++)
            {
                if (won)
                    break;

                for (int j = 0; j < board.GetLength(0) - 1; j++)
                {
                    if (board[i, j] != token)
                        break;

                    if (board[i, j] == board[i, j + 1])
                        won = true;
                    else
                    {
                        won = false;
                        break;
                    }
                }
            }

            if (won)
            {
                PrintBoard();
                Console.WriteLine("Player " + token + " has won!");
                Environment.Exit(0);
            }

            // Columns
            for (int i = 0; i < length; i++)
            {
                if (won)
                    break;

                //if (board[0, i] == token && board[1, i] == token && board[2, i] == token)
                //    won = true;

                for (int j = 0; j < length - 1; j++)
                {
                    if (board[j, i] != token)
                        break;

                    if (board[j, i] == board[j + 1, i])
                        won = true;
                    else
                    {
                        won = false;
                        break;
                    }
                }
            }

            if (won)
            {
                PrintBoard();
                Console.WriteLine("Player " + token + " has won!");
                Environment.Exit(0);
            }

            // Left Diagonal
            for (int i = 0; i < length - 1; i++)
            {
                if (board[i, i] != token)
                    break;

                if (board[i, i] == board[i + 1, i + 1])
                    won = true;
                else
                {
                    won = false;
                    break;
                }
            }

            if (won)
            {
                PrintBoard();
                Console.WriteLine("Player " + token + " has won!");
                Environment.Exit(0);
            }

            // Right Diagonal

            for (int i = 0; i < length - 1; i++)
            {
                if (board[i, length - 1 - i] != token)
                    break;

                if (board[i, length - 1 - i] == board[i + 1, length - 2 - i])
                    won = true;
                else
                {
                    won = false;
                    break;
                }
            }

            if (won)
            {
                PrintBoard();
                Console.WriteLine("Player " + token + " has won!");
                Environment.Exit(0);
            }

            // Check if there is a tie, if no player has won
            CheckTie();
        }

        // Checks the board to see if all places are full, without a winner
        public void CheckTie()
        {
            bool tie = false;
            int total = 0;

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    total += board[i, j];
                }
            }

            // 5*1 + 4*2 = 13
            if (total >= (Math.Ceiling((length * length + 0.0) / 2) * 1 + Math.Floor((length * length + 0.0) / 2) * 2))
                tie = true;

            if (tie)
            {
                PrintBoard();
                Console.WriteLine("The match is a tie!");
                Environment.Exit(0);
            }
        }

        // Change the player
        public void ChangePlayer()
        {
            player = !player;
        }

        // Prints the current Board
        public void PrintBoard()
        {
            // Get Player
            if (player)
                Console.Write("Player 1's turn:\n\n");
            else
                Console.Write("Player 2's turn:\n\n");
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (board[i, j] == 1)
                        Console.Write("O ");

                    else if (board[i, j] == 2)
                        Console.Write("X ");

                    else
                        Console.Write("0 ");
                }
                Console.Write("\n");
            }
        }
    }
}
