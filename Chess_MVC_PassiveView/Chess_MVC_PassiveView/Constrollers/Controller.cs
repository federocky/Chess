using Chess_MVC_PassiveView.Models;
using Chess_MVC_PassiveView.Views;

namespace Chess_MVC_PassiveView.Constrollers
{
    internal abstract class Controller
    {
        protected Board board;
        protected IViewFacade viewFacade;

        protected Controller(Board board, IViewFacade viewFacade)
        {
            this.board = board;
            this.viewFacade = viewFacade;
        }


    }
}
