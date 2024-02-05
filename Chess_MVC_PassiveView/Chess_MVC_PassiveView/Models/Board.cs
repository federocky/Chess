using Chess_MVC_PassiveView.Enums;
using Chess_MVC_PassiveView.Models.Pieces;

namespace Chess_MVC_PassiveView.Models
{
    internal class Board : IBoard
    {
        private Piece[][] board { get; set; }
        private Piece pieceDeleted { get; set; }
        private Coordinate lastMoveOrigin { get; set; }
        private Coordinate lastMoveTarget { get; set; }

        public Board()
        {
            board = new Piece[8][];
            pieceDeleted = new NullPiece();
            lastMoveOrigin = new Coordinate(0, 0);
            lastMoveTarget = new Coordinate(0, 0);
            FillBoard();
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
            SaveMovement(origin, target);
            var piece = this.board[origin.GetRow()][origin.GetColumn()];
            board[target.GetRow()][target.GetColumn()] = piece;
            board[origin.GetRow()][origin.GetColumn()] = new NullPiece();
        }

        public bool IsValidMove(Coordinate origin, Coordinate target)
        {
            //check if there is a piece of my color in target
            var playingColor = board[origin.GetRow()][origin.GetColumn()].IsColor(PieceColor.White) ? PieceColor.White : PieceColor.Black;
            if (board[target.GetRow()][target.GetColumn()].IsColor(playingColor))
            {
                return false;
            }

            if (origin.Equals(target))
            {
                return false;
            }

            if (MovementProvokeCheck(origin, target))
            {
                return false;
            }


            return board[origin.GetRow()][origin.GetColumn()].IsValidMove(origin, target, this);
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

        public bool IsCheckOn(PieceColor colorUnderAttack)
        {
            var attackingColor = colorUnderAttack == PieceColor.Black ? PieceColor.White : PieceColor.Black;
            var kingUnderAttackPosition = GetKingPosition(colorUnderAttack);

            for (int row = 0; row < board.Length; row++)
            {
                for (int col = 0; col < board[row].Length; col++)
                {
                    Piece currentPiece = board[row][col];

                    if (currentPiece.IsColor(attackingColor))
                    {
                        var origin = new Coordinate(row, col);

                        if (currentPiece.IsValidMove(origin, kingUnderAttackPosition, this))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public bool IsCheckMate(PieceColor colorUnderAttack)
        {
            var piecesPosition = GetAllPiecesPositions(colorUnderAttack);

            for (int row = 0; row < board.Length; row++)
            {
                for (int col = 0; col < board[row].Length; col++)
                {
                    foreach (var piecePosition in piecesPosition)
                    {
                        if (IsValidMove(piecePosition, new Coordinate(row, col))) return false;
                    }
                }
            }
            return true;
        }

        public void Write()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("   A B C D E F G H");


            for (int i = 7; i >= 0; i--)
            {
                Console.Write($"{i + 1}  ");
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(board[i][j] + " ");
                }
                Console.Write($" {i + 1}");
                Console.WriteLine();
            }

            Console.WriteLine("   A B C D E F G H");
        }

        private IEnumerable<Coordinate> GetAllPiecesPositions(PieceColor color)
        {
            for (int row = 0; row < board.Length; row++)
            {
                for (int col = 0; col < board[row].Length; col++)
                {
                    if (board[row][col].IsColor(color)) yield return new Coordinate(row, col);
                }
            }
        }

        private bool MovementProvokeCheck(Coordinate origin, Coordinate target)
        {
            var playingColor = board[origin.GetRow()][origin.GetColumn()].IsColor(PieceColor.White) ? PieceColor.White : PieceColor.Black;
            MovePiece(origin, target);
            var result = IsCheckOn(playingColor);
            UndoLastMove();
            return result;
        }

        private Coordinate GetKingPosition(PieceColor color)
        {
            for (int row = 0; row < board.Length; row++)
            {
                for (int col = 0; col < board[row].Length; col++)
                {
                    Piece currentPiece = board[row][col];

                    if (currentPiece.IsColor(color) && currentPiece is King)
                    {
                        return new Coordinate(row, col);
                    }
                }
            }
            return new Coordinate(0, 0);
        }

        private void SaveMovement(Coordinate origin, Coordinate target)
        {
            pieceDeleted = board[target.GetRow()][target.GetColumn()];
            lastMoveOrigin = origin;
            lastMoveTarget = target;
        }

        private void UndoLastMove()
        {
            var pieceMoved = board[lastMoveTarget.GetRow()][lastMoveTarget.GetColumn()];
            board[lastMoveOrigin.GetRow()][lastMoveOrigin.GetColumn()] = pieceMoved;
            board[lastMoveTarget.GetRow()][lastMoveTarget.GetColumn()] = pieceDeleted;
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


    }
}
