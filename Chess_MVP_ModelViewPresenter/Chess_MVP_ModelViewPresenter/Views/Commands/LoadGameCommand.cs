using Chess_MVP_ModelViewPresenter.Controllers;

namespace Chess_MVP_ModelViewPresenter.Views.Commands
{
    internal class LoadGameCommand : Utils.Command
    {
        public LoadGameCommand(StartController startController) : base("Cargar partida", startController)
        {
        }

        public override void Execute()
        {
            ((StartController)this.acceptorController).LoadGame();
        }
    }
}
