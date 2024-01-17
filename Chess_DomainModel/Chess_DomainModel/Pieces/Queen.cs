using Chess_DomainModel.Enums;
using Chess_DomainModel.Pieces.Moves;

namespace Chess_DomainModel.Pieces
{
    public class Queen : Piece
    {
        private DiagonalMove diagonalMove { get; set; }
        private StraightMove straightMove { get; set; }

        public Queen(PieceColor color) : base(color, GetSymbolColor(color))
        {
            diagonalMove = new DiagonalMove();
            straightMove= new StraightMove();
        }

        private static string GetSymbolColor(PieceColor color)
        {
            return color == PieceColor.White ? "♕" : "♛";
        }

        public override bool IsValidMove(Coordinate origin, Coordinate target, IBoard board)
        {
            return diagonalMove.IsValidMove(origin, target, board) || straightMove.IsValidMove(origin, target, board);
        }
    }
}
