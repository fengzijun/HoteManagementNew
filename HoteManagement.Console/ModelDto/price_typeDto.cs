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
    
    public partial class price_typeDto : BaseDtoEntity
    {
        
        public Nullable<int> hotelid { get; set; }
        public string pt_name { get; set; }
        public string remark { get; set; }
    		public virtual HotelDto UserHotel { get; set; }
    		}
}
