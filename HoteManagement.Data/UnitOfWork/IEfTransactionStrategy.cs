using HoteManagement.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoteManagement.Data.UnitOfWork
{
    public interface IEfTransactionStrategy
    {
        void InitOptions(UnitOfWorkOptions options);

        void Commit();

        void Dispose();

        //IDictionary<string, ActiveTransactionInfo> ActiveTransactions { get; set; }
        DbContext GetOrCreateDbContext();

        DbContext GetOrCreateDbContext(DbContext dbcontext, UnitOfWorkOptions options);

        void RollBack();

        bool IsInTranscation();

    }
}