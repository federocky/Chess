using Chess_MVC_PassiveView.Models;
using Chess_MVC_PassiveView.Utils;
using Chess_MVC_PassiveView.Views;

namespace Chess_MVC_PassiveView.Constrollers
{
    internal class StartController : AcceptorController
    {
        private Dictionary<Command, Controller> controllers { get; set; }

        private NewGameCommand newGameCommand { get; set; }
        private NewGameController newGameController { get; set; }
        private LoadCommand loadCommand { get; set; }
        private LoadController loadController { get; set; }
        private Menu menu { get; set; }

        public StartController(Board board, Turn turn, GameStatus gameStatus, Session session) : base(board, turn, gameStatus, session)
        {
            controllers = new Dictionary<Command, Controller>();

            newGameCommand = new NewGameCommand();
            newGameController = new NewGameController(board, turn, gameStatus, session);
            loadCommand = new LoadCommand();
            loadController = new LoadController(board, turn, gameStatus, session);

            controllers.Add(newGameCommand, newGameController);
            controllers.Add(loadCommand, loadController);

            menu = new Menu(controllers.Keys);
        }

        public override void Control()
        {
            newGameCommand.SetActive(true);
            loadCommand.SetActive(true);
            controllers[menu.Execute()].Control();
        }
    }
}
