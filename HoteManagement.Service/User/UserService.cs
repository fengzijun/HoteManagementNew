using Autofac.Extras.DynamicProxy;
using AutoMapper;
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

namespace HoteManagement.Service.User
{
    [Intercept(typeof(UnitOfWorkInterceptor))]
    public class UserService : ApplicationService, IUserService
    {
        public UserService(IRepository<Domain.account_goods> account_goodsRepository,
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


        public virtual bool CheckAccountUser(string username , string pwd)
        {
            return _Accounts_UsersRepository.TableNoTracking.Where(s => s.UserName == username && s.Password == pwd).FirstOrDefault() != null;
        }

        public virtual void AddAccountUser(Accounts_UsersDto user)
        {
            Domain.Accounts_Users accounts_Users = AutoMapper.Mapper.Map<Domain.Accounts_Users>(user);
            _Accounts_UsersRepository.Insert(accounts_Users);
        }

        public virtual void UpdateAccountUser(Accounts_UsersDto user)
        {
            Domain.Accounts_Users accounts_Users = AutoMapper.Mapper.Map<Domain.Accounts_Users>(user);
            _Accounts_UsersRepository.Update(accounts_Users);
        }

        public virtual Accounts_UsersDto GetAccountUser(string username,string pwd)
        {
            var model = _Accounts_UsersRepository.TableNoTracking.Where(s => s.UserName == username && s.Password == pwd).FirstOrDefault();
            return AutoMapper.Mapper.Map<Accounts_UsersDto>(model);
        }

        public virtual Accounts_UsersDto GetAccountUser(string username)
        {
            return _Accounts_UsersRepository.TableNoTracking.Where(s => s.UserName == username).ProjectToFirstOrDefault<Accounts_UsersDto>();
        }

        public virtual Accounts_UsersDto GetAccountUser(int id)
        {
            return _Accounts_UsersRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<Accounts_UsersDto>();
        }

        public virtual UserMenus GetAccountMenus(int userid)
        {
            var userrolemodel = _Accounts_UserRolesRepository.TableNoTracking.Where(s => s.UserID == userid).FirstOrDefault();
        
            var rolemodel = _Accounts_RolesRepository.TableNoTracking.Where(s => s.Id == userrolemodel.RoleID).FirstOrDefault();

            var rolemenuquery = _RoleMenuRepository.TableNoTracking.Where(s => s.RoleID == rolemodel.Id);

            if (rolemodel.hotelid.HasValue)
                rolemenuquery = rolemenuquery.Where(s => s.hotelid == rolemodel.hotelid);

            var rolemenus = rolemenuquery.ToList();

            //int?[] parnetids = rolemenus.Select(s => s.Menu_pid).Distinct().ToArray();

            //var parentmenus = _MenuRepository.TableNoTracking.Where(s => parnetids.Contains(s.Id)).ProjectToList<MenuDto>();
            //var tempparentmenus = _MenuRepository.TableNoTracking.Where(s => parnetids.Contains(s.Id)).ToList();
            //var parentmenus = AutoMapper.Mapper.Map<List<MenuDto>>(tempparentmenus);

            UserMenus userMenus = new UserMenus { RoleId = rolemodel.Id, UserId = userid };
            List<Menu> menus = new List<Menu>();

            foreach(var item in rolemenus)
            {
                if(!menus.Any(s=>s.ParentMenu.Id == item.Menu_pid))
                {
                    Menu menu = new Menu();
                    menu.ParentMenu = AutoMapper.Mapper.Map<MenuDto>(_MenuRepository.TableNoTracking.Where(s => s.Id == item.Menu_pid).FirstOrDefault());
                    menu.ClildMenus = new List<MenuDto>();
                    menus.Add(menu);
                }

                Menu model = menus.Where(s => s.ParentMenu.Id == item.Menu_pid).FirstOrDefault();
                var childmenu = _MenuRepository.TableNoTracking.Where(s => s.Id == item.Menu_id).FirstOrDefault();
                if (childmenu != null)
                {
                    var childmenudto = AutoMapper.Mapper.Map<MenuDto>(childmenu);
                    model.ClildMenus.Add(childmenudto);
                }
            }


            //foreach (var item in parentmenus)
            //{
            //    var menu = new Menu { ParentMenu = item };
            //    var childrenmenus = _RoleMenuRepository.TableNoTracking.Where(s => s.RoleID == rolemodel.Id && s.Menu_pid == item.Id).ToList();
            //    foreach (var chlilditem in childrenmenus)
            //    {
            //        var clildmenu = _MenuRepository.TableNoTracking.Where(s => s.Id == chlilditem.Menu_id).FirstOrDefault();

            //        if (clildmenu != null)
            //        {
            //            menu.ClildMenus.Add(AutoMapper.Mapper.Map<MenuDto>(clildmenu));
            //        }
            //    }
            //    menus.Add(menu);

            //}
            userMenus.Menus = menus;
            return userMenus;
        }


        public virtual customerDto GetCustomer(string account)
        {
            return _customerRepository.TableNoTracking.Where(s => s.accounts == account).ProjectToFirstOrDefault<customerDto>();
        }

        public virtual customerDto GetCustomerById(int id)
        {
            return _customerRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<customerDto>();
        }

        public virtual void UpdateCustomer(customerDto customer)
        {
            Domain.customer model = AutoMapper.Mapper.Map<Domain.customer>(customer);
            _customerRepository.Update(model);
        }

        public virtual List<CommissionDto> GetCommission(string account)
        {
            var result = _CommissionRepository.TableNoTracking;
            if (!string.IsNullOrEmpty(account))
                result = result.Where(s => s.Accounts == account);

            return result.ProjectToList<CommissionDto>();
        }

        public virtual CommissionDto GetCommissionById(int id)
        {
            return _CommissionRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirst<CommissionDto>();
        }

        public virtual List<CommissionDto> GetCommissionByIds(int[] ids)
        {
            return _CommissionRepository.TableNoTracking.Where(s => ids.Contains( s.Id)).ProjectToList<CommissionDto>();
        }

        public virtual void Addcprotocol(cprotocolDto cprotocol)
        {
            Domain.cprotocol model = AutoMapper.Mapper.Map<Domain.cprotocol>(cprotocol);
            _cprotocolRepository.Insert(model);
        }

        public virtual void Updatecprotocol(cprotocolDto cprotocol)
        {
            Domain.cprotocol model = AutoMapper.Mapper.Map<Domain.cprotocol>(cprotocol);
            _cprotocolRepository.Update(model);
        }

        public virtual cprotocolDto GetcprotocolById(int id)
        {
            return _cprotocolRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<cprotocolDto>();
        }

        public virtual List<cprotocolDto> Getcprotocol(string account)
        {
            return _cprotocolRepository.TableNoTracking.Where(s => s.Accounts == account).ProjectToList<cprotocolDto>();
        }

        public virtual List<cprotocolPriceDto> GetcprotocolPrice(string accounts , int? cpid)
        {
            var result = _cprotocolPriceRepository.TableNoTracking;
            if (!string.IsNullOrEmpty(accounts))
                result = result.Where(s => s.Accounts == accounts);
            if (cpid.HasValue)
                result = result.Where(s => s.cpID == cpid.Value);

            return result.ProjectToList<cprotocolPriceDto>();

        }

        public virtual void AddcprotocolPrice(cprotocolPriceDto cprotocolPrice)
        {
            Domain.cprotocolPrice model = AutoMapper.Mapper.Map<Domain.cprotocolPrice>(cprotocolPrice);
            _cprotocolPriceRepository.Insert(model);
        }

        public virtual void UpdatecprotocolPrice(cprotocolPriceDto cprotocolPrice)
        {
            Domain.cprotocolPrice model = AutoMapper.Mapper.Map<Domain.cprotocolPrice>(cprotocolPrice);
            _cprotocolPriceRepository.Update(model);
        }

        public virtual List<ContactsDto> GetContacts(string account)
        {
            var result = _ContactsRepository.TableNoTracking;
            if (!string.IsNullOrEmpty(account))
                result = result.Where(s => s.Accounts == account);

            return result.ProjectToList<ContactsDto>();

        }

        public virtual void AddMember(memberDto member)
        {
            Domain.member model = AutoMapper.Mapper.Map<Domain.member>(member);
            _memberRepository.Insert(model);
        }

        public virtual void UpdateMember(memberDto member)
        {
            Domain.member model = AutoMapper.Mapper.Map<Domain.member>(member);
            _memberRepository.Update(model);
        }


        public virtual memberDto GetMember(int id)
        {
            return _memberRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<memberDto>();
        }

        public virtual memberStateDto GetMemberState(int id)
        {
            return _memberStateRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<memberStateDto>();
        }

        public virtual List<memberTypeDto> GetmembertypeList(string name,int? stateid,int? mtype,DateTime? startime ,DateTime? endtime)
        {
            var result = _memberRepository.TableNoTracking;
            if (!string.IsNullOrEmpty(name))
                result = result.Where(s => s.Name.StartsWith(name));
            if(stateid.HasValue)
                result = result.Where(s => s.Statid == stateid);

            if (mtype.HasValue)
                result = result.Where(s => s.Mtype == mtype);

            if(startime.HasValue)
                result = result.Where(s => s.Baithday > startime);

            if (endtime.HasValue)
                result = result.Where(s => s.Baithday < endtime);

            return result.ProjectToList<memberTypeDto>();
        }


        public virtual memberTypeDto Getmembertype(int id)
        {
            return _memberTypeRepository.TableNoTracking.Where(s=>s.Id == id).ProjectToFirstOrDefault<memberTypeDto>();
        }

        public virtual void AddMemberType(memberTypeDto memberType)
        {
            Domain.memberType model = AutoMapper.Mapper.Map<Domain.memberType>(memberType);
            _memberTypeRepository.Insert(model);
        }

        public virtual void UpdateMemberType(memberTypeDto memberType)
        {
            Domain.memberType model = AutoMapper.Mapper.Map<Domain.memberType>(memberType);
            _memberTypeRepository.Update(model);
        }

        public virtual List<UsersDto> GetUserList(string userid,int? id,int? usertype)
        {
            var result = _UsersRepository.TableNoTracking;
            if (!string.IsNullOrEmpty(userid))
                result = result.Where(s => s.userid == userid);
            if (usertype.HasValue)
                result = result.Where(s => s.user_type == usertype);
            if (id.HasValue)
                result = result.Where(s => s.Id == id.Value);

            return result.ProjectToList<UsersDto>();
        }


        public virtual List<userTypeDto> GetUserTypeList(int? typeid)
        {
            var result = _userTypeRepository.TableNoTracking;
            if (typeid.HasValue)
                result = result.Where(s => s.typeid == typeid);

            return result.ProjectToList<userTypeDto>();
        }

        public virtual userTypeDto GetUserType(int id)
        {

            return _userTypeRepository.TableNoTracking.Where(s=>s.Id == id).ProjectToFirstOrDefault<userTypeDto>();
        }

        public virtual void AddUserType(userTypeDto userType)
        {
            Domain.userType model = AutoMapper.Mapper.Map<Domain.userType>(userType);
            _userTypeRepository.Insert(model);
        }

        public virtual void UpdateUserType(userTypeDto userType)
        {
            Domain.userType model = AutoMapper.Mapper.Map<Domain.userType>(userType);
            _userTypeRepository.Update(model);
        }

        public virtual  List<mtPriceDto> GetMtPrice(int mtid)
        {
            return _mtPriceRepository.TableNoTracking.Where(s => s.MTID == mtid).ProjectToList<mtPriceDto>();
        }


        public virtual void AddAccountsUserRoles(Accounts_UserRolesDto AccountsUserRoles)
        {
            Domain.Accounts_UserRoles model = AutoMapper.Mapper.Map<Domain.Accounts_UserRoles>(AccountsUserRoles);
            _Accounts_UserRolesRepository.Insert(model);

        }

        public virtual void UpdateAccountsUserRoles(Accounts_UserRolesDto AccountsUserRoles)
        {
            Domain.Accounts_UserRoles model = AutoMapper.Mapper.Map<Domain.Accounts_UserRoles>(AccountsUserRoles);
            _Accounts_UserRolesRepository.Update(model);

        }

        public virtual Accounts_UserRolesDto GetAccountsUserRolesById(int id)
        {
            return _Accounts_UserRolesRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<Accounts_UserRolesDto>();
        }

        public virtual List<Accounts_UserRolesDto> GetAccountsUserRolesList()
        {
            var result = _Accounts_UserRolesRepository.TableNoTracking;
        
            return result.ProjectToList<Accounts_UserRolesDto>();
        }

        public virtual void DeleteAccountsUserRoles(int id)
        {
            _Accounts_UserRolesRepository.Delete(id);
        }

        public virtual void AddAccounts_Roles(Accounts_RolesDto Accounts_Roles)
        {
            Domain.Accounts_Roles model = AutoMapper.Mapper.Map<Domain.Accounts_Roles>(Accounts_Roles);
            _Accounts_RolesRepository.Insert(model);

        }

        public virtual void UpdateAccounts_Roles(Accounts_RolesDto Accounts_Roles)
        {
            Domain.Accounts_Roles model = AutoMapper.Mapper.Map<Domain.Accounts_Roles>(Accounts_Roles);
            _Accounts_RolesRepository.Update(model);

        }

        public virtual Accounts_RolesDto GetAccounts_RolesById(int id)
        {
            return _Accounts_RolesRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<Accounts_RolesDto>();
        }

        public virtual List<Accounts_UserRolesDto> GetAccounts_RolesList()
        {
            var result = _Accounts_RolesRepository.TableNoTracking;

            return result.ProjectToList<Accounts_UserRolesDto>();
        }

        public virtual void DeleteAccounts_Roles(int id)
        {
            _Accounts_RolesRepository.Delete(id);
        }
    }
}
