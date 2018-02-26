using HoteManagement.Infrastructure;

namespace HoteManagement.Data
{
    public class EfStartUpTask : IStartupTask
    {
        public void Execute()
        {
            var provider = EngineContext.Current.Resolve<IDataProvider>();
            if (provider == null)
                throw new ArticleException("No IDataProvider found");
            provider.SetDatabaseInitializer(0);
        }

        public int Order
        {
            //ensure that this task is run first
            get { return -1000; }
        }
    }
}