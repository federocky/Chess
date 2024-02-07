using Chess_MVC_PassiveView.Models;

namespace Chess_MVC_PassiveView.Constrollers
{
    internal class ResumeController : Controller
    {
        public ResumeController() : base()
        {
        }
        public bool control()
        {
            var restart = viewFacade.CreateResumeView().ReadRestartGame();

            if(restart == "1")
            {
                board = new Board();
                gameStatus = new GameStatus();
                turn = new Turn();
                return true;
            }

            return false;
        }
    }
}
