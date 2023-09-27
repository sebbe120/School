using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFour
{
    public class Board
    {
        public int length = 6;
        public int width = 7;
        public int[,] board; // Matrix with the tokens
        private bool player = true; // true = Player 1, false = Player 2

        // Values on the board: 0: No values assigned, 1: Player 1, 2: Player 2
        // Sets all values of the board to 0 (No Player)
        public Board()
        {
            board = new int[length, width];
        }

        // Returns the player token
        public int GetPlayer()
        {
            int token;
            if (player)
                token = 1;
            else
                token = 2;

            return token;
        }

        // Returns the row for the given column
        public int GetRow(int column)
        {
            int place = -1;
            for (int row = length - 1; row >= 0; row--)
            {
                if (board[row, column] == 0)
                {
                    place = row;
                    break;
                }
            }

            return place;
        }

        // Sets the player token at place
        public void SetToken(int column)
        {
            int row = GetRow(column);

            board[row, column] = GetPlayer();

            // Check if the game is a tie
            if (Logic.CheckWon(this))
            {
                PrintBoard();
                Console.WriteLine("Player {0} won!", GetPlayer());
                Environment.Exit(0);
            }

            // Check if the game is a tie
            if (Logic.CheckTie(this))
            {
                PrintBoard();
                Console.WriteLine("The game is a Tie!");
                Environment.Exit(0);
            }

            ChangePlayer();
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
                for (int j = 0; j < width; j++)
                {
                    if (board[i, j] == 1)
                        Console.Write("O   ");

                    else if (board[i, j] == 2)
                        Console.Write("X   ");

                    else
                        Console.Write("+   ");
                }
                Console.Write("\n\n");
            }
        }
    }
}
