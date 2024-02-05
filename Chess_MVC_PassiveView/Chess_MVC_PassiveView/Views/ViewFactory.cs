using Chess_MVC_PassiveView.Views.Consol;

namespace Chess_MVC_PassiveView.Views
{
    internal interface IViewFactory
    {
        internal IPlayView CreatePlayView();
        internal IBoardView CreateBoardView();
    }
}
