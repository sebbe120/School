using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;

namespace Chess.ChessPieces
{
    public abstract class ChessPiece
    {
        private string name;
        private PlayerColor player;

        public ChessPiece(PlayerColor color)
        {
            Player = color;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public PlayerColor Player
        {
            get { return player; }
            private set { player = value; }
        }

        public void GetForegroundText(Button btn)
        {
            if (Player == PlayerColor.White)
            {
                btn.Foreground = Brushes.White;
            }

            else
            {
                btn.Foreground = Brushes.Black;
            }

            btn.Content = Name;
        }
        
        // Returns a list of possible moves
        public virtual (int, int)[] GetPossibleMoves(Button btn, ChessBoard board, ChessPiece chessPiece)
        {
            return null;
        }
    }
}
