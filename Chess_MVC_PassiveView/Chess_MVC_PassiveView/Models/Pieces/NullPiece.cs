using Chess_MVC_PassiveView.Enums;

namespace Chess_MVC_PassiveView.Models.Pieces
{
    internal class NullPiece : Piece
    {
        public NullPiece() : base(PieceColor.Null, "-")
        {
        }

        public override bool IsValidMove(Coordinate origin, Coordinate target, IBoard board)
        {
            throw new NotImplementedException();
        }
    }
}
