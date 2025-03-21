using Chess_MVP_ModelViewPresenter.Presenters;
using Chess_MVP_ModelViewPresenter.Enums;
using Chess_MVP_ModelViewPresenter.Models;

namespace Chess_MVP_ModelViewPresenter.Views.Consol
{
    internal class MoveViewConsole
    {
        public void Move(PlayPresenter playPresenteer)
        {
            var origin = "";
            var target = "";
            do
            {
                do
                {
                    Console.WriteLine("elegir origen");
                    origin = Console.ReadLine();

                } while (!playPresenteer.IsValidOrigin(origin));

                Console.WriteLine("elegir destino");
                target = Console.ReadLine();

            } while (!playPresenteer.IsVaLidaMove(origin, target));

            playPresenteer.Move(origin, target);

            if (playPresenteer.IsPawnPromotion())
            {
                var response = ReadPawnPromotion();
                playPresenteer.PromotePawn(new Coordinate(target), response);
            };
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
            } while (string.IsNullOrEmpty(response) || response != "1" && response != "2" && response != "3" && response != "4");

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
