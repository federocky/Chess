using Chess_MVC_PassiveView.Constrollers;
using Chess_MVC_PassiveView.Models;

namespace Chess_MVC_PassiveView
{
    internal class Chess
    {
        private Board board { get; set; }
        private Turn turn { get; set; }
        private GameStatus gameStatus { get; set; }
        private PlayController playController { get; set; }
        private ResumeController resumeController { get; set; }

        public Chess()
        {
            board = new Board();
            turn = new Turn();
            gameStatus = new GameStatus();
            playController = new PlayController(board, turn, gameStatus);
            resumeController = new ResumeController(board, turn, gameStatus);
        }


        protected void play()
        {
            do
            {
                playController.control();
            } while (resumeController.control());
        }

        static void Main(string[] args)
        {
          new Chess().play();
        }
    }
}