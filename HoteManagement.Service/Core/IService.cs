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

        List<Org_BusinessDto> GetBusiness(int? creatorid, string orgname, string name, int? approvalstatues, string unitname, string compileunit, string auditunit, DateTime? time, int? pageindex, out int totalpagecount);

        void UpdateBusiness(Org_BusinessDto org_BusinessDto);

        Org_BusinessDto GetBusiness(int id);

        UserInfoDto GetUserById(int id);


        List<ProjectSettlementDto> GetProjectSettlements(int? creatorid, int? pageindex, int? approvalstatues, string unitname, string unitname2, string unitname3, string projectname, DateTime? starttime, out int totalpagecount);

        void CreateProjectSettlement(ProjectSettlementDto projectSettlementDto);

        void UpdateProjectSettlement(ProjectSettlementDto projectSettlementDto);

        ProjectSettlementDto GetProjectSettlement(int id);

        void DeleteProjectSettlement(int id);
    }
}
