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
    
    public partial class creditDto : BaseDtoEntity
    {
        
        public Nullable<int> hotelid { get; set; }
        public Nullable<int> customerid { get; set; }
        public string roomnum { get; set; }
        public string username { get; set; }
        public string no { get; set; }
        public string creditno { get; set; }
        public Nullable<System.DateTime> expiredtime { get; set; }
        public string remark { get; set; }
        public string expire { get; set; }
        public Nullable<decimal> creditmoney { get; set; }
        public string authorizationcode { get; set; }
        public string documentno { get; set; }
        public Nullable<System.DateTime> createtime { get; set; }
        public string creator { get; set; }
    		public virtual HotelDto UserHotel { get; set; }
    		}
}
