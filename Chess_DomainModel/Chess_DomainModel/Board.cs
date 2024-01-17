using Chess_DomainModel.Enums;
using Chess_DomainModel.Pieces;

namespace Chess_DomainModel
{
    public class Board : IBoard
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
                                board[row][col] = PlacePieceOnBoard(col, PieceColor.White);
                                break;
                            case 1:
                                board[row][col] = new Pawn(PieceColor.White);
                                break;
                            case 6:
                                board[row][col] = new Pawn(PieceColor.Black);
                                break;
                            case 7:
                                board[row][col] = PlacePieceOnBoard(col, PieceColor.Black);
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

        private Piece PlacePieceOnBoard(int col, PieceColor color)
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

        public Piece GetPiece(Coordinate coordinate)
        {
            var rowOutOfBounds = coordinate.GetRow() < 0 || coordinate.GetRow() > 7;
            var colOutOfBounds = coordinate.GetColumn() < 0 || coordinate.GetColumn() > 7;

            if (rowOutOfBounds || colOutOfBounds) return new NullPiece();

            return this.board[coordinate.GetRow()][coordinate.GetColumn()];
        }

        public void MovePiece(Coordinate origin, Coordinate target)
        {
            var piece = this.board[origin.GetRow()][origin.GetColumn()];
            this.board[target.GetRow()][target.GetColumn()] = piece;
            this.board[origin.GetRow()][origin.GetColumn()] = new NullPiece();
        }

        public bool ArePieceInPath(List<Coordinate> coordinates)
        {
            foreach (var coordinate in coordinates)
            {
                if (this.board[coordinate.GetRow()][coordinate.GetColumn()] is not NullPiece) return true;
            }
            return false;
        }

        public bool IsValidCoordinate(string input)
        {
            if (string.IsNullOrEmpty(input)) return false;
            if (input.Length < 2 || input.Length > 2) return false;

            var firstChar = input[0].ToString().ToLower();
            if (!firstChar.Equals("a") && !firstChar.Equals("b") &&
                !firstChar.Equals("c") && !firstChar.Equals("d") &&
                !firstChar.Equals("e") && !firstChar.Equals("f") &&
                !firstChar.Equals("g") && !firstChar.Equals("h")) return false;

            var secondChar = input[1].ToString();
            if (!int.TryParse(secondChar, out var result)) return false;
            if (result <= 0 || result > 8) return false;

            return true;
        }
    }
}