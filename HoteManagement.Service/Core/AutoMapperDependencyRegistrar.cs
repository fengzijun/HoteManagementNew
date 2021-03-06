using Autofac;
using Autofac.Builder;
using Autofac.Core;
using Autofac.Extras.DynamicProxy;
using HoteManagement.Caching;
using HoteManagement.Configuration;

using HoteManagement.Fakes;
using HoteManagement.Infrastructure;
using HoteManagement.Infrastructure.DependencyManagement;
using HoteManagement.Infrastructure.UnitOfWork;
using HoteManagement.Service.Events;
using HoteManagement.Service.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using AutoMapper;
using HoteManagement.Service.Model;

namespace HoteManagement.Service.Core
{
    /// <summary>
    /// Dependency registrar
    /// </summary>
    public class AutoMapperDependencyRegistrar : IDependencyRegistrar
    {
        /// <summary>
        /// Register services and interfaces
        /// </summary>
        /// <param name="builder">Container builder</param>
        /// <param name="typeFinder">Type finder</param>
        /// <param name="config">Config</param>
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, ArticleConfig config)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Domain.account_goods,  account_goodsDto>();
                cfg.CreateMap<account_goodsDto, Domain.account_goods>();

                cfg.CreateMap<Domain.Accounts_Roles, Accounts_RolesDto>();
                cfg.CreateMap<Accounts_RolesDto, Domain.Accounts_Roles>();

                cfg.CreateMap<Domain.Accounts_UserRoles, Accounts_UserRolesDto>();
                cfg.CreateMap<Accounts_UserRolesDto, Domain.Accounts_UserRoles>();

                cfg.CreateMap<Domain.Accounts_Users, Accounts_UsersDto>();
                cfg.CreateMap<Accounts_UsersDto, Domain.Accounts_Users>();

                cfg.CreateMap<Domain.AddPrice, AddPriceDto>();
                cfg.CreateMap<AddPriceDto, Domain.AddPrice>();

                cfg.CreateMap<Domain.apartment, apartmentDto>();
                cfg.CreateMap<apartmentDto, Domain.apartment>();

                cfg.CreateMap<Domain.banner, bannerDto>();
                cfg.CreateMap<bannerDto, Domain.banner>();

                cfg.CreateMap<Domain.Book_Rdetail, Book_RdetailDto>();
                cfg.CreateMap<Book_RdetailDto, Domain.Book_Rdetail>();

                cfg.CreateMap<Domain.book_room, book_roomDto>();
                cfg.CreateMap<book_roomDto, Domain.book_room>();

                cfg.CreateMap<Domain.BookState, BookStateDto>();
                cfg.CreateMap<BookStateDto, Domain.BookState>();

                cfg.CreateMap<Domain.breakfirstcoupon, breakfirstcouponDto>();
                cfg.CreateMap<breakfirstcouponDto, Domain.breakfirstcoupon>();

                cfg.CreateMap<Domain.card_type, card_typeDto>();
                cfg.CreateMap<card_typeDto, Domain.card_type>();

                cfg.CreateMap<Domain.cCall, cCallDto>();
                cfg.CreateMap<cCallDto, Domain.cCall>();

                cfg.CreateMap<Domain.cDepartment, cDepartmentDto>();
                cfg.CreateMap<cDepartmentDto, Domain.cDepartment>();

                cfg.CreateMap<Domain.cIndustry, cIndustryDto>();
                cfg.CreateMap<cIndustryDto, Domain.cIndustry>();

                cfg.CreateMap<Domain.comm_unit, comm_unitDto>();
                cfg.CreateMap<comm_unitDto, Domain.comm_unit>();

                cfg.CreateMap<Domain.Commission, CommissionDto>();
                cfg.CreateMap<CommissionDto, Domain.Commission>();

                cfg.CreateMap<Domain.Contacts, ContactsDto>();
                cfg.CreateMap<ContactsDto, Domain.Contacts>();

                cfg.CreateMap<Domain.cost_type, cost_typeDto>();
                cfg.CreateMap<cost_typeDto, Domain.cost_type>();

                cfg.CreateMap<Domain.cPost, cPostDto>();
                cfg.CreateMap<cPostDto, Domain.cPost>();

                cfg.CreateMap<Domain.cprotocol, cprotocolDto>();
                cfg.CreateMap<cprotocolDto, Domain.cprotocol>();

                cfg.CreateMap<Domain.cprotocolPrice, cprotocolPriceDto>();
                cfg.CreateMap<cprotocolPriceDto, Domain.cprotocolPrice>();

                cfg.CreateMap<Domain.cpType, cpTypeDto>();
                cfg.CreateMap<cpTypeDto, Domain.cpType>();

                cfg.CreateMap<Domain.credit, creditDto>();
                cfg.CreateMap<creditDto, Domain.credit>();

                cfg.CreateMap<Domain.csysType, csysTypeDto>();
                cfg.CreateMap<csysTypeDto, Domain.csysType>();

                cfg.CreateMap<Domain.customer, customerDto>();
                cfg.CreateMap<customerDto, Domain.customer>();

                cfg.CreateMap<Domain.customerState, customerStateDto>();
                cfg.CreateMap<customerStateDto, Domain.customerState>();

                cfg.CreateMap<Domain.customerType, customerTypeDto>();
                cfg.CreateMap<customerTypeDto, Domain.customerType>();

                cfg.CreateMap<Domain.Entry, EntryDto>();
                cfg.CreateMap<EntryDto, Domain.Entry>();

                cfg.CreateMap<Domain.ExceedScheme, ExceedSchemeDto>();
                cfg.CreateMap<ExceedSchemeDto, Domain.ExceedScheme>();

                cfg.CreateMap<Domain.floor_ld, floor_ldDto>();
                cfg.CreateMap<floor_ldDto, Domain.floor_ld>();

                cfg.CreateMap<Domain.floor_manage, floor_manageDto>();
                cfg.CreateMap<floor_manageDto, Domain.floor_manage>();

                cfg.CreateMap<Domain.FtSet, FtSetDto>();
                cfg.CreateMap<FtSetDto, Domain.FtSet>();

                cfg.CreateMap<Domain.Goods, GoodsDto>();
                cfg.CreateMap<GoodsDto, Domain.Goods>();

                cfg.CreateMap<Domain.goods_account, goods_accountDto>();
                cfg.CreateMap<goods_accountDto, Domain.goods_account>();

                cfg.CreateMap<Domain.guest_source, guest_sourceDto>();
                cfg.CreateMap<guest_sourceDto, Domain.guest_source>();

                cfg.CreateMap<Domain.Hotel, HotelDto>();
                cfg.CreateMap<HotelDto, Domain.Hotel>();

                cfg.CreateMap<Domain.hour_room, hour_roomDto>();
                cfg.CreateMap<hour_roomDto, Domain.hour_room>();

                cfg.CreateMap<Domain.hourse_scheme, hourse_schemeDto>();
                cfg.CreateMap<hourse_schemeDto, Domain.hourse_scheme>();

                cfg.CreateMap<Domain.info, infoDto>();
                cfg.CreateMap<infoDto, Domain.info>();

                cfg.CreateMap<Domain.log, logDto>();
                cfg.CreateMap<logDto, Domain.log>();

                cfg.CreateMap<Domain.member, memberDto>();
                cfg.CreateMap<memberDto, Domain.member>();

                cfg.CreateMap<Domain.memberState, memberStateDto>();
                cfg.CreateMap<memberStateDto, Domain.memberState>();

                cfg.CreateMap<Domain.memberType, memberTypeDto>();
                cfg.CreateMap<memberTypeDto, Domain.memberType>();

                cfg.CreateMap<Domain.Menu, MenuDto>();
                cfg.CreateMap<MenuDto, Domain.Menu>();

                cfg.CreateMap<Domain.meth_pay, meth_payDto>();
                cfg.CreateMap<meth_payDto, Domain.meth_pay>();

                cfg.CreateMap<Domain.modes, modesDto>();
                cfg.CreateMap<modesDto, Domain.modes>();

                cfg.CreateMap<Domain.mRecords, mRecordsDto>();
                cfg.CreateMap<mRecordsDto, Domain.mRecords>();

                cfg.CreateMap<Domain.mtPrice, mtPriceDto>();
                cfg.CreateMap<mtPriceDto, Domain.mtPrice>();

                cfg.CreateMap<Domain.occu_infor, occu_inforDto>();
                cfg.CreateMap<occu_inforDto, Domain.occu_infor>();

                cfg.CreateMap<Domain.occu_informx, occu_informxDto>();
                cfg.CreateMap<occu_informxDto, Domain.occu_informx>();

                cfg.CreateMap<Domain.order_ext, order_extDto>();
                cfg.CreateMap<order_extDto, Domain.order_ext>();

                cfg.CreateMap<Domain.order_infor, order_inforDto>();
                cfg.CreateMap<order_inforDto, Domain.order_infor>();

                cfg.CreateMap<Domain.paymentMoney, paymentMoneyDto>();
                cfg.CreateMap<paymentMoneyDto, Domain.paymentMoney>();

                cfg.CreateMap<Domain.price_type, price_typeDto>();
                cfg.CreateMap<price_typeDto, Domain.price_type>();

                cfg.CreateMap<Domain.print, printDto>();
                cfg.CreateMap<printDto, Domain.print>();

                cfg.CreateMap<Domain.real_mode, real_modeDto>();
                cfg.CreateMap<real_modeDto, Domain.real_mode>();

                cfg.CreateMap<Domain.real_state, real_stateDto>();
                cfg.CreateMap<real_stateDto, Domain.real_state>();

                cfg.CreateMap<Domain.receipt, receiptDto>();
                cfg.CreateMap<receiptDto, Domain.receipt>();

                cfg.CreateMap<Domain.Remaker, RemakerDto>();
                cfg.CreateMap<RemakerDto, Domain.Remaker>();

                cfg.CreateMap<Domain.Repair, RepairDto>();
                cfg.CreateMap<RepairDto, Domain.Repair>();

                cfg.CreateMap<Domain.RoleMenu, RoleMenuDto>();
                cfg.CreateMap<RoleMenuDto, Domain.RoleMenu>();

                cfg.CreateMap<Domain.room_feature, room_featureDto>();
                cfg.CreateMap<room_featureDto, Domain.room_feature>();

                cfg.CreateMap<Domain.room_number, room_numberDto>();
                cfg.CreateMap<room_numberDto, Domain.room_number>();

                cfg.CreateMap<Domain.room_state, room_stateDto>();
                cfg.CreateMap<room_stateDto, Domain.room_state>();

                cfg.CreateMap<Domain.room_type, room_typeDto>();
                cfg.CreateMap<room_typeDto, Domain.room_type>();

                cfg.CreateMap<Domain.room_type_image, room_type_imageDto>();
                cfg.CreateMap<room_type_imageDto, Domain.room_type_image>();

                cfg.CreateMap<Domain.roomcoupon, roomcouponDto>();
                cfg.CreateMap<roomcouponDto, Domain.roomcoupon>();

                cfg.CreateMap<Domain.roomman, roommanDto>();
                cfg.CreateMap<roommanDto, Domain.roomman>();

                cfg.CreateMap<Domain.roomrent, roomrentDto>();
                cfg.CreateMap<roomrentDto, Domain.roomrent>();

                cfg.CreateMap<Domain.sale_man, sale_manDto>();
                cfg.CreateMap<sale_manDto, Domain.sale_man>();

                cfg.CreateMap<Domain.Shift, ShiftDto>();
                cfg.CreateMap<ShiftDto, Domain.Shift>();

                cfg.CreateMap<Domain.Shift_Exc, Shift_ExcDto>();
                cfg.CreateMap<Shift_ExcDto, Domain.Shift_Exc>();

                cfg.CreateMap<Domain.shopInfo, shopInfoDto>();
                cfg.CreateMap<shopInfoDto, Domain.shopInfo>();

                cfg.CreateMap<Domain.Sincethehous, SincethehousDto>();
                cfg.CreateMap<SincethehousDto, Domain.Sincethehous>();

                cfg.CreateMap<Domain.SuoRoom, SuoRoomDto>();
                cfg.CreateMap<SuoRoomDto, Domain.SuoRoom>();

                cfg.CreateMap<Domain.SuoSys, SuoSysDto>();
                cfg.CreateMap<SuoSysDto, Domain.SuoSys>();

                cfg.CreateMap<Domain.SysParamter, SysParamterDto>();
                cfg.CreateMap<SysParamterDto, Domain.SysParamter>();

                cfg.CreateMap<Domain.TypeScheme, TypeSchemeDto>();
                cfg.CreateMap<TypeSchemeDto, Domain.TypeScheme>();

                cfg.CreateMap<Domain.UserInfo, UserInfoDto>();
                cfg.CreateMap<UserInfoDto, Domain.UserInfo>();

                cfg.CreateMap<Domain.Users, UsersDto>();
                cfg.CreateMap<UsersDto, Domain.Users>();

                cfg.CreateMap<Domain.userType, userTypeDto>();
                cfg.CreateMap<userTypeDto, Domain.userType>();

                cfg.CreateMap<Domain.ZD_hourse, ZD_hourseDto>();
                cfg.CreateMap<ZD_hourseDto, Domain.ZD_hourse>();

                cfg.CreateMap<Domain.Org_Business, Org_BusinessDto>();
                cfg.CreateMap<Org_BusinessDto, Domain.Org_Business>();

                cfg.CreateMap<Domain.ProjectSettlement, ProjectSettlementDto>();
                cfg.CreateMap<ProjectSettlementDto, Domain.ProjectSettlement>();

            });
        }

        /// <summary>
        /// Order of this dependency registrar implementation
        /// </summary>
        public int Order
        {
            get { return 0; }
        }
    }

    //public class DbContextDependencyRegistrar: IDependencyRegistrar
    //{
    //    /// <summary>
    //    /// Register services and interfaces
    //    /// </summary>
    //    /// <param name="builder">Container builder</param>
    //    /// <param name="typeFinder">Type finder</param>
    //    /// <param name="config">Config</param>
    //    public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, ArticleConfig config)
    //    {
    //        builder.Register<IDbContext>(c => new BaseObjectContext(config.MsSqlConnectionString)).InstancePerLifetimeScope();
    //    }

    //    /// <summary>
    //    /// Order of this dependency registrar implementation
    //    /// </summary>
    //    public int Order
    //    {
    //        get { return 99; }
    //    }
    //}

    //public class SettingsSource : IRegistrationSource
    //{
    //    static readonly MethodInfo BuildMethod = typeof(SettingsSource).GetMethod(
    //        "BuildRegistration",
    //        BindingFlags.Static | BindingFlags.NonPublic);

    //    public IEnumerable<IComponentRegistration> RegistrationsFor(
    //            Service service,
    //            Func<Service, IEnumerable<IComponentRegistration>> registrations)
    //    {
    //        var ts = service as TypedService;
    //        if (ts != null && typeof(ISettings).IsAssignableFrom(ts.ServiceType))
    //        {
    //            var buildMethod = BuildMethod.MakeGenericMethod(ts.ServiceType);
    //            yield return (IComponentRegistration)buildMethod.Invoke(null, null);
    //        }
    //    }

    //    static IComponentRegistration BuildRegistration<TSettings>() where TSettings : ISettings, new()
    //    {
    //        return RegistrationBuilder
    //            .ForDelegate((c, p) =>
    //            {
    //                var currentStoreId = c.Resolve<IStoreContext>().CurrentStore.Id;
    //                //uncomment the code below if you want load settings per store only when you have two stores installed.
    //                //var currentStoreId = c.Resolve<IStoreService>().GetAllStores().Count > 1
    //                //    c.Resolve<IStoreContext>().CurrentStore.Id : 0;

    //                //although it's better to connect to your database and execute the following SQL:
    //                //DELETE FROM [Setting] WHERE [StoreId] > 0
    //                return c.Resolve<ISettingService>().LoadSetting<TSettings>(currentStoreId);
    //            })
    //            .InstancePerLifetimeScope()
    //            .CreateRegistration();
    //    }

    //    public bool IsAdapterForIndividualComponents { get { return false; } }
    //}
}