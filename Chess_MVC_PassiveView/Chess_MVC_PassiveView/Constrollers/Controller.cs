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

        protected Controller(Board board, Turn turn, GameStatus gameStatus)
        {
            this.board = board;
            this.turn = turn;
            this.gameStatus = gameStatus;
            viewFacade = new ViewFactory().GetViewFacade();
        }


    }
}
