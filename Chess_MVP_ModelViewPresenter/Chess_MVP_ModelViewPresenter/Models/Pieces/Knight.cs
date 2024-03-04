using Chess_MVP_ModelViewPresenter.Enums;

namespace Chess_MVP_ModelViewPresenter.Models.Pieces
{
    public class Knight : Piece
    {
        public Knight(PieceColor color) : base(color, GetSymbolColor(color))
        {
        }

        private static string GetSymbolColor(PieceColor color)
        {
            return color == PieceColor.White ? "♘" : "♞";
        }

        public override bool IsValidMove(Coordinate origin, Coordinate target, IBoard board)
        {
            var isVerticalMove = target.GetRow() == origin.GetRow() + 2 || target.GetRow() == origin.GetRow() - 2;
            var isHorizontalMove = target.GetColumn() == origin.GetColumn() + 2 || target.GetColumn() == origin.GetColumn() - 2;

            if (isVerticalMove && (target.GetColumn() == origin.GetColumn() + 1 || target.GetColumn() == origin.GetColumn() - 1)) return true;
            if (isHorizontalMove && (target.GetRow() == origin.GetRow() + 1 || target.GetRow() == origin.GetRow() - 1)) return true;

            return false;
        }
    }
}
