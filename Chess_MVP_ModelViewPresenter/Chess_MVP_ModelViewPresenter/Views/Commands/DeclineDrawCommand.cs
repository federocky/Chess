using Chess_MVP_ModelViewPresenter.Controllers;

namespace Chess_MVP_ModelViewPresenter.Views.Commands
{
    internal class DeclineDrawCommand : Utils.Command
    {

        public DeclineDrawCommand(PlayController playController) : base("Rechazar", playController)
        {
        }

        public override void Execute()
        {
            ((PlayController)this.acceptorController).DeclineDrawOffer();
        }
    }
}