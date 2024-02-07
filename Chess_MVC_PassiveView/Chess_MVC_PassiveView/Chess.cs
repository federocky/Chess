using Chess_MVC_PassiveView.Constrollers;

namespace Chess_MVC_PassiveView
{
    internal class Chess
    {
        private PlayController playController { get; set; }
        private ResumeController resumeController { get; set; }

        public Chess()
        {
            playController = new PlayController();
            resumeController = new ResumeController();
        }


        protected void play()
        {
            do
            {
                playController.control();
            } while (resumeController.control());
        }

        static void Main(string[] args)
        {
          new Chess().play();
        }
    }
}