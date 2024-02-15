using Chess_MVC_PassiveView.Models;

namespace Chess_MVC_PassiveView.Constrollers
{
    internal class DrawController : InGameController
    {
        public DrawController(Board board, Turn turn, GameStatus gameStatus, Session session) : base(board, turn, gameStatus, session)
        {
        }

        public override void Control()
        {
            Console.WriteLine("Soy Draw");
        }
    }
}
