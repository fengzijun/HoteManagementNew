using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoteManagement.Domain
{
    public class Org_Business:BaseEntity
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
