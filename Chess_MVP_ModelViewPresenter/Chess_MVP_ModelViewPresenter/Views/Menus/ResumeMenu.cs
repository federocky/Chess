using Chess_MVP_ModelViewPresenter.Controllers;
using Chess_MVP_ModelViewPresenter.Views.Commands;

namespace Chess_MVP_ModelViewPresenter.Views.Menus
{
    internal class ResumeMenu : Menu
    {
        public ResumeMenu(ResumeController resumeController)
        {
            AddCommand(new RestartCommand(resumeController));
            AddCommand(new ExitCommand(resumeController));
        }
    }
}
