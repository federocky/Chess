using Chess_MVC_PassiveView.Constrollers;
using System.Text;

namespace Chess_MVC_PassiveView
{
    internal class Chess
    {
        private Logic logic { get; set; }

        public Chess()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("♔ ♚"); // Prueba de salida

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