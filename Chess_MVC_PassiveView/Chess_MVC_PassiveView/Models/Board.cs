using Chess_MVC_PassiveView.Models.Pieces;

namespace Chess_MVC_PassiveView.Models
{
    internal class Board
    {
        private Piece[][] board { get; set; }
        private Piece pieceDeleted { get; set; }
        private Coordinate lastMoveOrigin { get; set; }
        private Coordinate lastMoveTarget { get; set; }


        public Piece GetPiece(Coordinate coordinate)
        {
            var rowOutOfBounds = coordinate.GetRow() < 0 || coordinate.GetRow() > 7;
            var colOutOfBounds = coordinate.GetColumn() < 0 || coordinate.GetColumn() > 7;

            if (rowOutOfBounds || colOutOfBounds) return new NullPiece();

            return this.board[coordinate.GetRow()][coordinate.GetColumn()];
        }

    }
}
