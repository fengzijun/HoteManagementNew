using HoteManagement.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoteManagement.Data.Dapper.UnitOfWork
{
    public interface IDapperTransactionStrategy
    {
        void InitOptions(UnitOfWorkOptions options);

        void Commit();

        void Dispose();

        //IDictionary<string, ActiveTransactionInfo> ActiveTransactions { get; set; }
        DbConnection GetOrCreateDbConnection();

        DbConnection GetOrCreateDbConnection(DbConnection dbcontext, UnitOfWorkOptions options);

        void RollBack();

        bool IsInTranscation();
    }
}
