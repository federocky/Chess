using Chess_DomainModel.Enums;
using Chess_DomainModel.Pieces;

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

        protected bool IsValidBasicMove(Coordinate origin, Coordinate target, IBoard board)
        {
            var isMyPieceInTarget = board.GetPiece(target) != null && board.GetPiece(target).IsColor(color);
            if (isMyPieceInTarget)
            {
                return false;
            }

            if (origin.Equals(target))
            {
                return false;
            }

            return true; 
        }

        //TODO: validacion general de que nadie se puede ir si esto pone en peligro al rey (esta es chunga)
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