﻿using Chess_MVP_ModelViewPresenter.Enums;
using Chess_MVP_ModelViewPresenter.Models.Pieces;

namespace Chess_MVP_ModelViewPresenter.Models
{
    public class Board : IBoard
    {
        protected Piece[][] board { get; set; }
        private Piece pieceDeleted { get; set; }
        private Coordinate lastMoveOrigin { get; set; }
        private Coordinate lastMoveTarget { get; set; }
        private int boardSize { get; set; }

        public Board()
        {
            Start();
        }

        public void Start()
        {
            board = new Piece[8][];
            pieceDeleted = new NullPiece();
            lastMoveOrigin = new Coordinate(0, 0);
            lastMoveTarget = new Coordinate(0, 0);
            boardSize = 8;
            FillBoard();
        }

        public void Start(string[][] piecesDisposition)
        {
            board = new Piece[8][];
            pieceDeleted = new NullPiece();
            lastMoveOrigin = new Coordinate(0, 0);
            lastMoveTarget = new Coordinate(0, 0);
            boardSize = 8;
            FillBoard(piecesDisposition);
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

            if (origin.Equals(target))
            {
                return false;
            }

            //check if there is a piece of my color in target
            var playingColor = board[origin.GetRow()][origin.GetColumn()].IsColor(PieceColor.White) ? PieceColor.White : PieceColor.Black;
            if (board[target.GetRow()][target.GetColumn()].IsColor(playingColor))
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
                if (coordinate.GetColumn() == boardSize || coordinate.GetRow() == boardSize) return true;
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

        public void Castle(PieceColor color, bool isMoveLeft)
        {
            var row = color == PieceColor.White ? 0 : 7;
            var originCol = isMoveLeft ? 0 : 7;
            var targetCol = isMoveLeft ? 3 : 5;

            var origin = new Coordinate(row, originCol);
            var target = new Coordinate(row, targetCol);
            MovePiece(origin, target);
        }

        public bool IsPawnPromotion(PieceColor color)
        {
            var row = color == PieceColor.White ? 7 : 0;

            for (int i = 0; i < boardSize; i++)
            {
                if (board[row][i] is Pawn) return true;
            }

            return false;
        }

        public void PromotePawn(Coordinate pawnCoordinate, PromotionPiece piece, PieceColor color)
        {
            Piece promotedTo = new Pawn(color);

            switch (piece)
            {
                case PromotionPiece.Bishop:
                    promotedTo = new Bishop(color);
                    break;
                case PromotionPiece.Knight:
                    promotedTo = new Knight(color);
                    break;
                case PromotionPiece.Rook:
                    promotedTo = new Rook(color);
                    break;
                case PromotionPiece.Queen:
                    promotedTo = new Queen(color);
                    break;
            }

            board[pawnCoordinate.GetRow()][pawnCoordinate.GetColumn()] = promotedTo;
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

        private void FillBoard(string[][] piecesDisposition)
        {
            for (int row = 0; row < piecesDisposition.Length; row++)
            {
                board[row] = new Piece[boardSize];

                for (int col = 0; col < piecesDisposition[row].Length; col++)
                {
                    board[row][col] = PlacePieceOnBoard(piecesDisposition[row][col]);
                }
            }
        }

        private void FillBoard()
        {
            for (int row = 0; row < boardSize; row++)
            {
                board[row] = new Piece[boardSize];
                for (int col = 0; col < boardSize; col++)
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

        private Piece PlacePieceOnBoard(string piece)
        {
            switch (piece)
            {
                case "♜":
                    return new Rook(PieceColor.Black);
                case "♞":
                    return new Knight(PieceColor.Black);
                case "♝":
                    return new Bishop(PieceColor.Black);
                case "♛":
                    return new Queen(PieceColor.Black);
                case "♚":
                    return new King(PieceColor.Black);
                case "♟":
                    return new Pawn(PieceColor.Black);
                case "♖":
                    return new Rook(PieceColor.White);
                case "♘":
                    return new Knight(PieceColor.White);
                case "♗":
                    return new Bishop(PieceColor.White);
                case "♕":
                    return new Queen(PieceColor.White);
                case "♔":
                    return new King(PieceColor.White);
                case "♙":
                    return new Pawn(PieceColor.White);
                default:
                    return new NullPiece();
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

        public String[][] DisplayBoard()
        {
            var result = new String[board.Length][];

            for (int row = 0; row < board.Length; row++)
            {
                result[row] = new string[board.Length];
                for (int col = 0; col < board[row].Length; col++)
                {
                    result[row][col] = board[row][col].ToString();
                }
            }

            return result;
        }

    }
}
