using Chess_MVP_ModelViewPresenter.Presenters;

namespace Chess_MVP_ModelViewPresenter.Views
{
    internal interface IView : IPresentersVisitor
    {
        void Interact(AcceptorPresenter acceptorPresenter);
    }
}
