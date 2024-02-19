using Chess_MVC_PassiveView.Enums;
using Chess_MVC_PassiveView.Models;
using Chess_MVC_PassiveView.Repositories;
using Chess_MVC_PassiveView.Views.Consol;

namespace Chess_MVC_PassiveView.Constrollers
{
    internal class LoadController : InGameController
    {
        private IRepository repository { get; set; }

        public LoadController(Board board, Turn turn, GameStatus gameStatus, Session session) : base(board, turn, gameStatus, session)
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

            session.Next();
            board.Start(gameSaved.PiecesDisposition);
            gameStatus.Restart(); 
            turn.Restart(gameSaved.Playing);
        }


    }
}
