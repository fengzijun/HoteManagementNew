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
    
    public partial class hour_room : BaseEntity
    {
        
        public Nullable<int> hotelid { get; set; }
        public Nullable<int> hs_room_id { get; set; }
        public string hs_name { get; set; }
        public string hs_start_long { get; set; }
        public Nullable<decimal> hs_start_price { get; set; }
        public string hs_add_time { get; set; }
        public Nullable<decimal> hs_add_price { get; set; }
        public string hs_min_time { get; set; }
        public Nullable<decimal> hs_min_price { get; set; }
        public string hs_max_time { get; set; }
        public Nullable<int> hs_type_id { get; set; }
        public Nullable<int> hs_jgtype_id { get; set; }
        public Nullable<int> hs_source_id { get; set; }
        public Nullable<System.TimeSpan> lostTime { get; set; }
        public Nullable<int> MtID { get; set; }
    		public virtual Hotel UserHotel { get; set; }
    		}
}
