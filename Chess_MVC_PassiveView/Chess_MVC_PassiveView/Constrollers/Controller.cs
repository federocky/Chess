using Chess_MVC_PassiveView.Models;
using Chess_MVC_PassiveView.Views;

namespace Chess_MVC_PassiveView.Constrollers
{
    internal abstract class Controller
    {
        protected Board board;
        protected ViewFactory viewFactory;

        protected Controller(Board board, ViewFactory viewFactory)
        {
            this.board = board;
            this.viewFactory = viewFactory;
        }


    }
}
