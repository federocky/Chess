using Chess_MVP_ModelViewPresenter.Models;

namespace Chess_MVP_ModelViewPresenter.UnitTests.Models
{
    public class BoardAdapter : Board
    {
        public void SetPiece(Piece piece, Coordinate coordinate)
        {
            board[coordinate.GetRow()][coordinate.GetColumn()] = piece;
        }
    }
}
