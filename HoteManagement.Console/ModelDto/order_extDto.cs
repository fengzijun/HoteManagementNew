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
    
    public partial class order_extDto : BaseDtoEntity
    {
        
        public string roomnum { get; set; }
        public string ordreno { get; set; }
        public Nullable<int> hotelid { get; set; }
        public Nullable<decimal> price { get; set; }
        public string name { get; set; }
        public Nullable<int> type { get; set; }
        public Nullable<int> num { get; set; }
        public Nullable<System.DateTime> opentime { get; set; }
        public string creator { get; set; }
        public Nullable<System.DateTime> createtime { get; set; }
    		public virtual HotelDto UserHotel { get; set; }
    		}
}
