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
    
    public partial class room_numberDto : BaseDtoEntity
    {
        
        public Nullable<int> hotelid { get; set; }
        public string Rn_flloeld { get; set; }
        public string Rn_floor { get; set; }
        public string Rn_roomNum { get; set; }
        public Nullable<int> Rn_state { get; set; }
        public Nullable<int> Rn_room { get; set; }
        public Nullable<int> Rn_Type { get; set; }
        public Nullable<decimal> Rn_price { get; set; }
        public string Rn_remaker { get; set; }
        public string Room_suod { get; set; }
        public Nullable<int> Room_sort { get; set; }
        public Nullable<int> Rn_Tobe { get; set; }
        public string Rn_suo { get; set; }
    		public virtual HotelDto UserHotel { get; set; }
    		}
}
