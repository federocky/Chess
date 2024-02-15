using Chess_MVC_PassiveView.Enums;
using Chess_MVC_PassiveView.Models;
using Chess_MVC_PassiveView.Models.Pieces;
using Chess_MVC_PassiveView.Utils;
using Chess_MVC_PassiveView.Views;

namespace Chess_MVC_PassiveView.Constrollers
{
    internal class PlayController : AcceptorController
    {
        private Dictionary<Command, Controller> controllers;

        private MoveCommand moveCommand {  get; set; }
        private MoveController moveController { get; set; }

        private ResignCommand resignCommand { get; set; }
        private ResignController resignController { get; set; }

        private DrawCommand drawCommand { get; set; }
        private DrawController drawController { get; set; }

        private Menu menu { get; set; }





        private IBoardView boardView { get; set; }
        private IPlayView playView { get; set; }

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
            //session.Next();
            //do
            //{
            //    Play();
            //} while (!gameStatus.IsGameFinished(board));

            boardView.Print(board.DisplayBoard());
            var playing = turn.GetPlaying();
            playView.ShowPlayer(playing);


            if (gameStatus.IsDrawOffer())
            {
                HandleDrawOffer();
            }
            else
            {
                HandlePlayerAction(playing);
            }

            turn.Next();


            moveCommand.SetActive(true);
            resignCommand.SetActive(true);
            drawCommand.SetActive(true);
            controllers[menu.Execute()].Control();
        }

        private void HandlePlayerAction(PieceColor playing)
        {
            var origin = playView.ReadOrigin();

            if (origin.IsEqualToIgnoreCase("proponer tablas"))
            {
                gameStatus.OfferDraw();
            }
            else if (origin.IsEqualToIgnoreCase("rendirse"))
            {
                playView.ShowResign(playing);
                gameStatus.Resing();
            }
            else
            {
                Move(origin, playing);
            }
        }

        private void HandleDrawOffer()
        {
            var drawResponse = playView.ReadDrawOfferResponse();

            if (!string.IsNullOrEmpty(drawResponse) && drawResponse == "1")
            {
                playView.ShowAcceptDraw();
                gameStatus.AcceptDrawOffer();
            }
            else
            {
                playView.ShowDeclineDraw();
                gameStatus.DeclineDrawOffer();
            }
        }

        private void Move(string? originInput, PieceColor color)
        {
            var origin = GetValidOrigin(originInput, color);
            var target = GetValidTarget(origin);

            board.MovePiece(origin, target);

            if (board.IsPawnPromotion(color))
            {
                var response = playView.ReadPawnPromotion();
                board.PromotePawn(target, response, color);
            }

        }

        private Coordinate GetValidOrigin(string? originInput, PieceColor color)
        {
            Coordinate origin;
            Piece piece;

            do
            {
                if (!board.IsValidCoordinate(originInput))
                {
                    originInput = playView.ReadOrigin();
                }

                origin = new Coordinate(originInput);
                piece = board.GetPiece(origin);

                if (piece is NullPiece || !piece.IsColor(color)) originInput = "invalid";

            } while (!board.IsValidCoordinate(originInput) || piece is NullPiece || !piece.IsColor(color));

            return origin;
        }

        private Coordinate GetValidTarget(Coordinate origin)
        {
            Coordinate target;
            var targetInput = "";
            bool isValidMove;

            do
            {
                do
                {
                    targetInput = playView.ReadTarget();

                } while (!board.IsValidCoordinate(targetInput));

                target = new Coordinate(targetInput);

                isValidMove = board.IsValidMove(origin, target);

                if (!isValidMove) playView.ShowWrongMove();

            } while (!isValidMove);

            return target;
        }


    }
}
