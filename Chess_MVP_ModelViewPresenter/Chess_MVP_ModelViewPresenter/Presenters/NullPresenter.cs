using Chess_MVP_ModelViewPresenter.Models;

namespace Chess_MVP_ModelViewPresenter.Presenters
{
    internal class NullPresenter : AcceptorPresenter
    {
        public NullPresenter() : base(new Board(), new Turn(), new Session())
        {
        }

        public override void Accept(IPresentersVisitor presentersVisitor)
        {
            throw new NotImplementedException();
        }

        public override bool IsNull()
        {
            return true;
        }
    }
}
