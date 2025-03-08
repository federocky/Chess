using Chess_MVP_ModelViewPresenter.Models;

namespace Chess_MVP_ModelViewPresenter.Presenters
{
    internal abstract class AcceptorPresenter : Presenter
    {
        protected AcceptorPresenter(Board board, Turn turn, Session session) : base(board, turn, session)
        {
        }

        public abstract void Accept(IPresentersVisitor presentersVisitor);

        public virtual bool IsNull()
        {
            return false;
        }

        public void NextState()
        {
            session.Next();
        }

        public void NextTurn()
        {
            turn.Next();
        }

    }
}
