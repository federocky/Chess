using Chess_MVP_ModelViewPresenter.Utils;

namespace Chess_MVP_ModelViewPresenter.Views
{
    internal class LoadGameCommand : Command
    {
        public LoadGameCommand(Controllers.StartController startController) : base("Cargar partida", startController)
        {
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
