using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFourGUI
{
    public static class Logic
    {
        // Checks if a player has connected 4 tokens
        public static bool CheckWon(Board board)
        {
            if (CheckRow(board))
                return true;

            if (CheckColumn(board))
                return true;

            if (CheckDiagonalLeft(board))
                return true;

            if (CheckDiagonalRight(board))
                return true;

            return false;
        }

        // Checks if a row has 4 connected tokens (Hardcoded)
        public static bool CheckRow(Board board)
        {
            bool won = false;

            for (int row = 0; row < board.length; row++)
            {
                for (int column = 0; column < board.width - 3; column++)
                {
                    // Check if place has a token
                    if (board.board[row, column] != board.GetPlayer())
                    {
                        continue;
                    }

                    if (board.board[row, column] == board.board[row, column + 1] &&
                        board.board[row, column + 1] == board.board[row, column + 2] &&
                        board.board[row, column + 2] == board.board[row, column + 3])
                    {
                        won = true;
                        row = board.length;
                        break;
                    }
                }
            }

            return won;
        }

        // Checks if a column has 4 connected tokens (Hardcoded)
        public static bool CheckColumn(Board board)
        {
            bool won = false;

            for (int column = 0; column < board.width; column++)
            {
                for (int row = 0; row < board.length - 3; row++)
                {
                    // Check if place has a token
                    if (board.board[row, column] != board.GetPlayer())
                    {
                        continue;
                    }

                    if (board.board[row, column] == board.board[row + 1, column] &&
                        board.board[row + 1, column] == board.board[row + 2, column] &&
                        board.board[row + 2, column] == board.board[row + 3, column])
                    {
                        won = true;
                        column = board.width;
                        break;
                    }
                }
            }

            return won;
        }

        // Checks if a rigth diagonal has 4 connected tokens (Hardcoded)
        public static bool CheckDiagonalLeft(Board board)
        {
            bool won = false;

            for (int row = 0; row < board.length - 3; row++)
            {
                for (int column = 0; column < board.width - 3; column++)
                {
                    // Check if place has a token
                    if (board.board[row, column] != board.GetPlayer())
                    {
                        continue;
                    }

                    if (board.board[row, column] == board.board[row + 1, column + 1] &&
                        board.board[row + 1, column + 1] == board.board[row + 2, column + 2] &&
                        board.board[row + 2, column + 2] == board.board[row + 3, column + 3])
                    {
                        won = true;
                        row = board.length;
                        break;
                    }
                }
            }

            return won;
        }

        // Checks if a rigth diagonal has 4 connected tokens (Hardcoded)
        public static bool CheckDiagonalRight(Board board)
        {
            bool won = false;

            for (int row = board.length - 1; row > 2; row--)
            {
                for (int column = 0; column < board.width - 3; column++)
                {
                    // Check if place has a token
                    if (board.board[row, column] != board.GetPlayer())
                    {
                        continue;
                    }

                    if (board.board[row, column] == board.board[row - 1, column + 1] &&
                        board.board[row - 1, column + 1] == board.board[row - 2, column + 2] &&
                        board.board[row - 2, column + 2] == board.board[row - 3, column + 3])
                    {
                        won = true;
                        row = 3;
                        break;
                    }
                }
            }

            return won;
        }

        // Checks if all places have a player
        public static bool CheckTie(Board board)
        {
            bool tie = true;

            for (int i = 0; i < board.length; i++)
            {
                for (int j = 0; j < board.width; j++)
                {
                    if (board.board[i, j] == 0)
                    {
                        tie = false;
                        i = board.length;
                        break;
                    }
                }
            }

            return tie;
        }
    }
}
