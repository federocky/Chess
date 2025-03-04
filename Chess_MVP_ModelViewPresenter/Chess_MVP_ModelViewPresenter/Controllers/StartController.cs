using Chess_MVP_ModelViewPresenter.Models;

namespace Chess_MVP_ModelViewPresenter.Controllers
{
    internal class StartController : AcceptorController
    {
        public StartController(Board board, Turn turn, Session session) : base(board, turn, session)
        {
        }

        public override void Accept(IControllersVisitor controllersVisitor)
        {
            controllersVisitor.Visit(this);
        }

        public void NewGame()
        {
            session.Next();
            board.Start();
            turn.Restart();
        }

        public void LoadGame()
        {

        }
    }
}
