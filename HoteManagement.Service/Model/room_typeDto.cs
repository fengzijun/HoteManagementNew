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

namespace HoteManagement.Service.Model
{
    
    public partial class room_typeDto : BaseDtoEntity
    {
        
        public Nullable<int> hotelid { get; set; }
        public string room_number { get; set; }
        public string room_name { get; set; }
        public string room_hour { get; set; }
        public Nullable<decimal> room_listedmoney { get; set; }
        public Nullable<decimal> room_zmmoney { get; set; }
        public string room_hourmation { get; set; }
        public string room_reamker { get; set; }
        public string room_image { get; set; }
        public Nullable<decimal> room_ealry_price { get; set; }
        public Nullable<decimal> room_Moth_price { get; set; }
        public Nullable<int> room_Bfb { get; set; }
    	public virtual HotelDto UserHotel { get; set; }
    		}
}
