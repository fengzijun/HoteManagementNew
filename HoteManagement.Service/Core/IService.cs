using HoteManagement.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoteManagement.Service.Core
{
    public interface IService
    {
        UserInfoDto GetUserinfoByUsernameAndPwd(string username, string pwd);
    }
}
