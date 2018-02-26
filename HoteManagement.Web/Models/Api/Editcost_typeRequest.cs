using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoteManagement.Web.Models.Api
{
    public class Editcost_typeRequest
    {
        public string Price { get; set; }

        public string Remark { get; set; }

        public string Number { get; set; }

        public string Name { get; set; }

        public int Category { get; set; }

        public int Id { get; set; }
    }
}