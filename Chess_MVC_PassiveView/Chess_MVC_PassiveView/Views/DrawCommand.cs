using Chess_MVC_PassiveView.Utils;

namespace Chess_MVC_PassiveView.Views
{
    internal class DrawCommand : Command
    {
        public DrawCommand() : base("Proponer tablas")
        {
        }

        public override void SetActive(bool isActive)
        {
            this.isActive = isActive;
        }
    }
}
