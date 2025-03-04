using Chess_MVP_ModelViewPresenter.Controllers;

namespace Chess_MVP_ModelViewPresenter.Views.Commands
{
    internal class NewGameCommand : Utils.Command
    {
        public NewGameCommand(StartController startController) : base("Partida nueva", startController)
        {
        }

        public override void Execute()
        {
            ((StartController)this.acceptorController).NewGame();
        }
    }
}
