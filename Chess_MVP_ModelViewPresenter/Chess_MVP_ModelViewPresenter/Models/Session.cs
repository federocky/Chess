using Chess_MVP_ModelViewPresenter.Enums;

namespace Chess_MVP_ModelViewPresenter.Models
{
    internal class Session
    {
        private State state;

        public Session()
        {
            state = new State();
        }

        public GameState GetGameState()
        {
            return state.GetGameState();
        }
    }
}
