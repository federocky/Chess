using Chess_MVC_PassiveView.Models;

namespace Chess_MVC_PassiveView.Constrollers
{
    internal abstract class AcceptorController : Controller
    {
        protected AcceptorController(Board board, Turn turn,Session session) : base(board, turn, session)
        {
        }

        public virtual bool IsNull()
        {
            return false;
        }
    }
}
