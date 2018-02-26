using HoteManagement.Configuration;
using HoteManagement.Data.UnitOfWork;
using HoteManagement.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoteManagement.Data
{
    public class DbMasterSlaveCommandInterceptor : DbCommandInterceptor
    {
        private readonly string _masterConnectionString;
        private readonly string _slaveConnectionString;

        private readonly IEfTransactionStrategy _transactionStrategy;
        private readonly IDbContextProvider _dbContextProvider;


        public DbMasterSlaveCommandInterceptor()
        {
            var config = EngineContext.Current.Resolve<ArticleConfig>();
            _transactionStrategy = EngineContext.Current.Resolve<IEfTransactionStrategy>();
            _dbContextProvider = EngineContext.Current.Resolve<IDbContextProvider>();
            _slaveConnectionString = config.MsSqlConnectionString;
            _masterConnectionString = config.MsSqlWriteConnectionString;
        }

        private bool IsInTranscation()
        {
            var result  = _dbContextProvider.GetDbContext().Database.CurrentTransaction != null;
            return result;
        }

      
        private bool IsSameConnection(string oldconnection, string newconnection)
        {
            if (newconnection.Contains(oldconnection))
                return true;

            return false;
        }

        private void UpdateConnectionStringIfNeed(DbCommand command , string newconnectionstring)
        {
            if (string.IsNullOrWhiteSpace(newconnectionstring)) return;

            if (IsSameConnection(command.Connection.ConnectionString, newconnectionstring))
                return;
            if(command.Connection.State == ConnectionState.Open)
                command.Connection.Close();

            command.Connection.ConnectionString = newconnectionstring;
            command.Connection.Open();

        }

        public override void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            //this.UpdateConnectionString(interceptionContext, this.slaveConnectionString);
            //command.Connection.ConnectionString = this.slaveConnectionString;
            string text = command.CommandText;

            if (IsInTranscation())
            {
                UpdateConnectionStringIfNeed(command, _masterConnectionString);
            }
            else
            {
                UpdateConnectionStringIfNeed(command, _slaveConnectionString);
            }

            base.ReaderExecuted(command, interceptionContext);
        }

        public override void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            //this.UpdateConnectionString(interceptionContext, this.slaveConnectionString);
            //command.Connection.ConnectionString = this.slaveConnectionString;
            string text = command.CommandText;
            if (IsInTranscation())
            {
                UpdateConnectionStringIfNeed(command, _masterConnectionString);
            }
            else
            {
                UpdateConnectionStringIfNeed(command, _slaveConnectionString);
            }

            base.ScalarExecuted(command, interceptionContext);
        }

        public override void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            string connection = command.Connection.ConnectionString;
            string sql = command.CommandText;
            UpdateConnectionStringIfNeed(command, _masterConnectionString);
            
            base.NonQueryExecuting(command, interceptionContext);
        }
    }
}