using HoteManagement.Infrastructure;
using HoteManagement.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoteManagement.Data.UnitOfWork
{
    public class UnitOfWorkDbContextProvider: IDbContextProvider
    {
        private readonly IUnitOfWorkProvider _unitOfWorkProvider;

        public UnitOfWorkDbContextProvider(IUnitOfWorkProvider unitOfWorkProvider)
        {
            _unitOfWorkProvider = unitOfWorkProvider;
        }

        public DbContext GetDbContext()
        {
            return _unitOfWorkProvider.Current.GetDbContext(); 
        }
    }
}
