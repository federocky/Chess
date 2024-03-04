using Chess_MVP_ModelViewPresenter.Enums;

namespace Chess_MVP_ModelViewPresenter.Models.Pieces
{
    public class Bishop : Piece
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
