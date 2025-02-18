using Chess_MVP_ModelViewPresenter.Controllers;
using Chess_MVP_ModelViewPresenter.Utils;

namespace Chess_MVP_ModelViewPresenter.Views
{
    internal class MoveCommand : Command
    {
        public MoveCommand(PlayController playController) : base("Mover", playController)
        {
        }

        public override void Execute()
        {
            new MoveView().Move((PlayController)acceptorController);
        }
    }
}
