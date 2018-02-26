using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoteManagement.Web.Models.Api
{
    public class BatchCreateRoomNumberRequest
    {
        //楼栋
        public string floorId { get; set; }
        //楼层
        public string floorManage { get; set; }

        public string PreRoomNumber { get; set; }

        public string StartRoomNumber { get; set; }

        public string EndRoomNumber { get; set; }

        public int RoomType { get; set; }

        public string RoomPrice { get; set; }

        public string Remark { get; set; }
    }
}