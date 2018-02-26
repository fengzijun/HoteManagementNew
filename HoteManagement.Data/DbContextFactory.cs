using HoteManagement.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace HoteManagement.Data
{
    public class DbContextFactory : IDbContextFactory
    {
        //todo:这里可以自己通过注入的方式来实现，就会更加灵活
        private readonly IReadDbStrategy _readDbStrategy;

        private readonly ArticleConfig _articleconfig;

        public DbContextFactory(ArticleConfig articleconfig, IReadDbStrategy readDbStrategy)
        {
            _articleconfig = articleconfig;
            _readDbStrategy = readDbStrategy;
        }

        public DbContext GetWriteDbContext()
        {
            //string key = typeof(DbContextFactory).Name + "WriteDbContext";
            //_dbContext dbContext = CallContext.GetData(key) as _dbContext;
            //if (dbContext != null) return dbContext;
            //dbContext = new (_articleconfig.MsSqlWriteConnectionString);
            //CallContext.SetData(key, dbContext);
            //return dbContext;
            throw new NotImplementedException();
        }

        public DbContext GetReadDbContext()
        {
            //string key = typeof(DbContextFactory).Name + "ReadDbContext";
            //_dbContext dbContext = CallContext.GetData(key) as _dbContext;
            //if (dbContext != null) return dbContext;
            //dbContext = _readDbStrategy.GetDbContext();
            //CallContext.SetData(key, dbContext);
            //return dbContext;
            throw new NotImplementedException();
        }
    }
}