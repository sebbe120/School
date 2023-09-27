using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ConnectFour
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();

            // Menu options
            Console.WriteLine("## Connect Four ##");
            Console.WriteLine("## 1. PvP       ##");
            Console.WriteLine("## 2. VS AI     ##\n");
            Console.WriteLine("## 0. Exit      ##\n");
            Console.Write("Enter here: ");

            // Get menu option
            int input;
            do
            {
                input = int.Parse(Console.ReadLine());
            } while (input < 0 || input > 2);
            Console.Clear();

            switch (input)
            {
                case 1:
                    GamePlayers(board);
                    break;

                case 2:
                    GameRandom(board, false);
                    break;

                case 0:
                    Console.WriteLine("Goodbye!");
                    break;
            }
        }

        // Simulates a game of Connect Four with randomly chosen moves
        static void GameRandom(Board board, bool verbose = true)
        {
            Random r = new Random();

            // Create a list of moves, for a random simulated game of Connect 4
            List<int> moves = new List<int>();
            for (int i = 1; i < 7; i++)
            {
                moves.AddRange(Enumerable.Range(0, 7));
            }

            while (moves.Count != 0)
            {
                if (verbose)
                    board.PrintBoard();
                int placeIndex = r.Next(0, moves.Count);
                int place = moves[placeIndex];
                board.SetToken(place);
                moves.RemoveAt(placeIndex);
            }
        }

        // Connect Four with 2 players
        static void GamePlayers(Board board)
        {
            board.PrintBoard();
            int column;
            int row;
            do
            {
                Console.WriteLine("Please enter a column to place token:");
                column = int.Parse(Console.ReadLine());
                row = board.GetRow(column);
            } while (row == -1);
            Console.Clear();
            board.SetToken(column);
            GamePlayers(board);
        }
    }
}