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
    
    public partial class goods_account : BaseEntity
    {
        
        public Nullable<int> hotelid { get; set; }
        public string ga_name { get; set; }
        public string ga_number { get; set; }
        public string ga_roomNumber { get; set; }
        public string ga_unit { get; set; }
        public Nullable<int> ga_num { get; set; }
        public Nullable<decimal> ga_price { get; set; }
        public Nullable<int> ga_zffs_id { get; set; }
        public Nullable<System.DateTime> ga_date { get; set; }
        public string ga_people { get; set; }
        public Nullable<int> ga_Type { get; set; }
        public Nullable<decimal> ga_sum_price { get; set; }
        public string ga_remker { get; set; }
        public string ga_occuid { get; set; }
        public string ga_sfacount { get; set; }
        public Nullable<int> ga_isjz { get; set; }
        public string ga_goodNo { get; set; }
        public Nullable<int> ga_isys { get; set; }
        public string ga_Account { get; set; }
        public Nullable<int> ga_jsfs { get; set; }
    		public virtual Hotel UserHotel { get; set; }
    		}
}
