namespace Chess_MVP_ModelViewPresenter.Controllers
{
    internal abstract class AcceptorController : Controller
    {

        public abstract void Accept(IControllersVisitor controllersVisitor);

        public virtual bool IsNull()
        {
            return false;
        }
    }
}
