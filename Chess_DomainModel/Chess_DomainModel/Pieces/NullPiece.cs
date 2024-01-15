using Chess_DomainModel.Enums;

namespace Chess_DomainModel.Pieces
{
    public class NullPiece : Piece
    {
        public NullPiece() : base(PieceColor.nullColor, "-")
        {
        }

        public override bool IsValidMove(Coordinate origin, Coordinate target, IBoard board)
        {
            throw new NotImplementedException();
        }
    }
}
