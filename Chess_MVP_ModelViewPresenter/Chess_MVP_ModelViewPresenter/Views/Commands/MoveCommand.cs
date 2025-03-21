using Chess_MVP_ModelViewPresenter.Presenters;
using Chess_MVP_ModelViewPresenter.Views.Consol;

namespace Chess_MVP_ModelViewPresenter.Views.Commands
{
    internal class MoveCommand : Utils.Command
    {
        public MoveCommand(PlayPresenter playPresenter) : base("Mover", playPresenter)
        {
        }

        public override void Execute()
        {
            new MoveViewConsole().Move((PlayPresenter)acceptorPresenter);
        }
    }
}
