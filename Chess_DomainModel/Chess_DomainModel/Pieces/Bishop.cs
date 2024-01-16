using Chess_DomainModel.Enums;

namespace Chess_DomainModel.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(PieceColor color) : base(color, GetSymbolColor(color))
        {             
        }

        private static string GetSymbolColor(PieceColor color)
        {
            return color == PieceColor.White ? "♗" : "♝";
        }

        public override bool IsValidMove(Coordinate origin, Coordinate target, IBoard board)
        {
            int rowDifference = Math.Abs(target.GetRow() - origin.GetRow());
            int colDifference = Math.Abs(target.GetColumn() - origin.GetColumn());

            if (rowDifference != colDifference) return false; // Movimiento no es diagonal            

            var piecesInPath = GetDiagonalPathCoordinates(origin, target);
            var arePieceInTheWay = board.ArePieceInPath(piecesInPath);

            if (arePieceInTheWay) return false;

            return true;
        }


        private List<Coordinate> GetDiagonalPathCoordinates(Coordinate start, Coordinate end)
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
