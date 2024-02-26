using Chess_MVC_PassiveView.Models;

namespace Chess_MVC_PassiveView.Constrollers
{
    internal class DrawController : InGameController
    {
        public DrawController(Board board, Turn turn, Session session) : base(board, turn, session)
        {
        }

        public override void Control()
        {
            session.OfferDraw();
        }

        public bool HandleDrawOffer()
        {
            if (session.IsDrawOffer())
            {
                var playView = viewFacade.CreatePlayView();
                var drawResponse = playView.ReadDrawOfferResponse();

                if (!string.IsNullOrEmpty(drawResponse) && drawResponse == "1")
                {
                    playView.ShowAcceptDraw();
                    session.AcceptDrawOffer();
                }
                else
                {
                    playView.ShowDeclineDraw();
                    session.DeclineDrawOffer();
                }
                return true;
            }

            return false;
        }
    }
}
