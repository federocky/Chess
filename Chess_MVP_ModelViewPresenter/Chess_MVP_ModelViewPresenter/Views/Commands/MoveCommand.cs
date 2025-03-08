using Chess_MVP_ModelViewPresenter.Presenters;

namespace Chess_MVP_ModelViewPresenter.Views.Commands
{
    internal class MoveCommand : Utils.Command
    {
        public MoveCommand(PlayPresenter playPresenter) : base("Mover", playPresenter)
        {
        }

        public override void Execute()
        {
            new MoveView().Move((PlayPresenter)acceptorPresenter);
        }
    }
}
