using Chess_MVC_PassiveView.Enums;
using Chess_MVC_PassiveView.Models;
using Chess_MVC_PassiveView.Models.Pieces;
using Chess_MVC_PassiveView.Utils;
using Chess_MVC_PassiveView.Views;

namespace Chess_MVC_PassiveView.Constrollers
{
    internal class PlayController : Controller
    {
        private Turn turn { get; set; }

        public PlayController(Board board, IViewFacade viewFacade, GameStatus gameStatus) : base(board, viewFacade, gameStatus)
        {
            turn = new Turn();
        }

        public void control()
        {
            var boardView = viewFacade.CreateBoardView();
            var playView = viewFacade.CreatePlayView();

            boardView.Print(board);

            var playing = turn.GetPlaying();

            playView.ShowPlayer(playing);

            if (gameStatus.IsDrawOffer())
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
            else
            {
                var origin = playView.ReadOrigin();


                if (origin.IsEqualToIgnoreCase("proponer tablas"))
                {
                    OfferDraw(gameStatus);
                }
                else if (origin.IsEqualToIgnoreCase("rendirse"))
                {
                    Resign(gameStatus, playView, playing);
                }
                else
                {
                    Move(origin, playing);
                }
            }

            turn.Next();
        }

        private void Move(string? originInput, PieceColor color)
        {
            var targetInput = "";

            Coordinate origin;
            Coordinate target;
            bool isValidMove;
            Piece piece;

            var playView = viewFacade.CreatePlayView();


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

            board.MovePiece(origin, target);

        }


        private void Resign(GameStatus gameStatus, IPlayView playView, PieceColor color)
        {
            playView.ShowResign(color);
            gameStatus.Resing();
        }

        private void OfferDraw(GameStatus gameStatus)
        {
            gameStatus.OfferDraw();
        }
    }
}
