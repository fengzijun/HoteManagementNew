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
    public class OtherController : BaseController
    {
        // GET: Other
        public ActionResult GuestsourceIndex(int? pageindex)
        {
            var models = generateService.Getguest_sourceList(UserInfo.hotelid, pageindex.HasValue ? pageindex.Value : 1, 50);

            ViewBag.guestsourcelist = models;
            string url = "/other/GuestsourceIndex";
            ViewBag.PageInfo = new PageModel { PageCount = models.TotalPages, PageIndex = pageindex.HasValue ? pageindex.Value : 1, Url = url };

            return View();
        }


        [HttpPost]
        public JsonResult CreateGuestSource(string name)
        {
            if (string.IsNullOrEmpty(name))
                return new NewJsonResult(new Baseresponse { Message = "名字不能为空", Success = 0 });

         
            generateService.Addguest_source(new guest_sourceDto { gs_name = name, remark = string.Empty, hotelid = UserInfo.hotelid });

            return new NewJsonResult(new Baseresponse { Message = "添加成功", Success = 1 });
        }


        public ActionResult GetEditguestsourceView(int id)
        {
            var model = generateService.Getguest_sourceById(id);

            return PartialView("EditGuestSource", model);
        }

        [HttpPost]
        public JsonResult EditGuestSource(string name,int id)
        {
            if (string.IsNullOrEmpty(name))
                return new NewJsonResult(new Baseresponse { Message = "名字不能为空", Success = 0 });

            var model = generateService.Getguest_sourceById(id);
            model.gs_name = name;
            generateService.Updateguest_source(model);

            return new NewJsonResult(new Baseresponse { Message = "修改成功", Success = 1 });

        }

        [HttpGet]
        public JsonResult DeleteGuestSource(int id)
        {

            var model = generateService.Getguest_sourceById(id);
            if (model != null)
                generateService.Deleteguest_source(id);

            return new NewJsonResult(new Baseresponse { Message = "删除成功", Success = 1 });

        }


        public ActionResult communitIndex(int? pageindex)
        {
            var models = generateService.Getcomm_unitList(UserInfo.hotelid, pageindex.HasValue ? pageindex.Value : 1, 50);

            ViewBag.communitlist = models;
            string url = "/other/communitIndex";
            ViewBag.PageInfo = new PageModel { PageCount = models.TotalPages, PageIndex = pageindex.HasValue ? pageindex.Value : 1, Url = url };

            return View();
        }


        [HttpPost]
        public JsonResult Createcommunit(string name)
        {
            if (string.IsNullOrEmpty(name))
                return new NewJsonResult(new Baseresponse { Message = "名字不能为空", Success = 0 });


            generateService.Addcomm_unit(new comm_unitDto { unit_name = name ,remark = string.Empty, hotelid = UserInfo.hotelid});

            return new NewJsonResult(new Baseresponse { Message = "添加成功", Success = 1 });
        }


        public ActionResult GetEditcommunitView(int id)
        {
            var model = generateService.Getcomm_unitById(id);

            return PartialView("Editcommunit", model);
        }

        [HttpPost]
        public JsonResult Editcommunit(string name, int id)
        {
            if (string.IsNullOrEmpty(name))
                return new NewJsonResult(new Baseresponse { Message = "名字不能为空", Success = 0 });

            var model = generateService.Getcomm_unitById(id);
            model.unit_name = name;
            generateService.Updatecomm_unit(model);

            return new NewJsonResult(new Baseresponse { Message = "修改成功", Success = 1 });

        }

        [HttpGet]
        public JsonResult Deletecommunit(int id)
        {

            var model = generateService.Getcomm_unitById(id);
            if (model != null)
                generateService.Deletecomm_unit(id);

            return new NewJsonResult(new Baseresponse { Message = "删除成功", Success = 1 });

        }

        public ActionResult roomfeatureIndex(int? pageindex)
        {
            var models = generateService.Getroom_featureList(UserInfo.hotelid, pageindex.HasValue ? pageindex.Value : 1, 50);

            ViewBag.roomfeaturelist = models;
            string url = "/other/roomfeatureIndex";
            ViewBag.PageInfo = new PageModel { PageCount = models.TotalPages, PageIndex = pageindex.HasValue ? pageindex.Value : 1, Url = url };

            return View();
        }


        [HttpPost]
        public JsonResult Createroomfeature(string name)
        {
            if (string.IsNullOrEmpty(name))
                return new NewJsonResult(new Baseresponse { Message = "名字不能为空", Success = 0 });


            generateService.Addroom_feature(new room_featureDto { room_feature_name = name , remark = string.Empty, hotelid = UserInfo.hotelid });

            return new NewJsonResult(new Baseresponse { Message = "添加成功", Success = 1 });
        }


        public ActionResult GetEditroomfeatureView(int id)
        {
            var model = generateService.Getroom_featureById(id);

            return PartialView("Editroomfeature", model);
        }

        [HttpPost]
        public JsonResult Editroomfeature(string name, int id)
        {
            if (string.IsNullOrEmpty(name))
                return new NewJsonResult(new Baseresponse { Message = "名字不能为空", Success = 0 });

            var model = generateService.Getroom_featureById(id);
            model.room_feature_name = name;
            generateService.Updateroom_feature(model);

            return new NewJsonResult(new Baseresponse { Message = "修改成功", Success = 1 });

        }

        [HttpGet]
        public JsonResult Deleteroomfeature(int id)
        {

            var model = generateService.Getroom_featureById(id);
            if (model != null)
                generateService.Deleteroom_feature(id);

            return new NewJsonResult(new Baseresponse { Message = "删除成功", Success = 1 });

        }

        public ActionResult methpayIndex(int? pageindex)
        {
            var models = generateService.Getmeth_payList(pageindex.HasValue ? pageindex.Value : 1, 50);

            ViewBag.methpaylist = models;
            string url = "/other/methpayIndex";
            ViewBag.PageInfo = new PageModel { PageCount = models.TotalPages, PageIndex = pageindex.HasValue ? pageindex.Value : 1, Url = url };

            return View();
        }


        [HttpPost]
        public JsonResult Createmethpay(string name)
        {
            if (string.IsNullOrEmpty(name))
                return new NewJsonResult(new Baseresponse { Message = "名字不能为空", Success = 0 });


            generateService.Addmeth_pay(new  meth_payDto { meth_pay_name = name, remark = string.Empty });

            return new NewJsonResult(new Baseresponse { Message = "添加成功", Success = 1 });
        }


        public ActionResult GetEditmethpayView(int id)
        {
            var model = generateService.Getmeth_payById(id);

            return PartialView("Editmethpay", model);
        }

        [HttpPost]
        public JsonResult Editmethpay(string name, int id)
        {
            if (string.IsNullOrEmpty(name))
                return new NewJsonResult(new Baseresponse { Message = "名字不能为空", Success = 0 });

            var model = generateService.Getmeth_payById(id);
            model.meth_pay_name = name;
            generateService.Updatemeth_pay(model);

            return new NewJsonResult(new Baseresponse { Message = "修改成功", Success = 1 });

        }

        [HttpGet]
        public JsonResult Deletemethpay(int id)
        {

            var model = generateService.Getmeth_payById(id);
            if (model != null)
                generateService.Deletemeth_pay(id);

            return new NewJsonResult(new Baseresponse { Message = "删除成功", Success = 1 });

        }

        public ActionResult cardtypeIndex(int? pageindex)
        {
            var models = generateService.Getcard_typeList(null,pageindex.HasValue ? pageindex.Value : 1, 50);

            ViewBag.cardtypelist = models;
            string url = "/other/cardtypeIndex";
            ViewBag.PageInfo = new PageModel { PageCount = models.TotalPages, PageIndex = pageindex.HasValue ? pageindex.Value : 1, Url = url };

            return View();
        }


        [HttpPost]
        public JsonResult Createcardtype(string name)
        {
            if (string.IsNullOrEmpty(name))
                return new NewJsonResult(new Baseresponse { Message = "名字不能为空", Success = 0 });

            generateService.Addcard_type(new card_typeDto {  ct_name = name, remark = string.Empty });

            return new NewJsonResult(new Baseresponse { Message = "添加成功", Success = 1 });
        }


        public ActionResult GetEditcardtypeView(int id)
        {
            var model = generateService.Getcard_typeById(id);

            return PartialView("Editcardtype", model);
        }

        [HttpPost]
        public JsonResult Editcardtype(string name, int id)
        {
            if (string.IsNullOrEmpty(name))
                return new NewJsonResult(new Baseresponse { Message = "名字不能为空", Success = 0 });

            var model = generateService.Getcard_typeById(id);
            model.ct_name = name;
            generateService.Updatecard_type(model);

            return new NewJsonResult(new Baseresponse { Message = "修改成功", Success = 1 });

        }

        [HttpGet]
        public JsonResult Deletecardtype(int id)
        {

            var model = generateService.Getcard_typeById(id);
            if (model != null)
                generateService.Deletecard_type(id);

            return new NewJsonResult(new Baseresponse { Message = "删除成功", Success = 1 });

        }

        public ActionResult hourseschemeIndex(int? pageindex)
        {
            var models = generateService.Gethourse_schemeList(null, pageindex.HasValue ? pageindex.Value : 1, 50);

            ViewBag.hourseschemelist = models;
            string url = "/other/hourseschemeIndex";
            ViewBag.PageInfo = new PageModel { PageCount = models.TotalPages, PageIndex = pageindex.HasValue ? pageindex.Value : 1, Url = url };

            return View();
        }


        [HttpPost]
        public JsonResult Createhoursescheme(string name)
        {
            if (string.IsNullOrEmpty(name))
                return new NewJsonResult(new Baseresponse { Message = "名字不能为空", Success = 0 });

            generateService.Addhourse_scheme(new hourse_schemeDto {  hs_name = name });

            return new NewJsonResult(new Baseresponse { Message = "添加成功", Success = 1 });
        }


        public ActionResult GetEdithourseschemeView(int id)
        {
            var model = generateService.Gethourse_schemeById(id);

            return PartialView("Edithoursescheme", model);
        }

        [HttpPost]
        public JsonResult Edithoursescheme(string name, int id)
        {
            if (string.IsNullOrEmpty(name))
                return new NewJsonResult(new Baseresponse { Message = "名字不能为空", Success = 0 });

            var model = generateService.Gethourse_schemeById(id);
            model.hs_name = name;
            generateService.Updatehourse_scheme(model);

            return new NewJsonResult(new Baseresponse { Message = "修改成功", Success = 1 });

        }

        [HttpGet]
        public JsonResult Deletehoursescheme(int id)
        {

            var model = generateService.Gethourse_schemeById(id);
            if (model != null)
                generateService.Deletehourse_scheme(id);

            return new NewJsonResult(new Baseresponse { Message = "删除成功", Success = 1 });

        }
    }
}