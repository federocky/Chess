using Chess_DomainModel.Enums;

namespace Chess_DomainModel.Pieces
{
    public class Pawn : Piece
    {

        public Pawn(PieceColor color) : base(color, GetSymbolColor(color))
        {
        }

        private static string GetSymbolColor(PieceColor color)
        {
            return color == PieceColor.White ? "♙" : "♟";
        }


        public override bool IsValidMove(Coordinate origin, Coordinate target, IBoard board)
        {
            if (!IsValidBasicMove(origin, target, board)) return false;

            var pieceInDestination = board.GetPiece(new Coordinate(target.GetRow(), target.GetColumn()));

            var originRow = origin.GetRow();
            var originColumn = origin.GetColumn();
            var targetRow = target.GetRow();
            var targetColumn = target.GetColumn();

            if (color == PieceColor.White)
            {
                var moveOneForward = targetRow == originRow + 1 && targetColumn == originColumn;
                var moveTwoForward = targetRow == originRow + 2  && targetColumn == originColumn;
                var moveDiagonal = targetRow == originRow + 1 && ( targetColumn == originColumn + 1 || targetColumn == originColumn -1);
                var arePieceInTheWay = board.ArePieceInPath(new List<Coordinate> { new Coordinate(originRow + 1, originColumn)});

                if(moveOneForward && pieceInDestination is NullPiece) return true;
                if(moveTwoForward && origin.GetRow() == 1 && !arePieceInTheWay && pieceInDestination is NullPiece) return true;
                if(moveDiagonal && pieceInDestination.IsColor(PieceColor.Black)) return true;

            } else if (color == PieceColor.Black)
            {
                var moveOneForward = targetRow == originRow - 1 && originColumn == targetColumn;
                var moveTwoForward = targetRow == originRow - 2 && originColumn == targetColumn;
                var moveDiagonal = targetRow == originRow - 1 && (targetColumn == originColumn - 1 || targetColumn == originColumn +1);
                var arePieceInTheWay = board.ArePieceInPath(new List<Coordinate> { new Coordinate(originRow - 1, originColumn) });

                if (moveOneForward && pieceInDestination is NullPiece) return true;
                if (moveTwoForward && originRow == 6 && !arePieceInTheWay && pieceInDestination is NullPiece) return true;
                if (moveDiagonal && pieceInDestination.IsColor(PieceColor.White)) return true;
            }

            return false;
        }

    }
}
