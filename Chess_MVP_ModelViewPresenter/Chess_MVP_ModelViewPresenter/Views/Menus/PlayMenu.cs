using Chess_MVP_ModelViewPresenter.Controllers;
using Chess_MVP_ModelViewPresenter.Views.Commands;

namespace Chess_MVP_ModelViewPresenter.Views.Menus
{
    internal class PlayMenu : Menu
    {
        public PlayMenu(PlayController playController)
        {
            AddCommand(new MoveCommand(playController));
            AddCommand(new DrawCommand(playController));
            AddCommand(new SaveCommand(playController));
            AddCommand(new ResignCommand(playController));
        }
    }
}
