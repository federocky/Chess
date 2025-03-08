namespace Chess_MVP_ModelViewPresenter.Presenters
{
    internal interface IPresentersVisitor
    {
        void Visit(StartPresenter startPresenter);
        void Visit(PlayPresenter playPresenter);
        void Visit(ResumePresenter resumePresenter);
        void Visit(FinishPresenter finishPresenter);

    }
}
