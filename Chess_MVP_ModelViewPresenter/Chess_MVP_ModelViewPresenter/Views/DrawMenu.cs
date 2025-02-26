using Chess_MVP_ModelViewPresenter.Controllers;

namespace Chess_MVP_ModelViewPresenter.Views
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
