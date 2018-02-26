using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoteManagement.Web.Models.Api
{
    public class EditRoomNumberRequest
    {
        public string floorId { get; set; }
        //楼层
        public string floorManage { get; set; }

        public string RoomNumber { get; set; }

        public int RoomType { get; set; }

        public string RoomPrice { get; set; }

        public string Remark { get; set; }

        public int Id { get; set; }
    }
}