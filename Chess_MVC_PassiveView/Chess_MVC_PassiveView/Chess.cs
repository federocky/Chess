using Chess_MVC_PassiveView.Constrollers;
using Chess_MVC_PassiveView.Models;
using Chess_MVC_PassiveView.Views;

namespace Chess_MVC_PassiveView
{
    internal class Chess
    {
        private Board board { get; set; }

        private readonly IViewFacade viewFacade;
        private GameStatus gameStatus { get; set; }
        private PlayController playController { get; set; }
        private ResumeController resumeController { get; set; }

        public Chess()
        {
            board = new Board();
            gameStatus = new GameStatus();
            viewFacade = new ViewFactory().GetViewFacade();
            playController = new PlayController(board, viewFacade, gameStatus);
            resumeController = new ResumeController(board, viewFacade, gameStatus);
        }


        protected void play()
        {
            //TODO: pasar el gamestatus al board?
            do
            {
                playController.control();
            } while (!resumeController.control());
        }

        static void Main(string[] args)
        {
          new Chess().play();
        }
    }
}