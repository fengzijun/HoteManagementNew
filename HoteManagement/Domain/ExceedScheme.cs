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
    
    public partial class ExceedScheme : BaseEntity
    {
        
        public Nullable<int> hotelid { get; set; }
        public int TypeRoom { get; set; }
        public Nullable<int> GraceTime { get; set; }
        public Nullable<int> Earlyapart { get; set; }
        public Nullable<decimal> EarlyapartAddP { get; set; }
        public Nullable<int> EarlyInsufficient { get; set; }
        public Nullable<int> EarlyInExceed { get; set; }
        public Nullable<decimal> EarlyInAddPri { get; set; }
    		public virtual Hotel UserHotel { get; set; }
    		}
}
