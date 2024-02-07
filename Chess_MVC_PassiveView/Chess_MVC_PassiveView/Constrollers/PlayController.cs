using Chess_MVC_PassiveView.Enums;
using Chess_MVC_PassiveView.Models;
using Chess_MVC_PassiveView.Models.Pieces;
using Chess_MVC_PassiveView.Utils;
using Chess_MVC_PassiveView.Views;

namespace Chess_MVC_PassiveView.Constrollers
{
    internal class PlayController : Controller
    {
        private IBoardView boardView { get; set; }
        private IPlayView playView { get; set; }

        public PlayController() : base()
        {
            boardView = viewFacade.CreateBoardView();
            playView = viewFacade.CreatePlayView();
        }

        public void control()
        {
            do
            {
                Play();
            } while (!gameStatus.IsGameFinished(board));
        }

        private void Play()
        {
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
