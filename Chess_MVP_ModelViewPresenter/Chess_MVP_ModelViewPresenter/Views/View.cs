using Chess_MVP_ModelViewPresenter.Presenters;

namespace Chess_MVP_ModelViewPresenter.Views
{
    internal class View : IPresentersVisitor
    {
        private StartView startView { get; set; }
        private PlayView playView { get; set; }
        private ResumeView resumeView { get; set; }
        private FinishView finishView { get; set; }

        public View(IViewFacade viewFacade)
        {
            startView = new StartView();
            playView = new PlayView(viewFacade);
            resumeView = new ResumeView();
            finishView = new FinishView();
        }
        public void Interact(AcceptorPresenter acceptorPresenter)
        {
            acceptorPresenter.Accept(this);
        }

        public void Visit(StartPresenter startPresenter)
        {
            startView.Interact(startPresenter);
        }

        public void Visit(PlayPresenter playPresenter)
        {
            playView.Interact(playPresenter);
        }

        public void Visit(ResumePresenter resumePresenter)
        {
            resumeView.Interact(resumePresenter);
        }

        public void Visit(FinishPresenter finishPresenter)
        {
            finishView.Interact(finishPresenter);
        }
    }
}
