using Chess_MVC_PassiveView.Enums;
using Chess_MVC_PassiveView.Models;

namespace Chess_MVC_PassiveView.Views.Consol
{
    internal class PlayView : IPlayView
    {
        public string ReadOrigin()
        {
            Console.WriteLine("Introduzca un origen válido o escriba 'proponer tablas' o 'rendirse'");
            var originInput = Console.ReadLine();
            return originInput;
        }

        public string ReadTarget()
        {
            Console.WriteLine("Introduzca un destino válido");
            var targetInput = Console.ReadLine();
            return targetInput;
        }

        public string ReadDrawOfferResponse()
        {
            Console.WriteLine("SE HA OFRECIDO UN EMPATE. ¿QUIERES ACEPTARLO?");
            Console.WriteLine("1 - Si");
            Console.WriteLine("* - No");
            var drawResponse = Console.ReadLine();
            return drawResponse;
        }

        public PromotionPiece ReadPawnPromotion()
        {
            var response = "";

            do
            {
                Console.WriteLine("A que figura quieres promocionar?");
                Console.WriteLine("1 - Alfíl");
                Console.WriteLine("2 - Caballo");
                Console.WriteLine("3 - Torre");
                Console.WriteLine("4 - Reyna");
                response = Console.ReadLine();
            } while (string.IsNullOrEmpty(response) || (response != "1" && response != "2" && response != "3" && response != "4"));
            
            return ConvertToPromotionPiece(response);
        }

        public void ShowAcceptDraw()
        {
            Console.WriteLine("Se ha aceptado las tablas");
        }

        public void ShowDeclineDraw()
        {
            Console.WriteLine("Se ha rechazado las tablas");
        }

        public void ShowPlayer(PieceColor playing)
        {
            Console.WriteLine($"Turno del jugador {playing}");
        }

        public void ShowWrongMove()
        {
            Console.WriteLine("No se puede realizar el movimiento");
        }

        public void ShowResign(PieceColor color)
        {
            var playerColor = color == PieceColor.White ? "Blanco" : "Negro";
            Console.WriteLine($"EL JUGADOR {playerColor} SE HA RENDIDO.");
        }


        private PromotionPiece ConvertToPromotionPiece(string value)
        {
            switch (value)
            {
                case "1":
                    return PromotionPiece.Bishop;
                case "2":
                    return PromotionPiece.Knight;
                case "3":
                    return PromotionPiece.Rook;
                case "4":
                    return PromotionPiece.Queen;
                default:
                    throw new ArgumentException("El valor proporcionado no corresponde a ningún PromotionPiece.", nameof(value));
            }
        }

    }
}
