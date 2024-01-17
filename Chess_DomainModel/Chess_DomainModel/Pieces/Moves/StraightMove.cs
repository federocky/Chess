namespace Chess_DomainModel.Pieces.Moves
{
    public class StraightMove
    {

        public bool IsValidMove(Coordinate origin, Coordinate target, IBoard board)
        {
            var isSameRow = origin.GetRow() == target.GetRow();
            var isSameColumn = origin.GetColumn() == target.GetColumn();

            var boxesAffected = GetBoxesInPath(origin, target);

            var arePieceInTheWay = board.ArePieceInPath(boxesAffected);

            if ((isSameRow || isSameColumn) && !arePieceInTheWay) return true;

            return false;
        }

        private List<Coordinate> GetBoxesInPath(Coordinate origin, Coordinate target)
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
