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
    
    public partial class roomcoupon : BaseEntity
    {
        public int? hotelid { get; set; }
        public Nullable<int> bookid { get; set; }
        public string roomnum { get; set; }
        public Nullable<decimal> price { get; set; }
        public string creator { get; set; }
        public Nullable<System.DateTime> createtime { get; set; }
    		public virtual Hotel UserHotel { get; set; }
    		}
}
