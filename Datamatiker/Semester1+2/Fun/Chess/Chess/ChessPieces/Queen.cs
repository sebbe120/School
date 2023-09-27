using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Chess.ChessPieces
{
    public class Queen : ChessPiece
    {
        public Queen(PlayerColor color) : base(color)
        {
            base.Name = this.GetType().Name;
        }
    }
}
