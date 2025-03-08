using Chess_MVP_ModelViewPresenter.Factory;
using Chess_MVP_ModelViewPresenter.Presenters;
using Chess_MVP_ModelViewPresenter.Views;

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
            AcceptorPresenter acceptorPresenter;
            do
            {
                acceptorPresenter = Logic.GetPresenter();
                if (!acceptorPresenter.IsNull())
                {
                    view.Interact(acceptorPresenter);
                }
            } while (!acceptorPresenter.IsNull());
        }

        static void Main(string[] args)
        {
            new Chess().Play();
        }
    }
}
