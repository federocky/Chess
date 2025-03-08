using Chess_MVP_ModelViewPresenter.Presenters;
using Chess_MVP_ModelViewPresenter.Views.Commands;

namespace Chess_MVP_ModelViewPresenter.Views.Menus
{
    internal class StartMenu : Menu
    {

        public StartMenu(StartPresenter startPresenter)
        {
            AddCommand(new NewGameCommand(startPresenter));
            AddCommand(new LoadGameCommand(startPresenter));
        }
    }
}
