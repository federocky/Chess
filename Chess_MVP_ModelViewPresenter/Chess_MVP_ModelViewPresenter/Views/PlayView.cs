using Chess_MVP_ModelViewPresenter.Controllers;

namespace Chess_MVP_ModelViewPresenter.Views
{
    internal class PlayView
    {
        private IBoardView boardView { get; set; }

        public PlayView(IViewFacade viewFacade)
        {
            boardView = viewFacade.CreateBoardView();
        }

        internal void Interact(PlayController playController)
        {
            boardView.Print(playController.GetBoardString());
            Console.WriteLine($"Turno del jugador {playController.GetPlaying()}");
            Console.WriteLine("Que quieres hacer?");
            new PlayMenu(playController).Execute();
        }
    }
}
