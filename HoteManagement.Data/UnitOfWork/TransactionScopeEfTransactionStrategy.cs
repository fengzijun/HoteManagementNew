using HoteManagement.Infrastructure;
using HoteManagement.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace HoteManagement.Data.UnitOfWork
{
    public class TransactionScopeEfTransactionStrategy : IEfTransactionStrategy
    {
        protected UnitOfWorkOptions Options { get; private set; }


        public IDictionary<string, ActiveTransactionInfo> ActiveTransactions { get; set; }

        protected TransactionScope CurrentTransaction { get; set; }


        public TransactionScopeEfTransactionStrategy()
        {
            ActiveTransactions = new Dictionary<string, ActiveTransactionInfo>();
        }

        public void InitOptions(UnitOfWorkOptions options)
        {
            Options = options;

            StartTransaction();
        }

        public DbContext GetOrCreateDbContext()
        {        
            var dbContext = EngineContext.Current.Resolve<IDbContext>() as DbContext;
            //DbContexts.Add(dbContext);
            return dbContext;
        }

        public DbContext GetOrCreateDbContext(DbContext dbcontext, UnitOfWorkOptions options)
        {
            Options = options;
            return dbcontext;
        }


        public void RollBack()
        {

        }

        public bool IsInTranscation()
        {

            return false;
        }

        public virtual void Commit()
        {
            if (CurrentTransaction == null)
            {
                return;
            }

            CurrentTransaction.Complete();

            CurrentTransaction.Dispose();
            CurrentTransaction = null;
        }

        private void StartTransaction()
        {
            if (CurrentTransaction != null)
            {
                return;
            }

            var transactionOptions = new TransactionOptions
            {
                IsolationLevel = Options.IsolationLevel.GetValueOrDefault(IsolationLevel.ReadCommitted),
            };

            if (Options.Timeout.HasValue)
            {
                transactionOptions.Timeout = Options.Timeout.Value;
            }

            CurrentTransaction = new TransactionScope(
                Options.Scope.GetValueOrDefault(TransactionScopeOption.Required),
                transactionOptions,
                Options.AsyncFlowOption.GetValueOrDefault(TransactionScopeAsyncFlowOption.Enabled)
            );

           
        }

        public virtual void Dispose()
        {
            foreach (var activeTransaction in ActiveTransactions.Values)
            {
                //if (activeTransaction.AttendedDbContexts != null && activeTransaction.AttendedDbContexts.Count > 0)
                //{
                //    foreach (var attendedDbContext in activeTransaction.AttendedDbContexts)
                //    {
                //        attendedDbContext.Dispose();
                //    }
                //}
                if(activeTransaction.DbContextTransaction!=null)
                     activeTransaction.DbContextTransaction.Dispose();

                if (activeTransaction.DbContext.Database.CurrentTransaction != null)
                    activeTransaction.DbContext.Database.CurrentTransaction.Dispose();
            }

            ActiveTransactions.Clear();

            if (CurrentTransaction != null)
            {
                CurrentTransaction.Dispose();
                CurrentTransaction = null;
                
            }
        }
    }
}