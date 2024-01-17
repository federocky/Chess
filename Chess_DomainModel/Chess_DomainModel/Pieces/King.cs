using Chess_DomainModel.Enums;

namespace Chess_DomainModel.Pieces
{
    public class King : Piece
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
            if (!IsValidBasicMove(origin, target, board)) return false;

            if (target.GetRow() > origin.GetRow() + 1 || target.GetRow() < origin.GetRow() - 1 ||
               target.GetColumn() > origin.GetColumn() + 1 || target.GetColumn() < origin.GetColumn() - 1) return false;

            return true;
        }
    }
}
