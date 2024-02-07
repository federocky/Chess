using Chess_MVC_PassiveView.Views.Consol;

namespace Chess_MVC_PassiveView.Views
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
