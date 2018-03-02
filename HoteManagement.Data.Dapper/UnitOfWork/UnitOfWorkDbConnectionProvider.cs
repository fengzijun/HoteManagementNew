using HoteManagement.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HoteManagement.Data.Dapper.UnitOfWork
{
    public class UnitOfWorkDbConnectionProvider : IDbConnectionProvider
    {
        private readonly IUnitOfWorkProvider _unitOfWorkProvider;

        public UnitOfWorkDbConnectionProvider(IUnitOfWorkProvider unitOfWorkProvider)
        {
            _unitOfWorkProvider = unitOfWorkProvider;
        }

        public DbConnection GetConnection()
        {
            return _unitOfWorkProvider.Current.GetDbContext();
        }
    }
    
}
