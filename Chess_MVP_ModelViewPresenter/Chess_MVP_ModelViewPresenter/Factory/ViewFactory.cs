using Chess_MVP_ModelViewPresenter.Views;
using Chess_MVP_ModelViewPresenter.Views.Consol;

namespace Chess_MVP_ModelViewPresenter.Factory
{
    internal class ViewFactory
    {
        public IViewFacade GetViewFacade()
        {
            //TODO: implement logic to determin whether you need a console or other types of views
            return new ConsoleViewFacade();
        }
    }
}
