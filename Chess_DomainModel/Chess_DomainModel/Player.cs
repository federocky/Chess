using Chess_DomainModel.Enums;
using Chess_DomainModel.Pieces;

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
            var originInput = "";
            var targetInput = "";
            Piece piece;
            Coordinate origin;
            Coordinate target;
            bool pieceCanMove;
            bool boardAllowsMovement;

            Console.WriteLine($"Player {color} playing");
            
            do
            {
                do
                {
                    do
                    {
                        Console.WriteLine("Introduzca un origen válido");
                        originInput = Console.ReadLine();

                    } while (!board.IsValidCoordinate(originInput));

                    origin = new Coordinate(originInput);

                    piece = board.GetPiece(origin);

                    if (piece is NullPiece || !piece.IsColor(color)) Console.WriteLine("No hay una pieza de tu color en esa casilla");

                } while (piece is NullPiece || !piece.IsColor(color));

                do
                {
                    Console.WriteLine("Introduzca un destino válido");
                    targetInput = Console.ReadLine();

                } while (!board.IsValidCoordinate(targetInput));

                target = new Coordinate(targetInput);

                boardAllowsMovement = piece.IsValidBasicMove(origin, target, board);
                pieceCanMove = piece.IsValidMove(origin, target, board);

                if (!pieceCanMove || !boardAllowsMovement) Console.WriteLine("No se puede realizar el movimiento");

            } while (!pieceCanMove || !boardAllowsMovement);

            board.MovePiece(origin, target);

            board.Write();

        }


    }
}