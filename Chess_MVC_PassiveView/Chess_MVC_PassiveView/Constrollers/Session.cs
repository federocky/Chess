using Chess_MVC_PassiveView.Enums;
using Chess_MVC_PassiveView.Models;

namespace Chess_MVC_PassiveView.Constrollers
{
    internal class Session
    {
        private State state;

        public Session()
        {
            state = new State();
        }

        public void Next()
        {
            state.next();
        }

        public void Reset()
        {
            state.Reset();
        }

        public GameState GetGameState()
        {
            return state.getGameState();
        }
    }
}
