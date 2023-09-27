using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFourGUI
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

        // Sets the player token at place
        public void SetToken(int row, int column)
        {
            board[row, column] = GetPlayer();
        }

        // Change the player
        public void ChangePlayer()
        {
            player = !player;
        }
    }
}
