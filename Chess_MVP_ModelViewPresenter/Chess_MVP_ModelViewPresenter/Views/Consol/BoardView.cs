
namespace Chess_MVP_ModelViewPresenter.Views.Consol
{
    internal class BoardView : IBoardView
    {
        public void Print(string[][] board)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("   A B C D E F G H");

            for (int row = 7; row >= 0; row--)
            {
                System.Console.Write($"{row + 1}  ");
                for (int col = 0; col < 8; col++)
                {
                    System.Console.Write(board[row][col] + " ");
                }
                System.Console.Write($" {row + 1}");
                System.Console.WriteLine();
            }

            Console.WriteLine("   A B C D E F G H");

            Console.Write("\n\n\n");
        }
    }
}