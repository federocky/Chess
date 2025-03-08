using Chess_MVP_ModelViewPresenter.Controllers;

namespace Chess_MVP_ModelViewPresenter.Views.Commands
{
    internal class SaveCommand : Utils.Command
    {
        public SaveCommand(PlayController playController) : base("Guardar partida", playController)
        {
        }

        public override void Execute()
        {
            new SaveView().Save((PlayController)this.acceptorController);
        }
    }
}
