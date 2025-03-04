using Chess_MVP_ModelViewPresenter.Enums;
using Chess_MVP_ModelViewPresenter.Models;
using Chess_MVP_ModelViewPresenter.Models.Pieces;

namespace Chess_MVP_ModelViewPresenter.Controllers
{
    internal class PlayController : AcceptorController
    {
        public PlayController(Board board, Turn turn, Session session) : base(board, turn, session)
        {
        }

        public override void Accept(IControllersVisitor controllersVisitor)
        {
            controllersVisitor.Visit(this);
        }

        public void Move(string origin, string target)
        {
            var originCoordinate = new Coordinate(origin);
            var targetCoordinate = new Coordinate(target);

            board.MovePiece(originCoordinate, targetCoordinate);

            NextTurn();
        }

        public bool IsPawnPromotion()
        {
            return board.IsPawnPromotion(turn.GetPlaying());
        }

        public void OfferDraw()
        {
            session.OfferDraw();
            NextTurn();
        }

        public bool isDrawOffer()
        {
            return session.isDrawOffer();
        }

        public PieceColor GetPlaying()
        {
            return turn.GetPlaying();
        }

        public bool IsValidOrigin(string? origin)
        {
            if (origin == null) return false;
            if (!board.IsValidCoordinate(origin)) return false;

            var originCoordinate = new Coordinate(origin);
            var playerColor = turn.GetPlaying();

            var piece = board.GetPiece(originCoordinate);
            if(piece is NullPiece || !piece.IsColor(playerColor)) return false;

            return true;
        }

        public bool IsVaLidaMove(string origin, string? target)
        {
            if(target == null) return false;
            if (!board.IsValidCoordinate(target)) return false;

            var originCoordinate = new Coordinate(origin);
            var targetCoordinate = new Coordinate(target);
            if (!board.IsValidMove(originCoordinate, targetCoordinate)) return false;

            return true;
        }

        public string[][] GetBoardString()
        {
            return board.DisplayBoard();
        }

        public void PromotePawn(Coordinate target, PromotionPiece response)
        {
            board.PromotePawn(target, response, turn.GetPlaying());
        }

        internal void AcceptDrawOffer()
        {
            session.AcceptDrawOffer();
        }

        internal void DeclineDrawOffer()
        {
            session.DeclineDrawOffer();
            NextTurn();
        }
    }
}
