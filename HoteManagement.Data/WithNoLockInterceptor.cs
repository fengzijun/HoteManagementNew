using HoteManagement.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HoteManagement.Data
{
    public class WithNoLockInterceptor : DbCommandInterceptor
    {
        private const string InterceptionContextKey = "EM.WithNolockInterceptor";

        private readonly IAmbientScopeProvider<InterceptionContext> _interceptionScopeProvider;

        public WithNoLockInterceptor()
        {
            _interceptionScopeProvider = EngineContext.Current.Resolve<IAmbientScopeProvider<InterceptionContext>>();
        }

        public WithNoLockInterceptor(IAmbientScopeProvider<InterceptionContext> interceptionScopeProvider)
        {
            _interceptionScopeProvider = interceptionScopeProvider;
        }

        public InterceptionContext NolockingContext => _interceptionScopeProvider.GetValue(InterceptionContextKey);

        public override void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            using (UseNolocking())
            {
                if (NolockingContext?.UseNolocking ?? false)
                {
                    command.CommandText = GetNoLockSql(command.CommandText);
                    NolockingContext.CommandText = command.CommandText;
                }
            }
        }

        public override void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            using (UseNolocking())
            {
                if (NolockingContext?.UseNolocking ?? false)
                {
                    command.CommandText = GetNoLockSql(command.CommandText);
                    NolockingContext.CommandText = command.CommandText;
                }
            }
        }

        private string GetNoLockSql(string sql)
        {

            for (var index = 1; index < 10; index++)
            {
                string patternstring = @"(?<tableAlias>AS \[Extent" + index.ToString() + @"](?! WITH \(NOLOCK\)))";
                Regex TableAliasRegex = new Regex(patternstring, RegexOptions.Multiline | RegexOptions.IgnoreCase);
                sql = TableAliasRegex.Replace(sql, "${tableAlias} WITH (NOLOCK)", 1);
            }
            return sql;
        }

        public IDisposable UseNolocking()
        {
            return _interceptionScopeProvider.BeginScope(InterceptionContextKey, new InterceptionContext(string.Empty, true));
        }

        public class InterceptionContext
        {
            public InterceptionContext(string commandText, bool useNolocking)
            {
                CommandText = commandText;
                UseNolocking = useNolocking;
            }

            public string CommandText { get; set; }

            public bool UseNolocking { get; set; }
        }
    }
}
