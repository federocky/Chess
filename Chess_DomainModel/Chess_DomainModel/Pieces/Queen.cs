﻿using Chess_DomainModel.Enums;

namespace Chess_DomainModel.Pieces
{
    public class Queen : Piece
    {
        public Queen(PieceColor color) : base(color, GetSymbolColor(color))
        {
        }

        private static string GetSymbolColor(PieceColor color)
        {
            return color == PieceColor.White ? "♕" : "♛";
        }

        public override bool IsValidMove(Coordinate origin, Coordinate target, IBoard board)
        {
            throw new NotImplementedException();
        }
    }
}