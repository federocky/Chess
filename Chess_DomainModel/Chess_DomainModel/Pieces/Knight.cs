using Chess_DomainModel.Enums;

namespace Chess_DomainModel.Pieces
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
            var originRow = origin.GetRow();
            var originColumn = origin.GetColumn();
            var targetRow = target.GetRow();
            var targetColumn = target.GetColumn();

            var isVerticalMove = targetRow == originRow + 2 || targetRow == originRow - 2;
            var isHorizontalMove = targetColumn == originColumn +2 || targetColumn == originColumn - 2;

            if (isVerticalMove && (targetColumn == originColumn + 1 || targetColumn == originColumn - 1)) return true;
            if (isHorizontalMove && (targetRow == originRow + 1 || targetRow == originRow - 1)) return true;

            return false;
        }
    }
}
