using Chess_MVP_ModelViewPresenter.Enums;
using Chess_MVP_ModelViewPresenter.Models;

namespace Chess_MVP_ModelViewPresenter.Presenters
{
    internal class Logic
    {
        private Board board { get; set; }
        private Turn turn { get; set; }
        private Session session { get; set; }

        private Dictionary<GameState, AcceptorPresenter> acceptorPresenters;
        private StartPresenter startPresenter { get; set; }
        private PlayPresenter playPresenter { get; set; }
        private ResumePresenter resumePresenter { get; set; }
        private FinishPresenter finishPresenter { get; set; }

        public Logic()
        {
            board = new Board();
            turn = new Turn();
            session = new Session();

            startPresenter = new StartPresenter(board, turn, session);
            playPresenter = new PlayPresenter(board, turn, session);
            finishPresenter = new FinishPresenter(board, turn, session);
            resumePresenter = new ResumePresenter(board, turn, session);

            acceptorPresenters = new Dictionary<GameState, AcceptorPresenter>
            {
                { GameState.INITIAL, startPresenter },
                { GameState.IN_GAME, playPresenter },
                { GameState.FINISHED, finishPresenter },
                { GameState.RESUME, resumePresenter }
            };
        }
        public AcceptorPresenter GetPresenter()
        {
            if (acceptorPresenters.TryGetValue(session.GetGameState(), out var gameState))
            {
                return gameState;
            }

            return new NullPresenter();
        }
    }
}
