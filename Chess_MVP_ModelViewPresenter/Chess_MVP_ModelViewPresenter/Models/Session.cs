using Chess_MVP_ModelViewPresenter.Enums;

namespace Chess_MVP_ModelViewPresenter.Models
{
    internal class Session
    {
        private State state;
        private bool drawOffer { get; set; }
        private bool isGameFinished { get; set; }
        private ReasonGameFinished reasonGameFinished { get; set; }


        public Session()
        {
            state = new State();
        }

        public GameState GetGameState()
        {
            return state.GetGameState();
        }

        public void Next()
        {
            state.Next();
        }

        public void Restart()
        {
            Next();
            drawOffer = false;
            isGameFinished = false;
            reasonGameFinished = ReasonGameFinished.Null;
        }

        public void OfferDraw()
        {
            drawOffer = true;
        }

        internal bool isDrawOffer()
        {
            return this.drawOffer;
        }

        public void AcceptDrawOffer()
        {
            isGameFinished = true;
            reasonGameFinished = ReasonGameFinished.Draw;
        }

        public void DeclineDrawOffer()
        {
            drawOffer = false;
        }
    }
}
