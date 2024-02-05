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
    }
}
