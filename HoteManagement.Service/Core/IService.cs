using HoteManagement.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoteManagement.Service.Core
{
    public interface IGenerateService
    {
        UserInfoDto GetUserinfoByUsernameAndPwd(string username, string pwd);

        void CreateBusiness(Org_BusinessDto org_BusinessDto);
    }
}
