namespace Chess_MVC_PassiveView.Views.Consol
{
    internal class ConsoleViewFacade : IViewFacade
    {
        public IBoardView CreateBoardView()
        {
            return new BoardView();
        }

        public IPlayView CreatePlayView()
        {
            return new PlayView();
        }

        public IResumeView CreateResumeView()
        {
            return new ResumeView();
        }

        public IErrorView CreateErrorView()
        {
            return new ErrorView();
        }
        
    }
}
