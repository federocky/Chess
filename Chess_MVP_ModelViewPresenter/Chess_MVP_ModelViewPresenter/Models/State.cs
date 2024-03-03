using Chess_MVP_ModelViewPresenter.Enums;

namespace Chess_MVP_ModelViewPresenter.Models
{
    internal class State
    {
        private GameState gameState { get; set; }

        public GameState GetGameState()
        {
            return gameState;
        }
    }
}
