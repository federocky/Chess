using Chess_MVC_PassiveView.Models;

namespace Chess_MVC_PassiveView.Constrollers
{
    internal class NewGameController : InGameController
    {
        public NewGameController(Board board, Turn turn, Session session) : base(board, turn, session)
        {
        }

        public override void Control()
        {
            session.Restart();
            board.Start();
            turn.Restart();
            Console.WriteLine("Bienvenido al ajedrez papá!!");
        }
    }
}
