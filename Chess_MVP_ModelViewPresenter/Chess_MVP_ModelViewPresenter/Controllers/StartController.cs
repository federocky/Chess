namespace Chess_MVP_ModelViewPresenter.Controllers
{
    internal class StartController : AcceptorController
    {
        public override void Accept(IControllersVisitor controllersVisitor)
        {
            controllersVisitor.Visit(this);
        }
    }
}
