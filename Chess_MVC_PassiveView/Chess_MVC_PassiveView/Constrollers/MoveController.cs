using Chess_MVC_PassiveView.Enums;
using Chess_MVC_PassiveView.Models;
using Chess_MVC_PassiveView.Models.Pieces;
using Chess_MVC_PassiveView.Views;

namespace Chess_MVC_PassiveView.Constrollers
{
    internal class MoveController : InGameController
    {
        private IPlayView playView { get; set; }

        public MoveController(Board board, Turn turn, GameStatus gameStatus, Session session) : base(board, turn, gameStatus, session)
        {
            playView = viewFacade.CreatePlayView();
        }

        public override void Control()
        {
            //TODO: estas dos lineas van mejor dentro de GetValidOrigin
            //var originInput = playView.ReadOrigin();
            var playerColor = turn.GetPlaying();

            var origin = GetValidOrigin(originInput, playerColor);
            var target = GetValidTarget(origin);

            board.MovePiece(origin, target);

            if (board.IsPawnPromotion(playerColor))
            {
                var response = playView.ReadPawnPromotion();
                board.PromotePawn(target, response, playerColor);
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
