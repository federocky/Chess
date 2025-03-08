using Chess_MVP_ModelViewPresenter.Presenters;

namespace Chess_MVP_ModelViewPresenter.Views.Commands
{
    internal class LoadGameCommand : Utils.Command
    {
        public LoadGameCommand(StartPresenter startPresenter) : base("Cargar partida", startPresenter)
        {
        }

        public override void Execute()
        {
            new LoadView().Load((StartPresenter)acceptorPresenter);
        }
    }
}
