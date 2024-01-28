using Chess_DomainModel.Enums;
using Chess_DomainModel.Pieces;
using Chess_DomainModel.Utils;

namespace Chess_DomainModel
{
    public class Player
    {
        private readonly PieceColor color;

        public Player(PieceColor color)
        {
            this.color = color;
        }

        public void Play(Board board, GameStatus gameStatus)
        {

            Console.WriteLine($"Player {color} playing");

            var originInput = "";

            Console.WriteLine("Introduzca un origen válido o escriba 'proponer tablas' o 'rendirse'");
            originInput = Console.ReadLine();


            if (originInput.IsEqualToIgnoreCase("proponer tablas"))
            {
                OfferDraw(board);
            }
            else if (originInput.IsEqualToIgnoreCase("rendirse"))
            {
                Resign(gameStatus);
            }
            else
            {          
                Move(board, originInput);
            }

        }

        private void Resign(GameStatus gameStatus)
        {
            gameStatus.Resing();
        }

        private void OfferDraw(Board board)
        {
            throw new NotImplementedException();
        }

        private void Move(Board board, string? originInput)
        {
            var targetInput = "";

            Coordinate origin;
            Coordinate target;
            bool isValidMove;
            Piece piece;

           
            do
            {
                if (!board.IsValidCoordinate(originInput))
                {
                    Console.WriteLine("Coordenada invalida, vuelve a intentarlo");
                    originInput = Console.ReadLine();           
                }
                    
                origin = new Coordinate(originInput);
                piece = board.GetPiece(origin);

                if (piece is NullPiece || !piece.IsColor(color)) originInput = "invalid";

            } while (!board.IsValidCoordinate(originInput) || piece is NullPiece || !piece.IsColor(color));

            do
            {
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