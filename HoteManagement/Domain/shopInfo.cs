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
    
    public partial class shopInfo : BaseEntity
    {
        
        public Nullable<int> hotelid { get; set; }
        public string shop_Name { get; set; }
        public string shop_LxMan { get; set; }
        public string Shop_Telphone { get; set; }
        public string Shop_chuanzen { get; set; }
        public string Shop_Province { get; set; }
        public string Shop_City { get; set; }
        public string Shop_Area { get; set; }
        public string Shop_Address { get; set; }
        public string Shop_x { get; set; }
        public string Shop_y { get; set; }
        public string Shop_Remaker { get; set; }
        public Nullable<System.DateTime> Shop_date { get; set; }
    		public virtual Hotel UserHotel { get; set; }
    		}
}
