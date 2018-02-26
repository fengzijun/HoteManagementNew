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
    public class RoleController : BaseController
    {
        // GET: Role
        public ActionResult Index(int? pageindex)
        {
            var models = generateService.GetAccounts_RolesList(UserInfo.hotelid, pageindex.HasValue ? pageindex.Value : 1, 50);

            ViewBag.rolelist = models;
            string url = "/role/index";
            ViewBag.PageInfo = new PageModel { PageCount = models.TotalPages, PageIndex = pageindex.HasValue ? pageindex.Value : 1, Url = url };
            if (!UserInfo.hotelid.HasValue)
                PrepareHotelList(null, 0, null, 0, null, false);
            return View();
        }


        [HttpPost]
        public JsonResult Createrole(string name,int hotelid)
        {
            if (string.IsNullOrEmpty(name))
                return new NewJsonResult(new Baseresponse { Message = "名字不能为空", Success = 0 });

            var model = generateService.GetAccounts_RolesByName(name, UserInfo.hotelid);

            if (model != null)
                return new NewJsonResult(new Baseresponse { Message = "名字不能重复", Success = 0 });

            int? h = null;
            if (hotelid != 0 && !UserInfo.hotelid.HasValue)
                h = hotelid;
            else if (UserInfo.hotelid.HasValue)
                h = UserInfo.hotelid.Value;

            generateService.AddAccounts_Roles(new Accounts_RolesDto { hotelid = h, title  = name, Description = string.Empty, RoleID = 0 });

            return new NewJsonResult(new Baseresponse { Message = "添加成功", Success = 1 });
        }


        public ActionResult GetEditroleView(int id)
        {
            var model = generateService.GetAccounts_RolesById(id);

            return PartialView("Editrole", model);
        }

        [HttpPost]
        public JsonResult Editrole(string name, int id)
        {
            if (string.IsNullOrEmpty(name))
                return new NewJsonResult(new Baseresponse { Message = "名字不能为空", Success = 0 });

            var model = generateService.GetAccounts_RolesByName(name, UserInfo.hotelid);

            if (model != null)
                return new NewJsonResult(new Baseresponse { Message = "名字不能重复", Success = 0 });

            model = generateService.GetAccounts_RolesById(id);
            model.title = name;
            generateService.UpdateAccounts_Roles(model);

            return new NewJsonResult(new Baseresponse { Message = "修改成功", Success = 1 });

        }

        [HttpGet]
        public JsonResult Deleterole(int id)
        {

            var model = generateService.GetAccounts_RolesById(id);
            if (model != null)
                generateService.DeleteAccounts_Roles(id);

            return new NewJsonResult(new Baseresponse { Message = "删除成功", Success = 1 });

        }


    }
}