using Chess_MVC_PassiveView.Models;

namespace Chess_MVC_PassiveView.UnitTests.Models
{
    public class BoardAdapter : Board
    {
        public void SetPiece(Piece piece, Coordinate coordinate)
        {
            board[coordinate.GetRow()][coordinate.GetColumn()] = piece;
        }
    }
}
