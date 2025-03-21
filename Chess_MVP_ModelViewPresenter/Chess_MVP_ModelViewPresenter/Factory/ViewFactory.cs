using Chess_MVP_ModelViewPresenter.Enums;
using Chess_MVP_ModelViewPresenter.Views;
using Chess_MVP_ModelViewPresenter.Views.Consol;

namespace Chess_MVP_ModelViewPresenter.Factory
{
    internal static class ViewFactory
    {
        public static IView CreateView(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.CONSOLE:
                    return new ConsoleView(new ConsoleViewFacade());
            }

            return null;
        }
    }
}
