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
    
    public partial class ZD_hourse : BaseEntity
    {
        
        public Nullable<int> hotelid { get; set; }
        public Nullable<System.TimeSpan> latest { get; set; }
        public Nullable<int> Buffer { get; set; }
        public Nullable<int> tixing { get; set; }
        public Nullable<System.TimeSpan> beigin { get; set; }
        public Nullable<System.TimeSpan> endtime { get; set; }
    		public virtual Hotel UserHotel { get; set; }
    		}
}
