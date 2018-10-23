using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoteManagement.Web.Models.Api
{
    public class AuditProjectSettlementRequest
    {
        public int id { get; set; }

        public int approvalstatues { get; set; }

        public string reasion { get; set; }
    }
}