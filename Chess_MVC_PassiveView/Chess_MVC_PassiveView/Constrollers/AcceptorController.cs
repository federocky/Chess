using Chess_MVC_PassiveView.Models;

namespace Chess_MVC_PassiveView.Constrollers
{
    internal abstract class AcceptorController : Controller
    {
        protected AcceptorController(Board board, Turn turn, GameStatus gameStatus, Session session) : base(board, turn, gameStatus, session)
        {
        }

        public virtual bool IsNull()
        {
            return false;
        }
    }
}
