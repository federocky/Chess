using Chess_MVP_ModelViewPresenter.Controllers;
using Chess_MVP_ModelViewPresenter.Utils;

namespace Chess_MVP_ModelViewPresenter.Views.Commands
{
    internal class ExitCommand : Command
    {
        public ExitCommand(ResumeController resumeController): base("Salir", resumeController)
        {
        }

        public override void Execute()
        {
            ((ResumeController)acceptorController).NextState();
        }
    }
}
