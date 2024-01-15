namespace Chess_DomainModel.Pieces
{
    public interface IBoard
    {
        public bool AreTherePiece(List<Coordinate> coordinates);
        public Piece GetPiece(Coordinate coordinate);
    }
}