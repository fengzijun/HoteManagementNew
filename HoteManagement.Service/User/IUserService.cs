using HoteManagement.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoteManagement.Service.User
{
    public interface IUserService
    {

        bool CheckAccountUser(string username, string pwd);


        void AddAccountUser(Accounts_UsersDto user);


        void UpdateAccountUser(Accounts_UsersDto user);


        Accounts_UsersDto GetAccountUser(string username, string pwd);

        Accounts_UsersDto GetAccountUser(string username);


        Accounts_UsersDto GetAccountUser(int id);


        UserMenus GetAccountMenus(int userid);



        customerDto GetCustomer(string account);


        customerDto GetCustomerById(int id);


        void UpdateCustomer(customerDto customer);


        List<CommissionDto> GetCommission(string account);


        CommissionDto GetCommissionById(int id);


        List<CommissionDto> GetCommissionByIds(int[] ids);


        void Addcprotocol(cprotocolDto cprotocol);


        void Updatecprotocol(cprotocolDto cprotocol);


        cprotocolDto GetcprotocolById(int id);

        List<cprotocolDto> Getcprotocol(string account);


        List<cprotocolPriceDto> GetcprotocolPrice(string accounts, int? cpid);


        void AddcprotocolPrice(cprotocolPriceDto cprotocolPrice);


        void UpdatecprotocolPrice(cprotocolPriceDto cprotocolPrice);


        List<ContactsDto> GetContacts(string account);


        void AddMember(memberDto member);


        void UpdateMember(memberDto member);



        memberDto GetMember(int id);

        memberStateDto GetMemberState(int id);


        List<memberTypeDto> GetmembertypeList(string name, int? stateid, int? mtype, DateTime? startime, DateTime? endtime);



        memberTypeDto Getmembertype(int id);


        void AddMemberType(memberTypeDto memberType);


        void UpdateMemberType(memberTypeDto memberType);


        List<UsersDto> GetUserList(string userid, int? id, int? usertype);


        List<userTypeDto> GetUserTypeList(int? typeid);

        userTypeDto GetUserType(int id);


        void AddUserType(userTypeDto userType);


        void UpdateUserType(userTypeDto userType);

        List<mtPriceDto> GetMtPrice(int mtid);



        void AddAccountsUserRoles(Accounts_UserRolesDto AccountsUserRoles);


        void UpdateAccountsUserRoles(Accounts_UserRolesDto AccountsUserRoles);


        Accounts_UserRolesDto GetAccountsUserRolesById(int id);


        List<Accounts_UserRolesDto> GetAccountsUserRolesList();


        void DeleteAccountsUserRoles(int id);


        void AddAccounts_Roles(Accounts_RolesDto Accounts_Roles);


        void UpdateAccounts_Roles(Accounts_RolesDto Accounts_Roles);


        Accounts_RolesDto GetAccounts_RolesById(int id);


        List<Accounts_UserRolesDto> GetAccounts_RolesList();


        void DeleteAccounts_Roles(int id);
       

    }
}
