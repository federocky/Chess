using Chess_MVP_ModelViewPresenter.Controllers;
using Chess_MVP_ModelViewPresenter.Utils;

namespace Chess_MVP_ModelViewPresenter.Views
{
    internal class DeclineDrawCommand : Command
    {

        public DeclineDrawCommand(PlayController playController): base("Rechazar", playController)
        {
        }

        public override void Execute()
        {
            ((PlayController)this.acceptorController).AcceptDrawOffer();
        }
    }
}