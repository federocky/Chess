using Chess_DomainModel.Enums;

namespace Chess_DomainModel
{
    public class Turn
    {
        private Player playerWhite { get; set; }
        private Player playerBlack { get; set; }
        private PieceColor playing { get; set; }

        public Turn()
        {
            playing = PieceColor.Black;
            playerBlack = new Player(PieceColor.Black);
            playerWhite = new Player(PieceColor.White);
        }

        public void Play(Board board, GameStatus gameStatus)
        {
            if(playing == PieceColor.Black)
            {
                playing = PieceColor.White;
                playerWhite.Play(board, gameStatus);
            }
            else
            {
                playing = PieceColor.Black;
                playerBlack.Play(board, gameStatus);
            }
        }

        public PieceColor GetLastPlayerColor()
        {
            return playing;
        }
    }
}