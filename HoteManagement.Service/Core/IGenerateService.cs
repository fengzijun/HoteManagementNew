﻿using Autofac.Extras.DynamicProxy;
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
    public interface  IGenerateService
    {
        void Addaccount_goods(account_goodsDto account_goods);

        void Updateaccount_goods(account_goodsDto account_goods);


        account_goodsDto Getaccount_goodsById(int id);

        List<account_goodsDto> Getaccount_goodsList(int? hotelid);


        IPagedList<account_goodsDto> Getaccount_goodsList(int? hotelid, int pageindex, int pagesize);


        void Deleteaccount_goods(int id);


        void AddAccounts_Roles(Accounts_RolesDto Accounts_Roles);

        void UpdateAccounts_Roles(Accounts_RolesDto Accounts_Roles);


        Accounts_RolesDto GetAccounts_RolesById(int id);

        Accounts_RolesDto GetAccounts_RolesByName(string name,int? hotelid);

        List<Accounts_RolesDto> GetAccounts_RolesList(int? hotelid);


        IPagedList<Accounts_RolesDto> GetAccounts_RolesList(int? hotelid, int pageindex, int pagesize);


        void DeleteAccounts_Roles(int id);


        void AddAccounts_UserRoles(Accounts_UserRolesDto Accounts_UserRoles);

        void UpdateAccounts_UserRoles(Accounts_UserRolesDto Accounts_UserRoles);


        Accounts_UserRolesDto GetAccounts_UserRolesByUserId(int id);

        List<Accounts_UserRolesDto> GetAccounts_UserRolesList();


        IPagedList<Accounts_UserRolesDto> GetAccounts_UserRolesList(int? hotelid, int pageindex, int pagesize);


        void DeleteAccounts_UserRoles(int id);


        int AddAccounts_Users(Accounts_UsersDto Accounts_Users);

        void UpdateAccounts_Users(Accounts_UsersDto Accounts_Users);


        Accounts_UsersDto GetAccounts_UsersById(int id);

        Accounts_UsersDto GetAccounts_UsersByName(int? hotelid, string accountname);

        List<Accounts_UsersDto> GetAccounts_UsersList(int? hotelid);


        IPagedList<Accounts_UsersDto> GetAccounts_UsersList(int? hotelid, int pageindex, int pagesize);


        void DeleteAccounts_Users(int id);


        void AddAddPrice(AddPriceDto AddPrice);

        void UpdateAddPrice(AddPriceDto AddPrice);


        AddPriceDto GetAddPriceById(int id);

        List<AddPriceDto> GetAddPriceList(int? hotelid);


        IPagedList<AddPriceDto> GetAddPriceList(int? hotelid, int pageindex, int pagesize);


        void DeleteAddPrice(int id);


        void Addapartment(apartmentDto apartment);

        void Updateapartment(apartmentDto apartment);


        apartmentDto GetapartmentById(int id);

        List<apartmentDto> GetapartmentList(int? hotelid);


        IPagedList<apartmentDto> GetapartmentList(int? hotelid, int pageindex, int pagesize);


        void Deleteapartment(int id);


        void Addbanner(bannerDto banner);

        void Updatebanner(bannerDto banner);


        bannerDto GetbannerById(int id);

        List<bannerDto> GetbannerList(int? hotelid);


        IPagedList<bannerDto> GetbannerList(int? hotelid, int pageindex, int pagesize);


        void Deletebanner(int id);


        void AddBook_Rdetail(Book_RdetailDto Book_Rdetail);

        void UpdateBook_Rdetail(Book_RdetailDto Book_Rdetail);


        Book_RdetailDto GetBook_RdetailById(int id);

        List<Book_RdetailDto> GetBook_RdetailList(int? hotelid);


        IPagedList<Book_RdetailDto> GetBook_RdetailList(int? hotelid, int pageindex, int pagesize);


        void DeleteBook_Rdetail(int id);


        void Addbook_room(book_roomDto book_room);

        void Updatebook_room(book_roomDto book_room);


        book_roomDto Getbook_roomById(int id);

        List<book_roomDto> Getbook_roomList(int? hotelid);


        IPagedList<book_roomDto> Getbook_roomList(int? hotelid, int pageindex, int pagesize);


        void Deletebook_room(int id);


        void AddBookState(BookStateDto BookState);

        void UpdateBookState(BookStateDto BookState);


        BookStateDto GetBookStateById(int id);

        List<BookStateDto> GetBookStateList(int? hotelid);


        IPagedList<BookStateDto> GetBookStateList(int? hotelid, int pageindex, int pagesize);


        void DeleteBookState(int id);


        void Addbreakfirstcoupon(breakfirstcouponDto breakfirstcoupon);

        void Updatebreakfirstcoupon(breakfirstcouponDto breakfirstcoupon);


        breakfirstcouponDto GetbreakfirstcouponById(int id);

        List<breakfirstcouponDto> GetbreakfirstcouponList(int? hotelid);


        IPagedList<breakfirstcouponDto> GetbreakfirstcouponList(int? hotelid, int pageindex, int pagesize);


        void Deletebreakfirstcoupon(int id);


        void Addcard_type(card_typeDto card_type);

        void Updatecard_type(card_typeDto card_type);


        card_typeDto Getcard_typeById(int id);

        List<card_typeDto> Getcard_typeList(int? hotelid);


        IPagedList<card_typeDto> Getcard_typeList(int? hotelid, int pageindex, int pagesize);


        void Deletecard_type(int id);


        void AddcCall(cCallDto cCall);

        void UpdatecCall(cCallDto cCall);


        cCallDto GetcCallById(int id);

        List<cCallDto> GetcCallList(int? hotelid);


        IPagedList<cCallDto> GetcCallList(int? hotelid, int pageindex, int pagesize);


        void DeletecCall(int id);


        void AddcDepartment(cDepartmentDto cDepartment);

        void UpdatecDepartment(cDepartmentDto cDepartment);


        cDepartmentDto GetcDepartmentById(int id);

        List<cDepartmentDto> GetcDepartmentList(int? hotelid);


        IPagedList<cDepartmentDto> GetcDepartmentList(int? hotelid, int pageindex, int pagesize);


        void DeletecDepartment(int id);


        void AddcIndustry(cIndustryDto cIndustry);

        void UpdatecIndustry(cIndustryDto cIndustry);


        cIndustryDto GetcIndustryById(int id);

        List<cIndustryDto> GetcIndustryList(int? hotelid);


        IPagedList<cIndustryDto> GetcIndustryList(int? hotelid, int pageindex, int pagesize);


        void DeletecIndustry(int id);


        void Addcomm_unit(comm_unitDto comm_unit);

        void Updatecomm_unit(comm_unitDto comm_unit);


        comm_unitDto Getcomm_unitById(int id);

        List<comm_unitDto> Getcomm_unitList(int? hotelid);


        IPagedList<comm_unitDto> Getcomm_unitList(int? hotelid, int pageindex, int pagesize);


        void Deletecomm_unit(int id);


        void AddCommission(CommissionDto Commission);

        void UpdateCommission(CommissionDto Commission);


        CommissionDto GetCommissionById(int id);

        List<CommissionDto> GetCommissionList(int? hotelid);


        IPagedList<CommissionDto> GetCommissionList(int? hotelid, int pageindex, int pagesize);


        void DeleteCommission(int id);


        void AddContacts(ContactsDto Contacts);

        void UpdateContacts(ContactsDto Contacts);


        ContactsDto GetContactsById(int id);

        List<ContactsDto> GetContactsList(int? hotelid);


        IPagedList<ContactsDto> GetContactsList(int? hotelid, int pageindex, int pagesize);


        void DeleteContacts(int id);


        void Addcost_type(cost_typeDto cost_type);

        void Updatecost_type(cost_typeDto cost_type);


        cost_typeDto Getcost_typeById(int id);

        List<cost_typeDto> Getcost_typeList(int? hotelid, string name, int? type);


        IPagedList<cost_typeDto> Getcost_typeList(int? hotelid, string name, int? type, int pageindex, int pagesize);


        void Deletecost_type(int id);


        void AddcPost(cPostDto cPost);

        void UpdatecPost(cPostDto cPost);


        cPostDto GetcPostById(int id);

        List<cPostDto> GetcPostList(int? hotelid);


        IPagedList<cPostDto> GetcPostList(int? hotelid, int pageindex, int pagesize);


        void DeletecPost(int id);


        void Addcprotocol(cprotocolDto cprotocol);

        void Updatecprotocol(cprotocolDto cprotocol);


        cprotocolDto GetcprotocolById(int id);

        List<cprotocolDto> GetcprotocolList(int? hotelid);


        IPagedList<cprotocolDto> GetcprotocolList(int? hotelid, int pageindex, int pagesize);


        void Deletecprotocol(int id);


        void AddcprotocolPrice(cprotocolPriceDto cprotocolPrice);

        void UpdatecprotocolPrice(cprotocolPriceDto cprotocolPrice);


        cprotocolPriceDto GetcprotocolPriceById(int id);

        List<cprotocolPriceDto> GetcprotocolPriceList(int? hotelid);


        IPagedList<cprotocolPriceDto> GetcprotocolPriceList(int? hotelid, int pageindex, int pagesize);


        void DeletecprotocolPrice(int id);


        void AddcpType(cpTypeDto cpType);

        void UpdatecpType(cpTypeDto cpType);


        cpTypeDto GetcpTypeById(int id);

        List<cpTypeDto> GetcpTypeList(int? hotelid);


        IPagedList<cpTypeDto> GetcpTypeList(int? hotelid, int pageindex, int pagesize);


        void DeletecpType(int id);


        void Addcredit(creditDto credit);

        void Updatecredit(creditDto credit);


        creditDto GetcreditById(int id);

        List<creditDto> GetcreditList(int? hotelid);


        IPagedList<creditDto> GetcreditList(int? hotelid, int pageindex, int pagesize);


        void Deletecredit(int id);


        void AddcsysType(csysTypeDto csysType);

        void UpdatecsysType(csysTypeDto csysType);


        csysTypeDto GetcsysTypeById(int id);

        List<csysTypeDto> GetcsysTypeList(int? hotelid);


        IPagedList<csysTypeDto> GetcsysTypeList(int? hotelid, int pageindex, int pagesize);


        void DeletecsysType(int id);


        void Addcustomer(customerDto customer);

        void Updatecustomer(customerDto customer);


        customerDto GetcustomerById(int id);

        List<customerDto> GetcustomerList(int? hotelid);


        IPagedList<customerDto> GetcustomerList(int? hotelid, int pageindex, int pagesize);


        void Deletecustomer(int id);


        void AddcustomerState(customerStateDto customerState);

        void UpdatecustomerState(customerStateDto customerState);


        customerStateDto GetcustomerStateById(int id);

        List<customerStateDto> GetcustomerStateList(int? hotelid);


        IPagedList<customerStateDto> GetcustomerStateList(int? hotelid, int pageindex, int pagesize);


        void DeletecustomerState(int id);


        void AddcustomerType(customerTypeDto customerType);

        void UpdatecustomerType(customerTypeDto customerType);


        customerTypeDto GetcustomerTypeById(int id);

        List<customerTypeDto> GetcustomerTypeList(int? hotelid);


        IPagedList<customerTypeDto> GetcustomerTypeList(int? hotelid, int pageindex, int pagesize);


        void DeletecustomerType(int id);


        void AddEntry(EntryDto Entry);

        void UpdateEntry(EntryDto Entry);


        EntryDto GetEntryById(int id);

        List<EntryDto> GetEntryList(int? hotelid);


        IPagedList<EntryDto> GetEntryList(int? hotelid, int pageindex, int pagesize);


        void DeleteEntry(int id);


        void AddExceedScheme(ExceedSchemeDto ExceedScheme);

        void UpdateExceedScheme(ExceedSchemeDto ExceedScheme);


        ExceedSchemeDto GetExceedSchemeById(int id);

        List<ExceedSchemeDto> GetExceedSchemeList(int? hotelid);


        IPagedList<ExceedSchemeDto> GetExceedSchemeList(int? hotelid, int pageindex, int pagesize);


        void DeleteExceedScheme(int id);


        void Addfloor_ld(floor_ldDto floor_ld);

        void Updatefloor_ld(floor_ldDto floor_ld);


        floor_ldDto Getfloor_ldById(int id);

        floor_ldDto Getfloor_ldByName(string name, int? hotelid);

        List<floor_ldDto> Getfloor_ldList(int? hotelid);


        IPagedList<floor_ldDto> Getfloor_ldList(int? hotelid, int pageindex, int pagesize);


        void Deletefloor_ld(int id);


        void Addfloor_manage(floor_manageDto floor_manage);

        void Updatefloor_manage(floor_manageDto floor_manage);


        floor_manageDto Getfloor_manageById(int id);

        floor_manageDto Getfloor_manageByName(string name, string floornumber,int? hotelid);

        List<floor_manageDto> Getfloor_manageList(int? hotelid);


        IPagedList<floor_manageDto> Getfloor_manageList(int? hotelid, string floornumber, int pageindex, int pagesize);


        void Deletefloor_manage(int id);


        void AddFtSet(FtSetDto FtSet);

        void UpdateFtSet(FtSetDto FtSet);


        FtSetDto GetFtSetById(int id);

        List<FtSetDto> GetFtSetList(int? hotelid);


        IPagedList<FtSetDto> GetFtSetList(int? hotelid, int pageindex, int pagesize);


        void DeleteFtSet(int id);


        void AddGoods(GoodsDto Goods);

        void UpdateGoods(GoodsDto Goods);


        GoodsDto GetGoodsById(int id);

        List<GoodsDto> GetGoodsList(int? hotelid, string name, int? goodstype);


        IPagedList<GoodsDto> GetGoodsList(int? hotelid, string name, int? goodstype, int pageindex, int pagesize);


        void DeleteGoods(int id);


        void Addgoods_account(goods_accountDto goods_account);

        void Updategoods_account(goods_accountDto goods_account);


        goods_accountDto Getgoods_accountById(int id);

        List<goods_accountDto> Getgoods_accountList(int? hotelid);


        IPagedList<goods_accountDto> Getgoods_accountList(int? hotelid, int pageindex, int pagesize);


        void Deletegoods_account(int id);


        void Addguest_source(guest_sourceDto guest_source);

        void Updateguest_source(guest_sourceDto guest_source);


        guest_sourceDto Getguest_sourceById(int id);

        List<guest_sourceDto> Getguest_sourceList(int? hotelid);


        IPagedList<guest_sourceDto> Getguest_sourceList(int? hotelid, int pageindex, int pagesize);


        void Deleteguest_source(int id);


        void AddHotel(HotelDto Hotel);

        void UpdateHotel(HotelDto Hotel);


        HotelDto GetHotelById(int id);

        List<HotelDto> GetHotelList(string name, int? parentid, int? istop, int? isdeleted,int? ischain);


        IPagedList<HotelDto> GetHotelList(string name, int? parentid, int? istop, int? isdeleted, int? ischain,int pageindex, int pagesize);


        void DeleteHotel(int id);


        void Addhour_room(hour_roomDto hour_room);

        void Updatehour_room(hour_roomDto hour_room);


        hour_roomDto Gethour_roomById(int id);

        List<hour_roomDto> Gethour_roomList(int? hotelid);


        IPagedList<hour_roomDto> Gethour_roomList(int? hotelid, int pageindex, int pagesize);


        void Deletehour_room(int id);


        void Addhourse_scheme(hourse_schemeDto hourse_scheme);

        void Updatehourse_scheme(hourse_schemeDto hourse_scheme);


        hourse_schemeDto Gethourse_schemeById(int id);

        List<hourse_schemeDto> Gethourse_schemeList(int? hotelid);


        IPagedList<hourse_schemeDto> Gethourse_schemeList(int? hotelid, int pageindex, int pagesize);


        void Deletehourse_scheme(int id);


        void Addinfo(infoDto info);

        void Updateinfo(infoDto info);


        infoDto GetinfoById(int id);

        List<infoDto> GetinfoList(int? hotelid);


        IPagedList<infoDto> GetinfoList(int? hotelid, int pageindex, int pagesize);


        void Deleteinfo(int id);


        void Addlog(logDto log);

        void Updatelog(logDto log);


        logDto GetlogById(int id);

        List<logDto> GetlogList(int? hotelid);


        IPagedList<logDto> GetlogList(int? hotelid, int pageindex, int pagesize);


        void Deletelog(int id);


        void Addmember(memberDto member);

        void Updatemember(memberDto member);


        memberDto GetmemberById(int id);

        List<memberDto> GetmemberList(int? hotelid);


        IPagedList<memberDto> GetmemberList(int? hotelid,int pageindex, int pagesize);


        void Deletemember(int id);


        void AddmemberState(memberStateDto memberState);

        void UpdatememberState(memberStateDto memberState);


        memberStateDto GetmemberStateById(int id);

        List<memberStateDto> GetmemberStateList(int? hotelid);


        IPagedList<memberStateDto> GetmemberStateList(int? hotelid, int pageindex, int pagesize);


        void DeletememberState(int id);


        void AddmemberType(memberTypeDto memberType);

        void UpdatememberType(memberTypeDto memberType);


        memberTypeDto GetmemberTypeById(int id);

        List<memberTypeDto> GetmemberTypeList(int? hotelid);


        IPagedList<memberTypeDto> GetmemberTypeList(int? hotelid, int pageindex, int pagesize);


        void DeletememberType(int id);


        void AddMenu(MenuDto Menu);

        void UpdateMenu(MenuDto Menu);


        MenuDto GetMenuById(int id);

        List<MenuDto> GetMenuList(int? hotelid);


        IPagedList<MenuDto> GetMenuList(int? parentid,int? hotelid, int pageindex, int pagesize);


        void DeleteMenu(int id);


        void Addmeth_pay(meth_payDto meth_pay);

        void Updatemeth_pay(meth_payDto meth_pay);


        meth_payDto Getmeth_payById(int id);

        List<meth_payDto> Getmeth_payList();


        IPagedList<meth_payDto> Getmeth_payList( int pageindex, int pagesize);


        void Deletemeth_pay(int id);


        void Addmodes(modesDto modes);

        void Updatemodes(modesDto modes);


        modesDto GetmodesById(int id);

        List<modesDto> GetmodesList(int? hotelid);

        modesDto GetmodesByName(string name, int? hotelid);


        IPagedList<modesDto> GetmodesList(int? hotelid, int pageindex, int pagesize);


        void Deletemodes(int id);


        void AddmRecords(mRecordsDto mRecords);

        void UpdatemRecords(mRecordsDto mRecords);


        mRecordsDto GetmRecordsById(int id);

        List<mRecordsDto> GetmRecordsList(int? hotelid);


        IPagedList<mRecordsDto> GetmRecordsList(int? hotelid, int pageindex, int pagesize);


        void DeletemRecords(int id);


        void AddmtPrice(mtPriceDto mtPrice);

        void UpdatemtPrice(mtPriceDto mtPrice);


        mtPriceDto GetmtPriceById(int id);

        List<mtPriceDto> GetmtPriceList(int? hotelid);


        IPagedList<mtPriceDto> GetmtPriceList(int? hotelid, int pageindex, int pagesize);


        void DeletemtPrice(int id);


        void Addoccu_infor(occu_inforDto occu_infor);

        void Updateoccu_infor(occu_inforDto occu_infor);


        occu_inforDto Getoccu_inforById(int id);

        List<occu_inforDto> Getoccu_inforList(int? hotelid);


        IPagedList<occu_inforDto> Getoccu_inforList(int? hotelid, int pageindex, int pagesize);


        void Deleteoccu_infor(int id);


        void Addoccu_informx(occu_informxDto occu_informx);

        void Updateoccu_informx(occu_informxDto occu_informx);


        occu_informxDto Getoccu_informxById(int id);

        List<occu_informxDto> Getoccu_informxList(int? hotelid);


        IPagedList<occu_informxDto> Getoccu_informxList(int? hotelid, int pageindex, int pagesize);


        void Deleteoccu_informx(int id);


        void Addorder_ext(order_extDto order_ext);

        void Updateorder_ext(order_extDto order_ext);


        order_extDto Getorder_extById(int id);

        List<order_extDto> Getorder_extList(int? hotelid);


        IPagedList<order_extDto> Getorder_extList(int? hotelid, int pageindex, int pagesize);


        void Deleteorder_ext(int id);


        void Addorder_infor(order_inforDto order_infor);

        void Updateorder_infor(order_inforDto order_infor);


        order_inforDto Getorder_inforById(int id);

        List<order_inforDto> Getorder_inforList(int? hotelid);


        IPagedList<order_inforDto> Getorder_inforList(int? hotelid, int pageindex, int pagesize);


        void Deleteorder_infor(int id);


        void AddpaymentMoney(paymentMoneyDto paymentMoney);

        void UpdatepaymentMoney(paymentMoneyDto paymentMoney);


        paymentMoneyDto GetpaymentMoneyById(int id);

        List<paymentMoneyDto> GetpaymentMoneyList(int? hotelid);


        IPagedList<paymentMoneyDto> GetpaymentMoneyList(int? hotelid, int pageindex, int pagesize);


        void DeletepaymentMoney(int id);


        void Addprice_type(price_typeDto price_type);

        void Updateprice_type(price_typeDto price_type);


        price_typeDto Getprice_typeById(int id);

        List<price_typeDto> Getprice_typeList(int? hotelid);


        IPagedList<price_typeDto> Getprice_typeList(int? hotelid, int pageindex, int pagesize);


        void Deleteprice_type(int id);


        void Addprint(printDto print);

        void Updateprint(printDto print);


        printDto GetprintById(int id);

        List<printDto> GetprintList(int? hotelid);


        IPagedList<printDto> GetprintList(int? hotelid, int pageindex, int pagesize);


        void Deleteprint(int id);


        void Addreal_mode(real_modeDto real_mode);

        void Updatereal_mode(real_modeDto real_mode);


        real_modeDto Getreal_modeById(int id);

        List<real_modeDto> Getreal_modeList(int? hotelid);


        IPagedList<real_modeDto> Getreal_modeList(int? hotelid, int pageindex, int pagesize);


        void Deletereal_mode(int id);


        void Addreal_state(real_stateDto real_state);

        void Updatereal_state(real_stateDto real_state);


        real_stateDto Getreal_stateById(int id);

        List<real_stateDto> Getreal_stateList(int? hotelid);


        IPagedList<real_stateDto> Getreal_stateList(int? hotelid, int pageindex, int pagesize);


        void Deletereal_state(int id);


        void Addreceipt(receiptDto receipt);

        void Updatereceipt(receiptDto receipt);


        receiptDto GetreceiptById(int id);

        List<receiptDto> GetreceiptList(int? hotelid);


        IPagedList<receiptDto> GetreceiptList(int? hotelid, int pageindex, int pagesize);


        void Deletereceipt(int id);


        void AddRemaker(RemakerDto Remaker);

        void UpdateRemaker(RemakerDto Remaker);


        RemakerDto GetRemakerById(int id);

        List<RemakerDto> GetRemakerList(int? hotelid);


        IPagedList<RemakerDto> GetRemakerList(int? hotelid, int pageindex, int pagesize);


        void DeleteRemaker(int id);


        void AddRepair(RepairDto Repair);

        void UpdateRepair(RepairDto Repair);


        RepairDto GetRepairById(int id);

        List<RepairDto> GetRepairList(int? hotelid);


        IPagedList<RepairDto> GetRepairList(int? hotelid, int pageindex, int pagesize);


        void DeleteRepair(int id);


        void AddRoleMenu(RoleMenuDto RoleMenu);

        void UpdateRoleMenu(RoleMenuDto RoleMenu);


        RoleMenuDto GetRoleMenuById(int id);

        List<RoleMenuDto> GetRoleMenuList(int? hotelid,int? roleid);


        IPagedList<RoleMenuDto> GetRoleMenuList(int? hotelid, int pageindex, int pagesize);


        void DeleteRoleMenu(int id);


        void Addroom_feature(room_featureDto room_feature);

        void Updateroom_feature(room_featureDto room_feature);


        room_featureDto Getroom_featureById(int id);

        List<room_featureDto> Getroom_featureList(int? hotelid);


        IPagedList<room_featureDto> Getroom_featureList(int? hotelid, int pageindex, int pagesize);


        void Deleteroom_feature(int id);


        void Addroom_number(room_numberDto room_number);

        void Updateroom_number(room_numberDto room_number);


        room_numberDto Getroom_numberById(int id);

        room_numberDto Getroom_numberByroomnumber(int? hotelid, string floorid, string floormanage, string roomnumber);

        List<room_numberDto> Getroom_numberList(int? hotelid);


        IPagedList<room_numberDto> Getroom_numberList(int? hotelid, int pageindex, int pagesize);


        void Deleteroom_number(int id);


        void Addroom_state(room_stateDto room_state);

        void Updateroom_state(room_stateDto room_state);


        room_stateDto Getroom_stateById(int id);

        List<room_stateDto> Getroom_stateList(int? hotelid);


        IPagedList<room_stateDto> Getroom_stateList(int? hotelid, int pageindex, int pagesize);


        void Deleteroom_state(int id);


        void Addroom_type(room_typeDto room_type);

        void Updateroom_type(room_typeDto room_type);


        room_typeDto Getroom_typeById(int id);

        room_typeDto Getroom_typeByName(int? hotelid, string roomtypename);

        List<room_typeDto> Getroom_typeList(int? hotelid);


        IPagedList<room_typeDto> Getroom_typeList(int? hotelid, int pageindex, int pagesize);


        void Deleteroom_type(int id);


        void Addroom_type_image(room_type_imageDto room_type_image);

        void Updateroom_type_image(room_type_imageDto room_type_image);


        room_type_imageDto Getroom_type_imageById(int id);

        List<room_type_imageDto> Getroom_type_imageList(int? hotelid);


        IPagedList<room_type_imageDto> Getroom_type_imageList(int? hotelid, int pageindex, int pagesize);


        void Deleteroom_type_image(int id);


        void Addroomcoupon(roomcouponDto roomcoupon);

        void Updateroomcoupon(roomcouponDto roomcoupon);


        roomcouponDto GetroomcouponById(int id);

        List<roomcouponDto> GetroomcouponList(int? hotelid);


        IPagedList<roomcouponDto> GetroomcouponList(int? hotelid, int pageindex, int pagesize);


        void Deleteroomcoupon(int id);


        void Addroomman(roommanDto roomman);

        void Updateroomman(roommanDto roomman);


        roommanDto GetroommanById(int id);

        List<roommanDto> GetroommanList(int? hotelid);


        IPagedList<roommanDto> GetroommanList(int? hotelid, int pageindex, int pagesize);


        void Deleteroomman(int id);


        void Addroomrent(roomrentDto roomrent);

        void Updateroomrent(roomrentDto roomrent);


        roomrentDto GetroomrentById(int id);

        List<roomrentDto> GetroomrentList(int? hotelid);


        IPagedList<roomrentDto> GetroomrentList(int? hotelid, int pageindex, int pagesize);


        void Deleteroomrent(int id);


        void Addsale_man(sale_manDto sale_man);

        void Updatesale_man(sale_manDto sale_man);


        sale_manDto Getsale_manById(int id);

        List<sale_manDto> Getsale_manList(int? hotelid);


        IPagedList<sale_manDto> Getsale_manList(int? hotelid, int pageindex, int pagesize);


        void Deletesale_man(int id);


        void AddShift(ShiftDto Shift);

        void UpdateShift(ShiftDto Shift);


        ShiftDto GetShiftById(int id);

        List<ShiftDto> GetShiftList(int? hotelid);


        IPagedList<ShiftDto> GetShiftList(int? hotelid, int pageindex, int pagesize);


        void DeleteShift(int id);


        void AddShift_Exc(Shift_ExcDto Shift_Exc);

        void UpdateShift_Exc(Shift_ExcDto Shift_Exc);


        Shift_ExcDto GetShift_ExcById(int id);

        List<Shift_ExcDto> GetShift_ExcList(int? hotelid);


        IPagedList<Shift_ExcDto> GetShift_ExcList(int? hotelid, int pageindex, int pagesize);


        void DeleteShift_Exc(int id);


        void AddshopInfo(shopInfoDto shopInfo);

        void UpdateshopInfo(shopInfoDto shopInfo);


        shopInfoDto GetshopInfoById(int id);

        List<shopInfoDto> GetshopInfoList(int? hotelid);


        IPagedList<shopInfoDto> GetshopInfoList(int? hotelid, int pageindex, int pagesize);


        void DeleteshopInfo(int id);


        void AddSincethehous(SincethehousDto Sincethehous);

        void UpdateSincethehous(SincethehousDto Sincethehous);


        SincethehousDto GetSincethehousById(int id);

        List<SincethehousDto> GetSincethehousList(int? hotelid);


        IPagedList<SincethehousDto> GetSincethehousList(int? hotelid, int pageindex, int pagesize);


        void DeleteSincethehous(int id);


        void AddSuoRoom(SuoRoomDto SuoRoom);

        void UpdateSuoRoom(SuoRoomDto SuoRoom);


        SuoRoomDto GetSuoRoomById(int id);

        List<SuoRoomDto> GetSuoRoomList(int? hotelid);


        IPagedList<SuoRoomDto> GetSuoRoomList(int? hotelid, int pageindex, int pagesize);


        void DeleteSuoRoom(int id);


        void AddSuoSys(SuoSysDto SuoSys);

        void UpdateSuoSys(SuoSysDto SuoSys);


        SuoSysDto GetSuoSysById(int id);

        List<SuoSysDto> GetSuoSysList(int? hotelid);


        IPagedList<SuoSysDto> GetSuoSysList(int? hotelid, int pageindex, int pagesize);


        void DeleteSuoSys(int id);


        void AddSysParamter(SysParamterDto SysParamter);

        void UpdateSysParamter(SysParamterDto SysParamter);


        SysParamterDto GetSysParamterById(int id);

        List<SysParamterDto> GetSysParamterList(int? hotelid);


        IPagedList<SysParamterDto> GetSysParamterList(int? hotelid, int pageindex, int pagesize);


        void DeleteSysParamter(int id);


        void AddTypeScheme(TypeSchemeDto TypeScheme);

        void UpdateTypeScheme(TypeSchemeDto TypeScheme);


        TypeSchemeDto GetTypeSchemeById(int id);

        List<TypeSchemeDto> GetTypeSchemeList(int? hotelid);


        IPagedList<TypeSchemeDto> GetTypeSchemeList(int? hotelid, int pageindex, int pagesize);


        void DeleteTypeScheme(int id);


        void AddUserInfo(UserInfoDto UserInfo);

        void UpdateUserInfo(UserInfoDto UserInfo);


        UserInfoDto GetUserInfoById(int id);

        List<UserInfoDto> GetUserInfoList(int? hotelid);


        IPagedList<UserInfoDto> GetUserInfoList(int? hotelid, int pageindex, int pagesize);


        void DeleteUserInfo(int id);


        void AddUsers(UsersDto Users);

        void UpdateUsers(UsersDto Users);


        UsersDto GetUsersById(int id);

        List<UsersDto> GetUsersList(int? hotelid);


        IPagedList<UsersDto> GetUsersList(int? hotelid, int pageindex, int pagesize);


        void DeleteUsers(int id);


        void AdduserType(userTypeDto userType);

        void UpdateuserType(userTypeDto userType);


        userTypeDto GetuserTypeById(int id);

        List<userTypeDto> GetuserTypeList(int? hotelid);


        IPagedList<userTypeDto> GetuserTypeList(int? hotelid, int pageindex, int pagesize);


        void DeleteuserType(int id);


        void AddZD_hourse(ZD_hourseDto ZD_hourse);

        void UpdateZD_hourse(ZD_hourseDto ZD_hourse);


        ZD_hourseDto GetZD_hourseById(int id);

        List<ZD_hourseDto> GetZD_hourseList(int? hotelid);


        IPagedList<ZD_hourseDto> GetZD_hourseList(int? hotelid, int pageindex, int pagesize);


        void DeleteZD_hourse(int id);

    }
}
