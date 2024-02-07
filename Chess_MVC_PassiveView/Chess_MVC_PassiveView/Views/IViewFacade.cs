using Chess_MVC_PassiveView.Views.Consol;

namespace Chess_MVC_PassiveView.Views
{
    internal interface IViewFacade
    {
        internal IPlayView CreatePlayView();
        internal IBoardView CreateBoardView();
        internal IResumeView CreateResumeView();
    }
}
