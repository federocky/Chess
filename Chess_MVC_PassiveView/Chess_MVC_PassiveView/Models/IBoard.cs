namespace Chess_MVC_PassiveView.Models
{
    internal interface IBoard
    {
        public bool ArePieceInPath(List<Coordinate> coordinates);
        public Piece GetPiece(Coordinate coordinate);
    }
}
