using Chess_MVP_ModelViewPresenter.Presenters;

namespace Chess_MVP_ModelViewPresenter.Views.Commands
{
    internal class DrawCommand : Utils.Command
    {
        public DrawCommand(PlayPresenter playPresenter) : base("Proponer tablas", playPresenter)
        {
        }

        public override void Execute()
        {
            ((PlayPresenter)this.acceptorPresenter).OfferDraw();
        }
    }
}
