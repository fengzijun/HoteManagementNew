using System;
using System.Linq.Expressions;



using DapperExtensions;

namespace HoteManagement.Data.Dapper.Filters.Query
{
    public class NullDapperQueryFilterExecuter : IDapperQueryFilterExecuter
    {
        public static readonly NullDapperQueryFilterExecuter Instance = new NullDapperQueryFilterExecuter();

        public IPredicate ExecuteFilter<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : BaseEntity, new()
        {
            return null;
        }

        public PredicateGroup ExecuteFilter<TEntity>() where TEntity : BaseEntity, new()
        {
            return null;
        }
    }
}
