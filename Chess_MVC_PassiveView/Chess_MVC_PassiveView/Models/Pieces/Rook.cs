using Chess_MVC_PassiveView.Enums;

namespace Chess_MVC_PassiveView.Models.Pieces
{
    internal class Rook : Piece
    {
        private StraightMove straightMove { get; set; }
        private bool hasMove { get; set; }

        public Rook(PieceColor color) : base(color, GetSymbolColor(color))
        {
            straightMove = new StraightMove();
            hasMove = false;
        }

        private static string GetSymbolColor(PieceColor color)
        {
            return color == PieceColor.White ? "♖" : "♜";
        }

        public override bool IsValidMove(Coordinate origin, Coordinate target, IBoard board)
        {
            if(straightMove.IsValidMove(origin, target, board))
            {
                hasMove = true;
                return true;
            }
            return false;
        }

        public bool HasMove()
        {
            return hasMove;
        }
    }
}
