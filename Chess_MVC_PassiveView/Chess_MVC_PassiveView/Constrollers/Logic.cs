using Chess_MVC_PassiveView.Enums;
using Chess_MVC_PassiveView.Models;

namespace Chess_MVC_PassiveView.Constrollers
{
    internal class Logic
    {
        private Session session { get; set; }
        private Dictionary<GameState, AcceptorController> acceptorControllers { get; set; }
        private StartController startController { get; set; }
        private PlayController playController { get; set; }
        private ResumeController resumeController { get; set; }

        public Logic(Board board, Turn turn, GameStatus gameStatus)
        {
            session = new Session();
            startController = new StartController(board, turn, gameStatus, session);
            playController = new PlayController(board, turn, gameStatus, session);
            resumeController = new ResumeController(board, turn, gameStatus, session);
            acceptorControllers = new Dictionary<GameState, AcceptorController>
            {
                { GameState.INITIAL, startController },
                { GameState.IN_GAME, playController },
                { GameState.RESUME, resumeController }
            };
        }

        public AcceptorController GetController()
        {
            if( acceptorControllers.TryGetValue(session.GetGameState(), out var gameState))
            {
                return gameState;
            }

            return new NullController();
        }
    }
}
