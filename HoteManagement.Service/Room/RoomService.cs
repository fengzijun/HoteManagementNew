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

namespace HoteManagement.Service.Room
{
    [Intercept(typeof(UnitOfWorkInterceptor))]
    public class RoomService : ApplicationService, IRoomService
    {
        public RoomService(IRepository<Domain.account_goods> account_goodsRepository,
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




        public virtual List<room_typeDto> GetRoomTypeList()
        {
            return _room_typeRepository.TableNoTracking.ProjectToList<room_typeDto>();
        }

        public virtual room_typeDto GetRoomTypeById(int id)
        {
            return _room_typeRepository.TableNoTracking.ProjectToFirstOrDefault<room_typeDto>();
        }

        public virtual List<hourse_schemeDto> Gethourse_schemeList()
        {
            return _hourse_schemeRepository.TableNoTracking.ProjectToList<hourse_schemeDto>();
        }

        public virtual hourse_schemeDto Gethourse_schemeById()
        {
            return _hourse_schemeRepository.TableNoTracking.ProjectToFirstOrDefault<hourse_schemeDto>();
        }

        public virtual List<room_numberDto> GetRoomNumberList(int roomtype ,int statue)
        {
            return _room_numberRepository.TableNoTracking.Where(s => s.Rn_room == roomtype && s.Rn_state == statue).ProjectToList<room_numberDto>();
        }

        public virtual List<book_roomDto> GetBookRoomList(DateTime time , int[] stateid)
        {

            return _book_roomRepository.TableNoTracking.Where(s => s.time_from > time && stateid.Contains(s.state_id.Value)).ProjectToList<book_roomDto>();
        }

        public int GetBookRoomCount()
        {
            return _book_roomRepository.TableNoTracking.Count();
        }

        public virtual List<Book_RdetailDto> GetBookRetails(string bookno)
        {
            //return _book_rdetailRepository.TableNoTracking.Where(s => s.Book_no == bookno).ProjectToList<Book_RdetailDto>();
            return _Book_RdetailRepository.TableNoTracking.Where(s => s.Book_no == bookno).ProjectToList<Book_RdetailDto>();
        }


        public virtual guest_sourceDto GetGuest_Source(int id)
        {
            return _guest_sourceRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<guest_sourceDto>();
        }

        public virtual void UpdateBookRoom(book_roomDto book_Room)
        {
            Domain.book_room model = AutoMapper.Mapper.Map<Domain.book_room>(book_Room);

            _book_roomRepository.Update(model);
        }

        public virtual List<BookStateDto> GetBookStateList()
        {
            return _BookStateRepository.TableNoTracking.ProjectToList<BookStateDto>();
        }

        public virtual BookStateDto GetBookState(int id)
        {
            return _BookStateRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<BookStateDto>();
        }

        public virtual IPagedList<book_roomDto> GetBookRoomList(string bookname,DateTime? starttime, DateTime? endtime ,string bookno,string teleno,int[] stateid,int pageindex, int pagesize)
        {
            var result = _book_roomRepository.TableNoTracking;
            if (!string.IsNullOrEmpty(bookname))
                result = result.Where(s => s.book_Name.Contains(bookname));

            if (starttime.HasValue)
                result = result.Where(s => s.time_to >= starttime);

            if (endtime.HasValue)
                result = result.Where(s => s.time_to <= endtime);

            if (!string.IsNullOrEmpty(bookno))
                result = result.Where(s => s.book_no.Contains(bookno));

            if (!string.IsNullOrEmpty(teleno))
                result = result.Where(s => s.tele_no.Contains(teleno));

            if (stateid.Length > 0 && stateid.Length == 1)
            {
                int tempid = stateid[0];
                result = result.Where(s => s.state_id.Value == tempid);
            }
            else
            {
                result = result.Where(s => stateid.Contains(s.state_id.Value));
            }

            return new PagedList<book_roomDto>(result.ProjectToQueryable<book_roomDto>(), pageindex, pagesize);
                
        }

        public virtual List<card_typeDto> GetAllCardTypeList()
        {
            return _card_typeRepository.TableNoTracking.ProjectToList<card_typeDto>();
        }


        public virtual List<real_modeDto> GetAllRealModelList()
        {
            return _real_modeRepository.TableNoTracking.ProjectToList<real_modeDto>();
        }

        public virtual real_modeDto GetRealModelById(int id)
        {
            return _real_modeRepository.TableNoTracking.Where(s=>s.Id == id).ProjectToFirst<real_modeDto>();
        }

        public virtual void Addoccu_infor(occu_inforDto model)
        {
            Domain.occu_infor occu_Infor = AutoMapper.Mapper.Map<Domain.occu_infor>(model);

            _occu_inforRepository.Insert(occu_Infor);
        }

        public virtual List<occu_inforDto> GetOccu_inforList(string orderid,string roomnumber,int? stateid)
        {
            var result = _occu_inforRepository.TableNoTracking;
            if (!string.IsNullOrEmpty(orderid))
                result = result.Where(s => s.order_id == orderid);
            if(!string.IsNullOrEmpty(roomnumber))
                result = result.Where(s => s.room_number == roomnumber);
            if(stateid.HasValue)
                result = result.Where(s => s.state_id == stateid);

            return result.ProjectToList<occu_inforDto>();

        }

        public virtual occu_inforDto Getoccu_inforById(int id)
        {
            return _occu_inforRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<occu_inforDto>();
        }

        public virtual void Updateoccu_infor(occu_inforDto model)
        {
            Domain.occu_infor occu_Infor = AutoMapper.Mapper.Map<Domain.occu_infor>(model);

            _occu_inforRepository.Update(occu_Infor);
        }

        public virtual List<goods_accountDto> GetgoodsaccountList(string bookno,string ga_name,string account,string occno,string[] goodno,int? ga_Type)
        {
            var result = _goods_accountRepository.TableNoTracking;
            if (!string.IsNullOrEmpty(bookno))
                result = result.Where(s => s.ga_number == bookno);

            if (!string.IsNullOrEmpty(ga_name))
                result = result.Where(s => s.ga_name == ga_name);

            if (!string.IsNullOrEmpty(account))
                result = result.Where(s => s.ga_Account == account);


            if (!string.IsNullOrEmpty(occno))
                result = result.Where(s => s.ga_occuid == occno);

            if (goodno.Length>0 && goodno.Length == 1)
            {
                string temp = goodno[0];
                result = result.Where(s => s.ga_goodNo == temp);
            }
            else
            {
                result = result.Where(s => goodno.Contains(s.ga_goodNo));

            }
             
            if(ga_Type.HasValue)
            {
                result = result.Where(s => s.ga_Type == ga_Type);
            }

            return result.ProjectToList<goods_accountDto>();
        }

        public virtual void UpdateGoods_account(goods_accountDto goods_Account)
        {
            Domain.goods_account model = AutoMapper.Mapper.Map<Domain.goods_account>(goods_Account);

            _goods_accountRepository.Update(model);
        }


        public virtual void AddGoods_account(goods_accountDto goods_Account)
        {
            Domain.goods_account model = AutoMapper.Mapper.Map<Domain.goods_account>(goods_Account);

            _goods_accountRepository.Insert(model);
        }

        public virtual room_numberDto GetRoom_NumberById(int id)
        {
            return _room_numberRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<room_numberDto>();
        }

        public virtual void DeleteFloorManage(int id)
        {
            _floor_manageRepository.Delete(id);
        }

        public virtual void DeleteRoomType(int id)
        {
            _room_typeRepository.Delete(id);
        }

        public virtual void DeleteRoomNumber(int id)
        {
            _room_numberRepository.Delete(id);
        }

        public virtual void AddRoomType(room_typeDto room_Type)
        {
            Domain.room_type model = AutoMapper.Mapper.Map<Domain.room_type>(room_Type);
            _room_typeRepository.Insert(model);
        }

        public virtual void UpdateRoomType(room_typeDto room_Type)
        {
            Domain.room_type model = AutoMapper.Mapper.Map<Domain.room_type>(room_Type);
            _room_typeRepository.Update(model);
        }

        public virtual List<room_stateDto> GetRoomStateList()
        {
            return _room_stateRepository.TableNoTracking.Where(s => s.room_state_name != "取消").ProjectToList<room_stateDto>();
        }


        public virtual void Addroom_state(room_stateDto room_State)
        {
            Domain.room_state model = AutoMapper.Mapper.Map<Domain.room_state>(room_State);
            _room_stateRepository.Insert(model);
        }

        public virtual void Updateroom_state(room_stateDto room_State)
        {
            Domain.room_state model = AutoMapper.Mapper.Map<Domain.room_state>(room_State);
            _room_stateRepository.Update(model);
        }

        public virtual void AddFset(FtSetDto ftSet)
        {
            Domain.FtSet model = AutoMapper.Mapper.Map<Domain.FtSet>(ftSet);
            _FtSetRepository.Insert(model);

        }

        public virtual void UpdateFset(FtSetDto ftSet)
        {
            Domain.FtSet model = AutoMapper.Mapper.Map<Domain.FtSet>(ftSet);
            _FtSetRepository.Update(model);

        }

        public virtual void Addmodes(modesDto modes)
        {
            Domain.modes model = AutoMapper.Mapper.Map<Domain.modes>(modes);
            _modesRepository.Insert(model);

        }

        public virtual void Updatemodes(modesDto modes)
        {
            Domain.modes model = AutoMapper.Mapper.Map<Domain.modes>(modes);
            _modesRepository.Update(model);

        }

        public virtual modesDto GetmodesById(int id)
        {
            return _modesRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<modesDto>();
        }

        public virtual List<modesDto> GetmodesList()
        {
            var result = _modesRepository.TableNoTracking;
          
            return result.ProjectToList<modesDto>();
        }

        public virtual void Deletemodes(int id)
        {
            _modesRepository.Delete(id);
        }

        public virtual IPagedList<room_numberDto> GetRoomNumberPageList(int pageindx,int pagesize)
        {
            return new PagedList<room_numberDto>(_room_numberRepository.TableNoTracking.ProjectToQueryable<room_numberDto>(), pageindx, pagesize);
        }

    }
}
