using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks.Dataflow;

namespace TicTacToeGUI
{
    public class Board
    {
        public int length;
        public int[,] board; // Matrix with the tokens
        public bool player = true; // true = Player 1, false = Player 2
        public bool IsTie = false;

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
        public bool SetValue(int row, int column)
        {
            if (player)
                board[row, column] = 1;
            else if (!player)
                board[row, column] = 2;

            return (CheckWin());
        }

        // Get player token
        public string GetToken()
        {
            // Get Player
            string token = "O";
            if (!player)
                token = "X";

            return token;
        }

        // Checks the board to see if a person has won
        public bool CheckWin()
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
                return true;
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
                return true;
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
                return true;
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
                return true;
            }

            // Check if there is a tie, if no player has won
            return (CheckTie());
        }

        // Checks the board to see if all places are full, without a winner
        public bool CheckTie()
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
                // Write something for the draw
                IsTie = true;
                return true;
            }

            return false;
        }

        // Change the player
        public void ChangePlayer()
        {
            player = !player;
        }
    }
}
