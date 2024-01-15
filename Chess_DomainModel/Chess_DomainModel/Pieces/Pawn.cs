using Chess_DomainModel.Enums;

namespace Chess_DomainModel.Pieces
{
    public class Pawn : Piece
    {
        private bool isFirstMove { get; set; }

        public Pawn(PieceColor color) : base(color, GetSymbolColor(color))
        {
            isFirstMove = true;
        }

        private static string GetSymbolColor(PieceColor color)
        {
            return color == PieceColor.White ? "♙" : "♟";
        }

        //TODO: no he tenido en cuenta que el negro va para abajo. revisar y pensar. Tampoco tengo en cuenta si el camino está libre
        public override bool IsValidMove(Coordinate origin, Coordinate target, IBoard board)
        {
            var isHorizontalMove = origin.GetRow() == target.GetRow();
            var isWhiteBackwardsMove = target.GetRow() <= origin.GetRow() && color == PieceColor.White;
            var isBlackBackwardsMove = target.GetRow() >= origin.GetRow() && color == PieceColor.Black;
            var isMoveOverTwoRows = target.GetRow() > origin.GetRow() + 2;
            var isDiagonalMoveOverOneCol = target.GetColumn() > origin.GetColumn() + 1;

            var pieceInDestination = board.GetPiece(new Coordinate(target.GetRow(), target.GetColumn()));

            var moveOneForward = target.GetRow() == origin.GetRow() + 1 && origin.GetColumn() == target.GetColumn();
            var moveTwoForward = target.GetRow() == origin.GetRow() + 2  && origin.GetColumn() == target.GetColumn();
            var moveDiagonal = target.GetRow() == origin.GetRow() + 1 && target.GetColumn() == origin.GetColumn() + 1;

            var verticalValidMoveButRivalInDestination = (moveOneForward || moveTwoForward) && (!pieceInDestination.IsColor(color) && pieceInDestination is not NullPiece);
            var diagonalValidMoveButNotRivalInDestination = moveDiagonal && (pieceInDestination.IsColor(color) || pieceInDestination is NullPiece);

            if (isHorizontalMove || isWhiteBackwardsMove || isBlackBackwardsMove || isMoveOverTwoRows || isDiagonalMoveOverOneCol || (moveTwoForward && !isFirstMove) ||
                pieceInDestination.IsColor(color) || verticalValidMoveButRivalInDestination || diagonalValidMoveButNotRivalInDestination) 
                return false;

            isFirstMove = false;

            return true;
        }

    }
}
