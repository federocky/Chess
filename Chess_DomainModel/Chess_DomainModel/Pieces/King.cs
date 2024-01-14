using Chess_DomainModel.Enums;

namespace Chess_DomainModel.Pieces
{
    public class King : Piece
    {
        public King(PieceColor color) : base(color, GetSymbolColor(color))
        {
        }

        private static string GetSymbolColor(PieceColor color)
        {
            return color == PieceColor.White ? "♔" : "♚";
        }
    }
}
