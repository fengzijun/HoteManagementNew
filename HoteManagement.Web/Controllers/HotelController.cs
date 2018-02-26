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
    public class HotelController : BaseController
    {
      
        // GET: Hotel
        public ActionResult Index(string name,int? pageindex)
        {
            var models = generateService.GetHotelList(name, null, null, 0, null, pageindex.HasValue ? pageindex.Value : 1, 50);

            ViewBag.hotels = models;
            string url = string.Format("/hotel/index?name={0}", name);
            ViewBag.PageInfo = new PageModel { PageCount = models.TotalPages, PageIndex = pageindex.HasValue ? pageindex.Value : 1 , Url = url };
            return View();
        }

        public ActionResult Detail(int id)
        {
            var model = generateService.GetHotelById(id);
            if (model == null)
                return new HttpNotFoundResult();
            if (!model.ParentId.HasValue || model.ParentId.Value == 0)
                PrepareHotelList(null, model.ParentId.Value, null, 0, 1, false);
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var model = generateService.GetHotelById(id);
            if (model == null)
                return new HttpNotFoundResult();

            model.IsDeleted = 1;
            generateService.UpdateHotel(model);

            return Redirect("/sys/OperationResult?returnurl=/hotel/Index");
        }

        public ActionResult Edit(int id)
        {
            var model = generateService.GetHotelById(id);
            if (model == null)
                return new HttpNotFoundResult();

            PrepareHotelList(null, 0, null, 0, 1, true);

            HotelEditRequest requestmodel = new HotelEditRequest
            {
                Expiretime = model.Expiretime.Value,
                HotelName = model.HotelName,
                Id = model.Id,
                IsChain = model.IsChain == 1 ? true : false,
                ParentId = model.ParentId.Value,
                ParentHotel = model.ParentHotel == null ? null : new HotelEditRequest { Expiretime = model.ParentHotel.Expiretime.Value, HotelName = model.ParentHotel.HotelName, Id = model.ParentHotel.Id, IsChain = model.ParentHotel.IsChain == 1 ? true : false, ParentId = model.ParentHotel.ParentId.Value }
            };
            return View(requestmodel);
        }

        public ActionResult Create()
        {
            PrepareHotelList(null, 0, null, 0, 1, true);
            return View();
        }

        //private void PrepareChildHotelList(int parentid)
        //{
        //    var models = generateService.GetHotelList(null, parentid, null, 0, 1);
        //    List<SelectListItem> list = new List<SelectListItem>();
        //    foreach (var item in models)
        //    {
        //        list.Add(new SelectListItem { Text = item.HotelName, Value = item.Id.ToString() });

        //    }
        //    ViewBag.Hotellist = list;
        //}

        //private void PrepareHotelList()
        //{
        //    var models = generateService.GetHotelList(null,0, null, 0, 1);
        //    List<SelectListItem> list = new List<SelectListItem>();
        //    foreach (var item in models)
        //    {
        //        list.Add(new SelectListItem { Text = item.HotelName, Value = item.Id.ToString() });

        //    }
        //    list.Insert(0, new SelectListItem { Value = "0", Text = "请选择" });
        //    ViewBag.Hotellist = list;
        //}

        [HttpPost]
        public ActionResult Edit(HotelEditRequest request)
        {
            if (!ModelState.IsValid)
            {
                var model = generateService.GetHotelById(request.Id);
                if (model == null)
                    return new HttpNotFoundResult();

                PrepareHotelList(null, 0, null, 0, 1, true);
                HotelEditRequest requestmodel = new HotelEditRequest
                {
                    Expiretime = model.Expiretime.Value,
                    HotelName = model.HotelName,
                    Id = model.Id,
                    IsChain = model.IsChain == 1 ? true : false,
                    ParentId = model.ParentId.Value,
                    ParentHotel = model.ParentHotel == null ? null : new HotelEditRequest { Expiretime = model.ParentHotel.Expiretime.Value, HotelName = model.ParentHotel.HotelName, Id = model.ParentHotel.Id, IsChain = model.ParentHotel.IsChain == 1 ? true : false, ParentId = model.ParentHotel.ParentId.Value }
                };
                return View(requestmodel);
            }

            generateService.UpdateHotel(
                new HotelDto
                {
                    Id = request.Id,
                    CreateorId = UserInfo.Id,
                    CreateorIp = webHelper.GetCurrentIpAddress(),
                    IsChain = request.IsChain ? 1 : 0,
                    IsDeleted = 0,
                    IsTop = request.ParentId == 0 ? 1 : 0,
                    ParentId = request.ParentId,
                    HotelName = request.HotelName,
                    Expiretime = request.Expiretime,
                    Updatetime = DateTime.Now,
                });


            return Redirect("/sys/OperationResult?returnurl=/hotel/Index");
        }

        [HttpPost]
        public ActionResult Create(HotelRequest model)
        {
            if (!ModelState.IsValid)
            {
                PrepareHotelList(null, 0, null, 0, 1, true);
                return View(model);
            }

            generateService.AddHotel(
                new HotelDto {
                    CreateorId = UserInfo.Id,
                    CreateorIp = webHelper.GetCurrentIpAddress(),
                    IsChain = model.IsChain ? 1 : 0,
                    IsDeleted = 0,
                    IsTop = model.ParentId == 0 ? 1 : 0,
                    ParentId = model.ParentId,
                    Registertime = DateTime.Now,
                    HotelName = model.HotelName,
                    Expiretime = model.Expiretime,
                    Updatetime = DateTime.Now,
                    Createtime = DateTime.Now
                });


            return Redirect("/sys/OperationResult?returnurl=/hotel/Index");
        }
    }
}