using Chess_MVC_PassiveView.Enums;

namespace Chess_MVC_PassiveView.Models
{
    public interface IBoard
    {
        public bool ArePieceInPath(List<Coordinate> coordinates);
        public Piece GetPiece(Coordinate coordinate);
        public void Castle(PieceColor color, bool isMoveLeft);
    }
}
