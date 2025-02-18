using Chess_MVP_ModelViewPresenter.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_MVP_ModelViewPresenter.Views
{
    internal class PlayMenu : Menu
    {
        public PlayMenu(PlayController playController)
        {
            AddCommand(new MoveCommand(playController));
            AddCommand(new DrawCommand(playController));
        }
    }
}
