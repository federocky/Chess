using Chess_MVP_ModelViewPresenter.Presenters;
using Chess_MVP_ModelViewPresenter.Views.Commands;

namespace Chess_MVP_ModelViewPresenter.Views.Menus
{
    internal class ResumeMenu : Menu
    {
        public ResumeMenu(ResumePresenter resumePresenter)
        {
            AddCommand(new RestartCommand(resumePresenter));
            AddCommand(new ExitCommand(resumePresenter));
        }
    }
}
