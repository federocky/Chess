
using Chess_MVP_ModelViewPresenter.Controllers;
using Chess_MVP_ModelViewPresenter.Views.Menus;

namespace Chess_MVP_ModelViewPresenter.Views
{
    internal class ResumeView
    {
        internal void Interact(ResumeController resumeController)
        {
            Console.WriteLine("Que quieres hacer?");
            new ResumeMenu(resumeController).Execute();
        }
    }
}
