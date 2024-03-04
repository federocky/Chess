using Chess_MVP_ModelViewPresenter.Models;

namespace Chess_MVP_ModelViewPresenter.Controllers
{
    internal class PlayController : AcceptorController
    {
        public PlayController(Board board, Turn turn, Session session) : base(board, turn, session)
        {
        }

        public override void Accept(IControllersVisitor controllersVisitor)
        {
            controllersVisitor.Visit(this);
        }
    }
}
