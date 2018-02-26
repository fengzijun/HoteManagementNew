using HoteManagement.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoteManagement.Service.Sys
{
    public interface ISysService
    {
         int GetBannerCount();


         void AddBanner(bannerDto bannerDto);
    
        

     IPagedList<bannerDto> GetBannerPageList(int pageindex, int pagesize);


    bannerDto GetBannerByBannerId(string id);



          void UpdateBanner(bannerDto banner);


    SysParamterDto GetSysParamterById(int id);

    void UpdateSysParamter(SysParamterDto sysParamter);


    void AddSysParamter(SysParamterDto sysParamter);

    void AddExceedScheme(ExceedSchemeDto exceedScheme);


    void UpdateExceedScheme(ExceedSchemeDto exceedScheme);


    ExceedSchemeDto GetExceedSchemeById(int id);


    List<ExceedSchemeDto> GetExceedSchemeList(int? typeroom);


    List<cCallDto> GetCCallList();


    cCallDto GetCCall(int id);



    List<cpTypeDto> GetcptypeList();


    cpTypeDto Getcptype(int id);



    List<cDepartmentDto> GetcDepartmentList();


    cDepartmentDto GetcDepartment(int id);


    List<cPostDto> GetcPostList();


    cPostDto GetcPost(int id);

        List<csysTypeDto> GetcsysTypeList();


        List<customerTypeDto> GetcustomerTypeList();


        List<customerStateDto> GetcustomerStateList();


        customerStateDto GetcustomerState(int id);




        List<cIndustryDto> GetcIndustryList();


        cIndustryDto GetcIndustry(int id);


        List<cost_typeDto> GetCostType(int? ct_iftype, int? ct_categories);


        GoodsDto GetGoods(int id);



        List<AddPriceDto> GetAddPriceList();



        void AddmRecords(mRecordsDto mRecords);


        List<mRecordsDto> GetmRecords(string mid);



        List<mRecordsDto> GetmRecordsByType(string mid);


        List<mRecordsDto> GetmRecordsByType2(string mid);


        void Addfloor_manage(floor_manageDto floor_Manage);


        void Updatefloor_manage(floor_manageDto floor_Manage);


        List<floor_manageDto> Getfloor_manageList();


        floor_manageDto GetFloor_ManageById(int id);

        void Updategoods(GoodsDto goods);


        void Addgoods(GoodsDto goods);


        List<GoodsDto> GetGoodsList(int? Goods_ifType, int? Goods_categories);


        IPagedList<GoodsDto> GetGoodsList(int? Goods_ifType, int? Goods_categories, int pageindex, int pagesize);


        cost_typeDto GetCost_Type(int id);

        void UpdateCostType(cost_typeDto cost_Type);


        void AddCostType(cost_typeDto cost_Type);

        void AddCustomerstate(customerDto customer);


        void UpdateCustomerstate(customerDto customer);


        void AddcIndustry(cIndustryDto cIndustry);


        void UpdatecIndustry(cIndustryDto customer);


        void AddcpType(cpTypeDto cpType);


        void UpdatecpType(cpTypeDto cpType);


        void AddcsysType(csysTypeDto csysType);


        void UpdatecpType(csysTypeDto csysType);


        void AddcDepartment(cDepartmentDto cDepartment);


        void UpdatecDepartment(cDepartmentDto cDepartment);


        void AddcPost(cPostDto cPost);


        void UpdatecPost(cPostDto cPost);


        void AddcPost(cCallDto cCall);


        void UpdatecPost(cCallDto cCall);


        void DeleteCustomerState(int id);

        void DeleteCustomType(int id);


        void DeletecIndustry(int id);


        void DeletecpType(int id);


        void DeletecsysType(int id);


        void DeletecDepartment(int id);


        void DeletecPost(int id);


        void DeletecCall(int id);



        IPagedList<cost_typeDto> GetCostType(int? ct_iftype, int? ct_categories, string name, int pageindex, int pagesize);



        void AddShift(ShiftDto shift);


        void UpdateShift(ShiftDto shift);


        ShiftDto GetShiftById(int id);


        List<ShiftDto> GetShiftList();


        void DeleteShift(int id);


        void AddShiftInfo(shopInfoDto ShiftInfo);


        void UpdateShiftInfo(shopInfoDto ShiftInfo);


        shopInfoDto GetShiftInfoById(int id);


        List<shopInfoDto> GetShiftInfoList();


        void DeleteShiftInfo(int id);


        void Addfloor_id(floor_ldDto floor_id);


        void Updatefloor_id(floor_ldDto floor_id);

        floor_ldDto Getfloor_idById(int id);


        List<floor_ldDto> Getfloor_idList();


        void Deletefloor_id(int id);



        void Addprint(printDto print);


        void Updateprint(printDto print);


        printDto GetprintById(int id);


        List<printDto> GetprintList();


        void Deleteprint(int id);


        void AddSuoSys(SuoSysDto SuoSys);


        void UpdateSuoSys(SuoSysDto SuoSys);


        SuoSysDto GetSuoSysById(int id);


        List<SuoSysDto> GetSuoSysList(string name);


        void DeleteSuoSys(int id);


        void AddSuoRoom(SuoRoomDto SuoRoom);


        void UpdateSuoRoom(SuoRoomDto SuoRoom);


        SuoRoomDto GetSuoRoomById(int id);


        List<SuoRoomDto> GetSuoRoomList(string type, string roomnumber);


        void DeleteSuoRoom(int id);



        void Addmenu(MenuDto menu);


        void Updatemenu(MenuDto menu);


        MenuDto GetmenuById(int id);


        List<MenuDto> GetmenuList();


        IPagedList<MenuDto> GetmenuList(int pageindex, int pagesize);


        void Deletemenu(int id);



        void AddShift_Exc(Shift_ExcDto Shift_Exc);


        void UpdateShift_Exc(Shift_ExcDto Shift_Exc);


        Shift_ExcDto GetShift_ExcById(int id);


        List<Shift_ExcDto> GetShift_ExcList();


        IPagedList<Shift_ExcDto> GetShift_ExcList(int pageindex, int pagesize);


        void DeleteShift_Exc(int id);



        void Addreal_mode(real_modeDto real_mode);


        void Updatereal_mode(real_modeDto real_mode);


        real_modeDto Getreal_modeById(int id);


        List<real_modeDto> Getreal_modeList();

        IPagedList<real_modeDto> Getreal_modeList(int pageindex, int pagesize);


        void Deletereal_mode(int id);


        void AddRemaker(RemakerDto Remaker);


        void UpdateRemaker(RemakerDto Remaker);


        RemakerDto GetRemakerById(int id);


        List<RemakerDto> GetRemakerList();


        IPagedList<RemakerDto> GetRemakerList(int pageindex, int pagesize);


        void DeleteRemaker(int id);


        void AddSincethehous(SincethehousDto Sincethehous);


        void UpdateSincethehous(SincethehousDto Sincethehous);


        SincethehousDto GetSincethehousById(int id);
      

        List<SincethehousDto> GetSincethehousList();
     

        IPagedList<SincethehousDto> GetSincethehousList(int pageindex, int pagesize);
      

         void DeleteSincethehous(int id);
      


    }
}
