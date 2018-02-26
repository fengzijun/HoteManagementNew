using System.Data.Entity;

namespace HoteManagement.Data
{
    public interface IDbContextFactory
    {
        DbContext GetWriteDbContext();

        DbContext GetReadDbContext();
    }
}