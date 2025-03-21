using Chess_MVP_ModelViewPresenter.Presenters;
using Chess_MVP_ModelViewPresenter.Views.Menus;

namespace Chess_MVP_ModelViewPresenter.Views.Consol
{
    internal class ResumeViewConsole
    {
        internal void Interact(ResumePresenter resumePresenter)
        {
            Console.WriteLine("Que quieres hacer?");
            new ResumeMenu(resumePresenter).Execute();
        }
    }
}
