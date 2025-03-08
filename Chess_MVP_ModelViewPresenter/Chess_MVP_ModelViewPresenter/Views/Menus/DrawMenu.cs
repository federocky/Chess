using Chess_MVP_ModelViewPresenter.Presenters;
using Chess_MVP_ModelViewPresenter.Views.Commands;

namespace Chess_MVP_ModelViewPresenter.Views.Menus
{
    internal class DrawMenu : Menu
    {
        public DrawMenu(PlayPresenter playPresenter)
        {
            AddCommand(new AcceptDrawCommand(playPresenter));
            AddCommand(new DeclineDrawCommand(playPresenter));
        }
    }
}
