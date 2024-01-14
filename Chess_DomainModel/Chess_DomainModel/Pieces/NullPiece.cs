using Chess_DomainModel.Enums;

namespace Chess_DomainModel.Pieces
{
    public class NullPiece : Piece
    {
        public NullPiece() : base(PieceColor.nullColor, "-")
        {
        }
    }
}
