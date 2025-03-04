using Chess_MVP_ModelViewPresenter.Models;

namespace Chess_MVP_ModelViewPresenter.Controllers
{
    internal class ResumeController : AcceptorController
    {
        public ResumeController(Board board, Turn turn, Session session) : base(board, turn, session)
        {
        }

        public override void Accept(IControllersVisitor controllersVisitor)
        {
            controllersVisitor.Visit(this);
        }

        public void Restart()
        {
            session.Restart();
        }
    }
}
