//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace HoteManagement.Console.Model
{
    
    public partial class UserInfoDto : BaseDtoEntity
    {
        public int LoginID { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string UserRealName { get; set; }
        public string UserSex { get; set; }
        public string UserIDCardNumber { get; set; }
        public string UserEmail { get; set; }
        public string UserTel { get; set; }
        public string UserMobile { get; set; }
        public string UserAddress { get; set; }
        public string UserZipcode { get; set; }
        public Nullable<System.DateTime> UserRegTime { get; set; }
        public Nullable<System.DateTime> UserEndTime { get; set; }
        public string UserVerify { get; set; }
        public string UserFeeType { get; set; }
        public string UserType { get; set; }
        public string UserState { get; set; }
        public string UserCity { get; set; }
        public string OrgName { get; set; }
        public string OrgUnitName { get; set; }
        public string UserFax { get; set; }
        public string Certi_id { get; set; }
        public string DealMan { get; set; }
        public string DealmanTel { get; set; }
        public string UserLoginType { get; set; }
        public string UserSignPic { get; set; }
        public Nullable<bool> Status_CA { get; set; }
    		public virtual HotelDto UserHotel { get; set; }
    		}
}
