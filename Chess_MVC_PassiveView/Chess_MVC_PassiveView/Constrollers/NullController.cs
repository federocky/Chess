using Chess_MVC_PassiveView.Models;

namespace Chess_MVC_PassiveView.Constrollers
{
    internal class NullController : AcceptorController
    {
        public NullController() : base(new Board(), new Turn(), new GameStatus(), new Session())
        {
        }

        public override void Control()
        {
            
        }

        public override bool IsNull()
        {
            return true;
        }
    }
}
