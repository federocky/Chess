using Chess_MVP_ModelViewPresenter.Controllers;

namespace Chess_MVP_ModelViewPresenter.Views
{
    internal class StartView
    {
        internal void Interact(StartController startController)
        {
            Console.WriteLine("Bienvenido al ajedrez!!");
            new StartMenu(startController).Execute();

        }
    }
}
