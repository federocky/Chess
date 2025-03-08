using Chess_MVP_ModelViewPresenter.Presenters;

namespace Chess_MVP_ModelViewPresenter.Views.Commands
{
    internal class NewGameCommand : Utils.Command
    {
        public NewGameCommand(StartPresenter startPresenter) : base("Partida nueva", startPresenter)
        {
        }

        public override void Execute()
        {
            ((StartPresenter)this.acceptorPresenter).NewGame();
        }
    }
}
