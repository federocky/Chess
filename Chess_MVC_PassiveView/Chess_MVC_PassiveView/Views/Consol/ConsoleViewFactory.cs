namespace Chess_MVC_PassiveView.Views.Consol
{
    internal class ConsoleViewFactory : IViewFactory
    {
        public IBoardView CreateBoardView()
        {
            return new BoardView();
        }


        public IPlayView CreatePlayView()
        {
            return new PlayView();
        }

    }
}
