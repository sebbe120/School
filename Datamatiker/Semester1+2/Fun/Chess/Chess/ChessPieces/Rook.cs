using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Chess.ChessPieces
{
    public class Rook : ChessPiece
    {
        public Rook(PlayerColor color) : base(color)
        {
            base.Name = this.GetType().Name;
        }
    }
}
