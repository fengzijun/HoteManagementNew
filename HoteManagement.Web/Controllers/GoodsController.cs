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
    public class GoodsController : BaseController
    {
        // GET: Goods
        public ActionResult Index(string goodsname,int? pageindex)
        {
            var models = generateService.GetGoodsList(UserInfo.hotelid,goodsname,1, pageindex.HasValue ? pageindex.Value : 1, 50);

            ViewBag.goodslist = models;
            string url = string.Format("/goods/index?goodsname={0}", goodsname);
            ViewBag.PageInfo = new PageModel { PageCount = models.TotalPages, PageIndex = pageindex.HasValue ? pageindex.Value : 1, Url = url };
         
            ViewBag.Categorys = generateService.GetGoodsList(UserInfo.hotelid, null, 0);
            return View();
        }

        public ActionResult CategoryIndex(int? pageindex)
        {
            var models = generateService.GetGoodsList(UserInfo.hotelid, null, 0, pageindex.HasValue ? pageindex.Value : 1, 50);

            ViewBag.goodslist = models;
            string url = "/goods/CategoryIndex";
            ViewBag.PageInfo = new PageModel { PageCount = models.TotalPages, PageIndex = pageindex.HasValue ? pageindex.Value : 1, Url = url };

            //ViewBag.Categorys = generateService.GetGoodsList(UserInfo.hotelid, null, 0);
            return View();
        }


        [HttpPost]
        public JsonResult Creategoods(CreategoodsRequest request)
        {
            if (string.IsNullOrEmpty(request.Name))
                return new NewJsonResult(new Baseresponse { Message = "名字不能为空", Success = 0 });

            decimal price = 0;
            int score = 0;
            if(!decimal.TryParse(request.Price,out price))
            {
                return new NewJsonResult(new Baseresponse { Message = "价格，积分请输入正确的数字", Success = 0 });
            }

            if (!int.TryParse(request.Score, out score))
            {
                return new NewJsonResult(new Baseresponse { Message = "价格，积分请输入正确的数字", Success = 0 });
            }

            if (request.Category == 0)
                return new NewJsonResult(new Baseresponse { Message = "请选择类别", Success = 0 });

            generateService.AddGoods(new GoodsDto { Goods_categories = request.Category, Goods_ifType = 1, Goods_jf = int.Parse(request.Score), Goods_name = request.Name, Goods_number = request.Number, Goods_price = decimal.Parse(request.Price), Goods_Remaker = request.Remark, Goods_spell = string.Empty, Goods_state = request.Status.ToString(), Goods_unit = request.Unit, hotelid = UserInfo.hotelid  });

            return new NewJsonResult(new Baseresponse { Message = "添加成功", Success = 1 });
        }

        [HttpPost]
        public JsonResult CreategoodsCategory(CreategoodsRequest request)
        {
            if (string.IsNullOrEmpty(request.Name))
                return new NewJsonResult(new Baseresponse { Message = "名字不能为空", Success = 0 });

            generateService.AddGoods(new GoodsDto { Goods_categories = null, Goods_ifType = 0, Goods_name = request.Name,  Goods_Remaker = request.Remark, hotelid = UserInfo.hotelid });

            return new NewJsonResult(new Baseresponse { Message = "添加成功", Success = 1 });
        }



        public ActionResult GetEditgoodsView(int id)
        {
            var model = generateService.GetGoodsById(id);
            ViewBag.Categorys = generateService.GetGoodsList(UserInfo.hotelid, null, 0);
            return PartialView("Editgoods", model);
        }

        public ActionResult GetEditgoodscategoryView(int id)
        {
            var model = generateService.GetGoodsById(id);
         
            return PartialView("Editgoodscategory", model);
        }

        [HttpPost]
        public JsonResult Editgoods(EditgoodsRequest request)
        {
            if (string.IsNullOrEmpty(request.Name))
                return new NewJsonResult(new Baseresponse { Message = "名字不能为空", Success = 0 });
            decimal price = 0;
            int score = 0;
            if (!decimal.TryParse(request.Price, out price))
            {
                return new NewJsonResult(new Baseresponse { Message = "价格，积分请输入正确的数字", Success = 0 });
            }

            if (!int.TryParse(request.Score, out score))
            {
                return new NewJsonResult(new Baseresponse { Message = "价格，积分请输入正确的数字", Success = 0 });
            }

            if (request.Category == 0)
                return new NewJsonResult(new Baseresponse { Message = "请选择类别", Success = 0 });

            var model = generateService.GetGoodsById(request.Id);
            model.Goods_name = request.Name;
            model.Goods_categories = request.Category;
            model.Goods_jf = int.Parse(request.Score);
            model.Goods_number = request.Number;
            model.Goods_Remaker = request.Remark;
            model.Goods_unit = request.Unit;
            model.Goods_price = decimal.Parse(request.Price);
            model.Goods_state = request.Status.ToString();
            generateService.UpdateGoods(model);

            return new NewJsonResult(new Baseresponse { Message = "修改成功", Success = 1 });

        }

        [HttpPost]
        public JsonResult Editgoodscategory(EditgoodsRequest request)
        {
            if (string.IsNullOrEmpty(request.Name))
                return new NewJsonResult(new Baseresponse { Message = "名字不能为空", Success = 0 });
        

            var model = generateService.GetGoodsById(request.Id);
            model.Goods_name = request.Name;
       
            generateService.UpdateGoods(model);

            return new NewJsonResult(new Baseresponse { Message = "修改成功", Success = 1 });

        }


        [HttpGet]
        public JsonResult Deletegoods(int id)
        {

            var model = generateService.GetGoodsById(id);
            if (model != null)
                generateService.DeleteGoods(id);

            return new NewJsonResult(new Baseresponse { Message = "删除成功", Success = 1 });

        }

    }
}