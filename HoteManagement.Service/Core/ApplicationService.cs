﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------
using HoteManagement.Caching;
using HoteManagement.Data;
using HoteManagement.Infrastructure.Domain;
using HoteManagement.Service.Events;
using System;
using System.Collections.Generic;

namespace HoteManagement.Service.Model
{
    public abstract class ApplicationService : IApplicationService
    {
        protected readonly IRepository<Domain.account_goods> _account_goodsRepository;
        protected readonly IRepository<Domain.Accounts_Roles> _Accounts_RolesRepository;
        protected readonly IRepository<Domain.Accounts_UserRoles> _Accounts_UserRolesRepository;
        protected readonly IRepository<Domain.Accounts_Users> _Accounts_UsersRepository;
        protected readonly IRepository<Domain.AddPrice> _AddPriceRepository;
        protected readonly IRepository<Domain.apartment> _apartmentRepository;
        protected readonly IRepository<Domain.banner> _bannerRepository;
        protected readonly IRepository<Domain.Book_Rdetail> _Book_RdetailRepository;
        protected readonly IRepository<Domain.book_room> _book_roomRepository;
        protected readonly IRepository<Domain.BookState> _BookStateRepository;
        protected readonly IRepository<Domain.breakfirstcoupon> _breakfirstcouponRepository;
        protected readonly IRepository<Domain.card_type> _card_typeRepository;
        protected readonly IRepository<Domain.cCall> _cCallRepository;
        protected readonly IRepository<Domain.cDepartment> _cDepartmentRepository;
        protected readonly IRepository<Domain.cIndustry> _cIndustryRepository;
        protected readonly IRepository<Domain.comm_unit> _comm_unitRepository;
        protected readonly IRepository<Domain.Commission> _CommissionRepository;
        protected readonly IRepository<Domain.Contacts> _ContactsRepository;
        protected readonly IRepository<Domain.cost_type> _cost_typeRepository;
        protected readonly IRepository<Domain.cPost> _cPostRepository;
        protected readonly IRepository<Domain.cprotocol> _cprotocolRepository;
        protected readonly IRepository<Domain.cprotocolPrice> _cprotocolPriceRepository;
        protected readonly IRepository<Domain.cpType> _cpTypeRepository;
        protected readonly IRepository<Domain.credit> _creditRepository;
        protected readonly IRepository<Domain.csysType> _csysTypeRepository;
        protected readonly IRepository<Domain.customer> _customerRepository;
        protected readonly IRepository<Domain.customerState> _customerStateRepository;
        protected readonly IRepository<Domain.customerType> _customerTypeRepository;
        protected readonly IRepository<Domain.Entry> _EntryRepository;
        protected readonly IRepository<Domain.ExceedScheme> _ExceedSchemeRepository;
        protected readonly IRepository<Domain.floor_ld> _floor_ldRepository;
        protected readonly IRepository<Domain.floor_manage> _floor_manageRepository;
        protected readonly IRepository<Domain.FtSet> _FtSetRepository;
        protected readonly IRepository<Domain.Goods> _GoodsRepository;
        protected readonly IRepository<Domain.goods_account> _goods_accountRepository;
        protected readonly IRepository<Domain.guest_source> _guest_sourceRepository;
        protected readonly IRepository<Domain.Hotel> _HotelRepository;
        protected readonly IRepository<Domain.hour_room> _hour_roomRepository;
        protected readonly IRepository<Domain.hourse_scheme> _hourse_schemeRepository;
        protected readonly IRepository<Domain.info> _infoRepository;
        protected readonly IRepository<Domain.log> _logRepository;
        protected readonly IRepository<Domain.member> _memberRepository;
        protected readonly IRepository<Domain.memberState> _memberStateRepository;
        protected readonly IRepository<Domain.memberType> _memberTypeRepository;
        protected readonly IRepository<Domain.Menu> _MenuRepository;
        protected readonly IRepository<Domain.meth_pay> _meth_payRepository;
        protected readonly IRepository<Domain.modes> _modesRepository;
        protected readonly IRepository<Domain.mRecords> _mRecordsRepository;
        protected readonly IRepository<Domain.mtPrice> _mtPriceRepository;
        protected readonly IRepository<Domain.occu_infor> _occu_inforRepository;
        protected readonly IRepository<Domain.occu_informx> _occu_informxRepository;
        protected readonly IRepository<Domain.order_ext> _order_extRepository;
        protected readonly IRepository<Domain.order_infor> _order_inforRepository;
        protected readonly IRepository<Domain.paymentMoney> _paymentMoneyRepository;
        protected readonly IRepository<Domain.price_type> _price_typeRepository;
        protected readonly IRepository<Domain.print> _printRepository;
        protected readonly IRepository<Domain.real_mode> _real_modeRepository;
        protected readonly IRepository<Domain.real_state> _real_stateRepository;
        protected readonly IRepository<Domain.receipt> _receiptRepository;
        protected readonly IRepository<Domain.Remaker> _RemakerRepository;
        protected readonly IRepository<Domain.Repair> _RepairRepository;
        protected readonly IRepository<Domain.RoleMenu> _RoleMenuRepository;
        protected readonly IRepository<Domain.room_feature> _room_featureRepository;
        protected readonly IRepository<Domain.room_number> _room_numberRepository;
        protected readonly IRepository<Domain.room_state> _room_stateRepository;
        protected readonly IRepository<Domain.room_type> _room_typeRepository;
        protected readonly IRepository<Domain.room_type_image> _room_type_imageRepository;
        protected readonly IRepository<Domain.roomcoupon> _roomcouponRepository;
        protected readonly IRepository<Domain.roomman> _roommanRepository;
        protected readonly IRepository<Domain.roomrent> _roomrentRepository;
        protected readonly IRepository<Domain.sale_man> _sale_manRepository;
        protected readonly IRepository<Domain.Shift> _ShiftRepository;
        protected readonly IRepository<Domain.Shift_Exc> _Shift_ExcRepository;
        protected readonly IRepository<Domain.shopInfo> _shopInfoRepository;
        protected readonly IRepository<Domain.Sincethehous> _SincethehousRepository;
        protected readonly IRepository<Domain.SuoRoom> _SuoRoomRepository;
        protected readonly IRepository<Domain.SuoSys> _SuoSysRepository;
        protected readonly IRepository<Domain.SysParamter> _SysParamterRepository;
        protected readonly IRepository<Domain.TypeScheme> _TypeSchemeRepository;
        protected readonly IRepository<Domain.UserInfo> _UserInfoRepository;
        protected readonly IRepository<Domain.Users> _UsersRepository;
        protected readonly IRepository<Domain.userType> _userTypeRepository;
        protected readonly IRepository<Domain.ZD_hourse> _ZD_hourseRepository;

        protected readonly IDbContext _dbcontext;
        protected readonly IRedis _redishelper;
        protected readonly IEventPublisher _eventPublisher;
        protected readonly ILogger _logger;

        public ApplicationService(
           IRepository<Domain.account_goods> account_goodsRepository,
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
        ILogger logger

 ){
     _account_goodsRepository = account_goodsRepository;
   _Accounts_RolesRepository = Accounts_RolesRepository;
   _Accounts_UserRolesRepository = Accounts_UserRolesRepository;
   _Accounts_UsersRepository = Accounts_UsersRepository;
   _AddPriceRepository = AddPriceRepository;
   _apartmentRepository = apartmentRepository;
   _bannerRepository = bannerRepository;
   _Book_RdetailRepository = Book_RdetailRepository;
   _book_roomRepository = book_roomRepository;
   _BookStateRepository = BookStateRepository;
   _breakfirstcouponRepository = breakfirstcouponRepository;
   _card_typeRepository = card_typeRepository;
   _cCallRepository = cCallRepository;
   _cDepartmentRepository = cDepartmentRepository;
   _cIndustryRepository = cIndustryRepository;
   _comm_unitRepository = comm_unitRepository;
   _CommissionRepository = CommissionRepository;
   _ContactsRepository = ContactsRepository;
   _cost_typeRepository = cost_typeRepository;
   _cPostRepository = cPostRepository;
   _cprotocolRepository = cprotocolRepository;
   _cprotocolPriceRepository = cprotocolPriceRepository;
   _cpTypeRepository = cpTypeRepository;
   _creditRepository = creditRepository;
   _csysTypeRepository = csysTypeRepository;
   _customerRepository = customerRepository;
   _customerStateRepository = customerStateRepository;
   _customerTypeRepository = customerTypeRepository;
   _EntryRepository = EntryRepository;
   _ExceedSchemeRepository = ExceedSchemeRepository;
   _floor_ldRepository = floor_ldRepository;
   _floor_manageRepository = floor_manageRepository;
   _FtSetRepository = FtSetRepository;
   _GoodsRepository = GoodsRepository;
   _goods_accountRepository = goods_accountRepository;
   _guest_sourceRepository = guest_sourceRepository;
   _HotelRepository = HotelRepository;
   _hour_roomRepository = hour_roomRepository;
   _hourse_schemeRepository = hourse_schemeRepository;
   _infoRepository = infoRepository;
   _logRepository = logRepository;
   _memberRepository = memberRepository;
   _memberStateRepository = memberStateRepository;
   _memberTypeRepository = memberTypeRepository;
   _MenuRepository = MenuRepository;
   _meth_payRepository = meth_payRepository;
   _modesRepository = modesRepository;
   _mRecordsRepository = mRecordsRepository;
   _mtPriceRepository = mtPriceRepository;
   _occu_inforRepository = occu_inforRepository;
   _occu_informxRepository = occu_informxRepository;
   _order_extRepository = order_extRepository;
   _order_inforRepository = order_inforRepository;
   _paymentMoneyRepository = paymentMoneyRepository;
   _price_typeRepository = price_typeRepository;
   _printRepository = printRepository;
   _real_modeRepository = real_modeRepository;
   _real_stateRepository = real_stateRepository;
   _receiptRepository = receiptRepository;
   _RemakerRepository = RemakerRepository;
   _RepairRepository = RepairRepository;
   _RoleMenuRepository = RoleMenuRepository;
   _room_featureRepository = room_featureRepository;
   _room_numberRepository = room_numberRepository;
   _room_stateRepository = room_stateRepository;
   _room_typeRepository = room_typeRepository;
   _room_type_imageRepository = room_type_imageRepository;
   _roomcouponRepository = roomcouponRepository;
   _roommanRepository = roommanRepository;
   _roomrentRepository = roomrentRepository;
   _sale_manRepository = sale_manRepository;
   _ShiftRepository = ShiftRepository;
   _Shift_ExcRepository = Shift_ExcRepository;
   _shopInfoRepository = shopInfoRepository;
   _SincethehousRepository = SincethehousRepository;
   _SuoRoomRepository = SuoRoomRepository;
   _SuoSysRepository = SuoSysRepository;
   _SysParamterRepository = SysParamterRepository;
   _TypeSchemeRepository = TypeSchemeRepository;
   _UserInfoRepository = UserInfoRepository;
   _UsersRepository = UsersRepository;
   _userTypeRepository = userTypeRepository;
   _ZD_hourseRepository = ZD_hourseRepository;

            this._dbcontext = dbcontext;
            this._eventPublisher = eventPublisher;
           this._redishelper = redishelper;
            this._logger = logger;

 }

}

}