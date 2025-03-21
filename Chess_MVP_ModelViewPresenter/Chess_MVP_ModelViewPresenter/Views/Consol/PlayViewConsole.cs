using Chess_MVP_ModelViewPresenter.Presenters;
using Chess_MVP_ModelViewPresenter.Views.Menus;

namespace Chess_MVP_ModelViewPresenter.Views.Consol
{
    internal class PlayViewConsole
    {
        private IBoardView boardView { get; set; }

        public PlayViewConsole(IViewFacade viewFacade)
        {
            boardView = viewFacade.CreateBoardView();
        }

        internal void Interact(PlayPresenter playPresenter)
        {
            boardView.Print(playPresenter.GetBoardString());

            //TODO: estos string no van bien aqui si quieres estar desacoplado de console
            Console.WriteLine($"Turno del jugador {playPresenter.GetPlaying()}");

            if (playPresenter.isDrawOffer())
            {
                Console.WriteLine("Te han ofrecido tablas");
                Console.WriteLine("Que quieres hacer?");
                new DrawMenu(playPresenter).Execute();
            }
            else
            {
                Console.WriteLine("Que quieres hacer?");
                new PlayMenu(playPresenter).Execute();
            }

        }
    }
}
