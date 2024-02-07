using Chess_MVC_PassiveView.Constrollers;
using Chess_MVC_PassiveView.Models;
using Chess_MVC_PassiveView.Views;

namespace Chess_MVC_PassiveView
{
    internal class Chess
    {
        private Board board { get; set; }

        private IViewFacade viewFacade;
        private PlayController playController { get; set; }
        private ResumeController resumeController { get; set; }
        private GameStatus gameStatus { get; set; }

        public Chess()
        {
            board = new Board();
            gameStatus = new GameStatus();
            viewFacade = new ViewFactory().GetViewFacade();
            playController = new PlayController(board, viewFacade);
            resumeController = new ResumeController(board, viewFacade);
        }


        protected void play()
        {
            //TODO: pasar el gamestatus al board?
            do
            {
                playController.control(gameStatus);
            } while (!resumeController.control(gameStatus));
        }

        static void Main(string[] args)
        {
          new Chess().play();
        }
    }
}