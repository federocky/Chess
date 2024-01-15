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

        //TODO: turno tiene que conocer al board?
        public void Play(Board board)
        {
            if(playing == PieceColor.Black)
            {
                playing = PieceColor.White;
                playerWhite.Play(board);
            }
            else
            {
                playing = PieceColor.Black;
                playerBlack.Play(board);
            }
        }
    }
}