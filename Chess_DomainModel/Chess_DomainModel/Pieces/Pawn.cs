using Chess_DomainModel.Enums;

namespace Chess_DomainModel.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(PieceColor color) : base(color, GetSymbolColor(color))
        {
        }

        private static string GetSymbolColor(PieceColor color)
        {
            return color == PieceColor.White ? "♙" : "♟";
        }
    }
}
