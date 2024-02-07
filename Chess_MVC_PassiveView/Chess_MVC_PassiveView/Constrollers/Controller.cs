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

        protected Controller(Board board, Turn turn, IViewFacade viewFacade, GameStatus gameStatus)
        {
            this.board = board;
            this.turn = turn;
            this.viewFacade = viewFacade;
            this.gameStatus = gameStatus;
        }


    }
}
