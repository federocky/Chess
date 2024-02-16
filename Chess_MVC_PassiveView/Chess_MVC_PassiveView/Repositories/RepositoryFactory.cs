using Chess_MVC_PassiveView.Utils;

namespace Chess_MVC_PassiveView.Repositories
{
    internal static class RepositoryFactory
    {
        public static IRepository GetRepository()
        {
            if(GlobalConfig.databaseType == Enums.DatabaseType.FILE)
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
