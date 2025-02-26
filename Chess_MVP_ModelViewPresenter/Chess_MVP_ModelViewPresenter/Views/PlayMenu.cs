using Chess_MVP_ModelViewPresenter.Controllers;

namespace Chess_MVP_ModelViewPresenter.Views
{
    internal class PlayMenu : Menu
    {
        public PlayMenu(PlayController playController)
        {
            AddCommand(new MoveCommand(playController));
            AddCommand(new DrawCommand(playController));
        }
    }
}
