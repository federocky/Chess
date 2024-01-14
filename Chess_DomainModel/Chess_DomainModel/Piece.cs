using Chess_DomainModel.Enums;
using System.Drawing;

namespace Chess_DomainModel
{
    public abstract class Piece
    {
        private PieceColor color { get; set; }
        private String symbol { get; set; }

        protected Piece(PieceColor color, string symbol)
        {
            this.color = color;
            this.symbol = symbol;
        }

        public override string ToString()
        {
            return $"{symbol}";
        }
    }
}