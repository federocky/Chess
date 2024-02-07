using Chess_MVC_PassiveView.Models;
using Chess_MVC_PassiveView.Views;

namespace Chess_MVC_PassiveView.Constrollers
{
    internal class ResumeController : Controller
    {
        public ResumeController(Board board, Turn turn, IViewFacade viewFacade, GameStatus gameStatus) : base(board, turn, viewFacade, gameStatus)
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
