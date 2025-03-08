using Chess_MVP_ModelViewPresenter.Presenters;

namespace Chess_MVP_ModelViewPresenter.Views.Commands
{
    internal class DeclineDrawCommand : Utils.Command
    {

        public DeclineDrawCommand(PlayPresenter playPresenter) : base("Rechazar", playPresenter)
        {
        }

        public override void Execute()
        {
            ((PlayPresenter)this.acceptorPresenter).DeclineDrawOffer();
        }
    }
}