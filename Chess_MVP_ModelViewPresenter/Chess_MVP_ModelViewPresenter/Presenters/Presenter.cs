using Chess_MVP_ModelViewPresenter.Models;

namespace Chess_MVP_ModelViewPresenter.Presenters
{
    internal abstract class Presenter
    {
        protected Board board;
        protected Turn turn;
        protected Session session;

        protected Presenter(Board board, Turn turn, Session session)
        {
            this.board = board;
            this.turn = turn;
            this.session = session;
        }

    }
}
