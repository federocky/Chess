﻿using Chess_MVP_ModelViewPresenter.Controllers;
using Chess_MVP_ModelViewPresenter.Utils;

namespace Chess_MVP_ModelViewPresenter.Views
{
    internal class DrawCommand : Command
    {
        public DrawCommand(PlayController playController) : base("Proponer tablas", playController)
        {
        }

        public override void Execute()
        {
            ((PlayController)this.acceptorController).Draw();
        }
    }
}
