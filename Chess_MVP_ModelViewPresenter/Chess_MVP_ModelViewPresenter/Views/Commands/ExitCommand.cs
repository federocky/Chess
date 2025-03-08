using Chess_MVP_ModelViewPresenter.Presenters;
using Chess_MVP_ModelViewPresenter.Utils;

namespace Chess_MVP_ModelViewPresenter.Views.Commands
{
    internal class ExitCommand : Command
    {
        public ExitCommand(ResumePresenter resumePresenter): base("Salir", resumePresenter)
        {
        }

        public override void Execute()
        {
            ((ResumePresenter)acceptorPresenter).ExitGame();
        }
    }
}
