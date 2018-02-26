using HoteManagement.Infrastructure;
using HoteManagement.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoteManagement.Data.UnitOfWork
{
    public class EfUnitOfWork : UnitOfWorkBase
    {
        private readonly IEfTransactionStrategy _transactionStrategy;

        protected IDictionary<string, DbContext> ActiveDbContexts { get; }

        public EfUnitOfWork(IEfTransactionStrategy transactionStrategy)
        {
            _transactionStrategy = transactionStrategy;
            ActiveDbContexts = new Dictionary<string, DbContext>();
        }

    
        public override void CompleteUow()
        {
            //GetAllActiveDbContexts().ForEach(SaveChangesInDbContext);

            //SaveChanges();

            if (Options.IsTransactional == true)
            {
                _transactionStrategy.Commit();
            }
        }

        public override async Task CompleteUowAsync()
        {
            //await SaveChangesAsync();

            if (Options.IsTransactional == true)
            {
                _transactionStrategy.Commit();
            }
        }

        public override void BeginUow()
        {
            if (Options.IsTransactional == true)
            {
                _transactionStrategy.InitOptions(Options);
            }
        }

        public override void DisposeUow()
        {
            if (Options.IsTransactional == true)
            {
                _transactionStrategy.Dispose();
            }

            var dbcontexts = GetAllActiveDbContexts();

            if (dbcontexts != null && dbcontexts.Count > 0)
            {
                foreach (var activeDbContext in dbcontexts)
                {
                    activeDbContext.Dispose();
                }
            }

            ActiveDbContexts.Clear();
        }

        public override void RollBack()
        {
            _transactionStrategy.RollBack();
        }

        public List<DbContext> GetAllActiveDbContexts()
        {
            //return _transactionStrategy.ActiveTransactions.Values.ToList();
            return ActiveDbContexts.Values.ToList();
        }


        protected virtual void SaveChangesInDbContext(DbContext dbContext)
        {
            //_dbContext dbcontext2 = EngineContext.Current.Resolve<IDbContext>() as _dbContext;

            dbContext.SaveChanges();
        }

        protected virtual async Task SaveChangesInDbContextAsync(DbContext dbContext)
        {
            await dbContext.SaveChangesAsync();
        }

        public override void Complete(UnitOfWorkOptions options)
        {
            if (options.IsTransactional == true)
            {
                _transactionStrategy.Commit();
            }
        }

        public virtual DbContext GetOrCreateDbContext()
        {
            if (ActiveDbContexts.Count > 0)
            {
                var dbcontext = ActiveDbContexts.Select(s => s.Value).FirstOrDefault();

                if (Options != null && Options.IsTransactional == true)
                {
                    return _transactionStrategy.GetOrCreateDbContext(dbcontext, Options);
                }

                return dbcontext;
            }

            DbContext dbContext;
            if (Options != null && Options.IsTransactional == true)
                dbContext = _transactionStrategy.GetOrCreateDbContext();
            else
                dbContext = EngineContext.Current.Resolve<IDbContext>() as DbContext;

            ((IObjectContextAdapter)dbContext).ObjectContext.ObjectMaterialized += (sender, args) =>
            {
                ObjectContext_ObjectMaterialized(dbContext, args);
            };

            ActiveDbContexts[dbContext.Database.Connection.ConnectionString] = dbContext;

            return dbContext;
        }

        private static void ObjectContext_ObjectMaterialized(DbContext dbContext, ObjectMaterializedEventArgs e)
        {
            //var entityType = ObjectContext.GetObjectType(e.Entity.GetType());

            //dbContext.Configuration.AutoDetectChangesEnabled = false;
            //var previousState = dbContext.Entry(e.Entity).State;

            ////DateTimePropertyInfoHelper.NormalizeDatePropertyKinds(e.Entity, entityType);

            //dbContext.Entry(e.Entity).State = previousState;
            //dbContext.Configuration.AutoDetectChangesEnabled = true;
        }

        public void SaveChanges()
        {
            GetAllActiveDbContexts().ForEach(SaveChangesInDbContext);
        }

        public async Task SaveChangesAsync()
        {
            foreach (var dbContext in GetAllActiveDbContexts())
            {
                await SaveChangesInDbContextAsync(dbContext);
            }
        }
    }
}