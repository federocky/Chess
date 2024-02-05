using Chess_MVC_PassiveView.Enums;

namespace Chess_MVC_PassiveView.Models
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

        public void SetPlaying(PieceColor color) 
        {
            playing = color;
        }
    }
}
