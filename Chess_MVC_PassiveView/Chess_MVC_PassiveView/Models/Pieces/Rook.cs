using Chess_MVC_PassiveView.Enums;

namespace Chess_MVC_PassiveView.Models.Pieces
{
    internal class Rook : Piece
    {
        private StraightMove straightMove { get; set; }
        public Rook(PieceColor color) : base(color, GetSymbolColor(color))
        {
            straightMove = new StraightMove();
        }
        private static string GetSymbolColor(PieceColor color)
        {
            return color == PieceColor.White ? "♖" : "♜";
        }

        public override bool IsValidMove(Coordinate origin, Coordinate target, IBoard board)
        {
            return straightMove.IsValidMove(origin, target, board);
        }
    }
}
