using HoteManagement.Service.Core;
using HoteManagement.Service.Model;
using HoteManagement.Web.Core;
using HoteManagement.Web.Models.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace HoteManagement.Web.Controllers
{
    public class RoomController : BaseController
    {
        // GET: Room
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RoomTypeIndex(int? pageindex)
        {
            var models = generateService.Getroom_typeList(UserInfo.hotelid, pageindex.HasValue ? pageindex.Value : 1, 50);
            ViewBag.roomtypelist = models;

            string url = string.Format("/room/RoomTypeIndex");
            ViewBag.PageInfo = new PageModel { PageCount = models.TotalPages, PageIndex = pageindex.HasValue ? pageindex.Value : 1, Url = url };

            return View();
        }

        public ActionResult RoomNumberIndex(int? pageindex)
        {
            var models = generateService.Getroom_numberList(UserInfo.hotelid, pageindex.HasValue ? pageindex.Value : 1, 50);
            ViewBag.roomnumberlist = models;

            string url = string.Format("/room/RoomNumberIndex");
            ViewBag.PageInfo = new PageModel { PageCount = models.TotalPages, PageIndex = pageindex.HasValue ? pageindex.Value : 1, Url = url };

            var roomtypes = generateService.Getroom_typeList(UserInfo.hotelid, 1, 500);
            ViewBag.roomtypelist = roomtypes;

            var floorids = generateService.Getfloor_ldList(UserInfo.hotelid, 1, 500);
            ViewBag.flooridlist = floorids;

            ViewBag.floormanagelist = new PagedList<floor_manageDto>(new List<floor_manageDto>(), 1, 500);
            if (floorids.Count>0)
            {
                ViewBag.floormanagelist = generateService.Getfloor_manageList(UserInfo.hotelid, floorids[0].ld_Name, 1, 500);
            }

            return View();
        }

        [HttpPost]
        public JsonResult Createroomtype(CreateRoomTypeRequest request)
        {
            if(string.IsNullOrEmpty(request.roomtypename))
            {
                return new NewJsonResult(new Baseresponse { Success = 0, Message = "请填写名称" });
            }
            decimal price = 0;
            if(!decimal.TryParse(request.ealryprice,out price) || !decimal.TryParse(request.roomtypeprice, out price) || !decimal.TryParse(request.zmmoney, out price))
            {
                return new NewJsonResult(new Baseresponse { Success = 0, Message = "请填写正确的金额" });
            }



            generateService.Addroom_type(new room_typeDto { hotelid = UserInfo.hotelid, room_Bfb = request.bfb, room_ealry_price = decimal.Parse(request.ealryprice), room_hour = request.roomhour, room_name = request.roomtypename, room_zmmoney = decimal.Parse(request.zmmoney), room_image = string.Empty, room_Moth_price = 0, room_number = string.Empty, room_reamker = request.remark, room_hourmation = string.Empty, room_listedmoney = decimal.Parse(request.roomtypeprice) });

            return   new NewJsonResult(new Baseresponse { Success = 1, Message = "添加成功" });
        }

        [HttpPost]
        public JsonResult CreateroomNumber(CreateRoomNumberRequest request)
        {
            if (string.IsNullOrEmpty(request.RoomNumber))
            {
                return new NewJsonResult(new Baseresponse { Success = 0, Message = "请填写房号" });
            }
            decimal price = 0;
            if (!decimal.TryParse(request.RoomPrice, out price))
            {
                return new NewJsonResult(new Baseresponse { Success = 0, Message = "请填写正确的金额" });
            }

            if (string.IsNullOrEmpty(request.floorId))
            {
                return new NewJsonResult(new Baseresponse { Success = 0, Message = "请选择楼栋" });
            }

            if (string.IsNullOrEmpty(request.floorManage))
            {
                return new NewJsonResult(new Baseresponse { Success = 0, Message = "请选择楼层" });
            }

            generateService.Addroom_number(new room_numberDto
            {
                hotelid = UserInfo.hotelid,
                Rn_flloeld = request.floorId,
                Rn_floor = request.floorManage,
                Rn_price = decimal.Parse(request.RoomPrice),
                Rn_remaker = request.Remark,
                Rn_room = request.RoomType,
                Rn_roomNum = request.RoomNumber,
                Rn_state = 0,
                Rn_suo = string.Empty,
                Rn_Tobe = 0,
                Rn_Type = 1,
                Room_sort = 0,
                Room_suod = "否"
            });


            return new NewJsonResult(new Baseresponse { Success = 1, Message = "添加成功" });
        }

        [HttpPost]
        public JsonResult BatchCreateroomNumber(BatchCreateRoomNumberRequest request)
        {
            int roomnumber = 0;
            if (!int.TryParse(request.EndRoomNumber,out roomnumber) || !int.TryParse(request.StartRoomNumber, out roomnumber))
            {
                return new NewJsonResult(new Baseresponse { Success = 0, Message = "请填写正确房号" });
            }

            if(int.Parse(request.StartRoomNumber)>int.Parse(request.EndRoomNumber))
            {
                return new NewJsonResult(new Baseresponse { Success = 0, Message = "尾数房号必须大于起始房号" });
            }

            decimal price = 0;
            if (!decimal.TryParse(request.RoomPrice, out price))
            {
                return new NewJsonResult(new Baseresponse { Success = 0, Message = "请填写正确的金额" });
            }

            if (string.IsNullOrEmpty(request.floorId))
            {
                return new NewJsonResult(new Baseresponse { Success = 0, Message = "请选择楼栋" });
            }

            if (string.IsNullOrEmpty(request.floorManage))
            {
                return new NewJsonResult(new Baseresponse { Success = 0, Message = "请选择楼层" });
            }
        
            for(int roomindex = int.Parse(request.StartRoomNumber);roomindex<=int.Parse(request.EndRoomNumber); roomindex++)
            {
                string number = roomindex.ToString();
                if (!string.IsNullOrEmpty(request.PreRoomNumber))
                    number = request.PreRoomNumber + roomindex;
                generateService.Addroom_number(new room_numberDto
                {
                    hotelid = UserInfo.hotelid,
                    Rn_flloeld = request.floorId,
                    Rn_floor = request.floorManage,
                    Rn_price = decimal.Parse(request.RoomPrice),
                    Rn_remaker = request.Remark,
                    Rn_room = request.RoomType,
                    Rn_roomNum = number,
                    Rn_state = 0,
                    Rn_suo = string.Empty,
                    Rn_Tobe = 0,
                    Rn_Type = 1,
                    Room_sort = 0,
                    Room_suod = "否"
                });
            }

            return new NewJsonResult(new Baseresponse { Success = 1, Message = "添加成功" });
        }

        public ActionResult GetEditroomtypeView(int id)
        {
            var model = generateService.Getroom_typeById(id);

            return PartialView("EditRoomtype", model);
        }

        [HttpPost]
        public JsonResult EditRoomType(EditRoomTypeRequest request)
        {
            if (string.IsNullOrEmpty(request.roomtypename))
            {
                return new NewJsonResult(new Baseresponse { Success = 0, Message = "请填写名称" });
            }
            decimal price = 0;
            if (!decimal.TryParse(request.ealryprice, out price) || !decimal.TryParse(request.roomtypeprice, out price) || !decimal.TryParse(request.zmmoney, out price))
            {
                return new NewJsonResult(new Baseresponse { Success = 0, Message = "请正确的金额" });
            }

            var model = generateService.Getroom_typeByName(UserInfo.hotelid, request.roomtypename);

            if (model != null)
                return new NewJsonResult(new Baseresponse { Message = "名称不能重复", Success = 0 });

            model = generateService.Getroom_typeById(request.Id);
            model.room_Bfb = request.bfb;
            model.room_ealry_price = decimal.Parse(request.ealryprice);
            model.room_hour = request.roomhour;
            model.room_listedmoney = decimal.Parse(request.roomtypeprice);
            model.room_zmmoney = decimal.Parse(request.zmmoney);
            model.room_name = request.roomtypename;
            model.room_reamker = request.remark;

            generateService.Updateroom_type(model);

            return new NewJsonResult(new Baseresponse { Message = "修改成功", Success = 1 });

        }

        [HttpPost]
        public JsonResult EditRoomNumber(EditRoomNumberRequest request)
        {
            if (string.IsNullOrEmpty(request.RoomNumber))
            {
                return new NewJsonResult(new Baseresponse { Success = 0, Message = "请填写房号" });
            }
            decimal price = 0;
            if (!decimal.TryParse(request.RoomPrice, out price))
            {
                return new NewJsonResult(new Baseresponse { Success = 0, Message = "请填写正确的金额" });
            }

            if (string.IsNullOrEmpty(request.floorId))
            {
                return new NewJsonResult(new Baseresponse { Success = 0, Message = "请选择楼栋" });
            }

            if (string.IsNullOrEmpty(request.floorManage))
            {
                return new NewJsonResult(new Baseresponse { Success = 0, Message = "请选择楼层" });
            }

            var model = generateService.Getroom_numberByroomnumber(UserInfo.hotelid, request.floorId, request.floorManage, request.RoomNumber);

            if(model!=null)
            {
                return new NewJsonResult(new Baseresponse { Success = 0, Message = "房号不能重复" });

            }

            model = generateService.Getroom_numberById(request.Id);

            model.Rn_flloeld = request.floorId;
            model.Rn_floor = request.floorManage;
            model.Rn_price = decimal.Parse(request.RoomPrice);
            model.Rn_remaker = request.Remark;
            model.Rn_Type = request.RoomType;
            model.Rn_roomNum = request.RoomNumber;

            generateService.Updateroom_number(model);


            return new NewJsonResult(new Baseresponse { Success = 1, Message = "修改成功" });

        }

        public ActionResult GetEditroomNumberView(int id)
        {
            var model = generateService.Getroom_numberById(id);
            var roomtypes = generateService.Getroom_typeList(UserInfo.hotelid, 1, 500);
            ViewBag.roomtypelist = roomtypes;

            var floorids = generateService.Getfloor_ldList(UserInfo.hotelid, 1, 500);
            ViewBag.flooridlist = floorids;

            ViewBag.floormanagelist = new PagedList<floor_manageDto>(new List<floor_manageDto>(), 1, 500);
            if (floorids.Count > 0)
            {
                ViewBag.floormanagelist = generateService.Getfloor_manageList(UserInfo.hotelid, floorids[0].ld_Name, 1, 500);
            }
            return PartialView("EditRoomNumber", model);
        }

        [HttpGet]
        public JsonResult DeleteRoomType(int id)
        {

            var model = generateService.Getroom_typeById(id);
            if (model != null)
                generateService.Deleteroom_type(id);

            return new NewJsonResult(new Baseresponse { Message = "删除成功", Success = 1 });

        }

        [HttpGet]
        public JsonResult DeleteRoomNumber(int id)
        {

            var model = generateService.Getroom_numberById(id);
            if (model != null)
                generateService.Deleteroom_number(id);

            return new NewJsonResult(new Baseresponse { Message = "删除成功", Success = 1 });

        }


        [HttpGet]
        public JsonResult BatchDeleteRoomNumber(string id)
        {
            if(string.IsNullOrEmpty(id))
                return new NewJsonResult(new Baseresponse { Message = "请选择删除项", Success = 0 });
            string[] ids = id.Split(new char[] { ',' });
            foreach(var item in ids)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    var model = generateService.Getroom_numberById(int.Parse(item));
                    if (model != null)
                        generateService.Deleteroom_number(int.Parse(item));
                }
              
            }
          

            return new NewJsonResult(new Baseresponse { Message = "删除成功", Success = 1 });

        }
    }
}