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
    
    public partial class Sincethehous : BaseEntity
    {
        
        public Nullable<int> hotelid { get; set; }
        public string hs_Numberno { get; set; }
        public string hs_room { get; set; }
        public string hs_yuany { get; set; }
        public Nullable<System.DateTime> hs_date { get; set; }
        public Nullable<System.DateTime> hs_ksDate { get; set; }
        public string hs_ylDate { get; set; }
        public string hs_Documentno { get; set; }
        public Nullable<int> hs_type { get; set; }
        public string hs_people { get; set; }
        public string hs_Result { get; set; }
        public string hs_remaker { get; set; }
    		public virtual Hotel UserHotel { get; set; }
    		}
}
