using Chess_MVP_ModelViewPresenter.Enums;

namespace Chess_MVP_ModelViewPresenter.Models.Pieces
{
    public class King : Piece
    {
        public bool hasMove { get; set; }

        public King(PieceColor color) : base(color, GetSymbolColor(color))
        {
            hasMove = false;
        }

        private static string GetSymbolColor(PieceColor color)
        {
            return color == PieceColor.White ? "♔" : "♚";
        }

        public override bool IsValidMove(Coordinate origin, Coordinate target, IBoard board)
        {
            if(IsValidCastling(origin, target, board)) return true;

            if (target.GetRow() > origin.GetRow() + 1 || target.GetRow() < origin.GetRow() - 1 ||
               target.GetColumn() > origin.GetColumn() + 1 || target.GetColumn() < origin.GetColumn() - 1) return false;

            hasMove = true;
            return true;
        }

        private bool IsValidCastling(Coordinate origin, Coordinate target, IBoard board)
        {
            if (hasMove) return false;

            var row = color == PieceColor.White ? 0 : 7;

            var isMoveRight = target.GetColumn() == origin.GetColumn() + 2;
            var isMoveLeft = target.GetColumn() == origin.GetColumn() - 2;

            if(!isMoveLeft && !isMoveRight) return false;

            var rook = isMoveLeft ? board.GetPiece(new Coordinate(row, 0)) : board.GetPiece(new Coordinate(row, 7));

            if(rook is not Rook || ((Rook)rook).HasMove()) return false;

            var path = isMoveLeft ?
                new List<Coordinate> { new Coordinate(row, origin.GetColumn() - 1), new Coordinate(row, origin.GetColumn() - 2) } :
                new List<Coordinate> { new Coordinate(row, origin.GetColumn() + 1), new Coordinate(row, origin.GetColumn() + 2) } ;

            if(board.ArePieceInPath(path)) return false;

            board.Castle(color, isMoveLeft);

            hasMove = true;
            return true;
        }
    }
}
