using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoteManagement.Web.Models.Api
{
    public class EditPermissionRequest
    {
        public string Ids { get; set; }

        public int RoleId { get; set; }

        public int HotelId { get; set; }
    }
}