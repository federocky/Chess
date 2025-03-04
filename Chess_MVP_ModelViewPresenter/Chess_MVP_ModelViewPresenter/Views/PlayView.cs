using Chess_MVP_ModelViewPresenter.Controllers;
using Chess_MVP_ModelViewPresenter.Views.Menus;

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

            //TODO: estos string no van bien aqui si quieres estar desacoplado de console
            Console.WriteLine($"Turno del jugador {playController.GetPlaying()}");

            if (playController.isDrawOffer())
            {
                Console.WriteLine("Te han ofrecido tablas");
                Console.WriteLine("Que quieres hacer?");
                new DrawMenu(playController).Execute();
            }
            else
            {
                Console.WriteLine("Que quieres hacer?");
                new PlayMenu(playController).Execute();
            }

        }
    }
}
