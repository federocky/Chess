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
        public bool hasMove { get; set; }

        public King(PieceColor color) : base(color, GetSymbolColor(color))
        {
            hasMove = false;
        }

        private static string GetSymbolColor(PieceColor color)
        {
            return color == PieceColor.White ? "♔" : "♚";
        }

        //TODO: hacer el enroque
        public override bool IsValidMove(Coordinate origin, Coordinate target, IBoard board)
        {
            if(IsValidCastling(origin, target, board)) return true;

            if (target.GetRow() > origin.GetRow() + 1 || target.GetRow() < origin.GetRow() - 1 ||
               target.GetColumn() > origin.GetColumn() + 1 || target.GetColumn() < origin.GetColumn() - 1) return false;

            return true;
        }

        private bool IsValidCastling(Coordinate origin, Coordinate target, IBoard board)
        {
            if (hasMove) return false;

            var row = color == PieceColor.White ? 0 : 7;

            var isMoveRight = target.GetColumn() == origin.GetColumn() + 2;
            var isMoveLeft = target.GetColumn() == origin.GetColumn() - 2;

            if(!isMoveLeft && !isMoveRight) return false;

            var rook = isMoveLeft ? board.GetPiece(new Coordinate(row, 0)) : board.GetPiece(new Coordinate(row, 7));

            if(rook is not Rook) return false;

            if (((Rook)rook).HasMove()) return false;

            var path = isMoveLeft ?
                new List<Coordinate> { new Coordinate(row, origin.GetColumn() - 1), new Coordinate(row, origin.GetColumn() - 2) } :
                new List<Coordinate> { new Coordinate(row, origin.GetColumn() + 1), new Coordinate(row, origin.GetColumn() + 2) } ;

            if(board.ArePieceInPath(path)) return false;

            board.Castle(color, isMoveLeft);

            return true;
        }
    }
}
