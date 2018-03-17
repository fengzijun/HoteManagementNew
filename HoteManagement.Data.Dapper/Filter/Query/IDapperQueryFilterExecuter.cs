using System;
using System.Linq.Expressions;

using DapperExtensions;

namespace HoteManagement.Data.Dapper.Filters.Query
{
    public interface IDapperQueryFilterExecuter
    {
        IPredicate ExecuteFilter<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : BaseEntity, new();

        PredicateGroup ExecuteFilter<TEntity>() where TEntity : BaseEntity, new();
    }
}
