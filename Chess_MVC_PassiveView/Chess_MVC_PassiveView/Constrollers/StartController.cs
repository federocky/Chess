using Chess_MVC_PassiveView.Models;

namespace Chess_MVC_PassiveView.Constrollers
{
    internal class StartController : AcceptorController
    {
        public StartController(Board board, Turn turn, GameStatus gameStatus, Session session) : base(board, turn, gameStatus, session)
        {
        }

        public override void Control()
        {
            //TODO: Cambiar
            session.Next();
            Console.WriteLine("Bienvenido al ajedrez papá!!");
        }
    }
}
