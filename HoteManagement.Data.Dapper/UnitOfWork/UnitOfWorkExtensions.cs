using HoteManagement.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoteManagement.Data.Dapper.UnitOfWork
{
    public static class UnitOfWorkExtensions
    {

        public static DbConnection GetDbContext(this IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }

            if (!(unitOfWork is DapperUnitOfWork))
            {
                throw new ArgumentException("unitOfWork is not type of " + typeof(DapperUnitOfWork).FullName, nameof(unitOfWork));
            }

            return (unitOfWork as DapperUnitOfWork).GetOrCreateDbContext();
        }


    }
}
