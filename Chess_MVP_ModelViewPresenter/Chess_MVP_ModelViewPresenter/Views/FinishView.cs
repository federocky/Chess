using Chess_MVP_ModelViewPresenter.Controllers;

namespace Chess_MVP_ModelViewPresenter.Views
{
    internal class FinishView
    {
        internal void Interact(FinishController finishController)
        {
            Console.WriteLine("PARTIDA FINALIZADA");

            var winner = finishController.GetWinner() == Enums.PieceColor.White ? "Blanco" : "Negro";
            var looser = winner == "Blanco" ? "Negro" : "Blanco";

            switch (finishController.GetReasonFinished())
            {   
                case Enums.ReasonGameFinished.Checkmate:
                    Console.WriteLine($"El jugador {winner} ha ganado. ¡¡ENHORABUENA!!");
                    break;
                case Enums.ReasonGameFinished.Draw:
                    Console.WriteLine("Ha habido un EMPATE");
                    break;
                case Enums.ReasonGameFinished.Resign:
                    Console.WriteLine($"El jugador {looser} se ha rendido");
                    break;
                case Enums.ReasonGameFinished.Save:
                    Console.WriteLine("Partidad guardada");
                    break;
                case Enums.ReasonGameFinished.Null:
                    break;
                default:
                    break;
            }

            finishController.NextState();
        }
    }
}