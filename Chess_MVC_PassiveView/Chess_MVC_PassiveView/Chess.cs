using Chess_MVC_PassiveView.Constrollers;
using Chess_MVC_PassiveView.Models;
using Chess_MVC_PassiveView.Views;

namespace Chess_MVC_PassiveView
{
    internal class Chess
    {
        private Turn turn { get; set; }
        private Board board { get; set; }

        private ViewFactory viewFactory;
        private PlayController playController { get; set; }
        private ResumeController resumeController { get; set; }
        private StartController startController { get; set; }

        //private GameStatus gameStatus { get; set; }
        private bool keepPlaying { get; set; }

        public Chess()
        {
            turn = new Turn();
            board = new Board();
            startController = new StartController(board, viewFactory);
            playController = new PlayController(board, viewFactory);
            resumeController = new ResumeController(board, viewFactory);
        }

        protected void play()
        {
            do
            {
                startController.control();
                playController.control();
            } while (resumeController.control());
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}