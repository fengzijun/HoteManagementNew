using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoteManagement.Web.Models.Api
{
    public class EditRoomTypeRequest
    {
        public string roomtypename { get; set; }

        public string roomtypeprice { get; set; }

        public string zmmoney { get; set; }

        public string roomhour { get; set; }

        public string ealryprice { get; set; }

        public int bfb { get; set; }

        public string remark { get; set; }

        public int Id { get; set; }
    }
}