using Chess_MVP_ModelViewPresenter.Enums;
using Chess_MVP_ModelViewPresenter.Models;

namespace Chess_MVP_ModelViewPresenter.Controllers
{
    internal class FinishController : AcceptorController
    {
        public FinishController(Board board, Turn turn, Session session) : base(board, turn, session)
        {

        }

        public override void Accept(IControllersVisitor controllersVisitor)
        {
            controllersVisitor.Visit(this);
        }

        public ReasonGameFinished GetReasonFinished()
        {
            return session.GetReasonGameFinished();
        }

        internal PieceColor GetWinner()
        {
            return turn.GetPlaying() == PieceColor.White ? PieceColor.Black : PieceColor.White;
        }


    }
}
