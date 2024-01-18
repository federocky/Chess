using Chess_DomainModel.Enums;

namespace Chess_DomainModel
{
    public abstract class Piece
    {
        protected PieceColor color { get; set; }
        private String symbol { get; set; }

        protected Piece(PieceColor color, string symbol)
        {
            this.color = color;
            this.symbol = symbol;
        }

        public abstract bool IsValidMove(Coordinate origin, Coordinate target, IBoard board);

        public bool IsColor(PieceColor color)
        {
            return this.color == color;
        }

        public override string ToString()
        {
            return $"{symbol}";
        }
    }
}