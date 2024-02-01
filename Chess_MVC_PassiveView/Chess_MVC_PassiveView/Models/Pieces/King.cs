using Chess_MVC_PassiveView.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_MVC_PassiveView.Models.Pieces
{
    internal class King : Piece
    {
        public King(PieceColor color) : base(color, GetSymbolColor(color))
        {
        }

        private static string GetSymbolColor(PieceColor color)
        {
            return color == PieceColor.White ? "♔" : "♚";
        }

        //TODO: hacer el enroque
        public override bool IsValidMove(Coordinate origin, Coordinate target, IBoard board)
        {
            if (target.GetRow() > origin.GetRow() + 1 || target.GetRow() < origin.GetRow() - 1 ||
               target.GetColumn() > origin.GetColumn() + 1 || target.GetColumn() < origin.GetColumn() - 1) return false;

            return true;
        }
    }
}
