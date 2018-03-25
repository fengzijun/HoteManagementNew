using HoteManagement.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoteManagement.Web.Models.Api
{
    public class AuditBusinessRequest
    {
        public int Id { get; set; }

        public int ApprovalStatues { get; set; }

        public Org_BusinessDto Model { get; set; }
    }
}