namespace Chess_DomainModel
{
    internal class Chess
    {
        private Turn turn { get; set; }
        private Board board { get; set; }

    public Chess()
        {
            turn = new Turn();
            board = new Board();
        }

        private void Play()
        {
            Console.WriteLine("Que comience el Ajedrez");
            board.Write();

            do
            {
                turn.Play(board);
            } while (!IsGameFinished());
        }

        private bool IsGameFinished()
        {
            return false; //TODO: Implement it
        }

        static void Main(string[] args)
        {
            new Chess().Play();
        }
    }
}