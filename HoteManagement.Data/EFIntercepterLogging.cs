
using HoteManagement.Configuration;
using HoteManagement.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoteManagement.Data
{
    public class EFIntercepterLogging : DbCommandInterceptor
    {
        private readonly Stopwatch _stopwatch = new Stopwatch();

        public override void ScalarExecuting(System.Data.Common.DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            base.ScalarExecuting(command, interceptionContext);
            _stopwatch.Restart();
        }

        public override void ScalarExecuted(System.Data.Common.DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            var logger = EngineContext.Current.Resolve<ILogger>();
            _stopwatch.Stop();
            if (interceptionContext.Exception != null)
            {
                logger.WriteErrorLog($"sql: {command.CommandText}, 发生异常", interceptionContext.Exception);
            }
            else
            {
                if (_stopwatch.ElapsedMilliseconds > 3 * 1000)
                    logger.WriteWarn($"查询超过3s sql: {command.CommandText},耗时{_stopwatch.ElapsedMilliseconds}ms");
            }
            //logger.WriteLog($"connection:{command.Connection.ConnectionString},sql:{command.CommandText}");
            base.ScalarExecuted(command, interceptionContext);
        }

        public override void NonQueryExecuting(System.Data.Common.DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            base.NonQueryExecuting(command, interceptionContext);
            _stopwatch.Restart();
        }

        public override void NonQueryExecuted(System.Data.Common.DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            var logger = EngineContext.Current.Resolve<ILogger>();
            _stopwatch.Stop();
            if (interceptionContext.Exception != null)
            {
                logger.WriteErrorLog($"sql: {command.CommandText}, 发生异常", interceptionContext.Exception);
            }
            else
            {
                if (_stopwatch.ElapsedMilliseconds > 3 * 1000)
                    logger.WriteWarn($"查询超过3s sql: {command.CommandText},耗时{_stopwatch.ElapsedMilliseconds}ms");
            }
            //logger.WriteLog($"connection:{command.Connection.ConnectionString},sql:{command.CommandText}");
            base.NonQueryExecuted(command, interceptionContext);
        }

        public override void ReaderExecuting(System.Data.Common.DbCommand command, DbCommandInterceptionContext<System.Data.Common.DbDataReader> interceptionContext)
        {
            base.ReaderExecuting(command, interceptionContext);
            _stopwatch.Restart();
        }

        public override void ReaderExecuted(System.Data.Common.DbCommand command, DbCommandInterceptionContext<System.Data.Common.DbDataReader> interceptionContext)
        {
            var logger = EngineContext.Current.Resolve<ILogger>();
            _stopwatch.Stop();
            if (interceptionContext.Exception != null)
            {
                logger.WriteErrorLog($"sql: {command.CommandText}, 发生异常", interceptionContext.Exception);
            }
            else
            {
                if (_stopwatch.ElapsedMilliseconds > 3 * 1000)
                    logger.WriteWarn($"查询超过3s sql: {command.CommandText},耗时{_stopwatch.ElapsedMilliseconds}ms");
            }

           // logger.WriteLog($"connection:{command.Connection.ConnectionString},sql:{command.CommandText}");
            base.ReaderExecuted(command, interceptionContext);
        }
    }
}