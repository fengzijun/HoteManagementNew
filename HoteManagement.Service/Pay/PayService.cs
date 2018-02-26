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

namespace HoteManagement.Service.Pay
{
    [Intercept(typeof(UnitOfWorkInterceptor))]
    public class PayService:ApplicationService,IPayService
    {
        public PayService(IRepository<Domain.account_goods> account_goodsRepository,
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
        public virtual void AddGoodsAccount(goods_accountDto goodaccount)
        {
            Domain.goods_account model = AutoMapper.Mapper.Map<Domain.goods_account>(goodaccount);
            _goods_accountRepository.Insert(model);
        }

        public virtual List<meth_payDto> GetMethPayList(bool? methisya, bool? meth_is_jie)
        {
            var result = _meth_payRepository.TableNoTracking;

            if (methisya.HasValue)
                result = result.Where(s => s.meth_is_ya == methisya);
            if (meth_is_jie.HasValue)
                result = result.Where(s => s.meth_is_jie == meth_is_jie);

            return result.ProjectToList<meth_payDto>();
        }

        public virtual void Addmeth_pay(meth_payDto meth_Pay)
        {
            Domain.meth_pay model = AutoMapper.Mapper.Map<Domain.meth_pay>(meth_Pay);
            _meth_payRepository.Insert(model);

        }

        public virtual void Updatemeth_pay(meth_payDto meth_Pay)
        {
            Domain.meth_pay model = AutoMapper.Mapper.Map<Domain.meth_pay>(meth_Pay);
            _meth_payRepository.Update(model);

        }

        public virtual meth_payDto Getmeth_payId(int id)
        {
            return _meth_payRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<meth_payDto>();
        }

  

        public virtual void Deletemeth_pay(int id)
        {
            _meth_payRepository.Delete(id);
        }


    }
}
