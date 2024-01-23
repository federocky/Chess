using Chess_DomainModel.Enums;

namespace Chess_DomainModel
{
    internal class Chess
    {
        private Turn turn { get; set; }
        private Board board { get; set; }
        private bool keepPlaying { get; set; }

    public Chess()
        {
            turn = new Turn();
            board = new Board();
            keepPlaying = false;
        }

        private void Play()
        {            

            do
            {
                board = new Board();
                Console.WriteLine("Que comience el Ajedrez");
                board.Write();

                do
                {
                    turn.Play(board);
               
                } while (!IsGameFinished());

                
                Console.WriteLine("CHESS MASTER");
                var isNumber = false;

                
                Console.WriteLine("1- Juego Nuevo");
                Console.WriteLine("*- Salir");
                var input = Console.ReadLine();

                isNumber = int.TryParse(input, out var option);

                if (isNumber && option == 1) keepPlaying = true;  


            } while (keepPlaying);
        }

        private bool IsGameFinished()
        {
            var isCheckMate = false;
            var isCheckOnWhite = board.IsCheckOn(PieceColor.White);
            var isCheckOnBlack = board.IsCheckOn(PieceColor.Black);

            if (isCheckOnWhite || isCheckOnBlack)
            {
                PieceColor checkingColor = isCheckOnWhite ? PieceColor.White : PieceColor.Black;
                isCheckMate = board.IsCheckMate(checkingColor);

                if (isCheckMate) Console.WriteLine("¡¡¡JAQUE MATE!!!");
                else Console.WriteLine("¡¡¡JAQUE!!!");
            }
            return isCheckMate;
        }

        static void Main(string[] args)
        {
            new Chess().Play();
        }
    }
}