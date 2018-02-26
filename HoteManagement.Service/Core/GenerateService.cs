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

namespace HoteManagement.Service.Core
{
    [Intercept(typeof(UnitOfWorkInterceptor))]
    public class GenerateService : ApplicationService, IGenerateService
    {
        public GenerateService(IRepository<Domain.account_goods> account_goodsRepository,
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

        public virtual void Addaccount_goods(account_goodsDto account_goods)
        {
            Domain.account_goods model = AutoMapper.Mapper.Map<Domain.account_goods>(account_goods);
            _account_goodsRepository.Insert(model);
        }
        public virtual void Updateaccount_goods(account_goodsDto account_goods)
        {
            Domain.account_goods model = AutoMapper.Mapper.Map<Domain.account_goods>(account_goods);
            _account_goodsRepository.Update(model);
        }

        public virtual account_goodsDto Getaccount_goodsById(int id)
        {
            return _account_goodsRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<account_goodsDto>();
        }

        public virtual List<account_goodsDto> Getaccount_goodsList(int? hotelid)
        {
            var result = _account_goodsRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<account_goodsDto>();
        }

        public virtual IPagedList<account_goodsDto> Getaccount_goodsList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _account_goodsRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<account_goodsDto>(result.ProjectToQueryable<account_goodsDto>(), pageindex, pagesize);
        }

        public virtual void Deleteaccount_goods(int id)
        {
            _account_goodsRepository.Delete(id);
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
            var model = _Accounts_RolesRepository.TableNoTracking.Where(s => s.Id == id).FirstOrDefault();
            return AutoMapper.Mapper.Map<Accounts_RolesDto>(model);
        }

        public virtual Accounts_RolesDto GetAccounts_RolesByName(string name,int? hotelid)
        {
            var query = _Accounts_RolesRepository.TableNoTracking.Where(s => s.title == name);
            if (hotelid.HasValue)
                query = query.Where(s => s.hotelid == hotelid);
            var model = query.FirstOrDefault();
            return AutoMapper.Mapper.Map<Accounts_RolesDto>(model);
        }

        public virtual List<Accounts_RolesDto> GetAccounts_RolesList(int? hotelid)
        {
            var result = _Accounts_RolesRepository.TableNoTracking;
            if (hotelid.HasValue && hotelid.Value!=0)
                result = result.Where(s => s.hotelid == hotelid);
            var model = result.ToList();
            var finalmodel = AutoMapper.Mapper.Map<List<Accounts_RolesDto>>(model);
            foreach(var item in finalmodel)
            {
                if (item.hotelid.HasValue)
                {
                    item.UserHotel = AutoMapper.Mapper.Map<HotelDto>(_HotelRepository.TableNoTracking.Where(s => s.Id == item.hotelid).FirstOrDefault());
                }
                    
            }
           
            return finalmodel;
        }

        public virtual IPagedList<Accounts_RolesDto> GetAccounts_RolesList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _Accounts_RolesRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);


            var list = result.OrderByDescending(s => s.Id).Skip(pagesize * (pageindex - 1)).Take(pagesize).ToList();
            var count = result.Count();
            var pagelist = new PagedList<Accounts_RolesDto>(AutoMapper.Mapper.Map<List<Accounts_RolesDto>>(list), pageindex, pagesize, count);

            foreach (var item in pagelist)
            {
                if (item.hotelid.HasValue)
                    item.UserHotel = AutoMapper.Mapper.Map<HotelDto>(_HotelRepository.TableNoTracking.Where(s => s.Id == item.hotelid.Value).FirstOrDefault());
            }


            return pagelist;
        }

        public virtual void DeleteAccounts_Roles(int id)
        {
            _Accounts_RolesRepository.Delete(id);
        }

        public virtual void AddAccounts_UserRoles(Accounts_UserRolesDto Accounts_UserRoles)
        {
            Domain.Accounts_UserRoles model = AutoMapper.Mapper.Map<Domain.Accounts_UserRoles>(Accounts_UserRoles);
            _Accounts_UserRolesRepository.Insert(model);
        }
        public virtual void UpdateAccounts_UserRoles(Accounts_UserRolesDto Accounts_UserRoles)
        {
            Domain.Accounts_UserRoles model = AutoMapper.Mapper.Map<Domain.Accounts_UserRoles>(Accounts_UserRoles);
            _Accounts_UserRolesRepository.Update(model);
        }

        public virtual Accounts_UserRolesDto GetAccounts_UserRolesByUserId(int id)
        {
            var model = _Accounts_UserRolesRepository.TableNoTracking.Where(s => s.UserID == id).FirstOrDefault();

            return AutoMapper.Mapper.Map<Accounts_UserRolesDto>(model);
        }

        public virtual List<Accounts_UserRolesDto> GetAccounts_UserRolesList()
        {
            var result = _Accounts_UserRolesRepository.TableNoTracking;
      
            return result.ProjectToList<Accounts_UserRolesDto>();
        }

        public virtual IPagedList<Accounts_UserRolesDto> GetAccounts_UserRolesList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _Accounts_UserRolesRepository.TableNoTracking;

            return new PagedList<Accounts_UserRolesDto>(result.ProjectToQueryable<Accounts_UserRolesDto>(), pageindex, pagesize);
        }

        public virtual void DeleteAccounts_UserRoles(int id)
        {
            _Accounts_UserRolesRepository.Delete(id);
        }

        public virtual int AddAccounts_Users(Accounts_UsersDto Accounts_Users)
        {
            Domain.Accounts_Users model = AutoMapper.Mapper.Map<Domain.Accounts_Users>(Accounts_Users);
            var result = _Accounts_UsersRepository.Insert(model);
            return result.Id;
        }
        public virtual void UpdateAccounts_Users(Accounts_UsersDto Accounts_Users)
        {
            Domain.Accounts_Users model = AutoMapper.Mapper.Map<Domain.Accounts_Users>(Accounts_Users);
            _Accounts_UsersRepository.Update(model);
        }

        public virtual Accounts_UsersDto GetAccounts_UsersById(int id)
        {
            var model = AutoMapper.Mapper.Map<Accounts_UsersDto>(_Accounts_UsersRepository.TableNoTracking.Where(s => s.Id == id).FirstOrDefault()) ;
            if (model.hotelid.HasValue)
                model.UserHotel = AutoMapper.Mapper.Map<HotelDto>(_HotelRepository.TableNoTracking.Where(s => s.Id == model.hotelid.Value).FirstOrDefault());

            var userrolemodel = _Accounts_UserRolesRepository.TableNoTracking.Where(s => s.UserID == model.Id).FirstOrDefault();
            model.UserRole = AutoMapper.Mapper.Map<Accounts_RolesDto>(_Accounts_RolesRepository.TableNoTracking.Where(s => s.RoleID == userrolemodel.RoleID).FirstOrDefault());

            return model;
        }

        public virtual Accounts_UsersDto GetAccounts_UsersByName(int? hotelid,string accountname)
        {
            var query = _Accounts_UsersRepository.TableNoTracking.Where(s => s.UserName == accountname);
            if (hotelid.HasValue)
                query = query.Where(s => s.hotelid == hotelid);

            var model = AutoMapper.Mapper.Map<Accounts_UsersDto>(query.FirstOrDefault());

            if (model == null)
                return null;

            if (model.hotelid.HasValue)
            {
                var hotelmodel =  _HotelRepository.TableNoTracking.Where(s => s.Id == model.hotelid.Value).FirstOrDefault();
                model.UserHotel = AutoMapper.Mapper.Map<HotelDto>(hotelmodel);
            }
                

            var userrolemodel = _Accounts_UserRolesRepository.TableNoTracking.Where(s => s.UserID == model.Id).FirstOrDefault();
            if(userrolemodel!=null)
                model.UserRole = AutoMapper.Mapper.Map<Accounts_RolesDto>(_Accounts_RolesRepository.TableNoTracking.Where(s => s.RoleID == userrolemodel.RoleID).FirstOrDefault());

            return model;
        }

        public virtual List<Accounts_UsersDto> GetAccounts_UsersList(int? hotelid)
        {
            var result = _Accounts_UsersRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<Accounts_UsersDto>();
        }

        public virtual IPagedList<Accounts_UsersDto> GetAccounts_UsersList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _Accounts_UsersRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);

            var list = result.OrderByDescending(s => s.Id).Skip(pagesize * (pageindex - 1)).Take(pagesize).ToList();
            var count = result.Count();
            var pagelist = new PagedList<Accounts_UsersDto>(AutoMapper.Mapper.Map<List<Accounts_UsersDto>>(list), pageindex, pagesize, count);

            foreach (var item in pagelist)
            {
                if (item.hotelid.HasValue)
                    item.UserHotel = AutoMapper.Mapper.Map<HotelDto>(_HotelRepository.TableNoTracking.Where(s => s.Id == item.hotelid.Value).FirstOrDefault());

                var userrolemodel = _Accounts_UserRolesRepository.TableNoTracking.Where(s => s.UserID == item.Id).FirstOrDefault();
                var rolemodel = _Accounts_RolesRepository.TableNoTracking.Where(s => s.RoleID == userrolemodel.RoleID).FirstOrDefault();
                if(rolemodel!=null)
                   item.UserRole = AutoMapper.Mapper.Map<Accounts_RolesDto>(rolemodel);

            }

            return pagelist;

            //return new PagedList<Accounts_UsersDto>(result.ProjectToQueryable<Accounts_UsersDto>(), pageindex, pagesize);
        }

        public virtual void DeleteAccounts_Users(int id)
        {
            _Accounts_UsersRepository.Delete(id);
        }

        public virtual void AddAddPrice(AddPriceDto AddPrice)
        {
            Domain.AddPrice model = AutoMapper.Mapper.Map<Domain.AddPrice>(AddPrice);
            _AddPriceRepository.Insert(model);
        }
        public virtual void UpdateAddPrice(AddPriceDto AddPrice)
        {
            Domain.AddPrice model = AutoMapper.Mapper.Map<Domain.AddPrice>(AddPrice);
            _AddPriceRepository.Update(model);
        }

        public virtual AddPriceDto GetAddPriceById(int id)
        {
            return _AddPriceRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<AddPriceDto>();
        }

        public virtual List<AddPriceDto> GetAddPriceList(int? hotelid)
        {
            var result = _AddPriceRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<AddPriceDto>();
        }

        public virtual IPagedList<AddPriceDto> GetAddPriceList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _AddPriceRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<AddPriceDto>(result.ProjectToQueryable<AddPriceDto>(), pageindex, pagesize);
        }

        public virtual void DeleteAddPrice(int id)
        {
            _AddPriceRepository.Delete(id);
        }

        public virtual void Addapartment(apartmentDto apartment)
        {
            Domain.apartment model = AutoMapper.Mapper.Map<Domain.apartment>(apartment);
            _apartmentRepository.Insert(model);
        }
        public virtual void Updateapartment(apartmentDto apartment)
        {
            Domain.apartment model = AutoMapper.Mapper.Map<Domain.apartment>(apartment);
            _apartmentRepository.Update(model);
        }

        public virtual apartmentDto GetapartmentById(int id)
        {
            return _apartmentRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<apartmentDto>();
        }

        public virtual List<apartmentDto> GetapartmentList(int? hotelid)
        {
            var result = _apartmentRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<apartmentDto>();
        }

        public virtual IPagedList<apartmentDto> GetapartmentList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _apartmentRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<apartmentDto>(result.ProjectToQueryable<apartmentDto>(), pageindex, pagesize);
        }

        public virtual void Deleteapartment(int id)
        {
            _apartmentRepository.Delete(id);
        }

        public virtual void Addbanner(bannerDto banner)
        {
            Domain.banner model = AutoMapper.Mapper.Map<Domain.banner>(banner);
            _bannerRepository.Insert(model);
        }
        public virtual void Updatebanner(bannerDto banner)
        {
            Domain.banner model = AutoMapper.Mapper.Map<Domain.banner>(banner);
            _bannerRepository.Update(model);
        }

        public virtual bannerDto GetbannerById(int id)
        {
            return _bannerRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<bannerDto>();
        }

        public virtual List<bannerDto> GetbannerList(int? hotelid)
        {
            var result = _bannerRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<bannerDto>();
        }

        public virtual IPagedList<bannerDto> GetbannerList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _bannerRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<bannerDto>(result.ProjectToQueryable<bannerDto>(), pageindex, pagesize);
        }

        public virtual void Deletebanner(int id)
        {
            _bannerRepository.Delete(id);
        }

        public virtual void AddBook_Rdetail(Book_RdetailDto Book_Rdetail)
        {
            Domain.Book_Rdetail model = AutoMapper.Mapper.Map<Domain.Book_Rdetail>(Book_Rdetail);
            _Book_RdetailRepository.Insert(model);
        }
        public virtual void UpdateBook_Rdetail(Book_RdetailDto Book_Rdetail)
        {
            Domain.Book_Rdetail model = AutoMapper.Mapper.Map<Domain.Book_Rdetail>(Book_Rdetail);
            _Book_RdetailRepository.Update(model);
        }

        public virtual Book_RdetailDto GetBook_RdetailById(int id)
        {
            return _Book_RdetailRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<Book_RdetailDto>();
        }

        public virtual List<Book_RdetailDto> GetBook_RdetailList(int? hotelid)
        {
            var result = _Book_RdetailRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<Book_RdetailDto>();
        }

        public virtual IPagedList<Book_RdetailDto> GetBook_RdetailList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _Book_RdetailRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<Book_RdetailDto>(result.ProjectToQueryable<Book_RdetailDto>(), pageindex, pagesize);
        }

        public virtual void DeleteBook_Rdetail(int id)
        {
            _Book_RdetailRepository.Delete(id);
        }

        public virtual void Addbook_room(book_roomDto book_room)
        {
            Domain.book_room model = AutoMapper.Mapper.Map<Domain.book_room>(book_room);
            _book_roomRepository.Insert(model);
        }
        public virtual void Updatebook_room(book_roomDto book_room)
        {
            Domain.book_room model = AutoMapper.Mapper.Map<Domain.book_room>(book_room);
            _book_roomRepository.Update(model);
        }

        public virtual book_roomDto Getbook_roomById(int id)
        {
            return _book_roomRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<book_roomDto>();
        }

        public virtual List<book_roomDto> Getbook_roomList(int? hotelid)
        {
            var result = _book_roomRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<book_roomDto>();
        }

        public virtual IPagedList<book_roomDto> Getbook_roomList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _book_roomRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<book_roomDto>(result.ProjectToQueryable<book_roomDto>(), pageindex, pagesize);
        }

        public virtual void Deletebook_room(int id)
        {
            _book_roomRepository.Delete(id);
        }

        public virtual void AddBookState(BookStateDto BookState)
        {
            Domain.BookState model = AutoMapper.Mapper.Map<Domain.BookState>(BookState);
            _BookStateRepository.Insert(model);
        }
        public virtual void UpdateBookState(BookStateDto BookState)
        {
            Domain.BookState model = AutoMapper.Mapper.Map<Domain.BookState>(BookState);
            _BookStateRepository.Update(model);
        }

        public virtual BookStateDto GetBookStateById(int id)
        {
            return _BookStateRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<BookStateDto>();
        }

        public virtual List<BookStateDto> GetBookStateList(int? hotelid)
        {
            var result = _BookStateRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<BookStateDto>();
        }

        public virtual IPagedList<BookStateDto> GetBookStateList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _BookStateRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<BookStateDto>(result.ProjectToQueryable<BookStateDto>(), pageindex, pagesize);
        }

        public virtual void DeleteBookState(int id)
        {
            _BookStateRepository.Delete(id);
        }

        public virtual void Addbreakfirstcoupon(breakfirstcouponDto breakfirstcoupon)
        {
            Domain.breakfirstcoupon model = AutoMapper.Mapper.Map<Domain.breakfirstcoupon>(breakfirstcoupon);
            _breakfirstcouponRepository.Insert(model);
        }
        public virtual void Updatebreakfirstcoupon(breakfirstcouponDto breakfirstcoupon)
        {
            Domain.breakfirstcoupon model = AutoMapper.Mapper.Map<Domain.breakfirstcoupon>(breakfirstcoupon);
            _breakfirstcouponRepository.Update(model);
        }

        public virtual breakfirstcouponDto GetbreakfirstcouponById(int id)
        {
            return _breakfirstcouponRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<breakfirstcouponDto>();
        }

        public virtual List<breakfirstcouponDto> GetbreakfirstcouponList(int? hotelid)
        {
            var result = _breakfirstcouponRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<breakfirstcouponDto>();
        }

        public virtual IPagedList<breakfirstcouponDto> GetbreakfirstcouponList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _breakfirstcouponRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<breakfirstcouponDto>(result.ProjectToQueryable<breakfirstcouponDto>(), pageindex, pagesize);
        }

        public virtual void Deletebreakfirstcoupon(int id)
        {
            _breakfirstcouponRepository.Delete(id);
        }

        public virtual void Addcard_type(card_typeDto card_type)
        {
            Domain.card_type model = AutoMapper.Mapper.Map<Domain.card_type>(card_type);
            _card_typeRepository.Insert(model);
        }
        public virtual void Updatecard_type(card_typeDto card_type)
        {
            Domain.card_type model = AutoMapper.Mapper.Map<Domain.card_type>(card_type);
            _card_typeRepository.Update(model);
        }

        public virtual card_typeDto Getcard_typeById(int id)
        {
            var model = _card_typeRepository.TableNoTracking.Where(s => s.Id == id).FirstOrDefault();
            return AutoMapper.Mapper.Map<card_typeDto>(model);
        }

        public virtual List<card_typeDto> Getcard_typeList(int? hotelid)
        {
            var result = _card_typeRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<card_typeDto>();
        }

        public virtual IPagedList<card_typeDto> Getcard_typeList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _card_typeRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            var list = result.OrderByDescending(s => s.Id).Skip(pagesize * (pageindex - 1)).Take(pagesize).ToList();
            var count = result.Count();
            var pagelist = new PagedList<card_typeDto>(AutoMapper.Mapper.Map<List<card_typeDto>>(list), pageindex, pagesize, count);

       
            return pagelist;
        }

        public virtual void Deletecard_type(int id)
        {
            _card_typeRepository.Delete(id);
        }

        public virtual void AddcCall(cCallDto cCall)
        {
            Domain.cCall model = AutoMapper.Mapper.Map<Domain.cCall>(cCall);
            _cCallRepository.Insert(model);
        }
        public virtual void UpdatecCall(cCallDto cCall)
        {
            Domain.cCall model = AutoMapper.Mapper.Map<Domain.cCall>(cCall);
            _cCallRepository.Update(model);
        }

        public virtual cCallDto GetcCallById(int id)
        {
            return _cCallRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<cCallDto>();
        }

        public virtual List<cCallDto> GetcCallList(int? hotelid)
        {
            var result = _cCallRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<cCallDto>();
        }

        public virtual IPagedList<cCallDto> GetcCallList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _cCallRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<cCallDto>(result.ProjectToQueryable<cCallDto>(), pageindex, pagesize);
        }

        public virtual void DeletecCall(int id)
        {
            _cCallRepository.Delete(id);
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

        public virtual cDepartmentDto GetcDepartmentById(int id)
        {
            return _cDepartmentRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<cDepartmentDto>();
        }

        public virtual List<cDepartmentDto> GetcDepartmentList(int? hotelid)
        {
            var result = _cDepartmentRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<cDepartmentDto>();
        }

        public virtual IPagedList<cDepartmentDto> GetcDepartmentList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _cDepartmentRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<cDepartmentDto>(result.ProjectToQueryable<cDepartmentDto>(), pageindex, pagesize);
        }

        public virtual void DeletecDepartment(int id)
        {
            _cDepartmentRepository.Delete(id);
        }

        public virtual void AddcIndustry(cIndustryDto cIndustry)
        {
            Domain.cIndustry model = AutoMapper.Mapper.Map<Domain.cIndustry>(cIndustry);
            _cIndustryRepository.Insert(model);
        }
        public virtual void UpdatecIndustry(cIndustryDto cIndustry)
        {
            Domain.cIndustry model = AutoMapper.Mapper.Map<Domain.cIndustry>(cIndustry);
            _cIndustryRepository.Update(model);
        }

        public virtual cIndustryDto GetcIndustryById(int id)
        {
            return _cIndustryRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<cIndustryDto>();
        }

        public virtual List<cIndustryDto> GetcIndustryList(int? hotelid)
        {
            var result = _cIndustryRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<cIndustryDto>();
        }

        public virtual IPagedList<cIndustryDto> GetcIndustryList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _cIndustryRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<cIndustryDto>(result.ProjectToQueryable<cIndustryDto>(), pageindex, pagesize);
        }

        public virtual void DeletecIndustry(int id)
        {
            _cIndustryRepository.Delete(id);
        }

        public virtual void Addcomm_unit(comm_unitDto comm_unit)
        {
            Domain.comm_unit model = AutoMapper.Mapper.Map<Domain.comm_unit>(comm_unit);
            _comm_unitRepository.Insert(model);
        }
        public virtual void Updatecomm_unit(comm_unitDto comm_unit)
        {
            Domain.comm_unit model = AutoMapper.Mapper.Map<Domain.comm_unit>(comm_unit);
            _comm_unitRepository.Update(model);
        }

        public virtual comm_unitDto Getcomm_unitById(int id)
        {
            var model = _comm_unitRepository.TableNoTracking.Where(s => s.Id == id).FirstOrDefault();
            return AutoMapper.Mapper.Map<comm_unitDto>(model);
        }

        public virtual List<comm_unitDto> Getcomm_unitList(int? hotelid)
        {
            var result = _comm_unitRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<comm_unitDto>();
        }

        public virtual IPagedList<comm_unitDto> Getcomm_unitList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _comm_unitRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);

            var list = result.OrderByDescending(s => s.Id).Skip(pagesize * (pageindex - 1)).Take(pagesize).ToList();
            var count = result.Count();
            var pagelist = new PagedList<comm_unitDto>(AutoMapper.Mapper.Map<List<comm_unitDto>>(list), pageindex, pagesize, count);

            foreach (var item in pagelist)
            {
                if (item.hotelid.HasValue)
                    item.UserHotel = AutoMapper.Mapper.Map<HotelDto>(_HotelRepository.TableNoTracking.Where(s => s.Id == item.hotelid.Value).FirstOrDefault());
            }


            return pagelist;
          
        }

        public virtual void Deletecomm_unit(int id)
        {
            _comm_unitRepository.Delete(id);
        }

        public virtual void AddCommission(CommissionDto Commission)
        {
            Domain.Commission model = AutoMapper.Mapper.Map<Domain.Commission>(Commission);
            _CommissionRepository.Insert(model);
        }
        public virtual void UpdateCommission(CommissionDto Commission)
        {
            Domain.Commission model = AutoMapper.Mapper.Map<Domain.Commission>(Commission);
            _CommissionRepository.Update(model);
        }

        public virtual CommissionDto GetCommissionById(int id)
        {
            return _CommissionRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<CommissionDto>();
        }

        public virtual List<CommissionDto> GetCommissionList(int? hotelid)
        {
            var result = _CommissionRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<CommissionDto>();
        }

        public virtual IPagedList<CommissionDto> GetCommissionList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _CommissionRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<CommissionDto>(result.ProjectToQueryable<CommissionDto>(), pageindex, pagesize);
        }

        public virtual void DeleteCommission(int id)
        {
            _CommissionRepository.Delete(id);
        }

        public virtual void AddContacts(ContactsDto Contacts)
        {
            Domain.Contacts model = AutoMapper.Mapper.Map<Domain.Contacts>(Contacts);
            _ContactsRepository.Insert(model);
        }
        public virtual void UpdateContacts(ContactsDto Contacts)
        {
            Domain.Contacts model = AutoMapper.Mapper.Map<Domain.Contacts>(Contacts);
            _ContactsRepository.Update(model);
        }

        public virtual ContactsDto GetContactsById(int id)
        {
            return _ContactsRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<ContactsDto>();
        }

        public virtual List<ContactsDto> GetContactsList(int? hotelid)
        {
            var result = _ContactsRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<ContactsDto>();
        }

        public virtual IPagedList<ContactsDto> GetContactsList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _ContactsRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<ContactsDto>(result.ProjectToQueryable<ContactsDto>(), pageindex, pagesize);
        }

        public virtual void DeleteContacts(int id)
        {
            _ContactsRepository.Delete(id);
        }

        public virtual void Addcost_type(cost_typeDto cost_type)
        {
            Domain.cost_type model = AutoMapper.Mapper.Map<Domain.cost_type>(cost_type);
            _cost_typeRepository.Insert(model);
        }
        public virtual void Updatecost_type(cost_typeDto cost_type)
        {
            Domain.cost_type model = AutoMapper.Mapper.Map<Domain.cost_type>(cost_type);
            _cost_typeRepository.Update(model);
        }

        public virtual cost_typeDto Getcost_typeById(int id)
        {
            var model = _cost_typeRepository.TableNoTracking.Where(s => s.Id == id).FirstOrDefault();
            return AutoMapper.Mapper.Map<cost_typeDto>(model);
        }

        public virtual List<cost_typeDto> Getcost_typeList(int? hotelid, string name, int? type)
        {
            var result = _cost_typeRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);

            if (!string.IsNullOrEmpty(name))
                result = result.Where(s => s.ct_name.Contains(name));

            if (type.HasValue)
                result = result.Where(s => s.ct_iftype == type);


            var list = result.OrderByDescending(s => s.Id).ToList();
            var pagelist = AutoMapper.Mapper.Map<List<cost_typeDto>>(list);

            foreach (var item in pagelist)
            {
                if (item.hotelid.HasValue)
                    item.UserHotel = AutoMapper.Mapper.Map<HotelDto>(_HotelRepository.TableNoTracking.Where(s => s.Id == item.hotelid.Value).FirstOrDefault());

                if (item.ct_iftype == 1)
                    item.cost_typecategory = AutoMapper.Mapper.Map<cost_typeDto>(_cost_typeRepository.TableNoTracking.Where(s => s.Id == item.ct_categories).FirstOrDefault());
            }

            return pagelist;
        }

        public virtual IPagedList<cost_typeDto> Getcost_typeList(int? hotelid, string name, int? type, int pageindex, int pagesize)
        {
            var result = _cost_typeRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);

            if (!string.IsNullOrEmpty(name))
                result = result.Where(s => s.ct_name.Contains(name));

            if (type.HasValue)
                result = result.Where(s => s.ct_iftype == type);

            var count = result.Count();
            var list = result.OrderByDescending(s => s.Id).Skip(pagesize * (pageindex - 1)).Take(pagesize).ToList();
            var pagelist = new PagedList<cost_typeDto>(AutoMapper.Mapper.Map<List<cost_typeDto>>(list), pageindex, pagesize, count);

            foreach (var item in pagelist)
            {
                if (item.hotelid.HasValue)
                    item.UserHotel = AutoMapper.Mapper.Map<HotelDto>(_HotelRepository.TableNoTracking.Where(s => s.Id == item.hotelid.Value).FirstOrDefault());

                if (item.ct_iftype == 1)
                    item.cost_typecategory = AutoMapper.Mapper.Map<cost_typeDto>(_cost_typeRepository.TableNoTracking.Where(s => s.Id == item.ct_categories).FirstOrDefault());
            }

            return pagelist;
        }

        public virtual void Deletecost_type(int id)
        {
            _cost_typeRepository.Delete(id);
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

        public virtual cPostDto GetcPostById(int id)
        {
            return _cPostRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<cPostDto>();
        }

        public virtual List<cPostDto> GetcPostList(int? hotelid)
        {
            var result = _cPostRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<cPostDto>();
        }

        public virtual IPagedList<cPostDto> GetcPostList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _cPostRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<cPostDto>(result.ProjectToQueryable<cPostDto>(), pageindex, pagesize);
        }

        public virtual void DeletecPost(int id)
        {
            _cPostRepository.Delete(id);
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

        public virtual List<cprotocolDto> GetcprotocolList(int? hotelid)
        {
            var result = _cprotocolRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<cprotocolDto>();
        }

        public virtual IPagedList<cprotocolDto> GetcprotocolList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _cprotocolRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<cprotocolDto>(result.ProjectToQueryable<cprotocolDto>(), pageindex, pagesize);
        }

        public virtual void Deletecprotocol(int id)
        {
            _cprotocolRepository.Delete(id);
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

        public virtual cprotocolPriceDto GetcprotocolPriceById(int id)
        {
            return _cprotocolPriceRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<cprotocolPriceDto>();
        }

        public virtual List<cprotocolPriceDto> GetcprotocolPriceList(int? hotelid)
        {
            var result = _cprotocolPriceRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<cprotocolPriceDto>();
        }

        public virtual IPagedList<cprotocolPriceDto> GetcprotocolPriceList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _cprotocolPriceRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<cprotocolPriceDto>(result.ProjectToQueryable<cprotocolPriceDto>(), pageindex, pagesize);
        }

        public virtual void DeletecprotocolPrice(int id)
        {
            _cprotocolPriceRepository.Delete(id);
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

        public virtual cpTypeDto GetcpTypeById(int id)
        {
            return _cpTypeRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<cpTypeDto>();
        }

        public virtual List<cpTypeDto> GetcpTypeList(int? hotelid)
        {
            var result = _cpTypeRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<cpTypeDto>();
        }

        public virtual IPagedList<cpTypeDto> GetcpTypeList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _cpTypeRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<cpTypeDto>(result.ProjectToQueryable<cpTypeDto>(), pageindex, pagesize);
        }

        public virtual void DeletecpType(int id)
        {
            _cpTypeRepository.Delete(id);
        }

        public virtual void Addcredit(creditDto credit)
        {
            Domain.credit model = AutoMapper.Mapper.Map<Domain.credit>(credit);
            _creditRepository.Insert(model);
        }
        public virtual void Updatecredit(creditDto credit)
        {
            Domain.credit model = AutoMapper.Mapper.Map<Domain.credit>(credit);
            _creditRepository.Update(model);
        }

        public virtual creditDto GetcreditById(int id)
        {
            return _creditRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<creditDto>();
        }

        public virtual List<creditDto> GetcreditList(int? hotelid)
        {
            var result = _creditRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<creditDto>();
        }

        public virtual IPagedList<creditDto> GetcreditList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _creditRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<creditDto>(result.ProjectToQueryable<creditDto>(), pageindex, pagesize);
        }

        public virtual void Deletecredit(int id)
        {
            _creditRepository.Delete(id);
        }

        public virtual void AddcsysType(csysTypeDto csysType)
        {
            Domain.csysType model = AutoMapper.Mapper.Map<Domain.csysType>(csysType);
            _csysTypeRepository.Insert(model);
        }
        public virtual void UpdatecsysType(csysTypeDto csysType)
        {
            Domain.csysType model = AutoMapper.Mapper.Map<Domain.csysType>(csysType);
            _csysTypeRepository.Update(model);
        }

        public virtual csysTypeDto GetcsysTypeById(int id)
        {
            return _csysTypeRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<csysTypeDto>();
        }

        public virtual List<csysTypeDto> GetcsysTypeList(int? hotelid)
        {
            var result = _csysTypeRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<csysTypeDto>();
        }

        public virtual IPagedList<csysTypeDto> GetcsysTypeList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _csysTypeRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<csysTypeDto>(result.ProjectToQueryable<csysTypeDto>(), pageindex, pagesize);
        }

        public virtual void DeletecsysType(int id)
        {
            _csysTypeRepository.Delete(id);
        }

        public virtual void Addcustomer(customerDto customer)
        {
            Domain.customer model = AutoMapper.Mapper.Map<Domain.customer>(customer);
            _customerRepository.Insert(model);
        }
        public virtual void Updatecustomer(customerDto customer)
        {
            Domain.customer model = AutoMapper.Mapper.Map<Domain.customer>(customer);
            _customerRepository.Update(model);
        }

        public virtual customerDto GetcustomerById(int id)
        {
            return _customerRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<customerDto>();
        }

        public virtual List<customerDto> GetcustomerList(int? hotelid)
        {
            var result = _customerRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<customerDto>();
        }

        public virtual IPagedList<customerDto> GetcustomerList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _customerRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<customerDto>(result.ProjectToQueryable<customerDto>(), pageindex, pagesize);
        }

        public virtual void Deletecustomer(int id)
        {
            _customerRepository.Delete(id);
        }

        public virtual void AddcustomerState(customerStateDto customerState)
        {
            Domain.customerState model = AutoMapper.Mapper.Map<Domain.customerState>(customerState);
            _customerStateRepository.Insert(model);
        }
        public virtual void UpdatecustomerState(customerStateDto customerState)
        {
            Domain.customerState model = AutoMapper.Mapper.Map<Domain.customerState>(customerState);
            _customerStateRepository.Update(model);
        }

        public virtual customerStateDto GetcustomerStateById(int id)
        {
            return _customerStateRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<customerStateDto>();
        }

        public virtual List<customerStateDto> GetcustomerStateList(int? hotelid)
        {
            var result = _customerStateRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<customerStateDto>();
        }

        public virtual IPagedList<customerStateDto> GetcustomerStateList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _customerStateRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<customerStateDto>(result.ProjectToQueryable<customerStateDto>(), pageindex, pagesize);
        }

        public virtual void DeletecustomerState(int id)
        {
            _customerStateRepository.Delete(id);
        }

        public virtual void AddcustomerType(customerTypeDto customerType)
        {
            Domain.customerType model = AutoMapper.Mapper.Map<Domain.customerType>(customerType);
            _customerTypeRepository.Insert(model);
        }
        public virtual void UpdatecustomerType(customerTypeDto customerType)
        {
            Domain.customerType model = AutoMapper.Mapper.Map<Domain.customerType>(customerType);
            _customerTypeRepository.Update(model);
        }

        public virtual customerTypeDto GetcustomerTypeById(int id)
        {
            return _customerTypeRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<customerTypeDto>();
        }

        public virtual List<customerTypeDto> GetcustomerTypeList(int? hotelid)
        {
            var result = _customerTypeRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<customerTypeDto>();
        }

        public virtual IPagedList<customerTypeDto> GetcustomerTypeList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _customerTypeRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<customerTypeDto>(result.ProjectToQueryable<customerTypeDto>(), pageindex, pagesize);
        }

        public virtual void DeletecustomerType(int id)
        {
            _customerTypeRepository.Delete(id);
        }

        public virtual void AddEntry(EntryDto Entry)
        {
            Domain.Entry model = AutoMapper.Mapper.Map<Domain.Entry>(Entry);
            _EntryRepository.Insert(model);
        }
        public virtual void UpdateEntry(EntryDto Entry)
        {
            Domain.Entry model = AutoMapper.Mapper.Map<Domain.Entry>(Entry);
            _EntryRepository.Update(model);
        }

        public virtual EntryDto GetEntryById(int id)
        {
            return _EntryRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<EntryDto>();
        }

        public virtual List<EntryDto> GetEntryList(int? hotelid)
        {
            var result = _EntryRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<EntryDto>();
        }

        public virtual IPagedList<EntryDto> GetEntryList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _EntryRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<EntryDto>(result.ProjectToQueryable<EntryDto>(), pageindex, pagesize);
        }

        public virtual void DeleteEntry(int id)
        {
            _EntryRepository.Delete(id);
        }

        public virtual void AddExceedScheme(ExceedSchemeDto ExceedScheme)
        {
            Domain.ExceedScheme model = AutoMapper.Mapper.Map<Domain.ExceedScheme>(ExceedScheme);
            _ExceedSchemeRepository.Insert(model);
        }
        public virtual void UpdateExceedScheme(ExceedSchemeDto ExceedScheme)
        {
            Domain.ExceedScheme model = AutoMapper.Mapper.Map<Domain.ExceedScheme>(ExceedScheme);
            _ExceedSchemeRepository.Update(model);
        }

        public virtual ExceedSchemeDto GetExceedSchemeById(int id)
        {
            return _ExceedSchemeRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<ExceedSchemeDto>();
        }

        public virtual List<ExceedSchemeDto> GetExceedSchemeList(int? hotelid)
        {
            var result = _ExceedSchemeRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<ExceedSchemeDto>();
        }

        public virtual IPagedList<ExceedSchemeDto> GetExceedSchemeList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _ExceedSchemeRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<ExceedSchemeDto>(result.ProjectToQueryable<ExceedSchemeDto>(), pageindex, pagesize);
        }

        public virtual void DeleteExceedScheme(int id)
        {
            _ExceedSchemeRepository.Delete(id);
        }

        public virtual void Addfloor_ld(floor_ldDto floor_ld)
        {
            Domain.floor_ld model = AutoMapper.Mapper.Map<Domain.floor_ld>(floor_ld);
            _floor_ldRepository.Insert(model);
        }
        public virtual void Updatefloor_ld(floor_ldDto floor_ld)
        {
            Domain.floor_ld model = AutoMapper.Mapper.Map<Domain.floor_ld>(floor_ld);
            _floor_ldRepository.Update(model);
        }

        public virtual floor_ldDto Getfloor_ldById(int id)
        {
            var model = _floor_ldRepository.TableNoTracking.Where(s => s.Id == id).FirstOrDefault();
            return AutoMapper.Mapper.Map<floor_ldDto>(model);

        }

        public virtual floor_ldDto Getfloor_ldByName(string name,int? hotelid)
        {
            var query = _floor_ldRepository.TableNoTracking;
            if (!string.IsNullOrEmpty(name))
                query = query.Where(s => s.ld_Name == name);

            if (hotelid.HasValue && hotelid.Value != 0)
                query = query.Where(s => s.hotelid == hotelid);

            var model = query.FirstOrDefault();

            return AutoMapper.Mapper.Map<floor_ldDto>(model);
        }

        public virtual List<floor_ldDto> Getfloor_ldList(int? hotelid)
        {
            var result = _floor_ldRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<floor_ldDto>();
        }

        public virtual IPagedList<floor_ldDto> Getfloor_ldList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _floor_ldRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            //var list = result.ToList();
            var list =  result.OrderByDescending(s => s.Id).Skip(pagesize * (pageindex - 1)).Take(pagesize).ToList();
            var count = result.Count();
            var pagelist = new PagedList<floor_ldDto>(AutoMapper.Mapper.Map<List<floor_ldDto>>(list), pageindex, pagesize, count);
            return pagelist;
        }

        public virtual void Deletefloor_ld(int id)
        {
            _floor_ldRepository.Delete(id);
        }

        public virtual void Addfloor_manage(floor_manageDto floor_manage)
        {
            Domain.floor_manage model = AutoMapper.Mapper.Map<Domain.floor_manage>(floor_manage);
            _floor_manageRepository.Insert(model);
        }
        public virtual void Updatefloor_manage(floor_manageDto floor_manage)
        {
            Domain.floor_manage model = AutoMapper.Mapper.Map<Domain.floor_manage>(floor_manage);
            _floor_manageRepository.Update(model);
        }

        public virtual floor_manageDto Getfloor_manageById(int id)
        {
            var model = _floor_manageRepository.TableNoTracking.Where(s => s.Id == id).FirstOrDefault();
            return AutoMapper.Mapper.Map<floor_manageDto>(model);
        }

        public virtual floor_manageDto Getfloor_manageByName(string name,string floornumber,int? hotelid)
        {
            var query = _floor_manageRepository.TableNoTracking.Where(s => s.floor_name == floornumber && s.floor_name == name);
            if (hotelid.HasValue)
                query = query.Where(s => s.hotelid == hotelid);
            var model = query.FirstOrDefault();
            return AutoMapper.Mapper.Map<floor_manageDto>(model);
        }

        public virtual List<floor_manageDto> Getfloor_manageList(int? hotelid)
        {
            var result = _floor_manageRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<floor_manageDto>();
        }

        public virtual IPagedList<floor_manageDto> Getfloor_manageList(int? hotelid, string floornumber, int pageindex, int pagesize)
        {
            var result = _floor_manageRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);

            if (!string.IsNullOrEmpty(floornumber))
                result = result.Where(s => s.floor_number == floornumber);

            var list = result.OrderByDescending(s => s.Id).Skip(pagesize * (pageindex - 1)).Take(pagesize).ToList();
            var count = result.Count();
            var pagelist = new PagedList<floor_manageDto>(AutoMapper.Mapper.Map<List<floor_manageDto>>(list), pageindex, pagesize, count);

            return pagelist;
        }

        public virtual void Deletefloor_manage(int id)
        {
            _floor_manageRepository.Delete(id);
        }

        public virtual void AddFtSet(FtSetDto FtSet)
        {
            Domain.FtSet model = AutoMapper.Mapper.Map<Domain.FtSet>(FtSet);
            _FtSetRepository.Insert(model);
        }
        public virtual void UpdateFtSet(FtSetDto FtSet)
        {
            Domain.FtSet model = AutoMapper.Mapper.Map<Domain.FtSet>(FtSet);
            _FtSetRepository.Update(model);
        }

        public virtual FtSetDto GetFtSetById(int id)
        {
            return _FtSetRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<FtSetDto>();
        }

        public virtual List<FtSetDto> GetFtSetList(int? hotelid)
        {
            var result = _FtSetRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<FtSetDto>();
        }

        public virtual IPagedList<FtSetDto> GetFtSetList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _FtSetRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<FtSetDto>(result.ProjectToQueryable<FtSetDto>(), pageindex, pagesize);
        }

        public virtual void DeleteFtSet(int id)
        {
            _FtSetRepository.Delete(id);
        }

        public virtual void AddGoods(GoodsDto Goods)
        {
            Domain.Goods model = AutoMapper.Mapper.Map<Domain.Goods>(Goods);
            _GoodsRepository.Insert(model);
        }
        public virtual void UpdateGoods(GoodsDto Goods)
        {
            Domain.Goods model = AutoMapper.Mapper.Map<Domain.Goods>(Goods);
            _GoodsRepository.Update(model);
        }

        public virtual GoodsDto GetGoodsById(int id)
        {
            var model = _GoodsRepository.TableNoTracking.Where(s => s.Id == id).FirstOrDefault();
            return AutoMapper.Mapper.Map<GoodsDto>(model);
        }

        public virtual List<GoodsDto> GetGoodsList(int? hotelid, string name, int? goodstype)
        {
            var result = _GoodsRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            if (!string.IsNullOrEmpty(name))
                result = result.Where(s => s.Goods_name.Contains(name));

            if (goodstype.HasValue)
                result = result.Where(s => s.Goods_ifType == goodstype);

            var templist = result.ToList();
            var list = AutoMapper.Mapper.Map<List<GoodsDto>>(templist);

            foreach (var item in list)
            {
                if (item.hotelid.HasValue)
                    item.UserHotel = AutoMapper.Mapper.Map<HotelDto>(_HotelRepository.TableNoTracking.Where(s => s.Id == item.hotelid.Value).FirstOrDefault());

                if(item.Goods_ifType == 1)
                    item.GoosCategory = AutoMapper.Mapper.Map<GoodsDto>(_GoodsRepository.TableNoTracking.Where(s => s.Id == item.Goods_categories).FirstOrDefault());
            }

            return list;
        }

        public virtual IPagedList<GoodsDto> GetGoodsList(int? hotelid, string name,int? goodstype, int pageindex, int pagesize)
        {
            var result = _GoodsRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);

            if (!string.IsNullOrEmpty(name))
                result = result.Where(s => s.Goods_name.Contains(name));

            if (goodstype.HasValue)
                result = result.Where(s => s.Goods_ifType == goodstype);

            var count = result.Count();
            var list = result.OrderByDescending(s => s.Id).Skip(pagesize * (pageindex - 1)).Take(pagesize).ToList();
            var pagelist = new PagedList<GoodsDto>(AutoMapper.Mapper.Map<List<GoodsDto>>(list), pageindex, pagesize, count);

            foreach (var item in pagelist)
            {
                if (item.hotelid.HasValue)
                    item.UserHotel = AutoMapper.Mapper.Map<HotelDto>(_HotelRepository.TableNoTracking.Where(s => s.Id == item.hotelid.Value).FirstOrDefault());

                if (item.Goods_ifType == 1)
                    item.GoosCategory = AutoMapper.Mapper.Map<GoodsDto>(_GoodsRepository.TableNoTracking.Where(s => s.Id == item.Goods_categories).FirstOrDefault());
            }

            return pagelist;
        }

        public virtual void DeleteGoods(int id)
        {
            _GoodsRepository.Delete(id);
        }

        public virtual void Addgoods_account(goods_accountDto goods_account)
        {
            Domain.goods_account model = AutoMapper.Mapper.Map<Domain.goods_account>(goods_account);
            _goods_accountRepository.Insert(model);
        }
        public virtual void Updategoods_account(goods_accountDto goods_account)
        {
            Domain.goods_account model = AutoMapper.Mapper.Map<Domain.goods_account>(goods_account);
            _goods_accountRepository.Update(model);
        }

        public virtual goods_accountDto Getgoods_accountById(int id)
        {
            return _goods_accountRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<goods_accountDto>();
        }

        public virtual List<goods_accountDto> Getgoods_accountList(int? hotelid)
        {
            var result = _goods_accountRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<goods_accountDto>();
        }

        public virtual IPagedList<goods_accountDto> Getgoods_accountList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _goods_accountRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<goods_accountDto>(result.ProjectToQueryable<goods_accountDto>(), pageindex, pagesize);
        }

        public virtual void Deletegoods_account(int id)
        {
            _goods_accountRepository.Delete(id);
        }

        public virtual void Addguest_source(guest_sourceDto guest_source)
        {
            Domain.guest_source model = AutoMapper.Mapper.Map<Domain.guest_source>(guest_source);
            _guest_sourceRepository.Insert(model);
        }
        public virtual void Updateguest_source(guest_sourceDto guest_source)
        {
            Domain.guest_source model = AutoMapper.Mapper.Map<Domain.guest_source>(guest_source);
            _guest_sourceRepository.Update(model);
        }

        public virtual guest_sourceDto Getguest_sourceById(int id)
        {
            var model = _guest_sourceRepository.TableNoTracking.Where(s => s.Id == id).FirstOrDefault();
            return AutoMapper.Mapper.Map<guest_sourceDto>(model);
        }

        public virtual List<guest_sourceDto> Getguest_sourceList(int? hotelid)
        {
            var result = _guest_sourceRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<guest_sourceDto>();
        }

        public virtual IPagedList<guest_sourceDto> Getguest_sourceList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _guest_sourceRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);

            var list = result.OrderByDescending(s => s.Id).Skip(pagesize * (pageindex - 1)).Take(pagesize).ToList();
            var count = result.Count();
            var pagelist = new PagedList<guest_sourceDto>(AutoMapper.Mapper.Map<List<guest_sourceDto>>(list), pageindex, pagesize, count);

            foreach (var item in pagelist)
            {
                if (item.hotelid.HasValue)
                    item.UserHotel = AutoMapper.Mapper.Map<HotelDto>(_HotelRepository.TableNoTracking.Where(s => s.Id == item.hotelid.Value).FirstOrDefault());
            }


            return pagelist;
        }

        public virtual void Deleteguest_source(int id)
        {
            _guest_sourceRepository.Delete(id);
        }

        public virtual void AddHotel(HotelDto Hotel)
        {
            Domain.Hotel model = AutoMapper.Mapper.Map<Domain.Hotel>(Hotel);
            _HotelRepository.Insert(model);
        }
        public virtual void UpdateHotel(HotelDto Hotel)
        {
            Domain.Hotel model = AutoMapper.Mapper.Map<Domain.Hotel>(Hotel);
            _HotelRepository.Update(model);
        }

        public virtual HotelDto GetHotelById(int id)
        {
            var model = _HotelRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<HotelDto>();
            if(model.ParentId.HasValue && model.ParentId.Value!=0)
                model.ParentHotel = _HotelRepository.TableNoTracking.Where(s => s.Id == model.ParentId).ProjectToFirstOrDefault<HotelDto>();

            return model;
        }

        public virtual List<HotelDto> GetHotelList(string name ,int? parentid, int? istop,int? isdeleted, int? ischain)
        {
            var result = _HotelRepository.TableNoTracking;

            if (!string.IsNullOrEmpty(name))
                result = result.Where(s => s.HotelName.StartsWith(name));

            if (parentid.HasValue)
                result = result.Where(s => s.ParentId == parentid);

            if (istop.HasValue)
                result = result.Where(s => s.IsTop == istop);

            if (isdeleted.HasValue)
                result = result.Where(s => s.IsDeleted == isdeleted);

            if (ischain.HasValue)
                result = result.Where(s => s.IsChain == ischain);

            var list = result.ProjectToList<HotelDto>();

            foreach(var item in list)
            {
                if(item.ParentId!=0)
                {
                    item.ParentHotel = _HotelRepository.TableNoTracking.Where(s => s.Id == item.ParentId).ProjectToFirstOrDefault<HotelDto>();
                }
            }

            return list;
        }

        public virtual IPagedList<HotelDto> GetHotelList(string name, int? parentid, int? istop, int? isdeleted, int? ischain, int pageindex, int pagesize)
        {
            var result = _HotelRepository.TableNoTracking;

            if (!string.IsNullOrEmpty(name))
                result = result.Where(s => s.HotelName.StartsWith(name));

            if (parentid.HasValue)
                result = result.Where(s => s.ParentId == parentid);

            if (istop.HasValue)
                result = result.Where(s => s.IsTop == istop);

            if (isdeleted.HasValue)
                result = result.Where(s => s.IsDeleted == isdeleted);

            if (ischain.HasValue)
                result = result.Where(s => s.IsChain == ischain);

            var list =  new PagedList<HotelDto>(result.ProjectToQueryable<HotelDto>(), pageindex, pagesize);

            foreach (var item in list)
            {
                if (item.ParentId != 0)
                {
                    item.ParentHotel = _HotelRepository.TableNoTracking.Where(s => s.Id == item.ParentId).ProjectToFirstOrDefault<HotelDto>();
                }
            }

            return list;
        }

        public virtual void DeleteHotel(int id)
        {
            _HotelRepository.Delete(id);
        }

        public virtual void Addhour_room(hour_roomDto hour_room)
        {
            Domain.hour_room model = AutoMapper.Mapper.Map<Domain.hour_room>(hour_room);
            _hour_roomRepository.Insert(model);
        }
        public virtual void Updatehour_room(hour_roomDto hour_room)
        {
            Domain.hour_room model = AutoMapper.Mapper.Map<Domain.hour_room>(hour_room);
            _hour_roomRepository.Update(model);
        }

        public virtual hour_roomDto Gethour_roomById(int id)
        {
            return _hour_roomRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<hour_roomDto>();
        }

        public virtual List<hour_roomDto> Gethour_roomList(int? hotelid)
        {
            var result = _hour_roomRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<hour_roomDto>();
        }

        public virtual IPagedList<hour_roomDto> Gethour_roomList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _hour_roomRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<hour_roomDto>(result.ProjectToQueryable<hour_roomDto>(), pageindex, pagesize);
        }

        public virtual void Deletehour_room(int id)
        {
            _hour_roomRepository.Delete(id);
        }

        public virtual void Addhourse_scheme(hourse_schemeDto hourse_scheme)
        {
            Domain.hourse_scheme model = AutoMapper.Mapper.Map<Domain.hourse_scheme>(hourse_scheme);
            _hourse_schemeRepository.Insert(model);
        }
        public virtual void Updatehourse_scheme(hourse_schemeDto hourse_scheme)
        {
            Domain.hourse_scheme model = AutoMapper.Mapper.Map<Domain.hourse_scheme>(hourse_scheme);
            _hourse_schemeRepository.Update(model);
        }

        public virtual hourse_schemeDto Gethourse_schemeById(int id)
        {
            var model = _hourse_schemeRepository.TableNoTracking.Where(s => s.Id == id).FirstOrDefault();
            return AutoMapper.Mapper.Map<hourse_schemeDto>(model);
        }

        public virtual List<hourse_schemeDto> Gethourse_schemeList(int? hotelid)
        {
            var result = _hourse_schemeRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<hourse_schemeDto>();
        }

        public virtual IPagedList<hourse_schemeDto> Gethourse_schemeList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _hourse_schemeRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);

            var list = result.OrderByDescending(s => s.Id).Skip(pagesize * (pageindex - 1)).Take(pagesize).ToList();
            var count = result.Count();
            var pagelist = new PagedList<hourse_schemeDto>(AutoMapper.Mapper.Map<List<hourse_schemeDto>>(list), pageindex, pagesize, count);

            foreach (var item in pagelist)
            {
                if (item.hotelid.HasValue)
                    item.UserHotel = AutoMapper.Mapper.Map<HotelDto>(_HotelRepository.TableNoTracking.Where(s => s.Id == item.hotelid.Value).FirstOrDefault());
            }


            return pagelist;
        }

        public virtual void Deletehourse_scheme(int id)
        {
            _hourse_schemeRepository.Delete(id);
        }

        public virtual void Addinfo(infoDto info)
        {
            Domain.info model = AutoMapper.Mapper.Map<Domain.info>(info);
            _infoRepository.Insert(model);
        }
        public virtual void Updateinfo(infoDto info)
        {
            Domain.info model = AutoMapper.Mapper.Map<Domain.info>(info);
            _infoRepository.Update(model);
        }

        public virtual infoDto GetinfoById(int id)
        {
            return _infoRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<infoDto>();
        }

        public virtual List<infoDto> GetinfoList(int? hotelid)
        {
            var result = _infoRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<infoDto>();
        }

        public virtual IPagedList<infoDto> GetinfoList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _infoRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<infoDto>(result.ProjectToQueryable<infoDto>(), pageindex, pagesize);
        }

        public virtual void Deleteinfo(int id)
        {
            _infoRepository.Delete(id);
        }

        public virtual void Addlog(logDto log)
        {
            Domain.log model = AutoMapper.Mapper.Map<Domain.log>(log);
            _logRepository.Insert(model);
        }
        public virtual void Updatelog(logDto log)
        {
            Domain.log model = AutoMapper.Mapper.Map<Domain.log>(log);
            _logRepository.Update(model);
        }

        public virtual logDto GetlogById(int id)
        {
            return _logRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<logDto>();
        }

        public virtual List<logDto> GetlogList(int? hotelid)
        {
            var result = _logRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<logDto>();
        }

        public virtual IPagedList<logDto> GetlogList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _logRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<logDto>(result.ProjectToQueryable<logDto>(), pageindex, pagesize);
        }

        public virtual void Deletelog(int id)
        {
            _logRepository.Delete(id);
        }

        public virtual void Addmember(memberDto member)
        {
            Domain.member model = AutoMapper.Mapper.Map<Domain.member>(member);
            _memberRepository.Insert(model);
        }
        public virtual void Updatemember(memberDto member)
        {
            Domain.member model = AutoMapper.Mapper.Map<Domain.member>(member);
            _memberRepository.Update(model);
        }

        public virtual memberDto GetmemberById(int id)
        {
            return _memberRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<memberDto>();
        }

        public virtual List<memberDto> GetmemberList(int? hotelid)
        {
            var result = _memberRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<memberDto>();
        }

        public virtual IPagedList<memberDto> GetmemberList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _memberRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<memberDto>(result.ProjectToQueryable<memberDto>(), pageindex, pagesize);
        }

        public virtual void Deletemember(int id)
        {
            _memberRepository.Delete(id);
        }

        public virtual void AddmemberState(memberStateDto memberState)
        {
            Domain.memberState model = AutoMapper.Mapper.Map<Domain.memberState>(memberState);
            _memberStateRepository.Insert(model);
        }
        public virtual void UpdatememberState(memberStateDto memberState)
        {
            Domain.memberState model = AutoMapper.Mapper.Map<Domain.memberState>(memberState);
            _memberStateRepository.Update(model);
        }

        public virtual memberStateDto GetmemberStateById(int id)
        {
            return _memberStateRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<memberStateDto>();
        }

        public virtual List<memberStateDto> GetmemberStateList(int? hotelid)
        {
            var result = _memberStateRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<memberStateDto>();
        }

        public virtual IPagedList<memberStateDto> GetmemberStateList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _memberStateRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<memberStateDto>(result.ProjectToQueryable<memberStateDto>(), pageindex, pagesize);
        }

        public virtual void DeletememberState(int id)
        {
            _memberStateRepository.Delete(id);
        }

        public virtual void AddmemberType(memberTypeDto memberType)
        {
            Domain.memberType model = AutoMapper.Mapper.Map<Domain.memberType>(memberType);
            _memberTypeRepository.Insert(model);
        }
        public virtual void UpdatememberType(memberTypeDto memberType)
        {
            Domain.memberType model = AutoMapper.Mapper.Map<Domain.memberType>(memberType);
            _memberTypeRepository.Update(model);
        }

        public virtual memberTypeDto GetmemberTypeById(int id)
        {
            return _memberTypeRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<memberTypeDto>();
        }

        public virtual List<memberTypeDto> GetmemberTypeList(int? hotelid)
        {
            var result = _memberTypeRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<memberTypeDto>();
        }

        public virtual IPagedList<memberTypeDto> GetmemberTypeList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _memberTypeRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<memberTypeDto>(result.ProjectToQueryable<memberTypeDto>(), pageindex, pagesize);
        }

        public virtual void DeletememberType(int id)
        {
            _memberTypeRepository.Delete(id);
        }

        public virtual void AddMenu(MenuDto Menu)
        {
            Domain.Menu model = AutoMapper.Mapper.Map<Domain.Menu>(Menu);
            _MenuRepository.Insert(model);
        }
        public virtual void UpdateMenu(MenuDto Menu)
        {
            Domain.Menu model = AutoMapper.Mapper.Map<Domain.Menu>(Menu);
            _MenuRepository.Update(model);
        }

        public virtual MenuDto GetMenuById(int id)
        {
            var model = _MenuRepository.TableNoTracking.Where(s => s.Id == id).FirstOrDefault();
            return AutoMapper.Mapper.Map<MenuDto>(model);
        }

        public virtual List<MenuDto> GetMenuList(int? hotelid)
        {
            var result = _MenuRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<MenuDto>();
        }

        public virtual IPagedList<MenuDto> GetMenuList(int? parentid, int? hotelid, int pageindex, int pagesize)
        {
            var result = _MenuRepository.TableNoTracking.Where(s=>s.hotelid == hotelid);

            if (parentid.HasValue)
                result = result.Where(s => s.parent_id == parentid);
     
            var list = result.OrderByDescending(s => s.Id).Skip(pagesize * (pageindex - 1)).Take(pagesize).ToList();
            var count = result.Count();
            var pagelist = new PagedList<MenuDto>(AutoMapper.Mapper.Map<List<MenuDto>>(list), pageindex, pagesize, count);

            foreach (var item in pagelist)
            {
                if (item.hotelid.HasValue)
                    item.UserHotel = AutoMapper.Mapper.Map<HotelDto>(_HotelRepository.TableNoTracking.Where(s => s.Id == item.hotelid.Value).FirstOrDefault());

                if(item.parent_id.HasValue && item.parent_id!=0)
                    item.ParentMenu = AutoMapper.Mapper.Map<MenuDto>(_MenuRepository.TableNoTracking.Where(s => s.Id == item.parent_id.Value).FirstOrDefault());

                if(item.parent_id.HasValue && item.parent_id == 0)
                {
                    item.ChildMenus = AutoMapper.Mapper.Map<List<MenuDto>>(_MenuRepository.TableNoTracking.Where(s => s.parent_id == item.Id).ToList());
                }
            }

            return pagelist;
        }

        public virtual void DeleteMenu(int id)
        {
            _MenuRepository.Delete(id);
        }

        public virtual void Addmeth_pay(meth_payDto meth_pay)
        {
            Domain.meth_pay model = AutoMapper.Mapper.Map<Domain.meth_pay>(meth_pay);
            _meth_payRepository.Insert(model);
        }
        public virtual void Updatemeth_pay(meth_payDto meth_pay)
        {
            Domain.meth_pay model = AutoMapper.Mapper.Map<Domain.meth_pay>(meth_pay);
            _meth_payRepository.Update(model);
        }

        public virtual meth_payDto Getmeth_payById(int id)
        {
            var model = _meth_payRepository.TableNoTracking.Where(s => s.Id == id).FirstOrDefault();
            return AutoMapper.Mapper.Map<meth_payDto>(model);
        }

        public virtual List<meth_payDto> Getmeth_payList()
        {
            var result = _meth_payRepository.TableNoTracking;

            return result.ProjectToList<meth_payDto>();
        }

        public virtual IPagedList<meth_payDto> Getmeth_payList( int pageindex, int pagesize)
        {
            var result = _meth_payRepository.TableNoTracking;

            var list = result.OrderByDescending(s => s.Id).Skip(pagesize * (pageindex - 1)).Take(pagesize).ToList();
            var count = result.Count();
            var pagelist = new PagedList<meth_payDto>(AutoMapper.Mapper.Map<List<meth_payDto>>(list), pageindex, pagesize, count);

            return pagelist;
        }

        public virtual void Deletemeth_pay(int id)
        {
            _meth_payRepository.Delete(id);
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
            var model = _modesRepository.TableNoTracking.Where(s => s.Id == id).FirstOrDefault();

            return AutoMapper.Mapper.Map<modesDto>(model);
        }

        public virtual modesDto GetmodesByName(string name,int? hotelid)
        {
            var query = _modesRepository.TableNoTracking;
            if (!string.IsNullOrEmpty(name))
                query = query.Where(s => s.moshi_name == name);

            if (hotelid.HasValue && hotelid.Value != 0)
                query = query.Where(s => s.hotelid == hotelid);

            var model = query.FirstOrDefault();

            return AutoMapper.Mapper.Map<modesDto>(model);
        }


        public virtual List<modesDto> GetmodesList(int? hotelid)
        {
            var result = _modesRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<modesDto>();
        }

        public virtual IPagedList<modesDto> GetmodesList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _modesRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);

            var list = result.OrderByDescending(s => s.Id).Skip(pagesize * (pageindex - 1)).Take(pagesize).ToList();
            var count = result.Count();
            var pagelist = new PagedList<modesDto>(AutoMapper.Mapper.Map<List<modesDto>>(list), pageindex, pagesize, count);

            return pagelist;
        }

        public virtual void Deletemodes(int id)
        {
            _modesRepository.Delete(id);
        }

        public virtual void AddmRecords(mRecordsDto mRecords)
        {
            Domain.mRecords model = AutoMapper.Mapper.Map<Domain.mRecords>(mRecords);
            _mRecordsRepository.Insert(model);
        }
        public virtual void UpdatemRecords(mRecordsDto mRecords)
        {
            Domain.mRecords model = AutoMapper.Mapper.Map<Domain.mRecords>(mRecords);
            _mRecordsRepository.Update(model);
        }

        public virtual mRecordsDto GetmRecordsById(int id)
        {
            return _mRecordsRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<mRecordsDto>();
        }

        public virtual List<mRecordsDto> GetmRecordsList(int? hotelid)
        {
            var result = _mRecordsRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<mRecordsDto>();
        }

        public virtual IPagedList<mRecordsDto> GetmRecordsList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _mRecordsRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<mRecordsDto>(result.ProjectToQueryable<mRecordsDto>(), pageindex, pagesize);
        }

        public virtual void DeletemRecords(int id)
        {
            _mRecordsRepository.Delete(id);
        }

        public virtual void AddmtPrice(mtPriceDto mtPrice)
        {
            Domain.mtPrice model = AutoMapper.Mapper.Map<Domain.mtPrice>(mtPrice);
            _mtPriceRepository.Insert(model);
        }
        public virtual void UpdatemtPrice(mtPriceDto mtPrice)
        {
            Domain.mtPrice model = AutoMapper.Mapper.Map<Domain.mtPrice>(mtPrice);
            _mtPriceRepository.Update(model);
        }

        public virtual mtPriceDto GetmtPriceById(int id)
        {
            return _mtPriceRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<mtPriceDto>();
        }

        public virtual List<mtPriceDto> GetmtPriceList(int? hotelid)
        {
            var result = _mtPriceRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<mtPriceDto>();
        }

        public virtual IPagedList<mtPriceDto> GetmtPriceList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _mtPriceRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<mtPriceDto>(result.ProjectToQueryable<mtPriceDto>(), pageindex, pagesize);
        }

        public virtual void DeletemtPrice(int id)
        {
            _mtPriceRepository.Delete(id);
        }

        public virtual void Addoccu_infor(occu_inforDto occu_infor)
        {
            Domain.occu_infor model = AutoMapper.Mapper.Map<Domain.occu_infor>(occu_infor);
            _occu_inforRepository.Insert(model);
        }
        public virtual void Updateoccu_infor(occu_inforDto occu_infor)
        {
            Domain.occu_infor model = AutoMapper.Mapper.Map<Domain.occu_infor>(occu_infor);
            _occu_inforRepository.Update(model);
        }

        public virtual occu_inforDto Getoccu_inforById(int id)
        {
            return _occu_inforRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<occu_inforDto>();
        }

        public virtual List<occu_inforDto> Getoccu_inforList(int? hotelid)
        {
            var result = _occu_inforRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<occu_inforDto>();
        }

        public virtual IPagedList<occu_inforDto> Getoccu_inforList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _occu_inforRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<occu_inforDto>(result.ProjectToQueryable<occu_inforDto>(), pageindex, pagesize);
        }

        public virtual void Deleteoccu_infor(int id)
        {
            _occu_inforRepository.Delete(id);
        }

        public virtual void Addoccu_informx(occu_informxDto occu_informx)
        {
            Domain.occu_informx model = AutoMapper.Mapper.Map<Domain.occu_informx>(occu_informx);
            _occu_informxRepository.Insert(model);
        }
        public virtual void Updateoccu_informx(occu_informxDto occu_informx)
        {
            Domain.occu_informx model = AutoMapper.Mapper.Map<Domain.occu_informx>(occu_informx);
            _occu_informxRepository.Update(model);
        }

        public virtual occu_informxDto Getoccu_informxById(int id)
        {
            return _occu_informxRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<occu_informxDto>();
        }

        public virtual List<occu_informxDto> Getoccu_informxList(int? hotelid)
        {
            var result = _occu_informxRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<occu_informxDto>();
        }

        public virtual IPagedList<occu_informxDto> Getoccu_informxList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _occu_informxRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<occu_informxDto>(result.ProjectToQueryable<occu_informxDto>(), pageindex, pagesize);
        }

        public virtual void Deleteoccu_informx(int id)
        {
            _occu_informxRepository.Delete(id);
        }

        public virtual void Addorder_ext(order_extDto order_ext)
        {
            Domain.order_ext model = AutoMapper.Mapper.Map<Domain.order_ext>(order_ext);
            _order_extRepository.Insert(model);
        }
        public virtual void Updateorder_ext(order_extDto order_ext)
        {
            Domain.order_ext model = AutoMapper.Mapper.Map<Domain.order_ext>(order_ext);
            _order_extRepository.Update(model);
        }

        public virtual order_extDto Getorder_extById(int id)
        {
            return _order_extRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<order_extDto>();
        }

        public virtual List<order_extDto> Getorder_extList(int? hotelid)
        {
            var result = _order_extRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<order_extDto>();
        }

        public virtual IPagedList<order_extDto> Getorder_extList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _order_extRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<order_extDto>(result.ProjectToQueryable<order_extDto>(), pageindex, pagesize);
        }

        public virtual void Deleteorder_ext(int id)
        {
            _order_extRepository.Delete(id);
        }

        public virtual void Addorder_infor(order_inforDto order_infor)
        {
            Domain.order_infor model = AutoMapper.Mapper.Map<Domain.order_infor>(order_infor);
            _order_inforRepository.Insert(model);
        }
        public virtual void Updateorder_infor(order_inforDto order_infor)
        {
            Domain.order_infor model = AutoMapper.Mapper.Map<Domain.order_infor>(order_infor);
            _order_inforRepository.Update(model);
        }

        public virtual order_inforDto Getorder_inforById(int id)
        {
            return _order_inforRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<order_inforDto>();
        }

        public virtual List<order_inforDto> Getorder_inforList(int? hotelid)
        {
            var result = _order_inforRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<order_inforDto>();
        }

        public virtual IPagedList<order_inforDto> Getorder_inforList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _order_inforRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<order_inforDto>(result.ProjectToQueryable<order_inforDto>(), pageindex, pagesize);
        }

        public virtual void Deleteorder_infor(int id)
        {
            _order_inforRepository.Delete(id);
        }

        public virtual void AddpaymentMoney(paymentMoneyDto paymentMoney)
        {
            Domain.paymentMoney model = AutoMapper.Mapper.Map<Domain.paymentMoney>(paymentMoney);
            _paymentMoneyRepository.Insert(model);
        }
        public virtual void UpdatepaymentMoney(paymentMoneyDto paymentMoney)
        {
            Domain.paymentMoney model = AutoMapper.Mapper.Map<Domain.paymentMoney>(paymentMoney);
            _paymentMoneyRepository.Update(model);
        }

        public virtual paymentMoneyDto GetpaymentMoneyById(int id)
        {
            return _paymentMoneyRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<paymentMoneyDto>();
        }

        public virtual List<paymentMoneyDto> GetpaymentMoneyList(int? hotelid)
        {
            var result = _paymentMoneyRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<paymentMoneyDto>();
        }

        public virtual IPagedList<paymentMoneyDto> GetpaymentMoneyList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _paymentMoneyRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<paymentMoneyDto>(result.ProjectToQueryable<paymentMoneyDto>(), pageindex, pagesize);
        }

        public virtual void DeletepaymentMoney(int id)
        {
            _paymentMoneyRepository.Delete(id);
        }

        public virtual void Addprice_type(price_typeDto price_type)
        {
            Domain.price_type model = AutoMapper.Mapper.Map<Domain.price_type>(price_type);
            _price_typeRepository.Insert(model);
        }
        public virtual void Updateprice_type(price_typeDto price_type)
        {
            Domain.price_type model = AutoMapper.Mapper.Map<Domain.price_type>(price_type);
            _price_typeRepository.Update(model);
        }

        public virtual price_typeDto Getprice_typeById(int id)
        {
            return _price_typeRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<price_typeDto>();
        }

        public virtual List<price_typeDto> Getprice_typeList(int? hotelid)
        {
            var result = _price_typeRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<price_typeDto>();
        }

        public virtual IPagedList<price_typeDto> Getprice_typeList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _price_typeRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<price_typeDto>(result.ProjectToQueryable<price_typeDto>(), pageindex, pagesize);
        }

        public virtual void Deleteprice_type(int id)
        {
            _price_typeRepository.Delete(id);
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

        public virtual List<printDto> GetprintList(int? hotelid)
        {
            var result = _printRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<printDto>();
        }

        public virtual IPagedList<printDto> GetprintList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _printRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<printDto>(result.ProjectToQueryable<printDto>(), pageindex, pagesize);
        }

        public virtual void Deleteprint(int id)
        {
            _printRepository.Delete(id);
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

        public virtual List<real_modeDto> Getreal_modeList(int? hotelid)
        {
            var result = _real_modeRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<real_modeDto>();
        }

        public virtual IPagedList<real_modeDto> Getreal_modeList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _real_modeRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<real_modeDto>(result.ProjectToQueryable<real_modeDto>(), pageindex, pagesize);
        }

        public virtual void Deletereal_mode(int id)
        {
            _real_modeRepository.Delete(id);
        }

        public virtual void Addreal_state(real_stateDto real_state)
        {
            Domain.real_state model = AutoMapper.Mapper.Map<Domain.real_state>(real_state);
            _real_stateRepository.Insert(model);
        }
        public virtual void Updatereal_state(real_stateDto real_state)
        {
            Domain.real_state model = AutoMapper.Mapper.Map<Domain.real_state>(real_state);
            _real_stateRepository.Update(model);
        }

        public virtual real_stateDto Getreal_stateById(int id)
        {
            return _real_stateRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<real_stateDto>();
        }

        public virtual List<real_stateDto> Getreal_stateList(int? hotelid)
        {
            var result = _real_stateRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<real_stateDto>();
        }

        public virtual IPagedList<real_stateDto> Getreal_stateList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _real_stateRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<real_stateDto>(result.ProjectToQueryable<real_stateDto>(), pageindex, pagesize);
        }

        public virtual void Deletereal_state(int id)
        {
            _real_stateRepository.Delete(id);
        }

        public virtual void Addreceipt(receiptDto receipt)
        {
            Domain.receipt model = AutoMapper.Mapper.Map<Domain.receipt>(receipt);
            _receiptRepository.Insert(model);
        }
        public virtual void Updatereceipt(receiptDto receipt)
        {
            Domain.receipt model = AutoMapper.Mapper.Map<Domain.receipt>(receipt);
            _receiptRepository.Update(model);
        }

        public virtual receiptDto GetreceiptById(int id)
        {
            return _receiptRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<receiptDto>();
        }

        public virtual List<receiptDto> GetreceiptList(int? hotelid)
        {
            var result = _receiptRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<receiptDto>();
        }

        public virtual IPagedList<receiptDto> GetreceiptList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _receiptRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<receiptDto>(result.ProjectToQueryable<receiptDto>(), pageindex, pagesize);
        }

        public virtual void Deletereceipt(int id)
        {
            _receiptRepository.Delete(id);
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

        public virtual List<RemakerDto> GetRemakerList(int? hotelid)
        {
            var result = _RemakerRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<RemakerDto>();
        }

        public virtual IPagedList<RemakerDto> GetRemakerList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _RemakerRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<RemakerDto>(result.ProjectToQueryable<RemakerDto>(), pageindex, pagesize);
        }

        public virtual void DeleteRemaker(int id)
        {
            _RemakerRepository.Delete(id);
        }

        public virtual void AddRepair(RepairDto Repair)
        {
            Domain.Repair model = AutoMapper.Mapper.Map<Domain.Repair>(Repair);
            _RepairRepository.Insert(model);
        }
        public virtual void UpdateRepair(RepairDto Repair)
        {
            Domain.Repair model = AutoMapper.Mapper.Map<Domain.Repair>(Repair);
            _RepairRepository.Update(model);
        }

        public virtual RepairDto GetRepairById(int id)
        {
            return _RepairRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<RepairDto>();
        }

        public virtual List<RepairDto> GetRepairList(int? hotelid)
        {
            var result = _RepairRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<RepairDto>();
        }

        public virtual IPagedList<RepairDto> GetRepairList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _RepairRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<RepairDto>(result.ProjectToQueryable<RepairDto>(), pageindex, pagesize);
        }

        public virtual void DeleteRepair(int id)
        {
            _RepairRepository.Delete(id);
        }

        public virtual void AddRoleMenu(RoleMenuDto RoleMenu)
        {
            Domain.RoleMenu model = AutoMapper.Mapper.Map<Domain.RoleMenu>(RoleMenu);
            _RoleMenuRepository.Insert(model);
        }
        public virtual void UpdateRoleMenu(RoleMenuDto RoleMenu)
        {
            Domain.RoleMenu model = AutoMapper.Mapper.Map<Domain.RoleMenu>(RoleMenu);
            _RoleMenuRepository.Update(model);
        }

        public virtual RoleMenuDto GetRoleMenuById(int id)
        {
            return _RoleMenuRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<RoleMenuDto>();
        }

        public virtual List<RoleMenuDto> GetRoleMenuList(int? hotelid,int? roleid)
        {
            var result = _RoleMenuRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);

            if (roleid.HasValue)
                result = result.Where(s => s.RoleID == roleid);

            var models = result.ToList();

            return AutoMapper.Mapper.Map<List<RoleMenuDto>>(models);
        }

        public virtual IPagedList<RoleMenuDto> GetRoleMenuList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _RoleMenuRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<RoleMenuDto>(result.ProjectToQueryable<RoleMenuDto>(), pageindex, pagesize);
        }

        public virtual void DeleteRoleMenu(int id)
        {
            _RoleMenuRepository.Delete(id);
        }

        public virtual void Addroom_feature(room_featureDto room_feature)
        {
            Domain.room_feature model = AutoMapper.Mapper.Map<Domain.room_feature>(room_feature);
            _room_featureRepository.Insert(model);
        }
        public virtual void Updateroom_feature(room_featureDto room_feature)
        {
            Domain.room_feature model = AutoMapper.Mapper.Map<Domain.room_feature>(room_feature);
            _room_featureRepository.Update(model);
        }

        public virtual room_featureDto Getroom_featureById(int id)
        {
            var model = _room_featureRepository.TableNoTracking.Where(s => s.Id == id);
            return AutoMapper.Mapper.Map<room_featureDto>(model);
        }

        public virtual List<room_featureDto> Getroom_featureList(int? hotelid)
        {
            var result = _room_featureRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<room_featureDto>();
        }

        public virtual IPagedList<room_featureDto> Getroom_featureList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _room_featureRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);

            var list = result.OrderByDescending(s => s.Id).Skip(pagesize * (pageindex - 1)).Take(pagesize).ToList();
            var count = result.Count();
            var pagelist = new PagedList<room_featureDto>(AutoMapper.Mapper.Map<List<room_featureDto>>(list), pageindex, pagesize, count);

            foreach (var item in pagelist)
            {
                if (item.hotelid.HasValue)
                    item.UserHotel = AutoMapper.Mapper.Map<HotelDto>(_HotelRepository.TableNoTracking.Where(s => s.Id == item.hotelid.Value).FirstOrDefault());
            }


            return pagelist;

          
        }

        public virtual void Deleteroom_feature(int id)
        {
            _room_featureRepository.Delete(id);
        }

        public virtual void Addroom_number(room_numberDto room_number)
        {
            Domain.room_number model = AutoMapper.Mapper.Map<Domain.room_number>(room_number);
            _room_numberRepository.Insert(model);
        }
        public virtual void Updateroom_number(room_numberDto room_number)
        {
            Domain.room_number model = AutoMapper.Mapper.Map<Domain.room_number>(room_number);
            _room_numberRepository.Update(model);
        }

        public virtual room_numberDto Getroom_numberById(int id)
        {
            var model = _room_numberRepository.TableNoTracking.Where(s => s.Id == id).FirstOrDefault();
            return AutoMapper.Mapper.Map<room_numberDto>(model);
        }

        public virtual room_numberDto Getroom_numberByroomnumber(int? hotelid,string floorid,string floormanage,string roomnumber)
        {
            var query = _room_numberRepository.TableNoTracking;
            if (hotelid.HasValue)
                query = query.Where(s => s.hotelid == hotelid);
            if (!string.IsNullOrEmpty(floorid))
                query = query.Where(s => s.Rn_flloeld == floorid);
            if (!string.IsNullOrEmpty(floormanage))
                query = query.Where(s => s.Rn_floor == floormanage);
            if (!string.IsNullOrEmpty(roomnumber))
                query = query.Where(s => s.Rn_roomNum == roomnumber);

            var model = query.FirstOrDefault();
            return AutoMapper.Mapper.Map<room_numberDto>(model);
        }

        public virtual List<room_numberDto> Getroom_numberList(int? hotelid)
        {
            var result = _room_numberRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<room_numberDto>();
        }

        public virtual IPagedList<room_numberDto> Getroom_numberList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _room_numberRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);

            var list = result.OrderByDescending(s => s.Id).Skip(pagesize * (pageindex - 1)).Take(pagesize).ToList();
            var count = result.Count();
            var pagelist = new PagedList<room_numberDto>(AutoMapper.Mapper.Map<List<room_numberDto>>(list), pageindex, pagesize, count);

            foreach (var item in pagelist)
            {
                if (item.hotelid.HasValue)
                    item.UserHotel = AutoMapper.Mapper.Map<HotelDto>(_HotelRepository.TableNoTracking.Where(s => s.Id == item.hotelid.Value).FirstOrDefault());

                if(item.Rn_room.HasValue)
                      item.RoomType = AutoMapper.Mapper.Map<room_typeDto>(_room_typeRepository.TableNoTracking.Where(s => s.Id == item.Rn_room).FirstOrDefault());
            }

            return pagelist;
        }

        public virtual void Deleteroom_number(int id)
        {
            _room_numberRepository.Delete(id);
        }

        public virtual void Addroom_state(room_stateDto room_state)
        {
            Domain.room_state model = AutoMapper.Mapper.Map<Domain.room_state>(room_state);
            _room_stateRepository.Insert(model);
        }
        public virtual void Updateroom_state(room_stateDto room_state)
        {
            Domain.room_state model = AutoMapper.Mapper.Map<Domain.room_state>(room_state);
            _room_stateRepository.Update(model);
        }

        public virtual room_stateDto Getroom_stateById(int id)
        {
            return _room_stateRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<room_stateDto>();
        }

        public virtual List<room_stateDto> Getroom_stateList(int? hotelid)
        {
            var result = _room_stateRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<room_stateDto>();
        }

        public virtual IPagedList<room_stateDto> Getroom_stateList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _room_stateRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<room_stateDto>(result.ProjectToQueryable<room_stateDto>(), pageindex, pagesize);
        }

        public virtual void Deleteroom_state(int id)
        {
            _room_stateRepository.Delete(id);
        }

        public virtual void Addroom_type(room_typeDto room_type)
        {
            Domain.room_type model = AutoMapper.Mapper.Map<Domain.room_type>(room_type);
            _room_typeRepository.Insert(model);
        }
        public virtual void Updateroom_type(room_typeDto room_type)
        {
            Domain.room_type model = AutoMapper.Mapper.Map<Domain.room_type>(room_type);
            _room_typeRepository.Update(model);
        }

        public virtual room_typeDto Getroom_typeById(int id)
        {
            var model = _room_typeRepository.TableNoTracking.Where(s => s.Id == id).FirstOrDefault();
            return AutoMapper.Mapper.Map<room_typeDto>(model);
        }

        public virtual room_typeDto Getroom_typeByName(int? hotelid , string roomtypename)
        {
            var query = _room_typeRepository.TableNoTracking.Where(s => s.room_name == roomtypename);

            if (hotelid.HasValue)
                query = query.Where(s => s.hotelid == hotelid);

            var model = query.FirstOrDefault();

            return AutoMapper.Mapper.Map<room_typeDto>(model);
        }

        public virtual List<room_typeDto> Getroom_typeList(int? hotelid)
        {
            var result = _room_typeRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<room_typeDto>();
        }

        public virtual IPagedList<room_typeDto> Getroom_typeList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _room_typeRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);

            var list = result.OrderByDescending(s => s.Id).Skip(pagesize * (pageindex - 1)).Take(pagesize).ToList();
            var count = result.Count();
            var pagelist = new PagedList<room_typeDto>(AutoMapper.Mapper.Map<List<room_typeDto>>(list), pageindex, pagesize, count);

            foreach (var item in pagelist)
            {
                if (item.hotelid.HasValue)
                    item.UserHotel = AutoMapper.Mapper.Map<HotelDto>(_HotelRepository.TableNoTracking.Where(s => s.Id == item.hotelid.Value).FirstOrDefault());
            }


            return pagelist;
        }

        public virtual void Deleteroom_type(int id)
        {
            _room_typeRepository.Delete(id);
        }

        public virtual void Addroom_type_image(room_type_imageDto room_type_image)
        {
            Domain.room_type_image model = AutoMapper.Mapper.Map<Domain.room_type_image>(room_type_image);
            _room_type_imageRepository.Insert(model);
        }
        public virtual void Updateroom_type_image(room_type_imageDto room_type_image)
        {
            Domain.room_type_image model = AutoMapper.Mapper.Map<Domain.room_type_image>(room_type_image);
            _room_type_imageRepository.Update(model);
        }

        public virtual room_type_imageDto Getroom_type_imageById(int id)
        {
            return _room_type_imageRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<room_type_imageDto>();
        }

        public virtual List<room_type_imageDto> Getroom_type_imageList(int? hotelid)
        {
            var result = _room_type_imageRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<room_type_imageDto>();
        }

        public virtual IPagedList<room_type_imageDto> Getroom_type_imageList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _room_type_imageRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<room_type_imageDto>(result.ProjectToQueryable<room_type_imageDto>(), pageindex, pagesize);
        }

        public virtual void Deleteroom_type_image(int id)
        {
            _room_type_imageRepository.Delete(id);
        }

        public virtual void Addroomcoupon(roomcouponDto roomcoupon)
        {
            Domain.roomcoupon model = AutoMapper.Mapper.Map<Domain.roomcoupon>(roomcoupon);
            _roomcouponRepository.Insert(model);
        }
        public virtual void Updateroomcoupon(roomcouponDto roomcoupon)
        {
            Domain.roomcoupon model = AutoMapper.Mapper.Map<Domain.roomcoupon>(roomcoupon);
            _roomcouponRepository.Update(model);
        }

        public virtual roomcouponDto GetroomcouponById(int id)
        {
            return _roomcouponRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<roomcouponDto>();
        }

        public virtual List<roomcouponDto> GetroomcouponList(int? hotelid)
        {
            var result = _roomcouponRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<roomcouponDto>();
        }

        public virtual IPagedList<roomcouponDto> GetroomcouponList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _roomcouponRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<roomcouponDto>(result.ProjectToQueryable<roomcouponDto>(), pageindex, pagesize);
        }

        public virtual void Deleteroomcoupon(int id)
        {
            _roomcouponRepository.Delete(id);
        }

        public virtual void Addroomman(roommanDto roomman)
        {
            Domain.roomman model = AutoMapper.Mapper.Map<Domain.roomman>(roomman);
            _roommanRepository.Insert(model);
        }
        public virtual void Updateroomman(roommanDto roomman)
        {
            Domain.roomman model = AutoMapper.Mapper.Map<Domain.roomman>(roomman);
            _roommanRepository.Update(model);
        }

        public virtual roommanDto GetroommanById(int id)
        {
            return _roommanRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<roommanDto>();
        }

        public virtual List<roommanDto> GetroommanList(int? hotelid)
        {
            var result = _roommanRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<roommanDto>();
        }

        public virtual IPagedList<roommanDto> GetroommanList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _roommanRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<roommanDto>(result.ProjectToQueryable<roommanDto>(), pageindex, pagesize);
        }

        public virtual void Deleteroomman(int id)
        {
            _roommanRepository.Delete(id);
        }

        public virtual void Addroomrent(roomrentDto roomrent)
        {
            Domain.roomrent model = AutoMapper.Mapper.Map<Domain.roomrent>(roomrent);
            _roomrentRepository.Insert(model);
        }
        public virtual void Updateroomrent(roomrentDto roomrent)
        {
            Domain.roomrent model = AutoMapper.Mapper.Map<Domain.roomrent>(roomrent);
            _roomrentRepository.Update(model);
        }

        public virtual roomrentDto GetroomrentById(int id)
        {
            return _roomrentRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<roomrentDto>();
        }

        public virtual List<roomrentDto> GetroomrentList(int? hotelid)
        {
            var result = _roomrentRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<roomrentDto>();
        }

        public virtual IPagedList<roomrentDto> GetroomrentList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _roomrentRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<roomrentDto>(result.ProjectToQueryable<roomrentDto>(), pageindex, pagesize);
        }

        public virtual void Deleteroomrent(int id)
        {
            _roomrentRepository.Delete(id);
        }

        public virtual void Addsale_man(sale_manDto sale_man)
        {
            Domain.sale_man model = AutoMapper.Mapper.Map<Domain.sale_man>(sale_man);
            _sale_manRepository.Insert(model);
        }
        public virtual void Updatesale_man(sale_manDto sale_man)
        {
            Domain.sale_man model = AutoMapper.Mapper.Map<Domain.sale_man>(sale_man);
            _sale_manRepository.Update(model);
        }

        public virtual sale_manDto Getsale_manById(int id)
        {
            return _sale_manRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<sale_manDto>();
        }

        public virtual List<sale_manDto> Getsale_manList(int? hotelid)
        {
            var result = _sale_manRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<sale_manDto>();
        }

        public virtual IPagedList<sale_manDto> Getsale_manList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _sale_manRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<sale_manDto>(result.ProjectToQueryable<sale_manDto>(), pageindex, pagesize);
        }

        public virtual void Deletesale_man(int id)
        {
            _sale_manRepository.Delete(id);
        }

        public virtual void AddShift(ShiftDto Shift)
        {
            Domain.Shift model = AutoMapper.Mapper.Map<Domain.Shift>(Shift);
            _ShiftRepository.Insert(model);
        }
        public virtual void UpdateShift(ShiftDto Shift)
        {
            Domain.Shift model = AutoMapper.Mapper.Map<Domain.Shift>(Shift);
            _ShiftRepository.Update(model);
        }

        public virtual ShiftDto GetShiftById(int id)
        {
            var model = _ShiftRepository.TableNoTracking.Where(s => s.Id == id).FirstOrDefault();
            return AutoMapper.Mapper.Map<ShiftDto>(model);
        }

        public virtual List<ShiftDto> GetShiftList(int? hotelid)
        {
            var result = _ShiftRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<ShiftDto>();
        }

        public virtual IPagedList<ShiftDto> GetShiftList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _ShiftRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);

            var list = result.OrderByDescending(s => s.Id).Skip(pagesize * (pageindex - 1)).Take(pagesize).ToList();
            var count = result.Count();
            var pagelist = new PagedList<ShiftDto>(AutoMapper.Mapper.Map<List<ShiftDto>>(list), pageindex, pagesize, count);

            foreach (var item in pagelist)
            {
                if (item.hotelid.HasValue)
                    item.UserHotel = AutoMapper.Mapper.Map<HotelDto>(_HotelRepository.TableNoTracking.Where(s => s.Id == item.hotelid.Value).FirstOrDefault());
            }


            return pagelist;

        }

        public virtual void DeleteShift(int id)
        {
            _ShiftRepository.Delete(id);
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

        public virtual List<Shift_ExcDto> GetShift_ExcList(int? hotelid)
        {
            var result = _Shift_ExcRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<Shift_ExcDto>();
        }

        public virtual IPagedList<Shift_ExcDto> GetShift_ExcList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _Shift_ExcRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<Shift_ExcDto>(result.ProjectToQueryable<Shift_ExcDto>(), pageindex, pagesize);
        }

        public virtual void DeleteShift_Exc(int id)
        {
            _Shift_ExcRepository.Delete(id);
        }

        public virtual void AddshopInfo(shopInfoDto shopInfo)
        {
            Domain.shopInfo model = AutoMapper.Mapper.Map<Domain.shopInfo>(shopInfo);
            _shopInfoRepository.Insert(model);
        }
        public virtual void UpdateshopInfo(shopInfoDto shopInfo)
        {
            Domain.shopInfo model = AutoMapper.Mapper.Map<Domain.shopInfo>(shopInfo);
            _shopInfoRepository.Update(model);
        }

        public virtual shopInfoDto GetshopInfoById(int id)
        {
            return _shopInfoRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<shopInfoDto>();
        }

        public virtual List<shopInfoDto> GetshopInfoList(int? hotelid)
        {
            var result = _shopInfoRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<shopInfoDto>();
        }

        public virtual IPagedList<shopInfoDto> GetshopInfoList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _shopInfoRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<shopInfoDto>(result.ProjectToQueryable<shopInfoDto>(), pageindex, pagesize);
        }

        public virtual void DeleteshopInfo(int id)
        {
            _shopInfoRepository.Delete(id);
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

        public virtual List<SincethehousDto> GetSincethehousList(int? hotelid)
        {
            var result = _SincethehousRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<SincethehousDto>();
        }

        public virtual IPagedList<SincethehousDto> GetSincethehousList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _SincethehousRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<SincethehousDto>(result.ProjectToQueryable<SincethehousDto>(), pageindex, pagesize);
        }

        public virtual void DeleteSincethehous(int id)
        {
            _SincethehousRepository.Delete(id);
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

        public virtual List<SuoRoomDto> GetSuoRoomList(int? hotelid)
        {
            var result = _SuoRoomRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<SuoRoomDto>();
        }

        public virtual IPagedList<SuoRoomDto> GetSuoRoomList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _SuoRoomRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<SuoRoomDto>(result.ProjectToQueryable<SuoRoomDto>(), pageindex, pagesize);
        }

        public virtual void DeleteSuoRoom(int id)
        {
            _SuoRoomRepository.Delete(id);
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

        public virtual List<SuoSysDto> GetSuoSysList(int? hotelid)
        {
            var result = _SuoSysRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<SuoSysDto>();
        }

        public virtual IPagedList<SuoSysDto> GetSuoSysList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _SuoSysRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<SuoSysDto>(result.ProjectToQueryable<SuoSysDto>(), pageindex, pagesize);
        }

        public virtual void DeleteSuoSys(int id)
        {
            _SuoSysRepository.Delete(id);
        }

        public virtual void AddSysParamter(SysParamterDto SysParamter)
        {
            Domain.SysParamter model = AutoMapper.Mapper.Map<Domain.SysParamter>(SysParamter);
            _SysParamterRepository.Insert(model);
        }
        public virtual void UpdateSysParamter(SysParamterDto SysParamter)
        {
            Domain.SysParamter model = AutoMapper.Mapper.Map<Domain.SysParamter>(SysParamter);
            _SysParamterRepository.Update(model);
        }

        public virtual SysParamterDto GetSysParamterById(int id)
        {
            return _SysParamterRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<SysParamterDto>();
        }

        public virtual List<SysParamterDto> GetSysParamterList(int? hotelid)
        {
            var result = _SysParamterRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<SysParamterDto>();
        }

        public virtual IPagedList<SysParamterDto> GetSysParamterList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _SysParamterRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<SysParamterDto>(result.ProjectToQueryable<SysParamterDto>(), pageindex, pagesize);
        }

        public virtual void DeleteSysParamter(int id)
        {
            _SysParamterRepository.Delete(id);
        }

        public virtual void AddTypeScheme(TypeSchemeDto TypeScheme)
        {
            Domain.TypeScheme model = AutoMapper.Mapper.Map<Domain.TypeScheme>(TypeScheme);
            _TypeSchemeRepository.Insert(model);
        }
        public virtual void UpdateTypeScheme(TypeSchemeDto TypeScheme)
        {
            Domain.TypeScheme model = AutoMapper.Mapper.Map<Domain.TypeScheme>(TypeScheme);
            _TypeSchemeRepository.Update(model);
        }

        public virtual TypeSchemeDto GetTypeSchemeById(int id)
        {
            return _TypeSchemeRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<TypeSchemeDto>();
        }

        public virtual List<TypeSchemeDto> GetTypeSchemeList(int? hotelid)
        {
            var result = _TypeSchemeRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<TypeSchemeDto>();
        }

        public virtual IPagedList<TypeSchemeDto> GetTypeSchemeList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _TypeSchemeRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<TypeSchemeDto>(result.ProjectToQueryable<TypeSchemeDto>(), pageindex, pagesize);
        }

        public virtual void DeleteTypeScheme(int id)
        {
            _TypeSchemeRepository.Delete(id);
        }

        public virtual void AddUserInfo(UserInfoDto UserInfo)
        {
            Domain.UserInfo model = AutoMapper.Mapper.Map<Domain.UserInfo>(UserInfo);
            _UserInfoRepository.Insert(model);
        }
        public virtual void UpdateUserInfo(UserInfoDto UserInfo)
        {
            Domain.UserInfo model = AutoMapper.Mapper.Map<Domain.UserInfo>(UserInfo);
            _UserInfoRepository.Update(model);
        }

        public virtual UserInfoDto GetUserInfoById(int id)
        {
            return _UserInfoRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<UserInfoDto>();
        }

        public virtual List<UserInfoDto> GetUserInfoList(int? hotelid)
        {
            var result = _UserInfoRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<UserInfoDto>();
        }

        public virtual IPagedList<UserInfoDto> GetUserInfoList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _UserInfoRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<UserInfoDto>(result.ProjectToQueryable<UserInfoDto>(), pageindex, pagesize);
        }

        public virtual void DeleteUserInfo(int id)
        {
            _UserInfoRepository.Delete(id);
        }

        public virtual void AddUsers(UsersDto Users)
        {
            Domain.Users model = AutoMapper.Mapper.Map<Domain.Users>(Users);
            _UsersRepository.Insert(model);
        }
        public virtual void UpdateUsers(UsersDto Users)
        {
            Domain.Users model = AutoMapper.Mapper.Map<Domain.Users>(Users);
            _UsersRepository.Update(model);
        }

        public virtual UsersDto GetUsersById(int id)
        {
            return _UsersRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<UsersDto>();
        }

        public virtual List<UsersDto> GetUsersList(int? hotelid)
        {
            var result = _UsersRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<UsersDto>();
        }

        public virtual IPagedList<UsersDto> GetUsersList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _UsersRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<UsersDto>(result.ProjectToQueryable<UsersDto>(), pageindex, pagesize);
        }

        public virtual void DeleteUsers(int id)
        {
            _UsersRepository.Delete(id);
        }

        public virtual void AdduserType(userTypeDto userType)
        {
            Domain.userType model = AutoMapper.Mapper.Map<Domain.userType>(userType);
            _userTypeRepository.Insert(model);
        }
        public virtual void UpdateuserType(userTypeDto userType)
        {
            Domain.userType model = AutoMapper.Mapper.Map<Domain.userType>(userType);
            _userTypeRepository.Update(model);
        }

        public virtual userTypeDto GetuserTypeById(int id)
        {
            return _userTypeRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<userTypeDto>();
        }

        public virtual List<userTypeDto> GetuserTypeList(int? hotelid)
        {
            var result = _userTypeRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<userTypeDto>();
        }

        public virtual IPagedList<userTypeDto> GetuserTypeList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _userTypeRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<userTypeDto>(result.ProjectToQueryable<userTypeDto>(), pageindex, pagesize);
        }

        public virtual void DeleteuserType(int id)
        {
            _userTypeRepository.Delete(id);
        }

        public virtual void AddZD_hourse(ZD_hourseDto ZD_hourse)
        {
            Domain.ZD_hourse model = AutoMapper.Mapper.Map<Domain.ZD_hourse>(ZD_hourse);
            _ZD_hourseRepository.Insert(model);
        }
        public virtual void UpdateZD_hourse(ZD_hourseDto ZD_hourse)
        {
            Domain.ZD_hourse model = AutoMapper.Mapper.Map<Domain.ZD_hourse>(ZD_hourse);
            _ZD_hourseRepository.Update(model);
        }

        public virtual ZD_hourseDto GetZD_hourseById(int id)
        {
            return _ZD_hourseRepository.TableNoTracking.Where(s => s.Id == id).ProjectToFirstOrDefault<ZD_hourseDto>();
        }

        public virtual List<ZD_hourseDto> GetZD_hourseList(int? hotelid)
        {
            var result = _ZD_hourseRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return result.ProjectToList<ZD_hourseDto>();
        }

        public virtual IPagedList<ZD_hourseDto> GetZD_hourseList(int? hotelid, int pageindex, int pagesize)
        {
            var result = _ZD_hourseRepository.TableNoTracking;
            if (hotelid.HasValue)
                result = result.Where(s => s.hotelid == hotelid);
            return new PagedList<ZD_hourseDto>(result.ProjectToQueryable<ZD_hourseDto>(), pageindex, pagesize);
        }

        public virtual void DeleteZD_hourse(int id)
        {
            _ZD_hourseRepository.Delete(id);
        }

    }



}
