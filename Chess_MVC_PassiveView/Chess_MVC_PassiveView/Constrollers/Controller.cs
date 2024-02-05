using Chess_MVC_PassiveView.Models;
using Chess_MVC_PassiveView.Views;

namespace Chess_MVC_PassiveView.Constrollers
{
    internal abstract class Controller
    {
        protected Board board;
        protected IViewFactory viewFactory;

        protected Controller(Board board, IViewFactory viewFactory)
        {
            this.board = board;
            this.viewFactory = viewFactory;
        }


    }
}
