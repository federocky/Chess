using Chess_MVP_ModelViewPresenter.Controllers;
using Chess_MVP_ModelViewPresenter.Views.Commands;

namespace Chess_MVP_ModelViewPresenter.Views.Menus
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
