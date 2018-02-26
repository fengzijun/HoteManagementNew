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
    public class CosttypeController : BaseController
    {
        // GET: Costtype
        public ActionResult Index(string name, int? pageindex)
        {
            var models = generateService.Getcost_typeList(UserInfo.hotelid, name, 1, pageindex.HasValue ? pageindex.Value : 1, 50);

            ViewBag.cost_typelist = models;
            string url = string.Format("/cost_type/index?name={0}", name);
            ViewBag.PageInfo = new PageModel { PageCount = models.TotalPages, PageIndex = pageindex.HasValue ? pageindex.Value : 1, Url = url };

            ViewBag.Categorys = generateService.Getcost_typeList(UserInfo.hotelid, null, 0);
            return View();
        }

        public ActionResult CategoryIndex(int? pageindex)
        {
            var models = generateService.Getcost_typeList(UserInfo.hotelid, null, 0, pageindex.HasValue ? pageindex.Value : 1, 50);

            ViewBag.cost_typelist = models;
            string url = "/cost_type/CategoryIndex";
            ViewBag.PageInfo = new PageModel { PageCount = models.TotalPages, PageIndex = pageindex.HasValue ? pageindex.Value : 1, Url = url };

            //ViewBag.Categorys = generateService.Getcost_typeList(UserInfo.hotelid, null, 0);
            return View();
        }


        [HttpPost]
        public JsonResult Createcost_type(Createcost_typeRequest request)
        {
            if (string.IsNullOrEmpty(request.Name))
                return new NewJsonResult(new Baseresponse { Message = "名字不能为空", Success = 0 });

            decimal price = 0;
            int score = 0;
            if (!decimal.TryParse(request.Price, out price))
            {
                return new NewJsonResult(new Baseresponse { Message = "价格，积分请输入正确的数字", Success = 0 });
            }


            if (request.Category == 0)
                return new NewJsonResult(new Baseresponse { Message = "请选择类别", Success = 0 });

            generateService.Addcost_type(new cost_typeDto {   ct_categories = request.Category,  ct_iftype = 1, ct_name = request.Name, ct_number = request.Number, ct_money = decimal.Parse(request.Price), ct_remark = request.Remark, hotelid = UserInfo.hotelid });

            return new NewJsonResult(new Baseresponse { Message = "添加成功", Success = 1 });
        }

        [HttpPost]
        public JsonResult Createcost_typeCategory(Createcost_typeRequest request)
        {
            if (string.IsNullOrEmpty(request.Name))
                return new NewJsonResult(new Baseresponse { Message = "名字不能为空", Success = 0 });

            generateService.Addcost_type(new cost_typeDto { ct_categories = null, ct_iftype = 0,   ct_name = request.Name, ct_remark = string.Empty, hotelid = UserInfo.hotelid , ct_money = null, ct_number = null});

            return new NewJsonResult(new Baseresponse { Message = "添加成功", Success = 1 });
        }

        public ActionResult GetEditcost_typeView(int id)
        {
            var model = generateService.Getcost_typeById(id);
            ViewBag.Categorys = generateService.Getcost_typeList(UserInfo.hotelid, null, 0);
            return PartialView("Editcost_type", model);
        }

        public ActionResult GetEditcost_typecategoryView(int id)
        {
            var model = generateService.Getcost_typeById(id);

            return PartialView("Editcost_typecategory", model);
        }

        [HttpPost]
        public JsonResult Editcost_type(Editcost_typeRequest request)
        {
            if (string.IsNullOrEmpty(request.Name))
                return new NewJsonResult(new Baseresponse { Message = "名字不能为空", Success = 0 });
            decimal price = 0;

            if (!decimal.TryParse(request.Price, out price))
            {
                return new NewJsonResult(new Baseresponse { Message = "价格，积分请输入正确的数字", Success = 0 });
            }

            if (request.Category == 0)
                return new NewJsonResult(new Baseresponse { Message = "请选择类别", Success = 0 });

            var model = generateService.Getcost_typeById(request.Id);
            model.ct_name = request.Name;
            model.ct_categories = request.Category;
            model.ct_number = request.Number;
            model.ct_remark = request.Remark;
            model.ct_money = decimal.Parse(request.Price);
            generateService.Updatecost_type(model);

            return new NewJsonResult(new Baseresponse { Message = "修改成功", Success = 1 });

        }

        [HttpPost]
        public JsonResult Editcost_typecategory(Editcost_typeRequest request)
        {
            if (string.IsNullOrEmpty(request.Name))
                return new NewJsonResult(new Baseresponse { Message = "名字不能为空", Success = 0 });


            var model = generateService.Getcost_typeById(request.Id);
            model.ct_name = request.Name;

            generateService.Updatecost_type(model);

            return new NewJsonResult(new Baseresponse { Message = "修改成功", Success = 1 });

        }

        [HttpGet]
        public JsonResult Deletecost_type(int id)
        {

            var model = generateService.Getcost_typeById(id);
            if (model != null)
                generateService.Deletecost_type(id);

            return new NewJsonResult(new Baseresponse { Message = "删除成功", Success = 1 });

        }
    }
}