using Chess_MVP_ModelViewPresenter.Models;

namespace Chess_MVP_ModelViewPresenter.Controllers
{
    internal class NullController : AcceptorController
    {
        public NullController() : base(new Board(), new Turn(), new Session())
        {
        }

        public override void Accept(IControllersVisitor controllersVisitor)
        {
            throw new NotImplementedException();
        }

        public override bool IsNull()
        {
            return true;
        }
    }
}
