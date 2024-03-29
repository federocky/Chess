﻿using Chess_MVC_PassiveView.Models;
using Chess_MVC_PassiveView.Repositories;

namespace Chess_MVC_PassiveView.Constrollers
{
    internal class SaveController : InGameController
    {
        
        private IRepository repository { get; set; }

        public SaveController(Board board, Turn turn, Session session) : base(board, turn, session)
        {
            repository = RepositoryFactory.GetRepository();
        }

        public override void Control()
        {
            string datetime = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string gameName = $"game_{datetime}";
            var printedBoard = board.DisplayBoard();
            var playerColor = turn.GetPlaying();
            var flatBoard = "";

            for (int row = 7; row >= 0; row--)
            {
                for (int col = 0; col < 8; col++)
                {
                    flatBoard += printedBoard[row][col];                    
                }
            }

            if (repository.Save(flatBoard, gameName, playerColor))
            {
                session.GameSaved();
                viewFacade.CreatePlayView().ShowGameSaved();
            } 
            else
            {
                viewFacade.CreateErrorView().ShowErrorSaving(gameName);
            }
        }
    }
}
