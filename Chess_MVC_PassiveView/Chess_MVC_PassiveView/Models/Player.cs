using Chess_MVC_PassiveView.Enums;

namespace Chess_MVC_PassiveView.Models
{
    internal class Player
    {
        private readonly PieceColor color;

        public Player(PieceColor color)
        {
            this.color = color;
        }

        public void Play(Board board, GameStatus gameStatus)
        {



        }
    }
}
