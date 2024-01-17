using Chess_DomainModel.Enums;
using Chess_DomainModel.Pieces.Moves;

namespace Chess_DomainModel.Pieces
{
    public class Bishop : Piece
    {
        private DiagonalMove diagonalMove { get; set; }
        public Bishop(PieceColor color) : base(color, GetSymbolColor(color))
        {             
            diagonalMove = new DiagonalMove();
        }

        private static string GetSymbolColor(PieceColor color)
        {
            return color == PieceColor.White ? "♗" : "♝";
        }

        public override bool IsValidMove(Coordinate origin, Coordinate target, IBoard board)
        {   
            return diagonalMove.IsValidMove(origin, target, board);
        }

    }
}
