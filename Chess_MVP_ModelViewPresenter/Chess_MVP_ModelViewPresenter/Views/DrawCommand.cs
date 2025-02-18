using Chess_MVP_ModelViewPresenter.Controllers;
using Chess_MVP_ModelViewPresenter.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
