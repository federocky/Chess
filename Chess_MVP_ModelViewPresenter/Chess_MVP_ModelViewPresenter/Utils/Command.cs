using Chess_MVP_ModelViewPresenter.Controllers;

namespace Chess_MVP_ModelViewPresenter.Utils
{
    internal abstract class Command
    {
        internal string title { get; set; }
        protected AcceptorController acceptorController;

        public Command(string title, AcceptorController acceptorController)
        {
            this.title = title;
            this.acceptorController = acceptorController;
        }
        public abstract void Execute();

        public String GetTitle()
        {
            return title;
        }
    }
}
