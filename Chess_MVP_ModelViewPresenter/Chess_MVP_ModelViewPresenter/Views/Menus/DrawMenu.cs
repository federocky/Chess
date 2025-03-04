using Chess_MVP_ModelViewPresenter.Controllers;
using Chess_MVP_ModelViewPresenter.Views.Commands;

namespace Chess_MVP_ModelViewPresenter.Views.Menus
{
    internal class DrawMenu : Menu
    {
        public DrawMenu(PlayController playController)
        {
            AddCommand(new AcceptDrawCommand(playController));
            AddCommand(new DeclineDrawCommand(playController));
        }
    }
}
