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
    
    public partial class HotelDto : BaseDtoEntity
    {
        
        public string HotelName { get; set; }
        public int IsChain { get; set; }
        public int IsTop { get; set; }
        public Nullable<int> ParentId { get; set; }
        public Nullable<int> IsDeleted { get; set; }
        public Nullable<System.DateTime> Expiretime { get; set; }
        public Nullable<System.DateTime> Registertime { get; set; }
        public int CreateorId { get; set; }
        public string CreateorIp { get; set; }
        public Nullable<System.DateTime> Createtime { get; set; }
        public Nullable<System.DateTime> Updatetime { get; set; }
    		public virtual HotelDto UserHotel { get; set; }
    		}
}
