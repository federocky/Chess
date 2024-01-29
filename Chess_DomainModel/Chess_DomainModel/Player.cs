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
            var playing = color == PieceColor.White ? "Blanco" : "Negro";

            Console.WriteLine($"Turno del jugador {playing}");
            var originInput = "";

            if (gameStatus.IsDrawOffer())
            {
                Console.WriteLine("SE HA OFRECIDO UN EMPATE. ¿QUIERES ACEPTARLO?");
                Console.WriteLine("1 - Si");
                Console.WriteLine("* - No");
                var drawResponse = Console.ReadLine();

                if(!string.IsNullOrEmpty(drawResponse) && drawResponse == "1")
                {
                    Console.WriteLine("Se ha aceptado las tablas");
                    gameStatus.AcceptDrawOffer();
                } 
                else
                {
                    Console.WriteLine("Se ha rechazado las tablas");
                    gameStatus.DeclineDrawOffer();
                } 
            }
            else
            {
                Console.WriteLine("Introduzca un origen válido o escriba 'proponer tablas' o 'rendirse'");
                originInput = Console.ReadLine();


                if (originInput.IsEqualToIgnoreCase("proponer tablas"))
                {
                    OfferDraw(gameStatus);
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

        }

        private void Resign(GameStatus gameStatus)
        {
            gameStatus.Resing();
        }

        private void OfferDraw(GameStatus gameStatus)
        {
            gameStatus.OfferDraw();
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