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
    public class MenuController : BaseController
    {
        // GET: Menu
        public ActionResult Index(int? parentid , int? pageindex)
        {

            var models = generateService.GetMenuList(parentid.HasValue?parentid.Value:0, UserInfo.hotelid, pageindex.HasValue ? pageindex.Value : 1, 50);
            ViewBag.parentid = parentid.HasValue ? parentid.Value : 0;
            ViewBag.menulist = models;
            string url = "/menu/index";
            ViewBag.PageInfo = new PageModel { PageCount = models.TotalPages, PageIndex = pageindex.HasValue ? pageindex.Value : 1, Url = url };
            //if (!UserInfo.hotelid.HasValue)
            //    PrepareHotelList(null, 0, null, 0, null, false);
            return View();
        }

        public ActionResult Create(int? parentid)
        {
            return View(new CreateMenuRequst { ParentId = parentid.HasValue ? parentid.Value : 0 ,Isabled = true});
        }

        [HttpPost]
        public ActionResult Create(CreateMenuRequst request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            string image = string.Empty;
            var filename = string.Empty;
            if(request.File!=null)
            {
                var file = request.File;
                filename = "/upload/" + Guid.NewGuid().ToString() + ".png"; 
                file.SaveAs(Server.MapPath(filename));
            }

            generateService.AddMenu(new MenuDto { hotelid = UserInfo.hotelid, imgurl = filename, isable = request.Isabled, sortId = 0, url = request.Url, title = request.MenuName, parent_id = request.ParentId });

            return Redirect($"/sys/OperationResult?returnurl=/menu/Index?parentid={request.ParentId}");
        }

        public ActionResult Edit(int id)
        {
            var model = generateService.GetMenuById(id);
            if (model == null)
                return new HttpNotFoundResult();

            EditMenuRequst requestmodel = new EditMenuRequst
            {

                Id = model.Id,
                ParentId = model.parent_id.Value,
                Isabled = model.isable.Value,
                MenuName = model.title,
                Url = model.url
            };
            return View(requestmodel);
        }

        [HttpPost]
        public ActionResult Edit(EditMenuRequst request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            string image = string.Empty;
            var filename = string.Empty;
            if (request.File != null)
            {
                var file = request.File;
                filename = "/upload/" + Guid.NewGuid().ToString() + ".png";
                file.SaveAs(Server.MapPath(filename));
            }

            var model = generateService.GetMenuById(request.Id);

            model.title = request.MenuName;
            model.isable = request.Isabled;
            model.url = request.Url;
            model.imgurl = string.IsNullOrEmpty(filename) ? model.imgurl : filename;

            generateService.UpdateMenu(model);

            return Redirect($"/sys/OperationResult?returnurl=/menu/Index?parentid={request.ParentId}");
        }


        public ActionResult Delete(int id,int? parentid)
        {
            var model = generateService.GetMenuById(id);
            if (model == null)
                return new HttpNotFoundResult();


            generateService.DeleteMenu(id);
            int p = parentid.HasValue ? parentid.Value : 0;
            return Redirect($"/sys/OperationResult?returnurl=/menu/Index?parentid={p}");
        }
    }
}