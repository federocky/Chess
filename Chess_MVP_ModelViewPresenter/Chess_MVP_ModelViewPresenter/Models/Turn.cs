using Chess_MVP_ModelViewPresenter.Enums;

namespace Chess_MVP_ModelViewPresenter.Models
{
    internal class Turn
    {
        private PieceColor playing { get; set; }

        public Turn()
        {
            playing = PieceColor.White;
        }

        public void Next()
        {
            playing = playing == PieceColor.White ? PieceColor.Black : PieceColor.White;
        }

        public PieceColor GetPlaying()
        {
            return playing;
        }

        public void Restart(PieceColor player = PieceColor.White)
        {
            playing = player;
        }
    }
}
