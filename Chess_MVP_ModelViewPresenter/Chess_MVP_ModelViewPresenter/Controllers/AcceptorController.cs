using Chess_MVP_ModelViewPresenter.Models;

namespace Chess_MVP_ModelViewPresenter.Controllers
{
    internal abstract class AcceptorController : Controller
    {
        protected AcceptorController(Board board, Turn turn, Session session) : base(board, turn, session)
        {
        }

        public abstract void Accept(IControllersVisitor controllersVisitor);

        public virtual bool IsNull()
        {
            return false;
        }
    }
}
