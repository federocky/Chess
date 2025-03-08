using Chess_MVP_ModelViewPresenter.Presenters;
using Chess_MVP_ModelViewPresenter.Views.Commands;

namespace Chess_MVP_ModelViewPresenter.Views.Menus
{
    internal class PlayMenu : Menu
    {
        public PlayMenu(PlayPresenter playPresenter)
        {
            AddCommand(new MoveCommand(playPresenter));
            AddCommand(new DrawCommand(playPresenter));
            AddCommand(new SaveCommand(playPresenter));
            AddCommand(new ResignCommand(playPresenter));
        }
    }
}
