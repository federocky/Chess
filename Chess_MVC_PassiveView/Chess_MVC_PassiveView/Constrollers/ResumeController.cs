using Chess_MVC_PassiveView.Models;
using Chess_MVC_PassiveView.Views;

namespace Chess_MVC_PassiveView.Constrollers
{
    internal class ResumeController : Controller
    {
        public ResumeController(Board board, IViewFacade viewFacade, GameStatus gameStatus) : base(board, viewFacade, gameStatus)
        {
        }
        public bool control()
        {
            return gameStatus.IsGameFinished(board);
        }
    }
}
