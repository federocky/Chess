using Chess_MVC_PassiveView.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_MVC_PassiveView.Views
{
    internal class MoveCommand : Command
    {
        public MoveCommand() : base("Realiza un movimiento")
        {
        }

        public override void SetActive(bool isActive)
        {
            this.isActive = isActive;
        }
    }
}
