using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoteManagement.Data.Dapper.UnitOfWork
{
    public interface IDbConnectionProvider
    {
        DbConnection GetConnection();
    }
}
