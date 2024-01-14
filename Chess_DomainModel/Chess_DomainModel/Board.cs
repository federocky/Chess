using Chess_DomainModel.Enums;
using Chess_DomainModel.Pieces;

namespace Chess_DomainModel
{
    public class Board
    { 
        private Piece[][] board { get; set; } = new Piece[8][];

        public Board()
        {
            FillBoard();
        }

        private void FillBoard()
        {
            for (int row = 0; row < 8; row++)
            {
                board[row] = new Piece[8];
                for (int col = 0; col < 8; col++)
                {
                    
                    if (row == 0 || row == 1 || row == 6 || row == 7)
                    {
                        switch (row)
                        {
                            case 0:
                                board[row][col] = GetPiece(col, PieceColor.White);
                                break;
                            case 1:
                                board[row][col] = new Pawn(PieceColor.White);
                                break;
                            case 6:
                                board[row][col] = new Pawn(PieceColor.Black);
                                break;
                            case 7:
                                board[row][col] = GetPiece(col, PieceColor.Black);
                                break;
                            default:
                                board[row][col] = new NullPiece();
                                break;
                        }
                    }
                    else
                    {
                        board[row][col] = new NullPiece();
                    }

                }
            }
        }

        private Piece GetPiece(int col, PieceColor color)
        {
            switch (col)
            {
                case 0:
                    return new Rook(color);
                case 1:
                    return new Knight(color);
                case 2:
                    return new Bishop(color);
                case 3:
                    return new Queen(color);
                case 4:
                    return new King(color);
                case 5:
                    return new Bishop(color);
                case 6:
                    return new Knight(color);
                case 7:
                    return new Rook(color);
                default: 
                    return new NullPiece();
            }
        }

        public void Write()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("   A B C D E F G H");


            for (int i = 7; i >= 0; i--)
            {
                Console.Write($"{i+1}  ");
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(board[i][j] + " ");
                }
                Console.Write($" {i+1}");
                Console.WriteLine();
            }

            Console.WriteLine("   A B C D E F G H");
        }

    }
}