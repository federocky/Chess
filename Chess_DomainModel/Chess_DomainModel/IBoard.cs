namespace Chess_DomainModel
{
    public interface IBoard
    {
        public bool ArePieceInPath(List<Coordinate> coordinates);
        public Piece GetPiece(Coordinate coordinate);
    }
}