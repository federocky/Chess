using Chess_MVP_ModelViewPresenter.Presenters;
using Chess_MVP_ModelViewPresenter.Views.Consol;

namespace Chess_MVP_ModelViewPresenter.Views.Commands
{
    internal class SaveCommand : Utils.Command
    {
        public SaveCommand(PlayPresenter playPresenter) : base("Guardar partida", playPresenter)
        {
        }

        public override void Execute()
        {
            new SaveViewConsole().Save((PlayPresenter)this.acceptorPresenter);
        }
    }
}
