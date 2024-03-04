using Chess_MVP_ModelViewPresenter.Controllers;

namespace Chess_MVP_ModelViewPresenter.Views
{
    internal class StartMenu : Menu
    {

        public StartMenu(StartController startController)
        {
            AddCommand(new NewGameCommand(startController));
            AddCommand(new LoadGameCommand(startController));
        }
    }
}
