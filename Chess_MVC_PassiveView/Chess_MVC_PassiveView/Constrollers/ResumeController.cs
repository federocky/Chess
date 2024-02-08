﻿using Chess_MVC_PassiveView.Models;

namespace Chess_MVC_PassiveView.Constrollers
{
    internal class ResumeController : Controller
    {
        public ResumeController(Board board, Turn turn, GameStatus gameStatus) : base(board, turn, gameStatus)
        {
        }
        public bool control()
        {
            var restart = viewFacade.CreateResumeView().ReadRestartGame();

            if(restart == "1")
            {
                board = new Board();
                gameStatus.Restart();
                turn.Restart();
                return true;
            }

            return false;
        }
    }
}
