using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoteManagement.Data.Initializers
{
    /// <summary>
    /// sql CreateDatabaseIfNotExists
    /// </summary>
    public class CreateSqlDatabaseIfNotExists : CreateDatabaseIfNotExists<BaseObjectContext>
    {
        protected override void Seed(BaseObjectContext context)
        {
           
            base.Seed(context);
        }
    }
}