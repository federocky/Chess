using Chess_MVP_ModelViewPresenter.Controllers;

namespace Chess_MVP_ModelViewPresenter.Views.Commands
{
    internal class MoveCommand : Utils.Command
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
