using Chess_MVP_ModelViewPresenter.Enums;

namespace Chess_MVP_ModelViewPresenter.Models
{
    internal class SavedGame
    {
        public string[][] PiecesDisposition { get; set; }
        public PieceColor Playing { get; set; }

        public SavedGame()
        {
            PiecesDisposition = new string[0][];
        }

        public SavedGame(string game)
        {
            PiecesDisposition = GetPiecesDisposition(game);
            Playing = game.Split(';')[1] == PieceColor.White.ToString() ? PieceColor.White : PieceColor.Black;
        }

        private string[][] GetPiecesDisposition(string savedGame)
        {
            string piecesDisposition = savedGame.Split(';')[0];
            string[][] chessBoard = new string[8][];

            for (int row = 0; row < 8; row++)
            {
                chessBoard[row] = new string[8];

                for (int col = 0; col < 8; col++)
                {
                    int index = (7 - row) * 8 + col;
                    chessBoard[row][col] = piecesDisposition[index].ToString();
                }
            }

            return chessBoard;
        }
    }

}
