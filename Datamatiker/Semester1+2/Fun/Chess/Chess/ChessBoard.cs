using System;
using System.Collections.Generic;
using System.Text;
using Chess.ChessPieces;

namespace Chess
{
    public class ChessBoard
    {
        private ChessPiece[,] board;

        // Initializes the board with pieces
        public ChessBoard()
        {
            board = new ChessPiece[8, 8];

            board[1, 0] = new Pawn(PlayerColor.Black);
            board[1, 1] = new Pawn(PlayerColor.Black);
            board[1, 2] = new Pawn(PlayerColor.Black);
            board[1, 3] = new Pawn(PlayerColor.Black);
            board[1, 4] = new Pawn(PlayerColor.Black);
            board[1, 5] = new Pawn(PlayerColor.Black);
            board[1, 6] = new Pawn(PlayerColor.Black);
            board[1, 7] = new Pawn(PlayerColor.Black);

            board[0, 0] = new Rook(PlayerColor.Black);
            board[0, 1] = new Knight(PlayerColor.Black);
            board[0, 2] = new Bishop(PlayerColor.Black);
            board[0, 3] = new Queen(PlayerColor.Black);
            board[0, 4] = new King(PlayerColor.Black);
            board[0, 5] = new Bishop(PlayerColor.Black);
            board[0, 6] = new Knight(PlayerColor.Black);
            board[0, 7] = new Rook(PlayerColor.Black);

            board[6, 0] = new Pawn(PlayerColor.White);
            board[6, 1] = new Pawn(PlayerColor.White);
            board[6, 2] = new Pawn(PlayerColor.White);
            board[6, 3] = new Pawn(PlayerColor.White);
            board[6, 4] = new Pawn(PlayerColor.White);
            board[6, 5] = new Pawn(PlayerColor.White);
            board[6, 6] = new Pawn(PlayerColor.White);
            board[6, 7] = new Pawn(PlayerColor.White);

            board[7, 0] = new Rook(PlayerColor.White);
            board[7, 1] = new Knight(PlayerColor.White);
            board[7, 2] = new Bishop(PlayerColor.White);
            board[7, 3] = new Queen(PlayerColor.White);
            board[7, 4] = new King(PlayerColor.White);
            board[7, 5] = new Bishop(PlayerColor.White);
            board[7, 6] = new Knight(PlayerColor.White);
            board[7, 7] = new Rook(PlayerColor.White);
        }

        public ChessPiece[,] GetChessBoard()
        {
            return board;
        }
    }
}
