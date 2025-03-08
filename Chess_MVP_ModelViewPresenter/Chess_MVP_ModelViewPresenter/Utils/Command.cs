using Chess_MVP_ModelViewPresenter.Presenters;

namespace Chess_MVP_ModelViewPresenter.Utils
{
    internal abstract class Command
    {
        internal string title { get; set; }
        protected AcceptorPresenter acceptorPresenter;

        public Command(string title, AcceptorPresenter acceptorPresenter)
        {
            this.title = title;
            this.acceptorPresenter = acceptorPresenter;
        }
        public abstract void Execute();

        public String GetTitle()
        {
            return title;
        }
    }
}
