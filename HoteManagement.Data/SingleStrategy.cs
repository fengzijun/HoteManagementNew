using HoteManagement.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoteManagement.Data
{
    public class SingleStrategy : IReadDbStrategy
    {
        private readonly ArticleConfig _articleconfig;

        public SingleStrategy(ArticleConfig articleconfig)
        {
            _articleconfig = articleconfig;
        }

        public DbContext GetDbContext()
        {
            return new BaseObjectContext(_articleconfig.MsSqlConnectionString);
        }
    }
}