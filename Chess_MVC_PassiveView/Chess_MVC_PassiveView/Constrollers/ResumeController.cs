using Chess_MVC_PassiveView.Models;
using Chess_MVC_PassiveView.Views;

namespace Chess_MVC_PassiveView.Constrollers
{
    internal class ResumeController : Controller
    {
        public ResumeController(Board board, IViewFacade viewFacade) : base(board, viewFacade)
        {
        }
        public bool control(GameStatus gameStatus)
        {
            return gameStatus.IsGameFinished(board);
        }
    }
}
