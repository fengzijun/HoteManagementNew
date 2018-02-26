using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoteManagement.Data.Initializers
{
    /// <summary>
    /// sql DropCreateDatabaseIfModelChanges
    /// </summary>
    public class SqlDropCreateDatabaseIfModelChanges : DropCreateDatabaseIfModelChanges<BaseObjectContext>
    {
        public override void InitializeDatabase(BaseObjectContext context)
        {
            base.InitializeDatabase(context);

         
        }
    }
}