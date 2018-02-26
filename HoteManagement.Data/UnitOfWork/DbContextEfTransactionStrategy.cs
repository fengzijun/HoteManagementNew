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
    public class DbContextEfTransactionStrategy : IEfTransactionStrategy
    {

        protected UnitOfWorkOptions Options { get; private set; }

        public IDictionary<string, ActiveTransactionInfo> ActiveTransactions { get; set; }

        public DbContextEfTransactionStrategy()
        {
            if (ActiveTransactions == null)
                ActiveTransactions = new Dictionary<string, ActiveTransactionInfo>();
        }

        public void InitOptions(UnitOfWorkOptions options)
        {
            Options = options;
            if(ActiveTransactions == null)
                 ActiveTransactions = new Dictionary<string, ActiveTransactionInfo>();
            //StartTranscation();
        }

        public void StartTranscation(DbContext dbcontext)
        {
            //_dbContext dbContext = EngineContext.Current.Resolve<IDbContext>() as _dbContext;

            //if(dbContext.Database.CurrentTransaction == null)
            //{
            //    dbContext.Database.BeginTransaction((Options.IsolationLevel ?? IsolationLevel.ReadCommitted).ToSystemDataIsolationLevel());
            //}
            //else
            //{
            //    dbContext.Database.UseTransaction(dbContext.Database.CurrentTransaction.UnderlyingTransaction);
            //}
            //var activeTransaction = ActiveTransactions.GetOrDefault(dbContext.Database.Connection.ConnectionString);
            //if (activeTransaction == null)
            //{
            //    //dbContext = dbContextResolver.Resolve<TDbContext>(connectionString);
            //    var dbtransaction = dbContext.Database.BeginTransaction((Options.IsolationLevel ?? IsolationLevel.ReadCommitted).ToSystemDataIsolationLevel());
            //    activeTransaction = new ActiveTransactionInfo(dbtransaction, dbContext);
            //    ActiveTransactions[dbContext.Database.Connection.ConnectionString] = activeTransaction;
            //}
            //else
            //{
            //    //dbContext = dbContextResolver.Resolve<TDbContext>(activeTransaction.DbContextTransaction.UnderlyingTransaction.Connection, false);
            //    dbContext.Database.UseTransaction(activeTransaction.DbContextTransaction.UnderlyingTransaction);
            //    //activeTransaction.AttendedDbContexts.Add(dbContext);
            //}

            //return dbContext;

            //if (Options.IsTransactional == true)
            //{
            //    if (ActiveTransactions == null)
            //    {
            //        DbContext dbContext = EngineContext.Current.Resolve<IDbContext>() as DbContext;
            //        var tran = dbContext.Database.BeginTransaction((Options.IsolationLevel ?? IsolationLevel.ReadCommitted).ToSystemDataIsolationLevel());
            //        ActiveTransactions = new ActiveTransactionInfo(tran, dbContext);
            //        return;
            //    }

            //    if (ActiveTransactions.DbContextTransaction != null && ActiveTransactions.DbContext.Database.CurrentTransaction == null)
            //        ActiveTransactions.DbContext.Database.UseTransaction(ActiveTransactions.DbContextTransaction.UnderlyingTransaction);
            //}
         
            //ActiveTransactions.DbContextTransaction.UseTransaction(dbContext.Database.CurrentTransaction.UnderlyingTransaction);

        }

        public DbContext GetOrCreateDbContext()
        {
            //if (ActiveTransactions == null)
            //{
            //    _dbContext dbContext = EngineContext.Current.Resolve<IDbContext>() as _dbContext;
            //    var tran = dbContext.Database.BeginTransaction((Options.IsolationLevel ?? IsolationLevel.ReadCommitted).ToSystemDataIsolationLevel());
            //    ActiveTransactions = new ActiveTransactionInfo(tran, dbContext);
            //    return dbContext;
            //}

            //if (ActiveTransactions.DbContextTransaction != null && ActiveTransactions._dbContext.Database.CurrentTransaction == null)
            //    ActiveTransactions._dbContext.Database.UseTransaction(ActiveTransactions.DbContextTransaction.UnderlyingTransaction);

            ////ActiveTransactions.DbContextTransaction.UseTransaction(dbContext.Database.CurrentTransaction.UnderlyingTransaction);

            //return ActiveTransactions._dbContext;

            //if (ActiveTransactions == null)
            //    return null;

            //return ActiveTransactions.DbContext;

            DbContext dbContext;

            var activeTransaction = ActiveTransactions.Select(s => s.Value).FirstOrDefault();
            if (activeTransaction == null)
            {
                dbContext = EngineContext.Current.Resolve<IDbContext>() as DbContext;
                var dbtransaction = dbContext.Database.BeginTransaction((Options.IsolationLevel ?? IsolationLevel.ReadCommitted).ToSystemDataIsolationLevel());
                activeTransaction = new ActiveTransactionInfo(dbtransaction, dbContext);
                ActiveTransactions[dbContext.Database.Connection.ConnectionString] = activeTransaction;
            }
            else
            {
                dbContext = activeTransaction.DbContext;
                if (dbContext.Database.CurrentTransaction == null )
                {
                    dbContext.Database.UseTransaction(activeTransaction.DbContextTransaction.UnderlyingTransaction);
                    activeTransaction.AttendedDbContexts.Add(dbContext);
                }
                else
                {
                    //dbContext = EngineContext.Current.Resolve<IDbContext>() as DbContext;
                    //var dbtransaction = dbContext.Database.BeginTransaction((Options.IsolationLevel ?? IsolationLevel.ReadCommitted).ToSystemDataIsolationLevel());
                    //activeTransaction = new ActiveTransactionInfo(dbtransaction, dbContext);
                    //ActiveTransactions[dbContext.Database.Connection.ConnectionString] = activeTransaction;
                }
               
            }

            return dbContext;

        }

        public DbContext GetOrCreateDbContext(DbContext dbcontext, UnitOfWorkOptions options)
        {
            //if (ActiveTransactions == null)
            //{
            //    _dbContext dbContext = EngineContext.Current.Resolve<IDbContext>() as _dbContext;
            //    var tran = dbContext.Database.BeginTransaction((Options.IsolationLevel ?? IsolationLevel.ReadCommitted).ToSystemDataIsolationLevel());
            //    ActiveTransactions = new ActiveTransactionInfo(tran, dbContext);
            //    return dbContext;
            //}

            //if (ActiveTransactions.DbContextTransaction != null && ActiveTransactions._dbContext.Database.CurrentTransaction == null)
            //    ActiveTransactions._dbContext.Database.UseTransaction(ActiveTransactions.DbContextTransaction.UnderlyingTransaction);

            ////ActiveTransactions.DbContextTransaction.UseTransaction(dbContext.Database.CurrentTransaction.UnderlyingTransaction);

            //return ActiveTransactions._dbContext;

            //if (ActiveTransactions == null)
            //    return null;

            //return ActiveTransactions.DbContext;
            InitOptions(options);
            var activeTransaction = ActiveTransactions.Select(s => s.Value).FirstOrDefault();
            if (activeTransaction == null)
            {
                var dbtransaction = dbcontext.Database.BeginTransaction((Options.IsolationLevel ?? IsolationLevel.ReadCommitted).ToSystemDataIsolationLevel());
                activeTransaction = new ActiveTransactionInfo(dbtransaction, dbcontext);
                ActiveTransactions[dbcontext.Database.Connection.ConnectionString] = activeTransaction;
            }
            else
            {
                if (dbcontext.Database.CurrentTransaction == null )
                {
                    dbcontext.Database.UseTransaction(activeTransaction.DbContextTransaction.UnderlyingTransaction);
                    activeTransaction.AttendedDbContexts.Add(dbcontext);
                }
                else
                {
                    //var dbtransaction = dbcontext.Database.BeginTransaction((Options.IsolationLevel ?? IsolationLevel.ReadCommitted).ToSystemDataIsolationLevel());
                    //activeTransaction = new ActiveTransactionInfo(dbtransaction, dbcontext);
                    //ActiveTransactions[dbcontext.Database.Connection.ConnectionString] = activeTransaction;
                }
            }

            return dbcontext;

        }

        public void RollBack()
        {
            //foreach (var activeTransaction in ActiveTransactions.Values)
            //{
            //    //activeTransaction.DbContextTransaction.Rollback();
            //    if (activeTransaction._dbContext != null && activeTransaction._dbContext.Database.CurrentTransaction != null)
            //        activeTransaction._dbContext.Database.CurrentTransaction.Rollback();
            //}

            //_dbContext dbContext = EngineContext.Current.Resolve<IDbContext>() as _dbContext;
            //if (dbContext.Database.CurrentTransaction != null)
            //    dbContext.Database.CurrentTransaction.Rollback();

            foreach (var activeTransaction in ActiveTransactions.Values)
            {
                activeTransaction.DbContextTransaction.Rollback();
            }
        }

        public bool IsInTranscation()
        {
            if (ActiveTransactions == null || ActiveTransactions.Count == 0)
                return false;

            if (ActiveTransactions.FirstOrDefault().Value.DbContext != null && ActiveTransactions.FirstOrDefault().Value.DbContext.Database.CurrentTransaction != null)
                return true;

            return false;
        }

        public void Commit()
        {
            //_dbContext dbContext = EngineContext.Current.Resolve<IDbContext>() as _dbContext;
            //if (dbContext.Database.CurrentTransaction != null)
            //    dbContext.Database.CurrentTransaction.Commit();
            foreach (var activeTransaction in ActiveTransactions.Values)
            {
                activeTransaction.DbContextTransaction.Commit();
            }
        }

        public void Dispose()
        {
            foreach (var activeTransaction in ActiveTransactions.Values)
            {
                if (activeTransaction.AttendedDbContexts != null && activeTransaction.AttendedDbContexts.Count > 0)
                {
                    foreach (var attendedDbContext in activeTransaction.AttendedDbContexts)
                    {
                        attendedDbContext.Dispose();
                    }
                }

                if (activeTransaction.DbContextTransaction != null)
                    activeTransaction.DbContextTransaction.Dispose();

                if (activeTransaction.DbContext.Database.CurrentTransaction != null)
                    activeTransaction.DbContext.Database.CurrentTransaction.Dispose();
                //activeTransaction._dbContext.Dispose();
            }


            //_dbContext dbContext = EngineContext.Current.Resolve<IDbContext>() as _dbContext;
            //if (dbContext.Database.CurrentTransaction != null)
            //    dbContext.Database.CurrentTransaction.Dispose();
            foreach (var activeTransaction in ActiveTransactions.Values)
            {
                activeTransaction.Dispose();
            }

            ActiveTransactions.Clear();
        }
    }
}