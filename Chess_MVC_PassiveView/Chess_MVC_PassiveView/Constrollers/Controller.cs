using Chess_MVC_PassiveView.Models;
using Chess_MVC_PassiveView.Views;

namespace Chess_MVC_PassiveView.Constrollers
{
    internal abstract class Controller
    {
        protected Board board;
        protected Turn turn;
        protected IViewFacade viewFacade;
        protected Session session;

        protected Controller(Board board, Turn turn, Session session)
        {
            this.board = board;
            this.turn = turn;
            this.session = session;

            viewFacade = new ViewFactory().GetViewFacade();
        }

        public abstract void Control();


    }
}
