using Chess_DomainModel.Enums;
using Chess_DomainModel.Pieces.Moves;

namespace Chess_DomainModel.Pieces
{
    public class Rook : Piece
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
            if (!IsValidBasicMove(origin, target, board)) return false;
            return straightMove.IsValidMove(origin, target, board);
        }


    }
}
