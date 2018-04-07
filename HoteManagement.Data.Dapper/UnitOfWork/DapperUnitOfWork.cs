using HoteManagement.Infrastructure;
using HoteManagement.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoteManagement.Data.Dapper.UnitOfWork
{
    public class DapperUnitOfWork: UnitOfWorkBase
    {
        private readonly IDapperTransactionStrategy _transactionStrategy;

        protected IDictionary<string, DbConnection> ActiveDbConnections { get; }

        public DapperUnitOfWork(IDapperTransactionStrategy transactionStrategy)
        {
            _transactionStrategy = transactionStrategy;
            ActiveDbConnections = new Dictionary<string, DbConnection>();
        }


        public override void CompleteUow()
        {
            //GetAllActiveDbContexts().ForEach(SaveChangesInDbContext);

            //SaveChanges();

            if (Options.IsTransactional == true)
            {
                _transactionStrategy.Commit();
            }
        }

        public override async Task CompleteUowAsync()
        {
            //await SaveChangesAsync();

            if (Options.IsTransactional == true)
            {
                _transactionStrategy.Commit();
            }
        }

        public override void BeginUow()
        {
            if (Options.IsTransactional == true)
            {
                _transactionStrategy.InitOptions(Options);
            }

            var connection = GetOrCreateDbContext();
            Logger.WriteWarn(connection.ConnectionString);
            if (connection.State != ConnectionState.Open)
                connection.Open();
        }

        public override void DisposeUow()
        {
            if (Options.IsTransactional == true)
            {
                _transactionStrategy.Dispose();
            }

            var dbconnections = GetAllActiveDbConections();

            if (dbconnections != null && dbconnections.Count > 0)
            {
                foreach (var activeDbContext in dbconnections)
                {
                    activeDbContext.Dispose();
                }
            }

            ActiveDbConnections.Clear();

            var connection = GetOrCreateDbContext();
            if (connection != null)
                connection.Dispose();
        }

        public override void RollBack()
        {
            _transactionStrategy.RollBack();
        }

        public List<DbConnection> GetAllActiveDbConections()
        {
            //return _transactionStrategy.ActiveTransactions.Values.ToList();
            return ActiveDbConnections.Values.ToList();
        }


        protected virtual void SaveChangesInDbContext(DbConnection dbContext)
        {
            //_dbContext dbcontext2 = EngineContext.Current.Resolve<IDbContext>() as _dbContext;

            //dbContext.SaveChanges();
        }

        protected virtual async Task SaveChangesInDbContextAsync(DbConnection dbContext)
        {
            //await dbContext.SaveChangesAsync();

        }

        public override void Complete(UnitOfWorkOptions options)
        {
            if (options.IsTransactional == true)
            {
                _transactionStrategy.Commit();
            }
        }

        public virtual DbConnection GetOrCreateDbContext()
        {
            if (ActiveDbConnections.Count > 0)
            {
                var dbcontext = ActiveDbConnections.Select(s => s.Value).FirstOrDefault();

                if (Options != null && Options.IsTransactional == true)
                {
                    return _transactionStrategy.GetOrCreateDbConnection(dbcontext, Options);
                }

                return dbcontext;
            }

            DbConnection dbContext;
            if (Options != null && Options.IsTransactional == true)
                dbContext = _transactionStrategy.GetOrCreateDbConnection();
            else
                dbContext = EngineContext.Current.Resolve<IDbConnection>() as DbConnection;

            ActiveDbConnections[dbContext.ConnectionString] = dbContext;
            return dbContext;
        }

        public void SaveChanges()
        {
           // GetAllActiveDbContexts().ForEach(SaveChangesInDbContext);
        }

        public async Task SaveChangesAsync()
        {
            //foreach (var dbContext in GetAllActiveDbContexts())
            //{
            //    await SaveChangesInDbContextAsync(dbContext);
            //}
        }
    }
}
