using Chess_MVC_PassiveView.Models;
using Chess_MVC_PassiveView.Views.Consol;

namespace Chess_MVC_PassiveView.Constrollers
{
    internal class ResignController : InGameController
    {
        public ResignController(Board board, Turn turn, Session session) : base(board, turn, session)
        {
        }

        public override void Control()
        {
            viewFacade.CreatePlayView().ShowResign(turn.GetPlaying());
            session.Resing();
        }
    }
}
