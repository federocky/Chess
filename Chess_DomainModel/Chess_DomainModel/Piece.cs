using Chess_DomainModel.Enums;
using Chess_DomainModel.Pieces;
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

        public abstract bool IsValidMove(Coordinate origin, Coordinate target, IBoard board);

        public override string ToString()
        {
            return $"{symbol}";
        }
    }
}