using Chess_MVC_PassiveView.Models;

namespace Chess_MVC_PassiveView.Constrollers
{
    internal class ResumeController : AcceptorController
    {
        public ResumeController(Board board, Turn turn, Session session) : base(board, turn, session)
        {
        }


        public override void Control()
        {
            var restart = viewFacade.CreateResumeView().ReadRestartGame();

            if(restart == "1")
            {
                session.Reset();
            } 
            else
            {
                session.Next();
            }
        }
    }
}
