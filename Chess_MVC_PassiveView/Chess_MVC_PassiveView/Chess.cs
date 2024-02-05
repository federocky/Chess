using Chess_MVC_PassiveView.Constrollers;
using Chess_MVC_PassiveView.Models;
using Chess_MVC_PassiveView.Views;
using Chess_MVC_PassiveView.Views.Consol;

namespace Chess_MVC_PassiveView
{
    internal class Chess
    {
        private Turn turn { get; set; }
        private Board board { get; set; }

        private IViewFactory viewFactory;
        private PlayController playController { get; set; }
        private ResumeController resumeController { get; set; }
        private GameStatus gameStatus { get; set; }

        public Chess()
        {
            turn = new Turn();
            board = new Board();
            gameStatus = new GameStatus();
            viewFactory = CreateViewFactory();
            playController = new PlayController(board, viewFactory);
            resumeController = new ResumeController(board, viewFactory);
        }

        private IViewFactory CreateViewFactory()
        {
            //TODO: implement logic to determine if return consoleViewFactoryOrElse
            return new ConsoleViewFactory(); 
        }

        protected void play()
        {
            do
            {
                playController.control(turn, gameStatus);
            } while (!resumeController.control(gameStatus, board));
        }

        static void Main(string[] args)
        {
          new Chess().play();
        }
    }
}