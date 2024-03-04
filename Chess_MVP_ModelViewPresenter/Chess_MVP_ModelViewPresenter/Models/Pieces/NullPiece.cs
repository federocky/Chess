using Chess_MVP_ModelViewPresenter.Enums;

namespace Chess_MVP_ModelViewPresenter.Models.Pieces
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
