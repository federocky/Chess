using Chess_MVP_ModelViewPresenter.Controllers;

namespace Chess_MVP_ModelViewPresenter.Views.Commands
{
    internal class AcceptDrawCommand : Utils.Command
    {

        public AcceptDrawCommand(PlayController playController) : base("Aceptar", playController)
        {
        }

        public override void Execute()
        {
            ((PlayController)this.acceptorController).AcceptDrawOffer();
        }
    }
}