using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;

namespace Chess.ChessPieces
{
    public class Pawn : ChessPiece
    {
        public Pawn(PlayerColor color) : base(color)
        {
            base.Name = this.GetType().Name;
        }
    }
}
