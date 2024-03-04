namespace Chess_MVP_ModelViewPresenter.Controllers
{
    internal class ResumeController : AcceptorController
    {
        public override void Accept(IControllersVisitor controllersVisitor)
        {
            controllersVisitor.Visit(this);
        }
    }
}
