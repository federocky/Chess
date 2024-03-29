﻿using Chess_DomainModel.Enums;

namespace Chess_DomainModel
{
    public class GameStatus
    {
        private bool drawOffer { get; set; }
        private bool isGameFinished { get; set; }
        private ReasonGameFinished reasonGameFinished { get; set; } 


        public GameStatus()
        {
            drawOffer = false;
            isGameFinished = false;
            reasonGameFinished = ReasonGameFinished.Null;
        }

        public void OfferDraw()
        {
            drawOffer = true;
        }

        public bool IsDrawOffer()
        {
            return drawOffer;
        }

        public void AcceptDrawOffer()
        {
            isGameFinished = true;
            reasonGameFinished = ReasonGameFinished.Draw;
        }

        public void DeclineDrawOffer()
        {
            drawOffer = false;
        }

        public void Resing()
        {
            isGameFinished = true;
            reasonGameFinished = ReasonGameFinished.Resign;
        }

        public bool IsGameFinished(Board board)
        {
            if (IsCheckMate(board)){
                isGameFinished = true;
                reasonGameFinished = ReasonGameFinished.Checkmate;
            }
            return isGameFinished;
        }

        public ReasonGameFinished GetReasonGameFinished()
        {
            return reasonGameFinished;
        }

        private bool IsCheckMate(Board board)
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
    }
}
