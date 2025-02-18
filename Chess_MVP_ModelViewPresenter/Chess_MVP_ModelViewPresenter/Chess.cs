using Chess_MVP_ModelViewPresenter.Controllers;
using Chess_MVP_ModelViewPresenter.Factory;
using Chess_MVP_ModelViewPresenter.Presenters;
using Chess_MVP_ModelViewPresenter.Views;
using Chess_MVP_ModelViewPresenter.Views.Consol;

namespace Chess_MVP_ModelViewPresenter
{
    internal class Chess
    {

        private Logic Logic { get; set; }
        private View view {  get; set; }

        public Chess()
        {
            Logic = new Logic();
            //TODO: change this to make view also a console view
            view = new View(new ViewFactory().GetViewFacade());
        }

        protected void Play()
        {
            AcceptorController acceptorController;
            do
            {
                acceptorController = Logic.GetController();
                if (!acceptorController.IsNull())
                {
                    view.Interact(acceptorController);
                }
            } while (!acceptorController.IsNull());
        }

        static void Main(string[] args)
        {
            new Chess().Play();
        }
    }
}
