using Chess_MVP_ModelViewPresenter.Controllers;
using Chess_MVP_ModelViewPresenter.Enums;
using Chess_MVP_ModelViewPresenter.Models;

namespace Chess_MVP_ModelViewPresenter.Presenters
{
    internal class Logic
    {
        private Board board { get; set; }
        private Turn turn { get; set; }
        private Session session { get; set; }

        private Dictionary<GameState, AcceptorController> acceptorControllers;
        private StartController startController { get; set; }
        private PlayController playController { get; set; }
        private ResumeController resumeController { get; set; }

        public Logic()
        {
            board = new Board();
            turn = new Turn();
            session = new Session();

            startController = new StartController(board, turn, session);
            playController = new PlayController(board, turn, session);
            resumeController = new ResumeController(board, turn, session);

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
