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

namespace HoteManagement.Domain
{
    
    public partial class Shift_Exc : BaseEntity
    {
        
        public Nullable<int> hotelid { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> Good_Account_Id { get; set; }
        public Nullable<int> meth_pay_id { get; set; }
        public Nullable<int> shift_id { get; set; }
        public string shift_state { get; set; }
        public Nullable<decimal> shift_money { get; set; }
        public Nullable<System.DateTime> shift_dateTime { get; set; }
        public string ga_name { get; set; }
        public string ga_number { get; set; }
        public string ga_unit { get; set; }
        public Nullable<int> ga_num { get; set; }
        public Nullable<decimal> ga_price { get; set; }
        public Nullable<int> ga_zffs_id { get; set; }
        public Nullable<System.DateTime> ga_date { get; set; }
        public Nullable<int> ga_Type { get; set; }
        public Nullable<decimal> ga_sum_price { get; set; }
        public string Remark { get; set; }
        public string ga_roomNumber { get; set; }
    		public virtual Hotel UserHotel { get; set; }
    		}
}
