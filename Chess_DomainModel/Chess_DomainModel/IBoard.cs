using Chess_DomainModel.Enums;

namespace Chess_DomainModel
{
    public interface IBoard
    {
        public void MovePiece(Coordinate origin, Coordinate target);
        public bool MovementProvokeCheck(Coordinate origin, Coordinate target, PieceColor color);
        public bool ArePieceInPath(List<Coordinate> coordinates);
        public Piece GetPiece(Coordinate coordinate);
        public bool IsCheckOn(PieceColor colorUnderAttack);
    }
}