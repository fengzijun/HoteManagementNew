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
    public class ModesController : BaseController
    {
        // GET: Modes
        public ActionResult Index(int? pageindex)
        {
            var models = generateService.GetmodesList(UserInfo.hotelid, pageindex.HasValue ? pageindex.Value : 1, 50);

            ViewBag.modeslist = models;
            string url = "/floor/index";
            ViewBag.PageInfo = new PageModel { PageCount = models.TotalPages, PageIndex = pageindex.HasValue ? pageindex.Value : 1, Url = url };
            return View();
        }

        [HttpPost]
        public JsonResult CreateModes(string name)
        {
            if (string.IsNullOrEmpty(name))
                return new NewJsonResult(new Baseresponse { Message = "名字不能为空", Success = 0 });

            var model = generateService.GetmodesByName(name, UserInfo.hotelid);

            if (model != null)
                return new NewJsonResult(new Baseresponse { Message = "名字不能重复", Success = 0 });

            generateService.Addmodes(new modesDto { hotelid = UserInfo.hotelid, moshi_name = name, Reanker = string.Empty, sort = 0 });

            return new NewJsonResult(new Baseresponse { Message = "添加成功", Success = 1 });
        }

        public ActionResult GetEditModesView(int id)
        {
            var model = generateService.GetmodesById(id);

            return PartialView("EditModes", model);
        }

        [HttpPost]
        public JsonResult EditModes(string name, int id)
        {
            if (string.IsNullOrEmpty(name))
                return new NewJsonResult(new Baseresponse { Message = "名字不能为空", Success = 0 });

            var model = generateService.GetmodesByName(name, UserInfo.hotelid);

            if (model != null)
                return new NewJsonResult(new Baseresponse { Message = "名字不能重复", Success = 0 });

            model = generateService.GetmodesById(id);
            model.moshi_name = name;
            generateService.Updatemodes(model);

            return new NewJsonResult(new Baseresponse { Message = "修改成功", Success = 1 });

        }

        [HttpGet]
        public JsonResult Deletemodes(int id)
        {

            var model = generateService.GetmodesById(id);
            if (model != null)
                generateService.Deletemodes(id);

            return new NewJsonResult(new Baseresponse { Message = "删除成功", Success = 1 });

        }
    }
}