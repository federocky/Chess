using Chess_MVP_ModelViewPresenter.Controllers;
using Chess_MVP_ModelViewPresenter.Utils;

namespace Chess_MVP_ModelViewPresenter.Views
{
    internal class NewGameCommand : Command
    {
        public NewGameCommand(StartController startController) : base("Partida nueva", startController)
        {
        }

        public override void Execute()
        {
            ((StartController)this.acceptorController).NewGame();
            //int numberOfUsers = new PlayersDialog().read(Turn.NUM_PLAYERS);
            //((StartController)this.acceptorController).createPlayers(numberOfUsers);
        }
    }
}
