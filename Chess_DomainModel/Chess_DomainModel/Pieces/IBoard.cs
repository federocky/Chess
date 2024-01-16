namespace Chess_DomainModel.Pieces
{
    public interface IBoard
    {
        public bool ArePieceInPath(List<Coordinate> coordinates);
        public Piece GetPiece(Coordinate coordinate);
    }
}