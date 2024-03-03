using Chess_MVP_ModelViewPresenter.Controllers;
using Chess_MVP_ModelViewPresenter.Enums;
using Chess_MVP_ModelViewPresenter.Models;

namespace Chess_MVP_ModelViewPresenter.Presenters
{
    internal class Logic
    {
        private Session session { get; set; }

        private Dictionary<GameState, AcceptorController> acceptorControllers;
        private StartController startController { get; set; }
        private PlayController playController { get; set; }
        private ResumeController resumeController { get; set; }

        public Logic()
        {
            startController = new StartController();
            playController = new PlayController();
            resumeController = new ResumeController();

            acceptorControllers = new Dictionary<GameState, AcceptorController>
            {
                { GameState.INITIAL, startController },
                { GameState.IN_GAME, playController },
                { GameState.RESUME, resumeController }
            };
        }
        public AcceptorController GetController()
        {
            if (acceptorControllers.TryGetValue(session.GetGameState(), out var gameState))
            {
                return gameState;
            }

            return new NullController();
        }
    }
}
