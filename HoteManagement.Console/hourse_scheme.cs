//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace HoteManagement.Console
{
    using System;
    using System.Collections.Generic;
    
    public partial class hourse_scheme
    {
        public int Id { get; set; }
        public Nullable<int> hotelid { get; set; }
        public Nullable<int> hs_room { get; set; }
        public string hs_name { get; set; }
        public Nullable<decimal> hs_psmoney { get; set; }
        public string hs_Discount { get; set; }
        public Nullable<int> hs_type { get; set; }
        public Nullable<int> hs_jgtype { get; set; }
        public Nullable<int> hs_source_id { get; set; }
        public Nullable<bool> Hs_isAll { get; set; }
        public Nullable<System.DateTime> Hs_Strat { get; set; }
        public Nullable<System.DateTime> Hs_End { get; set; }
        public Nullable<decimal> Hs_zdr { get; set; }
        public string Hs_Reamrk { get; set; }
    }
}
