using HoteManagement.Data.UnitOfWork;
using HoteManagement.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace HoteManagement.Data
{
    /// <summary>
    /// Entity Framework repository
    /// </summary>
    public partial class EfRepository<T> : IRepository<T> where T : BaseEntity, new()
    {
        #region Fields

        private IDbContextProvider _dbContextProvider;
        private IUnitOfWork _unitofwork;

        #endregion Fields

        public virtual DbContext Context { get { return _dbContextProvider.GetDbContext(); } }

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context">Object context</param>
        public EfRepository(IUnitOfWork unitofwork, IDbContextProvider dbContextProvider)
        {
            _unitofwork = unitofwork;
            _dbContextProvider = dbContextProvider;
        }

        #endregion Ctor

        #region Utilities

        /// <summary>
        /// Get full error
        /// </summary>
        /// <param name="exc">Exception</param>
        /// <returns>Error</returns>
        protected string GetFullErrorText(DbEntityValidationException exc)
        {
            var msg = string.Empty;
            foreach (var validationErrors in exc.EntityValidationErrors)
                foreach (var error in validationErrors.ValidationErrors)
                    msg += $"Property: {error.PropertyName} Error: {error.ErrorMessage}" + Environment.NewLine;
            return msg;
        }

        #endregion Utilities

        #region Methods

        /// <summary>
        /// Get entity by identifier
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Entity</returns>
        public virtual T GetById(object id)
        {
            //see some suggested performance optimization (not tested)
            //http://stackoverflow.com/questions/11686225/dbset-find-method-ridiculously-slow-compared-to-singleordefault-on-id/11688189#comment34876113_11688189
            return this.Entities.Find(id);
        }

        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual T Insert(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                var resultentity = this.Entities.Add(entity);

                //this._context.SaveChanges();

                Context.SaveChanges();

                return resultentity;
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }

        /// <summary>
        /// Insert entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public virtual void Insert(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException(nameof(entities));

                foreach (var entity in entities)
                    this.Entities.Add(entity);

                //this._context.SaveChanges();

                Context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual void Update(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));
                var model = AttachEntityToContext(entity);
                Context.Entry(model).State = EntityState.Modified;
                //this._dbContext.SaveChanges();

                Context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }

        /// <summary>
        /// Update entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public virtual void Update(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException(nameof(entities));
                foreach (var item in entities)
                {
                    AttachEntityToContext(item);
                    Context.Entry(item).State = EntityState.Modified;
                }

                Context.SaveChanges();
                //this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual void Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));
                AttachEntityToContext(entity);
                this.Entities.Remove(entity);
                Context.SaveChanges();
                //this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <param name="id"></param>
        public virtual void Delete(int id)
        {
            try
            {
                T entity = new T { Id = id };
                this.Entities.Attach(entity);

                this.Entities.Remove(entity);
                Context.SaveChanges();
                //this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }

        /// <summary>
        /// Delete entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public virtual void Delete(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException(nameof(entities));

                foreach (var entity in entities)
                    this.Entities.Remove(entity);
                Context.SaveChanges();
                //this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }

        #endregion Methods

        #region Properties

        /// <summary>
        /// Gets a table
        /// </summary>
        public virtual IQueryable<T> Table { get { return this.Entities; } }

        /// <summary>
        /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        /// </summary>
        public virtual IQueryable<T> TableNoTracking { get { return this.Entities.AsNoTracking(); } } 

        /// <summary>
        /// Entities
        /// </summary>
        protected virtual IDbSet<T> Entities { get { return Context.Set<T>(); } }

        #endregion Properties

        /// <summary>
        ///
        /// </summary>
        /// <param name="model"></param>
        /// <param name="proNames"></param>
        /// <param name="isProUpdate"></param>
        public void Update(T model, List<string> proNames, bool isProUpdate = true)
        {
            //将 对象 添加到 EF中
            Context.Set<T>().Attach(model);
            var setEntry = ((IObjectContextAdapter)Context).ObjectContext.ObjectStateManager.GetObjectStateEntry(model);
            //指定列修改
            if (isProUpdate)
            {
                foreach (string proName in proNames)
                {
                    setEntry.SetModifiedProperty(proName);
                }
            }
            //忽略类修改
            else
            {
                Type t = typeof(T);
                List<PropertyInfo> proInfos = t.GetProperties(BindingFlags.Instance | BindingFlags.Public).ToList();
                foreach (var item in proInfos)
                {
                    string proName = item.Name;
                    if (proNames.Contains(proName))
                    {
                        continue;
                    }
                    setEntry.SetModifiedProperty(proName);
                }
            }

            Context.SaveChanges();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="model"></param>
        /// <param name="whereLambda"></param>
        /// <param name="modifiedProNames"></param>
        public void Update(T model, Expression<Func<T, bool>> whereLambda, params string[] modifiedProNames)
        {
            //查询要修改的数据
            List<T> listModifing = Context.Set<T>().Where(whereLambda).ToList();
            Type t = typeof(T);
            List<PropertyInfo> proInfos = t.GetProperties(BindingFlags.Instance | BindingFlags.Public).ToList();
            Dictionary<string, PropertyInfo> dictPros = new Dictionary<string, PropertyInfo>();
            proInfos.ForEach(p =>
            {
                if (modifiedProNames.Contains(p.Name))
                {
                    dictPros.Add(p.Name, p);
                }
            });
            if (dictPros.Count <= 0)
            {
                throw new Exception("指定修改的字段名称有误或为空");
            }
            foreach (var item in dictPros)
            {
                PropertyInfo proInfo = item.Value;

                //取出 要修改的值
                object newValue = proInfo.GetValue(model, null);

                //批量设置 要修改 对象的 属性
                foreach (T oModel in listModifing)
                {
                    //为 要修改的对象 的 要修改的属性 设置新的值
                    proInfo.SetValue(oModel, newValue, null);
                }
            }

            Context.SaveChanges();
        }

        /// <summary>
        /// Attach an entity to the context or return an already attached entity (if it was already attached)
        /// </summary>
        /// <typeparam name="TEntity">TEntity</typeparam>
        /// <param name="entity">Entity</param>
        /// <returns>Attached entity</returns>
        public virtual TEntity AttachEntityToContext<TEntity>(TEntity entity) where TEntity : BaseEntity, new()
        {
            //little hack here until Entity Framework really supports stored procedures
            //otherwise, navigation properties of loaded entities are not loaded until an entity is attached to the context
            var alreadyAttached = Context.Set<TEntity>().Local.FirstOrDefault(x => x.Id == entity.Id);
            if (alreadyAttached == null)
            {
                //attach new entity
                Context.Set<TEntity>().Attach(entity);
                //var properties = typeof(TEntity).GetProperties();
                //foreach(var property in properties)
                //{
                //    if(typeof(BaseEntity).IsAssignableFrom(property.PropertyType) && property.GetValue()!=null)
                //    {

                //    }
                //}
                return entity;
            }

            //entity is already loaded
            return alreadyAttached;
        }

    }
}