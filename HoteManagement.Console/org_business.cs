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
    
    public partial class org_business
    {
        public int id { get; set; }
        public string projectname { get; set; }
        public string buildunit { get; set; }
        public string compileunit { get; set; }
        public string auditunit { get; set; }
        public string projecttype { get; set; }
        public string projectsummary { get; set; }
        public string contract { get; set; }
        public string report { get; set; }
        public string price { get; set; }
        public string other { get; set; }
        public Nullable<System.DateTime> createtime { get; set; }
        public Nullable<System.DateTime> updatetime { get; set; }
        public string orgname { get; set; }
        public string creator { get; set; }
        public Nullable<int> creatorid { get; set; }
        public string audituser { get; set; }
        public Nullable<int> audituserid { get; set; }
        public Nullable<int> statues { get; set; }
    }
}