using Chess_MVC_PassiveView.Models;

namespace Chess_MVC_PassiveView.Constrollers
{
    internal class ResumeController : AcceptorController
    {
        public ResumeController(Board board, Turn turn, GameStatus gameStatus, Session session) : base(board, turn, gameStatus, session)
        {
        }


        public override void Control()
        {
            var restart = viewFacade.CreateResumeView().ReadRestartGame();

            if(restart == "1")
            {
                board.Start();
                gameStatus.Restart();
                turn.Restart();
                session.Reset();
            }
            session.Next();
        }
    }
}
