using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoteManagement.Data.Dapper.UnitOfWork
{
    public class ActiveTransactionInfo : IDisposable
    {
        public DbTransaction DbTransaction { get; }

        public DbConnection DbContext { get; }

        public List<DbConnection> AttendedDbContexts { get; }

        public ActiveTransactionInfo(DbTransaction dbContextTransaction, DbConnection starterDbContext)
        {
            DbTransaction = dbContextTransaction;
            DbContext = starterDbContext;

            AttendedDbContexts = new List<DbConnection>();
        }

        public void Dispose()
        {
            if (DbTransaction != null)
                DbTransaction.Dispose();

            if (DbContext != null)
                DbContext.Dispose();

            if (AttendedDbContexts != null)
                AttendedDbContexts.Clear();
        }
    }
}
