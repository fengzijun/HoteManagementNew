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
    public class FloorController : BaseController
    {
        // GET: Floor
        public ActionResult Index(int? pageindex)
        {
            var models = generateService.Getfloor_ldList(UserInfo.hotelid, pageindex.HasValue?pageindex.Value:1, 50);

            ViewBag.floorlist = models;
            string url = "/floor/index";
            ViewBag.PageInfo = new PageModel { PageCount = models.TotalPages, PageIndex = pageindex.HasValue ? pageindex.Value : 1, Url = url };
            return View();

        }

        public ActionResult FloorManageIndex(string floornumber, int? pageindex)
        {
            var models = generateService.Getfloor_manageList(UserInfo.hotelid, floornumber, pageindex.HasValue ? pageindex.Value : 1, 50);

            ViewBag.floorlist = models;
            string url = "/floor/FloorManageIndex?floornumber=" + floornumber;
            ViewBag.PageInfo = new PageModel { PageCount = models.TotalPages, PageIndex = pageindex.HasValue ? pageindex.Value : 1, Url = url };
            ViewBag.RequestFloorNumber = floornumber;
            return View();
        }

        [HttpPost]
        public JsonResult CreateFloor(string name)
        {
            if (string.IsNullOrEmpty(name))
                return new NewJsonResult(new Baseresponse { Message = "名字不能为空", Success = 0 });

            var model = generateService.Getfloor_ldByName(name, UserInfo.hotelid);

            if(model!=null)
                return new NewJsonResult(new Baseresponse { Message = "名字不能重复", Success = 0 });

            generateService.Addfloor_ld(new floor_ldDto { hotelid = UserInfo.hotelid, ld_Name = name });

            return new NewJsonResult(new Baseresponse { Message = "添加成功", Success = 1 });
        }

        [HttpPost]
        public JsonResult CreateFloorManage(string name, string floornumber)
        {
            if (string.IsNullOrEmpty(name))
                return new NewJsonResult(new Baseresponse { Message = "名字不能为空", Success = 0 });

            var model = generateService.Getfloor_manageByName(name, floornumber, UserInfo.hotelid);

            if (model != null)
                return new NewJsonResult(new Baseresponse { Message = "名字不能重复", Success = 0 });

            generateService.Addfloor_manage(new floor_manageDto { hotelid = UserInfo.hotelid, floor_name = name, floor_number = floornumber, floor_remaker = string.Empty, floor_sorting = "0" });

            return new NewJsonResult(new Baseresponse { Message = "添加成功", Success = 1 });
        }

        public ActionResult GetEditFloorView(int id)
        {
            var model = generateService.Getfloor_ldById(id);

            return PartialView("EditFloor", model);
        }

        public ActionResult GetEditFloorManageView(int id)
        {
            var model = generateService.Getfloor_manageById(id);

            return PartialView("EditFloorManage", model);
        }

        public JsonResult GetFloorManageByFloorId(string floorname)
        {
            var model = generateService.Getfloor_manageList(UserInfo.hotelid, floorname, 1, 500);

            return new NewJsonResult(model);
        }

        [HttpPost]
        public JsonResult EditFloor(string name,int id)
        {
            if (string.IsNullOrEmpty(name))
                return new NewJsonResult(new Baseresponse { Message = "名字不能为空", Success = 0 });

            var model = generateService.Getfloor_ldByName(name, UserInfo.hotelid);

            if (model != null)
                return new NewJsonResult(new Baseresponse { Message = "名字不能重复", Success = 0 });

            model = generateService.Getfloor_ldById(id);
            model.ld_Name = name;
            generateService.Updatefloor_ld(new floor_ldDto { hotelid = UserInfo.hotelid, ld_Name = name, Id = id });

            return new NewJsonResult(new Baseresponse { Message = "修改成功", Success = 1 });

        }

        [HttpPost]
        public JsonResult EditFloorManage(string name, int id)
        {
            if (string.IsNullOrEmpty(name))
                return new NewJsonResult(new Baseresponse { Message = "名字不能为空", Success = 0 });

            var model = generateService.Getfloor_manageById(id);

            var editmodel = generateService.Getfloor_manageByName(name, model.floor_number, UserInfo.hotelid);

            if (editmodel != null)
                return new NewJsonResult(new Baseresponse { Message = "名字不能重复", Success = 0 });

       
            model.floor_name = name;
            generateService.Updatefloor_manage(model);

            return new NewJsonResult(new Baseresponse { Message = "修改成功", Success = 1 });

        }

        [HttpGet]
        public JsonResult DeleteFloor(int id)
        {
        
            var model = generateService.Getfloor_ldById(id);
            if (model != null)
                generateService.Deletefloor_ld(id);

            return new NewJsonResult(new Baseresponse { Message = "删除成功", Success = 1 });

        }

        [HttpGet]
        public JsonResult DeleteFloorManage(int id)
        {

            var model = generateService.Getfloor_manageById(id);
            if (model != null)
                generateService.Deletefloor_manage(id);

            return new NewJsonResult(new Baseresponse { Message = "删除成功", Success = 1 });

        }
    }
}