using Chess_MVC_PassiveView.Constrollers;
using Chess_MVC_PassiveView.Models;

namespace Chess_MVC_PassiveView
{
    internal class Chess
    {
        private Board board { get; set; }
        private Turn turn { get; set; }
        private GameStatus gameStatus { get; set; }
        private Logic logic { get; set; }

        public Chess()
        {
            board = new Board();
            turn = new Turn();
            gameStatus = new GameStatus();
            logic = new Logic(board, turn, gameStatus);
        }


        protected void play()
        {
            AcceptorController acceptorController;
            do
            {
                acceptorController = logic.GetController();
                if(!acceptorController.IsNull())
                {
                    acceptorController.Control();
                }

            } while (!acceptorController.IsNull());
        }

        static void Main(string[] args)
        {
          new Chess().play();
        }
    }
}