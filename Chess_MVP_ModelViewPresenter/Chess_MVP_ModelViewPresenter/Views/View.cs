using Chess_MVP_ModelViewPresenter.Controllers;

namespace Chess_MVP_ModelViewPresenter.Views
{
    internal class View : IControllersVisitor
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
        public void Interact(AcceptorController acceptorController)
        {
            acceptorController.Accept(this);
        }

        public void Visit(StartController startController)
        {
            startView.Interact(startController);
        }

        public void Visit(PlayController playController)
        {
            playView.Interact(playController);
        }

        public void Visit(ResumeController resumeController)
        {
            resumeView.Interact(resumeController);
        }

        public void Visit(FinishController finishController)
        {
            finishView.Interact(finishController);
        }
    }
}
