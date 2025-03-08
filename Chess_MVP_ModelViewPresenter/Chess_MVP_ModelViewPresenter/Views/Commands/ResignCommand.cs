using Chess_MVP_ModelViewPresenter.Controllers;

namespace Chess_MVP_ModelViewPresenter.Views.Commands
{
    internal class ResignCommand : Utils.Command
    {
        public ResignCommand(PlayController startController) : base("Rendirse", startController)
        {
                
        }

        public override void Execute()
        {
            ((PlayController)this.acceptorController).Resign();
        }
    }
}
