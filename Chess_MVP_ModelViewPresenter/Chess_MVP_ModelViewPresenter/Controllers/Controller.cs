using Chess_MVP_ModelViewPresenter.Models;

namespace Chess_MVP_ModelViewPresenter.Controllers
{
    internal abstract class Controller
    {
        protected Board board;
        protected Turn turn;
        protected Session session;

        protected Controller(Board board, Turn turn, Session session)
        {
            this.board = board;
            this.turn = turn;
            this.session = session;
        }

    }
}
