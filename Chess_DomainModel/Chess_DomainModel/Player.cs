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

            
            do
            {
                do
                {
                    do
                    {
                        Console.WriteLine("Introduzca un origen válido");
                        originInput = Console.ReadLine();

                    } while (ValidateInput(originInput));

                    do
                    {
                        Console.WriteLine("Introduzca un destino válido");
                        targetInput = Console.ReadLine();

                    } while (ValidateInput(targetInput));


                    origin = new Coordinate(originInput);
                    target = new Coordinate(targetInput);

                    piece = board.GetPiece(origin);

                    if (piece is NullPiece) Console.WriteLine("No hay una pieza de tu color en esa casilla");

                } while (piece is NullPiece);
                

                pieceCanMove = piece.IsValidMove(origin, target, board);

                if (!pieceCanMove) Console.WriteLine("No se puede realizar el movimiento");

            } while (pieceCanMove);

            board.MovePiece(origin, target);

            board.Write();

        }

        private bool ValidateInput(string input)
        {
            if(input == null) return false;
            if(input.Length > 2) return false;

            var firstChar = input[0].ToString().ToLower();
            if (firstChar != "a" || firstChar != "b" || firstChar != "c" || firstChar != "d" || firstChar != "e" || firstChar !="f") return false;

            var secondChar = input[1].ToString();
            if(!int.TryParse(secondChar, out var result)) return false;
            if (result <= 0 || result > 8) return false;

            return true;
        }
    }
}