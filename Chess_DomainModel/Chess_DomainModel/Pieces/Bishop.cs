using Chess_DomainModel.Enums;

namespace Chess_DomainModel.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(PieceColor color) : base(color, GetSymbolColor(color))
        {             
        }

        private static string GetSymbolColor(PieceColor color)
        {
            return color == PieceColor.White ? "♗" : "♝";
        }
    }
}
