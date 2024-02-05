using Chess_MVC_PassiveView.Models;
using Chess_MVC_PassiveView.Views;

namespace Chess_MVC_PassiveView.Constrollers
{
    internal class ResumeController : Controller
    {
        public ResumeController(Board board, IViewFactory viewFactory) : base(board, viewFactory)
        {
        }
        public bool control(GameStatus gameStatus, Board board)
        {
            return gameStatus.IsGameFinished(board);
        }
    }
}
