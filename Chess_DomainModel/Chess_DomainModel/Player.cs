using Chess_DomainModel.Enums;

namespace Chess_DomainModel
{
    public class Player
    {
        private PieceColor color;

        public Player(PieceColor color)
        {
            this.color = color;
        }

        public void Play(Board board)
        {
            Console.WriteLine("Introduzca el origen");
            var originInput = Console.ReadLine();
            Console.WriteLine("Introduzca el destino");
            var targetInput = Console.ReadLine();

            var origin = new Coordinate(originInput);
            var target = new Coordinate(targetInput);

            var piece = board.GetPiece(origin);

            var pieceCanMove = piece.IsValidMove(origin, target, board);

            if(pieceCanMove) board.MovePiece(origin, target);

            board.Write();

        }
    }
}