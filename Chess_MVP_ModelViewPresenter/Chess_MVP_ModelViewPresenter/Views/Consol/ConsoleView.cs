using Chess_MVP_ModelViewPresenter.Presenters;

namespace Chess_MVP_ModelViewPresenter.Views.Consol
{
    internal class ConsoleView : IView
    {
        private StartViewConsole startView { get; set; }
        private PlayViewConsole playView { get; set; }
        private ResumeViewConsole resumeView { get; set; }
        private FinishViewConsole finishView { get; set; }

        public ConsoleView(IViewFacade viewFacade)
        {
            startView = new StartViewConsole();
            playView = new PlayViewConsole(viewFacade);
            resumeView = new ResumeViewConsole();
            finishView = new FinishViewConsole();
        }
        public void Interact(AcceptorPresenter acceptorPresenter)
        {
            acceptorPresenter.Accept(this);
        }

        public void Visit(StartPresenter startPresenter) => startView.Interact(startPresenter);

        public void Visit(PlayPresenter playPresenter) => playView.Interact(playPresenter);

        public void Visit(ResumePresenter resumePresenter) => resumeView.Interact(resumePresenter);

        public void Visit(FinishPresenter finishPresenter) => finishView.Interact(finishPresenter);

    }
}
