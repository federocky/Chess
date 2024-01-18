using Chess_DomainModel.Enums;
using Chess_DomainModel.Pieces;

namespace Chess_DomainModel
{
    public class Player
    {
        private readonly PieceColor color;

        public Player(PieceColor color)
        {
            this.color = color;
        }

        public void Play(Board board)
        {
            var originInput = "";
            var targetInput = "";
            Piece piece;
            Coordinate origin;
            Coordinate target;
            bool isValidMove;

            Console.WriteLine($"Player {color} playing");
            
            do
            {
                
                do
                {
                    Console.WriteLine("Introduzca un origen válido");
                    originInput = Console.ReadLine();

                    origin = new Coordinate(originInput);
                    piece = board.GetPiece(origin);

                } while (!board.IsValidCoordinate(originInput) || piece is NullPiece || !piece.IsColor(color));


                do
                {
                    Console.WriteLine("Introduzca un destino válido");
                    targetInput = Console.ReadLine();

                } while (!board.IsValidCoordinate(targetInput));

                target = new Coordinate(targetInput);

                isValidMove = board.IsValidMove(origin, target);

                if (!isValidMove) Console.WriteLine("No se puede realizar el movimiento");

            } while (!isValidMove);

            board.MovePiece(origin, target);

            board.Write();

        }


    }
}