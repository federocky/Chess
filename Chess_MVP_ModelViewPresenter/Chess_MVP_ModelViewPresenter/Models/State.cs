using Chess_MVP_ModelViewPresenter.Enums;

namespace Chess_MVP_ModelViewPresenter.Models
{
    internal class State
    {
        private GameState gameState { get; set; }

        public State()
        {
            gameState = GameState.INITIAL;
        }

        public void Restart()
        {
            gameState = 0;
        }

        public GameState GetGameState()
        {
            return gameState;
        }

        internal void NewGame()
        {
            this.gameState = GameState.IN_GAME;
        }

        internal void Resign()
        {
            gameState = GameState.FINISHED;
        }

        internal void GameSaved()
        {
            Restart();
        }

        internal void GameOver()
        {
            gameState = GameState.RESUME;
        }

        internal void AcceptDrawOffer()
        {
            gameState = GameState.FINISHED;
        }

        internal void GameLoaded()
        {
            gameState = GameState.IN_GAME;
        }

        internal void ExitGame()
        {
            gameState = GameState.EXIT;
        }
    }
}
