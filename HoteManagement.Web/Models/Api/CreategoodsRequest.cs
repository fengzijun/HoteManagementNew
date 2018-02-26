using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoteManagement.Web.Models.Api
{
    public class CreategoodsRequest
    {
        public string Price { get; set; }

        public string Unit { get; set; }

        public string Remark { get; set; }

        public string Number { get; set; }

        public string Name { get; set; }

        public string Score { get; set; }

        public int Status { get; set; }

        public int Category { get; set; }
    }
}