using HoteManagement.Data.Dapper.UnitOfWork;
using HoteManagement.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DapperExtensions;
using HoteManagement.Data.Dapper.Filters.Query;

namespace HoteManagement.Data.Dapper
{
    public class DapperRepository<T> : IRepository<T> where T : BaseEntity, new()
    {
        #region Fields

        private IUnitOfWork _unitofwork;
        private IDbConnectionProvider _dbconnectionProvider;
        private IDapperQueryFilterExecuter _dapperQueryFilterExecuter;

        #endregion Fields

        public DapperRepository(IUnitOfWork unitofwork,IDbConnectionProvider dbconnectionProvider, IDapperQueryFilterExecuter dapperQueryFilterExecuter)
        {
            _unitofwork = unitofwork;
            _dbconnectionProvider = dbconnectionProvider;
            _dapperQueryFilterExecuter = dapperQueryFilterExecuter;

        }


        /// <summary>
        /// Get entity by identifier
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Entity</returns>
        public T GetById(object id)
        {
            IDbConnection connnection = _dbconnectionProvider.GetConnection();
            //string sql = string.Format("Select * from {0} where id = @id", typeof(T).Name);
            return connnection.Get<T>(id);
        }

        public IEnumerable<T> GetList(string sql, object parameters = null)
        {
            IDbConnection connnection = _dbconnectionProvider.GetConnection();
            
            return connnection.Query<T>(sql, parameters);
        }

        public int Execute(string query, object parameters = null)
        {
            IDbConnection connnection = _dbconnectionProvider.GetConnection();
            return connnection.Execute(query, parameters);
        }

        public IEnumerable<T> GetAllPaged(Expression<Func<T, bool>> predicate, int pageNumber, int itemsPerPage, string sortingProperty, bool ascending = true)
        {
            IPredicate filteredPredicate = _dapperQueryFilterExecuter.ExecuteFilter<T>(predicate);
            IDbConnection connnection = _dbconnectionProvider.GetConnection();
            return connnection.GetPage<T>(
                filteredPredicate,
                new List<ISort> { new Sort { Ascending = ascending, PropertyName = sortingProperty } },
                pageNumber,
                itemsPerPage,
                null);
        }

        public int Count(Expression<Func<T, bool>> predicate)
        {
            IPredicate filteredPredicate = _dapperQueryFilterExecuter.ExecuteFilter<T>(predicate);
            IDbConnection connnection = _dbconnectionProvider.GetConnection();
            return connnection.Count<T>(filteredPredicate);
        }

        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public T Insert(T entity)
        {
            IDbConnection connnection = _dbconnectionProvider.GetConnection();
            connnection.Insert(entity);
            return entity;
        }

    

        /// <summary>
        /// Insert entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public void Insert(IEnumerable<T> entities)
        {
            IDbConnection connnection = _dbconnectionProvider.GetConnection();
            foreach (var item in entities)
                connnection.Insert(item);
        }

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public  void Update(T entity)
        {
            IDbConnection connnection = _dbconnectionProvider.GetConnection();
            connnection.Update(entity);
        }

        /// <summary>
        /// Update entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public void Update(IEnumerable<T> entities)
        {
            IDbConnection connnection = _dbconnectionProvider.GetConnection();
            foreach (var item in entities)
                connnection.Update(item);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            IDbConnection connnection = _dbconnectionProvider.GetConnection();
            var entity = connnection.Get<T>(id);
            connnection.Delete(entity);
        }

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public void Delete(T entity)
        {
            IDbConnection connnection = _dbconnectionProvider.GetConnection();
            connnection.Delete(entity);
        }

        /// <summary>
        /// Delete entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public void Delete(IEnumerable<T> entities)
        {
            IDbConnection connnection = _dbconnectionProvider.GetConnection();
            foreach(var item in entities)
                connnection.Delete(item);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="model"></param>
        /// <param name="proNames"></param>
        /// <param name="isProUpdate"></param>
        public void Update(T model, List<string> proNames, bool isProUpdate = true)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="model"></param>
        /// <param name="whereLambda"></param>
        /// <param name="modifiedProNames"></param>
        public void Update(T model, Expression<Func<T, bool>> whereLambda, params string[] modifiedProNames)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a table
        /// </summary>
        public IQueryable<T> Table { get; }

        /// <summary>
        /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        /// </summary>
        public IQueryable<T> TableNoTracking { get; }

    }
}
