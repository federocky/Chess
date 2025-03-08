using Chess_MVP_ModelViewPresenter.Presenters;

namespace Chess_MVP_ModelViewPresenter.Views.Commands
{
    internal class ResignCommand : Utils.Command
    {
        public ResignCommand(PlayPresenter startPresenter) : base("Rendirse", startPresenter)
        {
                
        }

        public override void Execute()
        {
            ((PlayPresenter)this.acceptorPresenter).Resign();
        }
    }
}
