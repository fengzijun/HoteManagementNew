using System;
using System.Linq.Expressions;

using DapperExtensions;


namespace HoteManagement.Data.Dapper.Expressions
{
    internal static class DapperExpressionExtensions
    {

        public static IPredicate ToPredicateGroup<TEntity>(this Expression<Func<TEntity, bool>> expression) where TEntity : BaseEntity , new()
        {
           
            var dev = new DapperExpressionVisitor<TEntity>();
            IPredicate pg = dev.Process(expression);

            return pg;
        }
    }
}
