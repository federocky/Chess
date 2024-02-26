using Chess_MVC_PassiveView.Models;

namespace Chess_MVC_PassiveView.Constrollers
{
    internal abstract class InGameController : Controller
    {
        public InGameController(Board board, Turn turn, Session session) : base(board, turn, session)
        {
        }

    }
}
