namespace Chess_DomainModel.Pieces.Moves
{
    public class DiagonalMove
    {
        public bool IsValidMove(Coordinate origin, Coordinate target, IBoard board)
        {
            int rowDifference = Math.Abs(target.GetRow() - origin.GetRow());
            int colDifference = Math.Abs(target.GetColumn() - origin.GetColumn());

            if (rowDifference != colDifference) return false; // Movimiento no es diagonal            

            var piecesInPath = GetDiagonalPathCoordinates(origin, target);
            var arePieceInTheWay = board.ArePieceInPath(piecesInPath);

            if (arePieceInTheWay) return false;

            return true;
        }


        public List<Coordinate> GetDiagonalPathCoordinates(Coordinate start, Coordinate end)
        {
            List<Coordinate> pathCoordinates = new List<Coordinate>();

            int rowDirection = Math.Sign(end.GetRow() - start.GetRow());
            int colDirection = Math.Sign(end.GetColumn() - start.GetColumn());

            int currentRow = start.GetRow() + rowDirection;
            int currentCol = start.GetColumn() + colDirection;

            while (currentRow != end.GetRow() || currentCol != end.GetColumn())
            {
                pathCoordinates.Add(new Coordinate(currentRow, currentCol));
                currentRow += rowDirection;
                currentCol += colDirection;
            }

            return pathCoordinates;
        }
    }
}
