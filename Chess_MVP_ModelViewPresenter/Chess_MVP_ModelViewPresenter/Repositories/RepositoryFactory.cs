using Chess_MVP_ModelViewPresenter.Utils;

namespace Chess_MVP_ModelViewPresenter.Repositories
{
    internal class RepositoryFactory
    {
        public static IRepository GetRepository()
        {
            if (GlobalConfig.databaseType == Enums.DatabaseType.FILE)
            {
                return new FileRepository();
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
