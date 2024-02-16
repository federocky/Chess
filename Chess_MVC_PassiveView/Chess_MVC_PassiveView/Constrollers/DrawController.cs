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
            gameStatus.OfferDraw();
        }

        public bool HandleDrawOffer()
        {
            if (gameStatus.IsDrawOffer())
            {
                var playView = viewFacade.CreatePlayView();
                var drawResponse = playView.ReadDrawOfferResponse();

                if (!string.IsNullOrEmpty(drawResponse) && drawResponse == "1")
                {
                    playView.ShowAcceptDraw();
                    gameStatus.AcceptDrawOffer();
                }
                else
                {
                    playView.ShowDeclineDraw();
                    gameStatus.DeclineDrawOffer();
                }
                return true;
            }

            return false;
        }
    }
}
