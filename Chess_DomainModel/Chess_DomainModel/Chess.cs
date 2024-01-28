using Chess_DomainModel.Enums;

namespace Chess_DomainModel
{
    internal class Chess
    {
        private Turn turn { get; set; }
        private Board board { get; set; }
        private GameStatus gameStatus { get; set; }
        private bool keepPlaying { get; set; }

    public Chess()
        {
            turn = new Turn();
            board = new Board();
            keepPlaying = false;
            gameStatus = new GameStatus();
        }

        private void Play()
        {            

            do
            {
                board = new Board();
                turn = new Turn();
                gameStatus = new GameStatus();

                Console.WriteLine("Que comience el Ajedrez");
                board.Write();

                do
                {
                    turn.Play(board, gameStatus);
               
                } while (!IsGameFinished());

                Console.WriteLine("JUEGO TERMINADO");
                PrintReasonGameFinished();

                
                Console.WriteLine("CHESS MASTER");
                var isNumber = false;

                
                Console.WriteLine("1- Juego Nuevo");
                Console.WriteLine("*- Salir");
                var input = Console.ReadLine();

                isNumber = int.TryParse(input, out var option);

                if (isNumber && option == 1) keepPlaying = true;  


            } while (keepPlaying);
        }

        private void PrintReasonGameFinished()
        {
            var reasonGameFinished = gameStatus.GetReasonGameFinished();
            var lastPlayer = turn.GetLastPlayerColor() == PieceColor.White ? "Blanco" : "Negro";

            if (reasonGameFinished == ReasonGameFinished.Draw)
            {
                Console.WriteLine("HAN EMPATADO LA PARTIDA");
            } else if (reasonGameFinished == ReasonGameFinished.Resign)
            {
                Console.WriteLine($"EL JUGADOR {lastPlayer} SE HA RENDIDO.");
            } else
            {
                Console.WriteLine($"EL JUGADOR {lastPlayer} HA GANADO POR JAQUE MATE. ¡¡¡ENHORABUENA!!!");
            }
        }

        private bool IsGameFinished()
        {
            return gameStatus.IsGameFinished(board);
        }

        static void Main(string[] args)
        {
            new Chess().Play();
        }
    }
}