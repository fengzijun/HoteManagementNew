using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace HoteManagement.Data.UnitOfWork
{
    public class ActiveTransactionInfo: IDisposable
    {
        public DbContextTransaction DbContextTransaction { get; }

        public DbContext DbContext { get; }

        public List<DbContext> AttendedDbContexts { get; }

        public ActiveTransactionInfo(DbContextTransaction dbContextTransaction, DbContext starterDbContext)
        {
            DbContextTransaction = dbContextTransaction;
            DbContext = starterDbContext;

            AttendedDbContexts = new List<DbContext>();
        }

        public void Dispose()
        {
            if (DbContextTransaction != null)
                DbContextTransaction.Dispose();

            if (DbContext != null)
                DbContext.Dispose();

            if (AttendedDbContexts != null)
                AttendedDbContexts.Clear();
        }
    }
}