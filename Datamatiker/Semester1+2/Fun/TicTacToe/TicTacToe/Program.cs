using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize Board and Menu
            Board board = new Board(3);
            Menu menu = new Menu();

            // Start the Tic tac toe game
            menu.Show();
            int stop = int.Parse(Console.ReadLine());
            Game(menu, board, stop);

            // To do list:
            // Catch for not typing an integer
        }

        static void Game(Menu menu, Board board, int stop = 1)
        {
            if (stop == 0)
                Environment.Exit(0);            

            // Select a place that does not have a token
            do
            {
                Console.Clear();
                board.PrintBoard();

                // Get place for token
                Console.Write("\nPlease enter the row: ");
                int row = int.Parse(Console.ReadLine());
                Console.Write("Please enter the column: ");
                int column = int.Parse(Console.ReadLine());

                int[] place = new int[2] { row, column };                
                board.SelectPlace(place[0], place[1]);

            } while (board.SelectedPlace == null);

            // Set token
            board.SetValue();

            // Change player and restart for input
            board.ChangePlayer();
            Game(menu, board);
        }
    }
}
