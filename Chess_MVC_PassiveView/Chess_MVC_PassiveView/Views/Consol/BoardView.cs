
using Chess_MVC_PassiveView.Models;

namespace Chess_MVC_PassiveView.Views.Consol
{
    internal class BoardView : IBoardView
    {
        public void Print(Board board)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("   A B C D E F G H");


            for (int row = 7; row >= 0; row--)
            {
                Console.Write($"{row + 1}  ");
                for (int col = 0; col < 8; col++)
                {
                    Console.Write(board.GetPiece(new Coordinate(row, col)) + " ");
                }
                Console.Write($" {row + 1}");
                Console.WriteLine();
            }

            Console.WriteLine("   A B C D E F G H");
        }
    }
}
