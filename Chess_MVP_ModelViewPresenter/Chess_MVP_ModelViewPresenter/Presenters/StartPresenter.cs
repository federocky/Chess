using Chess_MVP_ModelViewPresenter.Models;
using Chess_MVP_ModelViewPresenter.Repositories;
using Chess_MVP_ModelViewPresenter.Views;

namespace Chess_MVP_ModelViewPresenter.Presenters
{
    internal class StartPresenter : AcceptorPresenter
    {
        private IRepository repository { get; set; }

        public StartPresenter(Board board, Turn turn, Session session) : base(board, turn, session)
        {
            repository = RepositoryFactory.GetRepository();
        }

        public override void Accept(IPresentersVisitor presentersVisitor)
        {
            presentersVisitor.Visit(this);
        }

        public void NewGame()
        {
            session.Next();
            board.Start();
            turn.Restart();
        }

        internal IList<string> GetSavedGames()
        {
            return repository.GetSavedGamesList();
        }

        internal void Load(string selectedGame)
        {
            var gameSaved = repository.Load(selectedGame);

            board.Start(gameSaved.PiecesDisposition);
            session.Next();
            turn.Restart(gameSaved.Playing);
        }

    }
}
