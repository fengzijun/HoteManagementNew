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
    public class PermissionController : BaseController
    {
        // GET: Permission
        public ActionResult Index()
        {
            PrepareRoleList(UserInfo.hotelid, false);
            List<SelectListItem> list = ViewBag.Rolelist as List<SelectListItem>;
            if(list.Count>0)
            {
                var roleid = int.Parse(list[0].Value.Split(new char[] { '_' })[0]);
                var hotelid = int.Parse(list[0].Value.Split(new char[] { '_' })[1]);
                GetRoleMenus(roleid, hotelid);
            }
            return View();
        }

        public ActionResult GetRolePermission(int roleid,int? hotelid)
        {

            GetRoleMenus(roleid, hotelid);

            return PartialView("RoleMenu");

        }

        private void GetRoleMenus(int roleid,int? hotelid)
        {
            var menulist = generateService.GetMenuList(0, UserInfo.hotelid, 1, 50);

            int? h = CheckHotelid(hotelid);

            var rolemenulist = generateService.GetRoleMenuList(h, roleid);

            ViewBag.menulist = menulist;
            ViewBag.rolemenulist = rolemenulist;
        }

        [HttpPost]
        public JsonResult EditRolePermission(EditPermissionRequest reqeust)
        {
            if(string.IsNullOrEmpty(reqeust.Ids) || reqeust.RoleId == 0)
                return new NewJsonResult(new Baseresponse { Success = 0 });
            var rolemenulist = generateService.GetRoleMenuList(reqeust.HotelId, reqeust.RoleId);
            foreach(var item in rolemenulist)
            {
                generateService.DeleteRoleMenu(item.Id);
            }

            string[] ids = reqeust.Ids.Split(new char[] { ',' });
            foreach(var item in ids)
            {
                generateService.AddRoleMenu(new RoleMenuDto { hotelid = reqeust.HotelId, Menu_id = int.Parse(item), Menu_pid = 0, RoleID = reqeust.RoleId });
            }

            return new NewJsonResult(new Baseresponse { Success = 1 });
        }
    }
}