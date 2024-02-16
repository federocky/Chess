using Chess_MVC_PassiveView.Enums;
using Chess_MVC_PassiveView.Models;
using Chess_MVC_PassiveView.Models.Pieces;
using Chess_MVC_PassiveView.Utils;
using Chess_MVC_PassiveView.Views;

namespace Chess_MVC_PassiveView.Constrollers
{
    internal class PlayController : AcceptorController
    {
        private IBoardView boardView { get; set; }
        private IPlayView playView { get; set; }

        private Dictionary<Command, Controller> controllers { get; set; }
        private MoveCommand moveCommand {  get; set; }
        private MoveController moveController { get; set; }
        private ResignCommand resignCommand { get; set; }
        private ResignController resignController { get; set; }
        private DrawCommand drawCommand { get; set; }
        private DrawController drawController { get; set; }
        private Menu menu { get; set; }


        public PlayController(Board board, Turn turn, GameStatus gameStatus, Session session) : base(board, turn, gameStatus, session)
        {
            boardView = viewFacade.CreateBoardView();
            playView = viewFacade.CreatePlayView();

            controllers = new Dictionary<Command, Controller>();
            moveCommand = new MoveCommand();
            moveController = new MoveController(board, turn, gameStatus, session);
            resignCommand = new ResignCommand();
            resignController = new ResignController(board, turn, gameStatus, session);
            drawCommand = new DrawCommand();
            drawController = new DrawController(board, turn, gameStatus, session);

            controllers.Add(moveCommand, moveController);
            controllers.Add(resignCommand, resignController);
            controllers.Add(drawCommand, drawController);

            menu = new Menu(controllers.Keys);
        }

        public override void Control()
        {
            session.Next();
            do
            {
                Play();
            } while (!gameStatus.IsGameFinished(board));

        }

        private void Play()
        {
            boardView.Print(board.DisplayBoard());
            playView.ShowPlayer(turn.GetPlaying());

            if (!drawController.HandleDrawOffer())
            {
                moveCommand.SetActive(true);
                resignCommand.SetActive(true);
                drawCommand.SetActive(true);
                controllers[menu.Execute()].Control();
            }

            turn.Next();
        }






    }
}
