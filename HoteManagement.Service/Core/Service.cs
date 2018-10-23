using Autofac.Extras.DynamicProxy;
using HoteManagement.Data;
using HoteManagement.Data.Dapper.UnitOfWork;
using HoteManagement.Domain;
using HoteManagement.Infrastructure.UnitOfWork;
using HoteManagement.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HoteManagement;
using DapperExtensions;

namespace HoteManagement.Service.Core
{
    [Intercept(typeof(UnitOfWorkInterceptor))]
    public class GenerateService : ApplicationService, IGenerateService
    {
        public GenerateService(IRepository<Domain.UserInfo> UserInfoRepository,
             IRepository<Domain.Org_Business> org_BusinessRepository,
            IDbConnectionProvider DbConnectionProvider, IRepository<Domain.ProjectSettlement> projectsettlementRepository,
        ILogger logger):base(UserInfoRepository, org_BusinessRepository, DbConnectionProvider, projectsettlementRepository,logger)
        {

        }


        public virtual UserInfoDto GetUserinfoByUsernameAndPwd(string username, string pwd)
        {
            var model = _UserInfoRepository.GetList(@"select * from Userinfo where loginname = @loginname and password = @password", new { loginname = username, password = pwd })?.FirstOrDefault();
            if (model != null)
                return AutoMapper.Mapper.Map<UserInfoDto>(model);

            return null;
        }

        public virtual UserInfoDto GetUserById(int id)
        {
            var model = _UserInfoRepository.GetById(id);
            if (model != null)
                return AutoMapper.Mapper.Map<UserInfoDto>(model);

            return null;
        }

        public virtual void CreateBusiness(Org_BusinessDto org_BusinessDto)
        {
            var model = AutoMapper.Mapper.Map<Org_Business>(org_BusinessDto);
            
            _org_BusinessRepository.Insert(model);
        }

        public virtual void CreateProjectSettlement(ProjectSettlementDto projectSettlementDto)
        {
            var model = AutoMapper.Mapper.Map<ProjectSettlement>(projectSettlementDto);
            _projectsettlementRepository.Insert(model);
        }

        public virtual void UpdateProjectSettlement(ProjectSettlementDto projectSettlementDto)
        {
            var model = AutoMapper.Mapper.Map<ProjectSettlement>(projectSettlementDto);
            _projectsettlementRepository.Update(model);
        }

        public virtual void UpdateBusiness(Org_BusinessDto org_BusinessDto)
        {
            var model = AutoMapper.Mapper.Map<Org_Business>(org_BusinessDto);

            _org_BusinessRepository.Update(model);
        }

        public virtual ProjectSettlementDto GetProjectSettlement(int id)
        {
            var model = _projectsettlementRepository.GetById(id);

            return AutoMapper.Mapper.Map<ProjectSettlementDto>(model);
        }

        public virtual Org_BusinessDto GetBusiness(int id)
        {
            var model = _org_BusinessRepository.GetById(id);

            return AutoMapper.Mapper.Map<Org_BusinessDto>(model);
        }

        public virtual List<Org_BusinessDto> GetBusiness(int? creatorid,string orgname,string name, int? approvalstatues,string unitname,string compileunit,string auditunit, DateTime? time, int? pageindex,out int totalpagecount)
        {


            //Expression<Func<Org_Business, bool>> predicate = x => true;
            //if (creatorid.HasValue)
            //    predicate = predicate.And(s => s.creatorid == creatorid);
            //if(!string.IsNullOrEmpty(orgname))
            //    predicate = predicate.And(s => s.orgname == orgname);

            //var models = _org_BusinessRepository.GetAllPaged(predicate, pageindex.Value, 20, "Id");
            //var count = _org_BusinessRepository.Count(predicate);
            //var predicate = Predicates.Field<Org_Business>(f => f.orgname, Operator.Eq, orgname);
            //predicate
            // totalpagecount = count / 20;
            int pagesize = 20;
            IList<IPredicate> predList = new List<IPredicate>();
            if(creatorid.HasValue)
                predList.Add(Predicates.Field<Org_Business>(p => p.creatorid, Operator.Eq, creatorid.Value));
            if(!string.IsNullOrEmpty(orgname))
                predList.Add(Predicates.Field<Org_Business>(p => p.orgname, Operator.Eq, orgname));

           if(!string.IsNullOrEmpty(name))
                predList.Add(Predicates.Field<Org_Business>(p => p.projectname, Operator.Like, "%" + name + "%"));


            if (!string.IsNullOrEmpty(unitname))
                predList.Add(Predicates.Field<Org_Business>(p => p.buildunit, Operator.Like, "%" + unitname + "%"));

            if (!string.IsNullOrEmpty(compileunit))
                predList.Add(Predicates.Field<Org_Business>(p => p.compileunit, Operator.Like, "%" + compileunit + "%"));

            if (!string.IsNullOrEmpty(auditunit))
                predList.Add(Predicates.Field<Org_Business>(p => p.auditunit, Operator.Like, "%" + auditunit + "%"));

            if (approvalstatues.HasValue && approvalstatues.Value!=-2)
                predList.Add(Predicates.Field<Org_Business>(p => p.statues, Operator.Eq, approvalstatues.Value));

            if (time.HasValue)
            {
                predList.Add(Predicates.Field<Org_Business>(p => p.createtime, Operator.Ge, time.Value));
                predList.Add(Predicates.Field<Org_Business>(p => p.createtime, Operator.Lt, time.Value.AddDays(1)));
            }

            IPredicateGroup predGroup = Predicates.Group(GroupOperator.And, predList.ToArray());
            var connection = _dbConnectionProvider.GetConnection();
            //var models = connection.GetPage<Org_Business>(predGroup, new List<ISort> { new Sort { Ascending = true, PropertyName = "id" } },
            //    pageindex.Value,
            //    pagesize,
            //    null);
            //var count = connection.Count<Org_Business>(predGroup);
            List<ISort> sortList = new List<ISort>();
            sortList.Add(Predicates.Sort<Org_Business>(x => x.id, false));

            var models = connection.GetList<Org_Business>(predGroup, sortList).ToList();
            totalpagecount = models.Count() % pagesize == 0 ? models.Count() / pagesize : (models.Count() / pagesize) + 1;
            var result = AutoMapper.Mapper.Map<List<Org_BusinessDto>>(models.Skip(pagesize * (pageindex ?? 1 - 1) * pagesize).Take(pagesize).ToList());
            return result;
        }


        public virtual List<ProjectSettlementDto> GetProjectSettlements(int? creatorid, int? pageindex, int? approvalstatues, string unitname, string unitname2, string unitname3, string projectname, DateTime? starttime, out int totalpagecount)
        {


            //Expression<Func<Org_Business, bool>> predicate = x => true;
            //if (creatorid.HasValue)
            //    predicate = predicate.And(s => s.creatorid == creatorid);
            //if(!string.IsNullOrEmpty(orgname))
            //    predicate = predicate.And(s => s.orgname == orgname);

            //var models = _org_BusinessRepository.GetAllPaged(predicate, pageindex.Value, 20, "Id");
            //var count = _org_BusinessRepository.Count(predicate);
            //var predicate = Predicates.Field<Org_Business>(f => f.orgname, Operator.Eq, orgname);
            //predicate
            // totalpagecount = count / 20;
            int pagesize = 20;
            IList<IPredicate> predList = new List<IPredicate>();
            if (creatorid.HasValue)
                predList.Add(Predicates.Field<ProjectSettlement>(p => p.createid, Operator.Eq, creatorid.Value));
            if (approvalstatues.HasValue && approvalstatues.Value!=-2)
                predList.Add(Predicates.Field<ProjectSettlement>(p => p.approvalstatues, Operator.Eq, approvalstatues.Value));
            if (!string.IsNullOrEmpty(unitname))
                predList.Add(Predicates.Field<ProjectSettlement>(p => p.unitname, Operator.Like, "%" + unitname + "%"));

            if (!string.IsNullOrEmpty(unitname2))
                predList.Add(Predicates.Field<ProjectSettlement>(p => p.unitname2, Operator.Like, "%" + unitname2 + "%"));

            if (!string.IsNullOrEmpty(unitname3))
                predList.Add(Predicates.Field<ProjectSettlement>(p => p.unitname3, Operator.Like, "%" + unitname2 + "%"));

            if (!string.IsNullOrEmpty(projectname))
                predList.Add(Predicates.Field<ProjectSettlement>(p => p.projectname, Operator.Like, "%" + projectname + "%"));
            if (starttime.HasValue)
            {
                predList.Add(Predicates.Field<ProjectSettlement>(p => p.auditstarttime, Operator.Ge, starttime.Value));
                predList.Add(Predicates.Field<ProjectSettlement>(p => p.auditstarttime, Operator.Lt, starttime.Value.AddDays(1)));
            }


           

            IPredicateGroup predGroup = Predicates.Group(GroupOperator.And, predList.ToArray());
            var connection = _dbConnectionProvider.GetConnection();
            //var models = connection.GetPage<Org_Business>(predGroup, new List<ISort> { new Sort { Ascending = true, PropertyName = "id" } },
            //    pageindex.Value,
            //    pagesize,
            //    null);
            //var count = connection.Count<Org_Business>(predGroup);
            List<ISort> sortList = new List<ISort>();
            sortList.Add(Predicates.Sort<ProjectSettlement>(x => x.id, false));

            var models = connection.GetList<ProjectSettlement>(predGroup, sortList).ToList();
            totalpagecount = models.Count() % pagesize == 0 ? models.Count() / pagesize : (models.Count() / pagesize) + 1;
            var result = AutoMapper.Mapper.Map<List<ProjectSettlementDto>>(models.Skip(pagesize * (pageindex ?? 1 - 1) * pagesize).Take(pagesize).ToList());
            return result;
        }

        public virtual void DeleteProjectSettlement(int id)
        {
            _projectsettlementRepository.Delete(id);
         
        }


    }
}
