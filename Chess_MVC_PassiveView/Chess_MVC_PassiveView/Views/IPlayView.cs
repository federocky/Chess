using Chess_MVC_PassiveView.Enums;

namespace Chess_MVC_PassiveView.Views
{
    internal interface IPlayView
    {
        public string ReadOrigin();
        public string ReadTarget();
        public string ReadDrawOfferResponse();
        public PromotionPiece ReadPawnPromotion();
        public void ShowAcceptDraw();
        public void ShowDeclineDraw();
        public void ShowPlayer(PieceColor playing);
        public void ShowWrongMove();
        public void ShowResign(PieceColor color);
        public void ShowGameSaved();
    }
}
