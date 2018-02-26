using System.Data.Entity;

namespace HoteManagement.Data.UnitOfWork
{
    public class ActiveDbContextInfo
    {
        public DbContext DbContext { get; }

        public ActiveDbContextInfo(DbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}