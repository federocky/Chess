using Chess_MVP_ModelViewPresenter.Controllers;
using Chess_MVP_ModelViewPresenter.Utils;

namespace Chess_MVP_ModelViewPresenter.Views
{
    internal class AcceptDrawCommand : Command
    {

        public AcceptDrawCommand(PlayController playController): base("Aceptar", playController)
        {
        }

        public override void Execute()
        {
            ((PlayController)this.acceptorController).AcceptDrawOffer();
        }
    }
}