namespace Chess_MVP_ModelViewPresenter.Controllers
{
    internal class NullController : AcceptorController
    {
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
