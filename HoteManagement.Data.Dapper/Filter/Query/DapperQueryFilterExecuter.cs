using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HoteManagement.Data.Dapper.Expressions;

using DapperExtensions;

namespace HoteManagement.Data.Dapper.Filters.Query
{
    public class DapperQueryFilterExecuter : IDapperQueryFilterExecuter
    {
        //private readonly IEnumerable<IDapperQueryFilter> _queryFilters;

        public IPredicate ExecuteFilter<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : BaseEntity, new()
        {
            //ICollection<IDapperQueryFilter> filters = _queryFilters.ToList();

            //foreach (IDapperQueryFilter filter in filters)
            //{
            //    predicate = filter.ExecuteFilter<TEntity>(predicate);
            //}

            IPredicate pg = predicate.ToPredicateGroup<TEntity>();
            return pg;
        }

        public PredicateGroup ExecuteFilter<TEntity>() where TEntity : BaseEntity, new()
        {
            //ICollection<IDapperQueryFilter> filters = _queryFilters.ToList();
            var groups = new PredicateGroup
            {
                Operator = GroupOperator.And,
                Predicates = new List<IPredicate>()
            };

            //foreach (IDapperQueryFilter filter in filters)
            //{
            //    IFieldPredicate predicate = filter.ExecuteFilter<TEntity>();
            //    if (predicate != null)
            //    {
            //        groups.Predicates.Add(predicate);
            //    }
            //}

            return groups;
        }
    }
}
