using Chess_MVC_PassiveView.Utils;

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
