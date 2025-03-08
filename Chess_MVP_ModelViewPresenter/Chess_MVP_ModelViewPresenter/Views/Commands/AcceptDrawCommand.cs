using Chess_MVP_ModelViewPresenter.Presenters;

namespace Chess_MVP_ModelViewPresenter.Views.Commands
{
    internal class AcceptDrawCommand : Utils.Command
    {

        public AcceptDrawCommand(PlayPresenter playpresenter) : base("Aceptar", playpresenter)
        {
        }

        public override void Execute()
        {
            ((PlayPresenter)this.acceptorPresenter).AcceptDrawOffer();
        }
    }
}