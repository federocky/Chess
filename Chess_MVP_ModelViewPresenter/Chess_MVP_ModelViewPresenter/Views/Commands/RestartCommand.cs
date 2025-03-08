using Chess_MVP_ModelViewPresenter.Presenters;
using Chess_MVP_ModelViewPresenter.Utils;

namespace Chess_MVP_ModelViewPresenter.Views.Commands
{
    internal class RestartCommand : Command
    {
        public RestartCommand(ResumePresenter resumePresenter) : base("Reiniciar", resumePresenter)
        {                
        }

        public override void Execute()
        {
            ((ResumePresenter)this.acceptorPresenter).Restart();
        }
    }
}
