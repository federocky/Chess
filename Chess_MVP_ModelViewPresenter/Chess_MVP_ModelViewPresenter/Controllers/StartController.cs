namespace Chess_MVP_ModelViewPresenter.Controllers
{
    internal class StartController : AcceptorController
    {
        public override void Accept(IControllersVisitor controllersVisitor)
        {
            controllersVisitor.Visit(this);
        }

        public void Control()
        {
            Console.WriteLine("estoy en la lona");
            //Aqui debo cambiar el estado de la sesion para así pasar a la siguiente vista.
        }
    }
}
