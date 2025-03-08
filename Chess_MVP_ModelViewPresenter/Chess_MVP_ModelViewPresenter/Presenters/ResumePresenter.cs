using Chess_MVP_ModelViewPresenter.Models;

namespace Chess_MVP_ModelViewPresenter.Presenters
{
    internal class ResumePresenter : AcceptorPresenter
    {
        public ResumePresenter(Board board, Turn turn, Session session) : base(board, turn, session)
        {
        }

        public override void Accept(IPresentersVisitor presentersVisitor)
        {
            presentersVisitor.Visit(this);
        }

        public void Restart()
        {
            session.Restart();
        }
    }
}
