using Chess_MVP_ModelViewPresenter.Enums;

namespace Chess_MVP_ModelViewPresenter.Models
{
    internal class Session
    {
        private State state;
        private bool drawOffer { get; set; }
        private ReasonGameFinished reasonGameFinished { get; set; }


        public Session()
        {
            state = new State();
        }

        public GameState GetGameState()
        {
            return state.GetGameState();
        }

        public void Restart()
        {
            drawOffer = false;
            reasonGameFinished = ReasonGameFinished.Null;
            state.Restart();
        }

        public void OfferDraw()
        {
            drawOffer = true;
        }

        internal bool isDrawOffer()
        {
            return drawOffer;
        }

        public void AcceptDrawOffer()
        {
            reasonGameFinished = ReasonGameFinished.Draw;
            state.AcceptDrawOffer();
        }

        public void DeclineDrawOffer()
        {
            drawOffer = false;
        }

        public ReasonGameFinished GetReasonGameFinished()
        {
            return reasonGameFinished;
        }

        internal void GameSaved()
        {
            reasonGameFinished = ReasonGameFinished.Save;
            state.GameSaved();
        }

        internal void Resign()
        {
            reasonGameFinished = ReasonGameFinished.Resign;
            state.Resign();
        }

        internal void NewGame()
        {
            state.NewGame();
        }

        internal void Resume()
        {
            Restart();
        }

        internal void GameOver()
        {
            state.GameOver();
        }

        internal void GameLoaded()
        {
            state.GameLoaded();
        }

        internal void ExitGame()
        {
            state.ExitGame();
        }
    }
}
