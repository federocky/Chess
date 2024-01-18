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

        public bool IsValidBasicMove(Coordinate origin, Coordinate target, IBoard board)
        {
            //check if there is a piece of my color in target
            if (board.GetPiece(target) != null && board.GetPiece(target).IsColor(color))
            {
                return false;
            }

            if (origin.Equals(target))
            {
                return false;
            }

            if(board.MovementProvokeCheck(origin, target, color))
            {
                return false;
            }

            return true; 
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