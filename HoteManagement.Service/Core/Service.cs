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
            IDbConnectionProvider DbConnectionProvider,
          ILogger logger):base(UserInfoRepository, org_BusinessRepository, DbConnectionProvider,logger)
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

        public virtual void UpdateBusiness(Org_BusinessDto org_BusinessDto)
        {
            var model = AutoMapper.Mapper.Map<Org_Business>(org_BusinessDto);

            _org_BusinessRepository.Update(model);
        }


        public virtual Org_BusinessDto GetBusiness(int id)
        {
            var model = _org_BusinessRepository.GetById(id);

            return AutoMapper.Mapper.Map<Org_BusinessDto>(model);
        }

        public virtual List<Org_BusinessDto> GetBusiness(int? creatorid,string orgname,bool isadmin,int? pageindex,out int totalpagecount)
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

            if(isadmin)
                predList.Add(Predicates.Field<Org_Business>(p => p.statues, Operator.Lt, 1));

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

    }
}
