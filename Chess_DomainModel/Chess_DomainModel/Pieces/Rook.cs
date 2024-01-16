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

            var boxesAffected = GetBoxesInMyWay(origin, target);

            var arePieceInTheWay = board.ArePieceInPath(boxesAffected);

            if ((isSameRow || isSameColumn) &&  !arePieceInTheWay) return true;

            return false;
        }

        private List<Coordinate> GetBoxesInMyWay(Coordinate origin, Coordinate target)
        {
            var coordinates = new List<Coordinate>();

            var minorRow = Math.Min(origin.GetRow(), target.GetRow());
            var majorRow = Math.Max(target.GetRow(), origin.GetRow());
            var minorCol = Math.Min(origin.GetColumn(), target.GetColumn());
            var majorCol = Math.Max(target.GetColumn(), origin.GetColumn());
                
            for (int i = minorRow + 1; i < majorRow; i++)
            {
                coordinates.Add(new Coordinate(i, origin.GetColumn()));
            }            
                
            for (int i = minorCol + 1; i < majorCol; i++)
            {
                coordinates.Add(new Coordinate(origin.GetRow(), i));
            }            

            return coordinates;
        }
    }
}
