namespace Chess_MVC_PassiveView.Utils
{
    internal abstract class Command
    {
        internal string title { get; set; }
        public bool isActive { get; set; }

        public Command(string title)
        {
            this.title = title;
            isActive = false;
        }

        public abstract void SetActive(bool isActive);

        public bool IsActive()
        {
            return isActive;
        }

        public String GetTitle()
        {
            return title;
        }
    }
}
