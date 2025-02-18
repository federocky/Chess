using Chess_MVP_ModelViewPresenter.Controllers;
using Chess_MVP_ModelViewPresenter.Enums;
using Chess_MVP_ModelViewPresenter.Models;

namespace Chess_MVP_ModelViewPresenter.Views
{
    internal class MoveView
    {
        public void Move(PlayController playController)
        {
            var origin = "";
            var target = "";
            do
            {
                do
                {
                    Console.WriteLine("elegir origen");
                    origin = Console.ReadLine();

                } while (!playController.IsValidOrigin(origin));

                Console.WriteLine("elegir destino");
                target = Console.ReadLine();

            } while (!playController.IsVaLidaMove(origin, target));

            playController.Move(origin, target);

            if (playController.IsPawnPromotion())
            {
                var response = ReadPawnPromotion();
                playController.PromotePawn(new Coordinate(target), response);
            }

            playController.Next();
        }


        private PromotionPiece ReadPawnPromotion()
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
