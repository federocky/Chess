using Chess_MVP_ModelViewPresenter.Controllers;
using Chess_MVP_ModelViewPresenter.Utils;

namespace Chess_MVP_ModelViewPresenter.Views.Commands
{
    internal class RestartCommand : Command
    {
        public RestartCommand(ResumeController resumeController) : base("Reiniciar", resumeController)
        {                
        }

        public override void Execute()
        {
            ((ResumeController)this.acceptorController).Restart();
        }
    }
}
