using HoteManagement.Data.Dapper.UnitOfWork;
using HoteManagement.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HoteManagement.Data.Dapper
{
    public class DapperRepository<T> : IRepository<T> where T : BaseEntity, new()
    {
        #region Fields

        private IUnitOfWork _unitofwork;
        private IDbConnectionProvider _dbconnectionProvider;

        #endregion Fields

        public DapperRepository(IUnitOfWork unitofwork,IDbConnectionProvider dbconnectionProvider)
        {
            _unitofwork = unitofwork;
            _dbconnectionProvider = dbconnectionProvider;
        }


        /// <summary>
        /// Get entity by identifier
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Entity</returns>
        public T GetById(object id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public T Insert(T entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Insert entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public void Insert(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public  void Update(T entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public void Update(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public void Delete(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
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
