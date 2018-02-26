using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoteManagement.Web.Models.Api
{
    public class EditUserRequest
    {

        public string AccountName { get; set; }

        public string Pwd { get; set; }

        public string ConfirmPwd { get; set; }

        public string Gender { get; set; }

        public string Mobile { get; set; }

        public int RoleId { get; set; }

        public int Id { get; set; }

        public string TureName { get; set; }

        public int? HotelId { get; set; }

    }
}