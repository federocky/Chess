using Chess_MVP_ModelViewPresenter.Presenters;
using Chess_MVP_ModelViewPresenter.Views.Consol;

namespace Chess_MVP_ModelViewPresenter.Views.Commands
{
    internal class LoadGameCommand : Utils.Command
    {
        public LoadGameCommand(StartPresenter startPresenter) : base("Cargar partida", startPresenter)
        {
        }

        public override void Execute()
        {
            new LoadViewConsole().Load((StartPresenter)acceptorPresenter);
        }
    }
}
