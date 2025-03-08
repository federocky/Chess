using Chess_MVP_ModelViewPresenter.Enums;
using Chess_MVP_ModelViewPresenter.Models;
using Chess_MVP_ModelViewPresenter.Models.Pieces;
using Chess_MVP_ModelViewPresenter.Repositories;

namespace Chess_MVP_ModelViewPresenter.Controllers
{
    internal class PlayController : AcceptorController
    {
        private IRepository repository { get; set; }

        public PlayController(Board board, Turn turn, Session session) : base(board, turn, session)
        {
            repository = RepositoryFactory.GetRepository();
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

        internal bool Save()
        {
            var isGameSaved = false;

            string datetime = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string gameName = $"game_{datetime}";
            var printedBoard = board.DisplayBoard();
            var playerColor = turn.GetPlaying();
            var flatBoard = "";

            for (int row = 7; row >= 0; row--)
            {
                for (int col = 0; col < 8; col++)
                {
                    flatBoard += printedBoard[row][col];
                }
            }

            if (repository.Save(flatBoard, gameName, playerColor))
            {
                session.GameSaved();
                isGameSaved = true;
            }

            return isGameSaved;
        }
    }
}
