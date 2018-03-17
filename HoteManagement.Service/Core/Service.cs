using Autofac.Extras.DynamicProxy;
using HoteManagement.Data;
using HoteManagement.Data.Dapper.UnitOfWork;
using HoteManagement.Infrastructure.UnitOfWork;
using HoteManagement.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoteManagement.Service.Core
{
    [Intercept(typeof(UnitOfWorkInterceptor))]
    public class GenerateService : ApplicationService, IGenerateService
    {
        public GenerateService(IRepository<Domain.UserInfo> UserInfoRepository,
            IDbConnectionProvider DbConnectionProvider,
          ILogger logger):base(UserInfoRepository, DbConnectionProvider,logger)
        {

        }


        public virtual UserInfoDto GetUserinfoByUsernameAndPwd(string username, string pwd)
        {
            var model = _UserInfoRepository.GetList(@"select * from Userinfo where loginname = @loginname and password = @password", new { loginname = username, password = pwd })?.FirstOrDefault();
            if (model != null)
                return AutoMapper.Mapper.Map<UserInfoDto>(model);

            return null;
        }

    }
}
