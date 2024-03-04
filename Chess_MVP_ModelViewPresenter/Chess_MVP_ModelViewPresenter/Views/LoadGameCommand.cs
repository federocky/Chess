using Chess_MVP_ModelViewPresenter.Controllers;
using Chess_MVP_ModelViewPresenter.Utils;

namespace Chess_MVP_ModelViewPresenter.Views
{
    internal class LoadGameCommand : Command
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
