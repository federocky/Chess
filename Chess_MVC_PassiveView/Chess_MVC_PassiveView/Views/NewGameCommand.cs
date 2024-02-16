using Chess_MVC_PassiveView.Utils;

namespace Chess_MVC_PassiveView.Views
{
    internal class NewGameCommand : Command
    {
        public NewGameCommand() : base("Partida nueva")
        {
        }

        public override void SetActive(bool isActive)
        {
           this.isActive = isActive;
        }
    }
}
