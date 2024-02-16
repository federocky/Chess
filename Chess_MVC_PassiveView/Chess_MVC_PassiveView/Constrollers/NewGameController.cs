using Chess_MVC_PassiveView.Models;

namespace Chess_MVC_PassiveView.Constrollers
{
    internal class NewGameController : InGameController
    {
        public NewGameController(Board board, Turn turn, GameStatus gameStatus, Session session) : base(board, turn, gameStatus, session)
        {
        }

        public override void Control()
        {
            session.Next();
            board.Start();
            gameStatus.Restart();
            turn.Restart();
            Console.WriteLine("Bienvenido al ajedrez papá!!");
        }
    }
}
