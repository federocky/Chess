using Chess_MVP_ModelViewPresenter.Models;
using Chess_MVP_ModelViewPresenter.Repositories;
using Chess_MVP_ModelViewPresenter.Views;

namespace Chess_MVP_ModelViewPresenter.Controllers
{
    internal class StartController : AcceptorController
    {
        private IRepository repository { get; set; }

        public StartController(Board board, Turn turn, Session session) : base(board, turn, session)
        {
            repository = RepositoryFactory.GetRepository();
        }

        public override void Accept(IControllersVisitor controllersVisitor)
        {
            controllersVisitor.Visit(this);
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
