using Chess_MVP_ModelViewPresenter.Controllers;

namespace Chess_MVP_ModelViewPresenter.Views.Commands
{
    internal class DrawCommand : Utils.Command
    {
        public DrawCommand(PlayController playController) : base("Proponer tablas", playController)
        {
        }

        public override void Execute()
        {
            ((PlayController)this.acceptorController).OfferDraw();
        }
    }
}
