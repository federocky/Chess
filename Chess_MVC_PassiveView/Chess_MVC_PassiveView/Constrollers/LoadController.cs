using Chess_MVC_PassiveView.Models;

namespace Chess_MVC_PassiveView.Constrollers
{
    internal class LoadController : InGameController
    {
        public LoadController(Board board, Turn turn, GameStatus gameStatus, Session session) : base(board, turn, gameStatus, session)
        {
        }

        public override void Control()
        {
            session.Next();
            board.Start(); //load board froma a string
            gameStatus.Restart(); 
            turn.Restart(); //set turn from db
        }
    }
}
