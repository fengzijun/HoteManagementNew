using HoteManagement.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoteManagement.Data.UnitOfWork
{
    public static class UnitOfWorkExtensions
    {
       
        public static DbContext GetDbContext(this IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }

            if (!(unitOfWork is EfUnitOfWork))
            {
                throw new ArgumentException("unitOfWork is not type of " + typeof(EfUnitOfWork).FullName, nameof(unitOfWork));
            }

            return (unitOfWork as EfUnitOfWork).GetOrCreateDbContext() ;
        }
    }
}
