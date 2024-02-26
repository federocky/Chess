using Chess_MVC_PassiveView.Constrollers;
using Chess_MVC_PassiveView.Models;

namespace Chess_MVC_PassiveView
{
    internal class Chess
    {
        private Logic logic { get; set; }

        public Chess()
        {
            logic = new Logic();
        }


        protected void play()
        {
            AcceptorController acceptorController;
            do
            {
                acceptorController = logic.GetController();
                if(!acceptorController.IsNull())
                {
                    acceptorController.Control();
                }

            } while (!acceptorController.IsNull());
        }

        static void Main(string[] args)
        {
          new Chess().play();
        }
    }
}