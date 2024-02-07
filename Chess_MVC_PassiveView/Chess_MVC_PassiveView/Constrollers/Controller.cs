using Chess_MVC_PassiveView.Models;
using Chess_MVC_PassiveView.Views;

namespace Chess_MVC_PassiveView.Constrollers
{
    internal abstract class Controller
    {
        protected Board board;
        protected IViewFacade viewFacade;
        protected GameStatus gameStatus;

        protected Controller(Board board, IViewFacade viewFacade, GameStatus gameStatus)
        {
            this.board = board;
            this.viewFacade = viewFacade;
            this.gameStatus = gameStatus;
        }


    }
}
