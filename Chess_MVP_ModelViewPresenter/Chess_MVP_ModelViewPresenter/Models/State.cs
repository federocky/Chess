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

        public void Next()
        {
            gameState = (GameState)((int)gameState + 1);
        }

        public void Restart()
        {
            gameState = 0;
        }

        public GameState GetGameState()
        {
            return gameState;
        }
    }
}
