using Chess_MVC_PassiveView.Utils;

namespace Chess_MVC_PassiveView.Views
{
    internal class ResignCommand : Command
    {
        public ResignCommand() : base("Rendirse")
        {
        }

        public override void SetActive(bool isActive)
        {
            this.isActive = isActive;
        }
    }
}
