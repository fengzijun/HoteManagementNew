using System;
using System.Linq.Expressions;

using DapperExtensions;

namespace HoteManagement.Data.Dapper.Filters.Query
{
    public interface IDapperQueryFilter 
    {

        IFieldPredicate ExecuteFilter<TEntity>() where TEntity : BaseEntity, new();

        Expression<Func<TEntity, bool>> ExecuteFilter<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : BaseEntity, new();
    }
}
