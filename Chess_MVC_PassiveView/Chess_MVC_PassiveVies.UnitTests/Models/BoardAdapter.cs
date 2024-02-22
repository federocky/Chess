using Chess_MVC_PassiveView.Models;

namespace Chess_MVC_PassiveView.UnitTests.Models
{
    internal class BoardAdapter : Board
    {
        public void setPiece(Piece piece, Coordinate coordinate)
        {
            board[coordinate.GetRow()][coordinate.GetColumn()] = piece;
        }
    }
}
