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
    public class ShiftController : BaseController
    {
        // GET: Shift
        public ActionResult Index(int? pageindex)
        {
            var models = generateService.GetShiftList(UserInfo.hotelid, pageindex.HasValue ? pageindex.Value : 1, 50);

            ViewBag.shiftlist = models;
            string url = "/shift/index";
            ViewBag.PageInfo = new PageModel { PageCount = models.TotalPages, PageIndex = pageindex.HasValue ? pageindex.Value : 1, Url = url };
         
            return View();
        }


        [HttpPost]
        public JsonResult Createshift(string name)
        {
            if (string.IsNullOrEmpty(name))
                return new NewJsonResult(new Baseresponse { Message = "名字不能为空", Success = 0 });


            generateService.AddShift(new ShiftDto { hotelid = UserInfo.hotelid, user_id = 0, remark = string.Empty, shfit_name = name, goods_account_id = 0 });

            return new NewJsonResult(new Baseresponse { Message = "添加成功", Success = 1 });
        }


        public ActionResult GetEditshiftView(int id)
        {
            var model = generateService.GetShiftById(id);

            return PartialView("Editshift", model);
        }

        [HttpPost]
        public JsonResult Editshift(string name, int id)
        {
            if (string.IsNullOrEmpty(name))
                return new NewJsonResult(new Baseresponse { Message = "名字不能为空", Success = 0 });

            var model = generateService.GetShiftById(id);
            model.shfit_name = name;
            generateService.UpdateShift(model);

            return new NewJsonResult(new Baseresponse { Message = "修改成功", Success = 1 });

        }

        [HttpGet]
        public JsonResult Deleteshift(int id)
        {

            var model = generateService.GetShiftById(id);
            if (model != null)
                generateService.DeleteShift(id);

            return new NewJsonResult(new Baseresponse { Message = "删除成功", Success = 1 });

        }
    }
}