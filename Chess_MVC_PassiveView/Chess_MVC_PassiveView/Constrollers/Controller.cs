using Chess_MVC_PassiveView.Models;
using Chess_MVC_PassiveView.Views;

namespace Chess_MVC_PassiveView.Constrollers
{
    internal abstract class Controller
    {
        protected Board board;
        protected Turn turn;
        protected IViewFacade viewFacade;
        protected GameStatus gameStatus;

        protected Controller()
        {
            board = new Board();
            turn = new Turn();
            gameStatus = new GameStatus();
            viewFacade = new ViewFactory().GetViewFacade();
        }


    }
}
