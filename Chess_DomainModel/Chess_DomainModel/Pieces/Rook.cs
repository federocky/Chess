using Chess_DomainModel.Enums;

namespace Chess_DomainModel.Pieces
{
    public class Rook : Piece
    {
        public Rook(PieceColor color) : base(color, GetSymbolColor(color))
        {
        }
        private static string GetSymbolColor(PieceColor color)
        {
            return color == PieceColor.White ? "♖" : "♜";
        }


        public override bool IsValidMove(Coordinate origin, Coordinate target, IBoard board)
        {
            var isSamePosition = origin.GetColumn() == target.GetColumn() && origin.GetRow() == target.GetRow();
            var isSameRow = origin.GetRow() == target.GetRow();
            var isSameColumn = origin.GetColumn() == target.GetColumn();

            if (isSamePosition) return false;

            var boxesAffected = GetBoxesAffected(origin, target);

            var arePieceInTheWay = board.AreTherePiece(boxesAffected);

            if ((isSameRow || isSameColumn) &&  !arePieceInTheWay) return true;

            return false;
        }

        private Coordinate[] GetBoxesAffected(Coordinate origin, Coordinate target)
        {
            return new Coordinate[] { }; //TODO: implement this.
        }
    }
}
