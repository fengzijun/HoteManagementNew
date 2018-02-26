using Autofac.Extras.DynamicProxy;
using HoteManagement.Caching;
using HoteManagement.Data;
using HoteManagement.Infrastructure.UnitOfWork;
using HoteManagement.Service.Events;
using HoteManagement.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace HoteManagement.Service.Sys
{
    [Intercept(typeof(UnitOfWorkInterceptor))]
    public class SysService : ApplicationService, ISysService
    {
        public SysService(IRepository<Domain.account_goods> account_goodsRepository,
          IRepository<Domain.Accounts_Roles> Accounts_RolesRepository,
          IRepository<Domain.Accounts_UserRoles> Accounts_UserRolesRepository,
          IRepository<Domain.Accounts_Users> Accounts_UsersRepository,
          IRepository<Domain.AddPrice> AddPriceRepository,
          IRepository<Domain.apartment> apartmentRepository,
          IRepository<Domain.banner> bannerRepository,
          IRepository<Domain.Book_Rdetail> Book_RdetailRepository,
          IRepository<Domain.book_room> book_roomRepository,
          IRepository<Domain.BookState> BookStateRepository,
          IRepository<Domain.breakfirstcoupon> breakfirstcouponRepository,
          IRepository<Domain.card_type> card_typeRepository,
          IRepository<Domain.cCall> cCallRepository,
          IRepository<Domain.cDepartment> cDepartmentRepository,
          IRepository<Domain.cIndustry> cIndustryRepository,
          IRepository<Domain.comm_unit> comm_unitRepository,
          IRepository<Domain.Commission> CommissionRepository,
          IRepository<Domain.Contacts> ContactsRepository,
          IRepository<Domain.cost_type> cost_typeRepository,
          IRepository<Domain.cPost> cPostRepository,
          IRepository<Domain.cprotocol> cprotocolRepository,
          IRepository<Domain.cprotocolPrice> cprotocolPriceRepository,
          IRepository<Domain.cpType> cpTypeRepository,
          IRepository<Domain.credit> creditRepository,
          IRepository<Domain.csysType> csysTypeRepository,
          IRepository<Domain.customer> customerRepository,
          IRepository<Domain.customerState> customerStateRepository,
          IRepository<Domain.customerType> customerTypeRepository,
          IRepository<Domain.Entry> EntryRepository,
          IRepository<Domain.ExceedScheme> ExceedSchemeRepository,
          IRepository<Domain.floor_ld> floor_ldRepository,
          IRepository<Domain.floor_manage> floor_manageRepository,
          IRepository<Domain.FtSet> FtSetRepository,
          IRepository<Domain.Goods> GoodsRepository,
          IRepository<Domain.goods_account> goods_accountRepository,
          IRepository<Domain.guest_source> guest_sourceRepository,
          IRepository<Domain.Hotel> HotelRepository,
          IRepository<Domain.hour_room> hour_roomRepository,
          IRepository<Domain.hourse_scheme> hourse_schemeRepository,
          IRepository<Domain.info> infoRepository,
          IRepository<Domain.log> logRepository,
          IRepository<Domain.member> memberRepository,
          IRepository<Domain.memberState> memberStateRepository,
          IRepository<Domain.memberType> memberTypeRepository,
          IRepository<Domain.Menu> MenuRepository,
          IRepository<Domain.meth_pay> meth_payRepository,
          IRepository<Domain.modes> modesRepository,
          IRepository<Domain.mRecords> mRecordsRepository,
          IRepository<Domain.mtPrice> mtPriceRepository,
          IRepository<Domain.occu_infor> occu_inforRepository,
          IRepository<Domain.occu_informx> occu_informxRepository,
          IRepository<Domain.order_ext> order_extRepository,
          IRepository<Domain.order_infor> order_inforRepository,
          IRepository<Domain.paymentMoney> paymentMoneyRepository,
          IRepository<Domain.price_type> price_typeRepository,
          IRepository<Domain.print> printRepository,
          IRepository<Domain.real_mode> real_modeRepository,
          IRepository<Domain.real_state> real_stateRepository,
          IRepository<Domain.receipt> receiptRepository,
          IRepository<Domain.Remaker> RemakerRepository,
          IRepository<Domain.Repair> RepairRepository,
          IRepository<Domain.RoleMenu> RoleMenuRepository,
          IRepository<Domain.room_feature> room_featureRepository,
          IRepository<Domain.room_number> room_numberRepository,
          IRepository<Domain.room_state> room_stateRepository,
          IRepository<Domain.room_type> room_typeRepository,
          IRepository<Domain.room_type_image> room_type_imageRepository,
          IRepository<Domain.roomcoupon> roomcouponRepository,
          IRepository<Domain.roomman> roommanRepository,
          IRepository<Domain.roomrent> roomrentRepository,
          IRepository<Domain.sale_man> sale_manRepository,
          IRepository<Domain.Shift> ShiftRepository,
          IRepository<Domain.Shift_Exc> Shift_ExcRepository,
          IRepository<Domain.shopInfo> shopInfoRepository,
          IRepository<Domain.Sincethehous> SincethehousRepository,
          IRepository<Domain.SuoRoom> SuoRoomRepository,
          IRepository<Domain.SuoSys> SuoSysRepository,
          IRepository<Domain.SysParamter> SysParamterRepository,
          IRepository<Domain.TypeScheme> TypeSchemeRepository,
          IRepository<Domain.UserInfo> UserInfoRepository,
          IRepository<Domain.Users> UsersRepository,
          IRepository<Domain.userType> userTypeRepository,
          IRepository<Domain.ZD_hourse> ZD_hourseRepository,
        IDbContext dbcontext,
        IRedis redishelper,
        IEventPublisher eventPublisher,
        ILogger logger) : base(
                 account_goodsRepository,
   Accounts_RolesRepository,
   Accounts_UserRolesRepository,
   Accounts_UsersRepository,
   AddPriceRepository,
   apartmentRepository,
   bannerRepository,
   Book_RdetailRepository,
   book_roomRepository,
   BookStateRepository,
   breakfirstcouponRepository,
   card_typeRepository,
   cCallRepository,
   cDepartmentRepository,
   cIndustryRepository,
   comm_unitRepository,
   CommissionRepository,
   ContactsRepository,
   cost_typeRepository,
   cPostRepository,
   cprotocolRepository,
   cprotocolPriceRepository,
   cpTypeRepository,
   creditRepository,
   csysTypeRepository,
   customerRepository,
   customerStateRepository,
   customerTypeRepository,
   EntryRepository,
   ExceedSchemeRepository,
   floor_ldRepository,
   floor_manageRepository,
   FtSetRepository,
   GoodsRepository,
   goods_accountRepository,
   guest_sourceRepository,
   HotelRepository,
   hour_roomRepository,
   hourse_schemeRepository,
   infoRepository,
   logRepository,
   memberRepository,
   memberStateRepository,
   memberTypeRepository,
   MenuRepository,
   meth_payRepository,
   modesRepository,
   mRecordsRepository,
   mtPriceRepository,
   occu_inforRepository,
   occu_informxRepository,
   order_extRepository,
   order_inforRepository,
   paymentMoneyRepository,
   price_typeRepository,
   printRepository,
   real_modeRepository,
   real_stateRepository,
   receiptRepository,
   RemakerRepository,
   RepairRepository,
   RoleMenuRepository,
   room_featureRepository,
   room_numberRepository,
   room_stateRepository,
   room_typeRepository,
   room_type_imageRepository,
   roomcouponRepository,
   roommanRepository,
   roomrentRepository,
   sale_manRepository,
   ShiftRepository,
   Shift_ExcRepository,
   shopInfoRepository,
   SincethehousRepository,
   SuoRoomRepository,
   SuoSysRepository,
   SysParamterRepository,
   TypeSchemeRepository,
   UserInfoRepository,
   UsersRepository,
   userTypeRepository,
   ZD_hourseRepository,

 dbcontext,
 redishelper,
 eventPublisher,
 logger)
        {
        }



        public virtual int GetBannerCount()
        {
            int count = _bannerRepository.TableNoTracking.Count();
            if (count == 0)
                return 1;
            else
                return count + 1;
        }

        public virtual void AddBanner(bannerDto bannerDto)
        {
            Domain.banner banner = AutoMapper.Mapper.Map<Domain.banner>(bannerDto);
            banner.banner_id = Guid.NewGuid().ToString();

            _bannerRepository.Insert(banner);

        }

        public virtual IPagedList<bannerDto> GetBannerPageList(int pageindex,int pagesize)
        {
            var resultquery = _bannerRepository.TableNoTracking.OrderByDescending(s => s.sortId);

            var list = new PagedList<bannerDto>(resultquery.ProjectToQueryable<bannerDto>(), pageindex, pagesize);

            return list;
        }

        public virtual bannerDto GetBannerByBannerId(string id)
        {
            return _bannerRepository.TableNoTracking.Where(s => s.banner_id == id).ProjectToFirst<bannerDto>();
        }

        public virtual void UpdateBanner(bannerDto banner)
        {
            Domain.banner model = AutoMapper.Mapper.Map<Domain.banner>(banner);
            _bannerRepository.Update(model);
        }

        public virtual SysParamterDto GetSysParamterById(int id)
        {
            return _SysParamterRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<SysParamterDto>();
        }

        public virtual void UpdateSysParamter(SysParamterDto sysParamter)
        {
            Domain.SysParamter model = AutoMapper.Mapper.Map<Domain.SysParamter>(sysParamter);
            _SysParamterRepository.Update(model);
        }

        public virtual void AddSysParamter(SysParamterDto sysParamter)
        {
            Domain.SysParamter model = AutoMapper.Mapper.Map<Domain.SysParamter>(sysParamter);
            _SysParamterRepository.Insert(model);
        }

        public virtual void AddExceedScheme(ExceedSchemeDto exceedScheme)
        {
            Domain.ExceedScheme model = AutoMapper.Mapper.Map<Domain.ExceedScheme>(exceedScheme);
            _ExceedSchemeRepository.Insert(model);
        }

        public virtual void UpdateExceedScheme(ExceedSchemeDto exceedScheme)
        {
            Domain.ExceedScheme model = AutoMapper.Mapper.Map<Domain.ExceedScheme>(exceedScheme);
            _ExceedSchemeRepository.Update(model);
        }

        public virtual ExceedSchemeDto GetExceedSchemeById(int id)
        {
            return _ExceedSchemeRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<ExceedSchemeDto>();
        }

        public virtual List<ExceedSchemeDto> GetExceedSchemeList(int? typeroom)
        {
            var result = _ExceedSchemeRepository.TableNoTracking;
            if (typeroom.HasValue)
                result = result.Where(s => s.TypeRoom == typeroom.Value);

            return result.ProjectToList<ExceedSchemeDto>();
        }

        public virtual List<cCallDto> GetCCallList()
        {
            return _cCallRepository.TableNoTracking.ProjectToList<cCallDto>();
        }

        public virtual cCallDto GetCCall(int id)
        {
            return _cCallRepository.TableNoTracking.Where(s=>s.Id == id).ProjectToFirst<cCallDto>();
        }


        public virtual List<cpTypeDto> GetcptypeList()
        {
            return _cpTypeRepository.TableNoTracking.ProjectToList<cpTypeDto>();
        }

        public virtual cpTypeDto Getcptype(int id)
        {
            return _cpTypeRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirst<cpTypeDto>();
        }


        public virtual List<cDepartmentDto> GetcDepartmentList()
        {
            return _cDepartmentRepository.TableNoTracking.ProjectToList<cDepartmentDto>();
        }

        public virtual cDepartmentDto GetcDepartment(int id)
        {
            return _cDepartmentRepository.TableNoTracking.Where(s=>s.Id == id).ProjectToFirst<cDepartmentDto>();
        }


        public virtual List<cPostDto> GetcPostList()
        {
            return _cPostRepository.TableNoTracking.ProjectToList<cPostDto>();
        }

        public virtual cPostDto GetcPost(int id)
        {
            return _cPostRepository.TableNoTracking.Where(s=>s.Id == id).ProjectToFirst<cPostDto>();
        }

        public virtual List<csysTypeDto> GetcsysTypeList()
        {
            return _csysTypeRepository.TableNoTracking.ProjectToList<csysTypeDto>();
        }

        public virtual List<customerTypeDto> GetcustomerTypeList()
        {
            return _customerRepository.TableNoTracking.ProjectToList<customerTypeDto>();
        }

        public virtual List<customerStateDto> GetcustomerStateList()
        {
            return _customerStateRepository.TableNoTracking.ProjectToList<customerStateDto>();
        }

        public virtual customerStateDto GetcustomerState(int id)
        {
            return _customerStateRepository.TableNoTracking.Where(s=>s.Id == id).ProjectToFirst<customerStateDto>();
        }



        public virtual List<cIndustryDto> GetcIndustryList()
        {
            return _cIndustryRepository.TableNoTracking.ProjectToList<cIndustryDto>();
        }

        public virtual cIndustryDto GetcIndustry(int id)
        {
            return _cIndustryRepository.TableNoTracking.Where(s=>s.Id == id).ProjectToFirst<cIndustryDto>();
        }

        public virtual List<cost_typeDto> GetCostType(int? ct_iftype,int? ct_categories)
        {
            var result = _cost_typeRepository.TableNoTracking;
            if (ct_iftype.HasValue)
                result = result.Where(s => s.ct_iftype == ct_iftype);

            if (ct_categories.HasValue)
                result = result.Where(s => s.ct_categories == ct_categories);

            return result.ProjectToList<cost_typeDto>();
        }


        public virtual GoodsDto GetGoods(int id)
        {
            return _account_goodsRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirst<GoodsDto>();

        }


        public virtual List<AddPriceDto> GetAddPriceList()
        {
            return _AddPriceRepository.TableNoTracking.ProjectToList<AddPriceDto>();
        }


        public virtual void AddmRecords(mRecordsDto mRecords)
        {
            Domain.mRecords records = AutoMapper.Mapper.Map<Domain.mRecords>(mRecords);
            _mRecordsRepository.Insert(records);
        }

        public virtual List<mRecordsDto> GetmRecords(string mid)
        {

            var result = _mRecordsRepository.TableNoTracking;
            if (!string.IsNullOrEmpty(mid))
                result = result.Where(s => s.mmid == mid);
   
            return result.ProjectToList<mRecordsDto>();

        }


        public virtual List<mRecordsDto> GetmRecordsByType(string mid)
        {

            var result = _mRecordsRepository.TableNoTracking;
            if (!string.IsNullOrEmpty(mid))
                result = result.Where(s => s.mmid == mid);
            result = result.Where(s => s.Type == 3 || s.Type == 4);

            return result.ProjectToList<mRecordsDto>();

        }

        public virtual List<mRecordsDto> GetmRecordsByType2(string mid)
        {

            var result = _mRecordsRepository.TableNoTracking;
            if (!string.IsNullOrEmpty(mid))
                result = result.Where(s => s.mmid == mid);
            result = result.Where(s => s.Type == 1 || s.Type == 2);

            return result.ProjectToList<mRecordsDto>();

        }

        public virtual void Addfloor_manage(floor_manageDto floor_Manage)
        {
            Domain.floor_manage mdoel = AutoMapper.Mapper.Map<Domain.floor_manage>(floor_Manage);
       

            _floor_manageRepository.Insert(mdoel);

        }

        public virtual void Updatefloor_manage(floor_manageDto floor_Manage)
        {
            Domain.floor_manage mdoel = AutoMapper.Mapper.Map<Domain.floor_manage>(floor_Manage);


            _floor_manageRepository.Update(mdoel);

        }

        public virtual List<floor_manageDto> Getfloor_manageList()
        {
            return _floor_manageRepository.TableNoTracking.ProjectToList<floor_manageDto>();
        }

        public virtual floor_manageDto GetFloor_ManageById(int id)
        {
            return _floor_manageRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<floor_manageDto>();
        }

        public virtual void Updategoods(GoodsDto goods)
        {
            Domain.Goods model = AutoMapper.Mapper.Map<Domain.Goods>(goods);
            _GoodsRepository.Update(model);

        }

        public virtual void Addgoods(GoodsDto goods)
        {
            Domain.Goods model = AutoMapper.Mapper.Map<Domain.Goods>(goods);
            _GoodsRepository.Insert(model);

        }

        public virtual List<GoodsDto> GetGoodsList(int? Goods_ifType,int? Goods_categories)
        {
            var result = _GoodsRepository.TableNoTracking;
            if (Goods_ifType.HasValue)
                result = result.Where(s => s.Goods_ifType == Goods_ifType);
            if (Goods_categories.HasValue)
                result = result.Where(s => s.Goods_categories == Goods_categories);

            return result.ProjectToList<GoodsDto>();
        }

        public virtual IPagedList<GoodsDto> GetGoodsList(int? Goods_ifType, int? Goods_categories, int pageindex, int pagesize)
        {
            var result = _GoodsRepository.TableNoTracking;
            if (Goods_ifType.HasValue)
                result = result.Where(s => s.Goods_ifType == Goods_ifType);
            if (Goods_categories.HasValue)
                result = result.Where(s => s.Goods_categories == Goods_categories);

            

            return new PagedList<GoodsDto>(result.ProjectToQueryable<GoodsDto>(), pageindex, pagesize);
        }

        public virtual cost_typeDto GetCost_Type(int id)
        {
            return _cost_typeRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<cost_typeDto>();
        }

        public virtual void UpdateCostType(cost_typeDto cost_Type)
        {
            Domain.cost_type model = AutoMapper.Mapper.Map<Domain.cost_type>(cost_Type);
            _cost_typeRepository.Update(model);
        }

        public virtual void AddCostType(cost_typeDto cost_Type)
        {
            Domain.cost_type model = AutoMapper.Mapper.Map<Domain.cost_type>(cost_Type);
            _cost_typeRepository.Insert(model);
        }

        public virtual void AddCustomerstate(customerDto customer)
        {
            Domain.customerState model = AutoMapper.Mapper.Map<Domain.customerState>(customer);
            _customerStateRepository.Insert(model);
        }

        public virtual void UpdateCustomerstate(customerDto customer)
        {
            Domain.customerState model = AutoMapper.Mapper.Map<Domain.customerState>(customer);
            _customerStateRepository.Update(model);
        }

        public virtual void AddcIndustry(cIndustryDto cIndustry)
        {
            Domain.cIndustry model = AutoMapper.Mapper.Map<Domain.cIndustry>(cIndustry);
            _cIndustryRepository.Insert(model);
        }

        public virtual void UpdatecIndustry(cIndustryDto customer)
        {
            Domain.cIndustry model = AutoMapper.Mapper.Map<Domain.cIndustry>(customer);
            _cIndustryRepository.Update(model);
        }

        public virtual void AddcpType(cpTypeDto cpType)
        {
            Domain.cpType model = AutoMapper.Mapper.Map<Domain.cpType>(cpType);
            _cpTypeRepository.Insert(model);
        }

        public virtual void UpdatecpType(cpTypeDto cpType)
        {
            Domain.cpType model = AutoMapper.Mapper.Map<Domain.cpType>(cpType);
            _cpTypeRepository.Update(model);
        }

        public virtual void AddcsysType(csysTypeDto csysType)
        {
            Domain.csysType model = AutoMapper.Mapper.Map<Domain.csysType>(csysType);
            _csysTypeRepository.Insert(model);
        }

        public virtual void UpdatecpType(csysTypeDto csysType)
        {
            Domain.csysType model = AutoMapper.Mapper.Map<Domain.csysType>(csysType);
            _csysTypeRepository.Update(model);
        }

        public virtual void AddcDepartment(cDepartmentDto cDepartment)
        {
            Domain.cDepartment model = AutoMapper.Mapper.Map<Domain.cDepartment>(cDepartment);
            _cDepartmentRepository.Insert(model);
        }

        public virtual void UpdatecDepartment(cDepartmentDto cDepartment)
        {
            Domain.cDepartment model = AutoMapper.Mapper.Map<Domain.cDepartment>(cDepartment);
            _cDepartmentRepository.Update(model);
        }

        public virtual void AddcPost(cPostDto cPost)
        {
            Domain.cPost model = AutoMapper.Mapper.Map<Domain.cPost>(cPost);
            _cPostRepository.Insert(model);
        }

        public virtual void UpdatecPost(cPostDto cPost)
        {
            Domain.cPost model = AutoMapper.Mapper.Map<Domain.cPost>(cPost);
            _cPostRepository.Update(model);
        }

        public virtual void AddcPost(cCallDto cCall)
        {
            Domain.cCall model = AutoMapper.Mapper.Map<Domain.cCall>(cCall);
            _cCallRepository.Insert(model);
        }

        public virtual void UpdatecPost(cCallDto cCall)
        {
            Domain.cCall model = AutoMapper.Mapper.Map<Domain.cCall>(cCall);
            _cCallRepository.Update(model);
        }

        public virtual void DeleteCustomerState(int id)
        {
            _customerStateRepository.Delete(id);
        }

        public virtual void DeleteCustomType(int id)
        {
            _customerTypeRepository.Delete(id);
        }

        public virtual void DeletecIndustry(int id)
        {
            _cIndustryRepository.Delete(id);
        }

        public virtual void DeletecpType(int id)
        {
            _cpTypeRepository.Delete(id);
        }

        public virtual void DeletecsysType(int id)
        {
            _csysTypeRepository.Delete(id);
        }

        public virtual void DeletecDepartment(int id)
        {
            _cDepartmentRepository.Delete(id);
        }

        public virtual void DeletecPost(int id)
        {
            _cPostRepository.Delete(id);
        }

        public virtual void DeletecCall(int id)
        {
            _cCallRepository.Delete(id);
        }


        public virtual IPagedList<cost_typeDto> GetCostType(int? ct_iftype, int? ct_categories, string name,int pageindex ,int pagesize)
        {
            var result = _cost_typeRepository.TableNoTracking;
            if (ct_iftype.HasValue)
                result = result.Where(s => s.ct_iftype == ct_iftype);

            if (ct_categories.HasValue)
                result = result.Where(s => s.ct_categories == ct_categories);

            if (!string.IsNullOrEmpty(name))
                result = result.Where(s => s.ct_number.StartsWith(name) || s.ct_name.StartsWith(name));

            return new PagedList<cost_typeDto>(result.ProjectToQueryable<cost_typeDto>(), pageindex, pagesize);
        }


        public virtual void AddShift(ShiftDto shift)
        {
            Domain.Shift model = AutoMapper.Mapper.Map<Domain.Shift>(shift);
            _ShiftRepository.Insert(model);

        }

        public virtual void UpdateShift(ShiftDto shift)
        {
            Domain.Shift model = AutoMapper.Mapper.Map<Domain.Shift>(shift);
            _ShiftRepository.Update(model);

        }

        public virtual ShiftDto GetShiftById(int id)
        {
            return _ShiftRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<ShiftDto>();
        }

        public virtual List<ShiftDto> GetShiftList()
        {
            return _ShiftRepository.TableNoTracking.ProjectToList<ShiftDto>();
        }

        public virtual void DeleteShift(int id)
        {
            _ShiftRepository.Delete(id);
        }

        public virtual void AddShiftInfo(shopInfoDto ShiftInfo)
        {
            Domain.shopInfo model = AutoMapper.Mapper.Map<Domain.shopInfo>(ShiftInfo);
            _shopInfoRepository.Insert(model);

        }

        public virtual void UpdateShiftInfo(shopInfoDto ShiftInfo)
        {
            Domain.shopInfo model = AutoMapper.Mapper.Map<Domain.shopInfo>(ShiftInfo);
            _shopInfoRepository.Update(model);

        }

        public virtual shopInfoDto GetShiftInfoById(int id)
        {
            return _shopInfoRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<shopInfoDto>();
        }

        public virtual List<shopInfoDto> GetShiftInfoList()
        {
            return _shopInfoRepository.TableNoTracking.ProjectToList<shopInfoDto>();
        }

        public virtual void DeleteShiftInfo(int id)
        {
            _shopInfoRepository.Delete(id);
        }

        public virtual void Addfloor_id(floor_ldDto floor_id)
        {
            Domain.floor_ld model = AutoMapper.Mapper.Map<Domain.floor_ld>(floor_id);
            _floor_ldRepository.Insert(model);

        }

        public virtual void Updatefloor_id(floor_ldDto floor_id)
        {
            Domain.floor_ld model = AutoMapper.Mapper.Map<Domain.floor_ld>(floor_id);
            _floor_ldRepository.Update(model);

        }

        public virtual floor_ldDto Getfloor_idById(int id)
        {
            return _floor_ldRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<floor_ldDto>();
        }

        public virtual List<floor_ldDto> Getfloor_idList()
        {
            return _floor_ldRepository.TableNoTracking.ProjectToList<floor_ldDto>();
        }

        public virtual void Deletefloor_id(int id)
        {
            _floor_ldRepository.Delete(id);
        }


        public virtual void Addprint(printDto print)
        {
            Domain.print model = AutoMapper.Mapper.Map<Domain.print>(print);
            _printRepository.Insert(model);

        }

        public virtual void Updateprint(printDto print)
        {
            Domain.print model = AutoMapper.Mapper.Map<Domain.print>(print);
            _printRepository.Update(model);

        }

        public virtual printDto GetprintById(int id)
        {
            return _printRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<printDto>();
        }

        public virtual List<printDto> GetprintList()
        {
            return _printRepository.TableNoTracking.ProjectToList<printDto>();
        }

        public virtual void Deleteprint(int id)
        {
            _printRepository.Delete(id);
        }

        public virtual void AddSuoSys(SuoSysDto SuoSys)
        {
            Domain.SuoSys model = AutoMapper.Mapper.Map<Domain.SuoSys>(SuoSys);
            _SuoSysRepository.Insert(model);

        }

        public virtual void UpdateSuoSys(SuoSysDto SuoSys)
        {
            Domain.SuoSys model = AutoMapper.Mapper.Map<Domain.SuoSys>(SuoSys);
            _SuoSysRepository.Update(model);

        }

        public virtual SuoSysDto GetSuoSysById(int id)
        {
            return _SuoSysRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<SuoSysDto>();
        }

        public virtual List<SuoSysDto> GetSuoSysList(string name)
        {
            var result = _SuoSysRepository.TableNoTracking;
            if (!string.IsNullOrEmpty(name))
                result = result.Where(s => s.SuoTypeName == name);

            return result.ProjectToList<SuoSysDto>();
        }

        public virtual void DeleteSuoSys(int id)
        {
            _SuoSysRepository.Delete(id);
        }

        public virtual void AddSuoRoom(SuoRoomDto SuoRoom)
        {
            Domain.SuoRoom model = AutoMapper.Mapper.Map<Domain.SuoRoom>(SuoRoom);
            _SuoRoomRepository.Insert(model);

        }

        public virtual void UpdateSuoRoom(SuoRoomDto SuoRoom)
        {
            Domain.SuoRoom model = AutoMapper.Mapper.Map<Domain.SuoRoom>(SuoRoom);
            _SuoRoomRepository.Update(model);

        }

        public virtual SuoRoomDto GetSuoRoomById(int id)
        {
            return _SuoRoomRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<SuoRoomDto>();
        }

        public virtual List<SuoRoomDto> GetSuoRoomList(string type,string roomnumber)
        {
            var result = _SuoRoomRepository.TableNoTracking;
            if (!string.IsNullOrEmpty(type))
                result = result.Where(s => s.SuoType == type);

            if (!string.IsNullOrEmpty(type))
                result = result.Where(s => s.RoomNumber == roomnumber);
            return result.ProjectToList<SuoRoomDto>();
        }

        public virtual void DeleteSuoRoom(int id)
        {
            _SuoRoomRepository.Delete(id);
        }


        public virtual void Addmenu(MenuDto menu)
        {
            Domain.Menu model = AutoMapper.Mapper.Map<Domain.Menu>(menu);
            _MenuRepository.Insert(model);

        }

        public virtual void Updatemenu(MenuDto menu)
        {
            Domain.Menu model = AutoMapper.Mapper.Map<Domain.Menu>(menu);
            _MenuRepository.Update(model);

        }

        public virtual MenuDto GetmenuById(int id)
        {
            return _MenuRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<MenuDto>();
        }

        public virtual List<MenuDto> GetmenuList()
        {
            var result = _MenuRepository.TableNoTracking;
          
            return result.ProjectToList<MenuDto>();
        }

        public virtual IPagedList<MenuDto> GetmenuList(int pageindex,int pagesize)
        {
            var result = _MenuRepository.TableNoTracking;

            return new PagedList<MenuDto>(result.ProjectToQueryable<MenuDto>(), pageindex, pagesize);
        }

        public virtual void Deletemenu(int id)
        {
            _MenuRepository.Delete(id);
        }


        public virtual void AddShift_Exc(Shift_ExcDto Shift_Exc)
        {
            Domain.Shift_Exc model = AutoMapper.Mapper.Map<Domain.Shift_Exc>(Shift_Exc);
            _Shift_ExcRepository.Insert(model);

        }

        public virtual void UpdateShift_Exc(Shift_ExcDto Shift_Exc)
        {
            Domain.Shift_Exc model = AutoMapper.Mapper.Map<Domain.Shift_Exc>(Shift_Exc);
            _Shift_ExcRepository.Update(model);

        }

        public virtual Shift_ExcDto GetShift_ExcById(int id)
        {
            return _Shift_ExcRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<Shift_ExcDto>();
        }

        public virtual List<Shift_ExcDto> GetShift_ExcList()
        {
            var result = _Shift_ExcRepository.TableNoTracking;

            return result.ProjectToList<Shift_ExcDto>();
        }

        public virtual IPagedList<Shift_ExcDto> GetShift_ExcList(int pageindex, int pagesize)
        {
            var result = _Shift_ExcRepository.TableNoTracking;

            return new PagedList<Shift_ExcDto>(result.ProjectToQueryable<Shift_ExcDto>(), pageindex, pagesize);
        }

        public virtual void DeleteShift_Exc(int id)
        {
            _Shift_ExcRepository.Delete(id);
        }


        public virtual void Addreal_mode(real_modeDto real_mode)
        {
            Domain.real_mode model = AutoMapper.Mapper.Map<Domain.real_mode>(real_mode);
            _real_modeRepository.Insert(model);

        }

        public virtual void Updatereal_mode(real_modeDto real_mode)
        {
            Domain.real_mode model = AutoMapper.Mapper.Map<Domain.real_mode>(real_mode);
            _real_modeRepository.Update(model);

        }

        public virtual real_modeDto Getreal_modeById(int id)
        {
            return _real_modeRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<real_modeDto>();
        }

        public virtual List<real_modeDto> Getreal_modeList()
        {
            var result = _real_modeRepository.TableNoTracking;

            return result.ProjectToList<real_modeDto>();
        }

        public virtual IPagedList<real_modeDto> Getreal_modeList(int pageindex, int pagesize)
        {
            var result = _real_modeRepository.TableNoTracking;

            return new PagedList<real_modeDto>(result.ProjectToQueryable<real_modeDto>(), pageindex, pagesize);
        }

        public virtual void Deletereal_mode(int id)
        {
            _real_modeRepository.Delete(id);
        }

        public virtual void AddRemaker(RemakerDto Remaker)
        {
            Domain.Remaker model = AutoMapper.Mapper.Map<Domain.Remaker>(Remaker);
            _RemakerRepository.Insert(model);

        }

        public virtual void UpdateRemaker(RemakerDto Remaker)
        {
            Domain.Remaker model = AutoMapper.Mapper.Map<Domain.Remaker>(Remaker);
            _RemakerRepository.Update(model);

        }

        public virtual RemakerDto GetRemakerById(int id)
        {
            return _RemakerRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<RemakerDto>();
        }

        public virtual List<RemakerDto> GetRemakerList()
        {
            var result = _RemakerRepository.TableNoTracking;

            return result.ProjectToList<RemakerDto>();
        }

        public virtual IPagedList<RemakerDto> GetRemakerList(int pageindex, int pagesize)
        {
            var result = _RemakerRepository.TableNoTracking;

            return new PagedList<RemakerDto>(result.ProjectToQueryable<RemakerDto>(), pageindex, pagesize);
        }

        public virtual void DeleteRemaker(int id)
        {
            _RemakerRepository.Delete(id);
        }

        public virtual void AddSincethehous(SincethehousDto Sincethehous)
        {
            Domain.Sincethehous model = AutoMapper.Mapper.Map<Domain.Sincethehous>(Sincethehous);
            _SincethehousRepository.Insert(model);

        }

        public virtual void UpdateSincethehous(SincethehousDto Sincethehous)
        {
            Domain.Sincethehous model = AutoMapper.Mapper.Map<Domain.Sincethehous>(Sincethehous);
            _SincethehousRepository.Update(model);

        }

        public virtual SincethehousDto GetSincethehousById(int id)
        {
            return _SincethehousRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<SincethehousDto>();
        }

        public virtual List<SincethehousDto> GetSincethehousList()
        {
            var result = _SincethehousRepository.TableNoTracking;

            return result.ProjectToList<SincethehousDto>();
        }

        public virtual IPagedList<SincethehousDto> GetSincethehousList(int pageindex, int pagesize)
        {
            var result = _SincethehousRepository.TableNoTracking;

            return new PagedList<SincethehousDto>(result.ProjectToQueryable<SincethehousDto>(), pageindex, pagesize);
        }

        public virtual void DeleteSincethehous(int id)
        {
            _SincethehousRepository.Delete(id);
        }
    }
}
