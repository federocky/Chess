using Chess_MVC_PassiveView.Models;
using Chess_MVC_PassiveView.Repositories;

namespace Chess_MVC_PassiveView.Constrollers
{
    internal class LoadController : InGameController
    {
        private IRepository repository { get; set; }

        public LoadController(Board board, Turn turn, Session session) : base(board, turn, session)
        {
            repository = RepositoryFactory.GetRepository();
        }

        public override void Control()
        {
            var games = repository.GetSavedGamesList();
            
            if (games.Count == 0)
            {
                viewFacade.CreatePlayView().ShowNotSavedGames();
                return;
            }

            var fileName = viewFacade.CreatePlayView().ReadGameToLoad(games);
            
            var gameSaved = repository.Load(fileName);

            board.Start(gameSaved.PiecesDisposition);
            session.Restart(); 
            turn.Restart(gameSaved.Playing);
        }


    }
}
