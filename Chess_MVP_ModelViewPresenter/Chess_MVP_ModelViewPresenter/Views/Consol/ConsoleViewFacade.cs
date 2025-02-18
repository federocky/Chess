namespace Chess_MVP_ModelViewPresenter.Views.Consol
{
    internal class ConsoleViewFacade : IViewFacade
    {
        IBoardView IViewFacade.CreateBoardView()
        {
            return new BoardView();
        }
    }
}
