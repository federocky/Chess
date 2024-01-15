﻿using Chess_DomainModel.Enums;
using Chess_DomainModel.Pieces;

namespace Chess_DomainModel
{
    public class Player
    {
        private PieceColor color;

        public Player(PieceColor color)
        {
            this.color = color;
        }

        //TODO: metodo muy largo.
        public void Play(Board board)
        {
            var originInput = "";
            var targetInput = "";
            Piece piece;
            Coordinate origin;
            Coordinate target;
            bool pieceCanMove;

            Console.WriteLine($"Player {color} playing");
            
            do
            {
                do
                {
                    do
                    {
                        Console.WriteLine("Introduzca un origen válido");
                        originInput = Console.ReadLine();

                    } while (!IsValidInput(originInput));

                    origin = new Coordinate(originInput);

                    piece = board.GetPiece(origin);

                    if (piece is NullPiece || !piece.IsColor(color)) Console.WriteLine("No hay una pieza de tu color en esa casilla");

                } while (piece is NullPiece || !piece.IsColor(color));

                do
                {
                    Console.WriteLine("Introduzca un destino válido");
                    targetInput = Console.ReadLine();

                } while (!IsValidInput(targetInput));

                target = new Coordinate(targetInput);

                pieceCanMove = piece.IsValidMove(origin, target, board);

                if (!pieceCanMove) Console.WriteLine("No se puede realizar el movimiento");

            } while (!pieceCanMove);

            board.MovePiece(origin, target);

            board.Write();

        }

        //TODO: esto huele a que lo debería saber el tablero y no el player.
        private bool IsValidInput(string input)
        {
            if(string.IsNullOrEmpty(input)) return false;
            if(input.Length < 2 || input.Length > 2) return false;

            var firstChar = input[0].ToString().ToLower();
            if (!firstChar.Equals("a") && !firstChar.Equals("b") && 
                !firstChar.Equals("c") && !firstChar.Equals("d") && 
                !firstChar.Equals("e") && !firstChar.Equals("f") &&
                !firstChar.Equals("g") && !firstChar.Equals("h")) return false;

            var secondChar = input[1].ToString();
            if(!int.TryParse(secondChar, out var result)) return false;
            if (result <= 0 || result > 8) return false;

            return true;
        }
    }
}