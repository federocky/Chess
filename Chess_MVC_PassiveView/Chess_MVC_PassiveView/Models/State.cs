using Chess_MVC_PassiveView.Enums;

namespace Chess_MVC_PassiveView.Models
{
    internal class State
    {
        private GameState gameState {  get; set; }

        public State()
        {
            gameState = GameState.INITIAL;
        }

        public void next()
        {
            gameState = (GameState)((int) gameState + 1);
        }

        public GameState getGameState()
        {
            return gameState;
        }

        public void Reset()
        {
            gameState = GameState.INITIAL;
        }
    }
}
