namespace Chess_MVP_ModelViewPresenter.Controllers
{
    internal interface IControllersVisitor
    {
        void Visit(StartController startController);
        void Visit(PlayController playController);
        void Visit(ResumeController resumeController);

    }
}
