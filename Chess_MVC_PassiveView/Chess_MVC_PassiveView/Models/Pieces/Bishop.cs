using Chess_MVC_PassiveView.Enums;

namespace Chess_MVC_PassiveView.Models.Pieces
{
    internal class Bishop : Piece
    {
        private DiagonalMove diagonalMove { get; set; }
        public Bishop(PieceColor color) : base(color, GetSymbolColor(color))
        {
            diagonalMove = new DiagonalMove();
        }

        private static string GetSymbolColor(PieceColor color)
        {
            return color == PieceColor.White ? "♗" : "♝";
        }

        public override bool IsValidMove(Coordinate origin, Coordinate target, IBoard board)
        {
            return diagonalMove.IsValidMove(origin, target, board);
        }

    }
}
