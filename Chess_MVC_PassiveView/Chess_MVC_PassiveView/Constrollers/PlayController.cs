﻿using Chess_MVC_PassiveView.Models;
using Chess_MVC_PassiveView.Utils;
using Chess_MVC_PassiveView.Views;

namespace Chess_MVC_PassiveView.Constrollers
{
    internal class PlayController : AcceptorController
    {
        private IBoardView boardView { get; set; }
        private IPlayView playView { get; set; }

        private Dictionary<Command, Controller> controllers { get; set; }
        private MoveCommand moveCommand {  get; set; }
        private MoveController moveController { get; set; }
        private ResignCommand resignCommand { get; set; }
        private ResignController resignController { get; set; }
        private DrawCommand drawCommand { get; set; }
        private DrawController drawController { get; set; }
        private SaveCommand saveCommand { get; set; }
        private SaveController saveController { get; set; }
        private Menu menu { get; set; }


        public PlayController(Board board, Turn turn, Session session) : base(board, turn, session)
        {
            boardView = viewFacade.CreateBoardView();
            playView = viewFacade.CreatePlayView();

            controllers = new Dictionary<Command, Controller>();
            moveCommand = new MoveCommand();
            moveController = new MoveController(board, turn, session);
            resignCommand = new ResignCommand();
            resignController = new ResignController(board, turn, session);
            drawCommand = new DrawCommand();
            drawController = new DrawController(board, turn, session);
            saveCommand = new SaveCommand();
            saveController = new SaveController(board, turn, session);

            controllers.Add(moveCommand, moveController);
            controllers.Add(resignCommand, resignController);
            controllers.Add(drawCommand, drawController);
            controllers.Add(saveCommand, saveController);

            menu = new Menu(controllers.Keys);
        }

        public override void Control()
        {
            session.Next();
            do
            {
                Play();
            } while (!session.IsGameFinished(board));

        }

        private void Play()
        {
            boardView.Print(board.DisplayBoard());
            playView.ShowPlayer(turn.GetPlaying());

            if (!drawController.HandleDrawOffer())
            {
                moveCommand.SetActive(true);
                resignCommand.SetActive(true);
                drawCommand.SetActive(true);
                saveCommand.SetActive(true);
                controllers[menu.Execute()].Control();
            }

            turn.Next();
        }


    }
}
