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
    public class UserController : BaseController
    {
        // GET: User
        public ActionResult Index(int? pageindex)
        {

            var models = generateService.GetAccounts_UsersList(UserInfo.hotelid, pageindex.HasValue ? pageindex.Value : 1, 50);

            ViewBag.Userlist = models;
            string url = "/User/index";
            ViewBag.PageInfo = new PageModel { PageCount = models.TotalPages, PageIndex = pageindex.HasValue ? pageindex.Value : 1, Url = url };

            if(!UserInfo.hotelid.HasValue)
            {
                PrepareHotelList(null, null, null, 0, null, false);
            }

            PrepareRoleList(UserInfo.hotelid, false);

            return View();
        }

      

        [HttpPost]
        public JsonResult CreateUser(CreateUserRequest request)
        {

            if(request == null)
                return new NewJsonResult(new Baseresponse { Message = "参数不能为空", Success = 0 });

            if (string.IsNullOrEmpty(request.AccountName))
                return new NewJsonResult(new Baseresponse { Message = "名字不能为空", Success = 0 });

            if (string.IsNullOrEmpty(request.Pwd))
                return new NewJsonResult(new Baseresponse { Message = "密码不能为空", Success = 0 });

            if (request.Pwd != request.ConfirmPwd)
                return new NewJsonResult(new Baseresponse { Message = "密码不匹配", Success = 0 });

          

            int? hotelid = null;

            if (UserInfo.hotelid.HasValue)
            {
                hotelid = UserInfo.hotelid;
            }
            else if(request.HotelId.HasValue && request.HotelId.Value!=0)
            {
                hotelid = request.HotelId.Value;
            }

            var model = generateService.GetAccounts_UsersByName(UserInfo.hotelid, request.AccountName);

            if (model != null)
                return new NewJsonResult(new Baseresponse { Message = "名字不能重复", Success = 0 });

            int userid = generateService.AddAccounts_Users(new Accounts_UsersDto { hotelid = hotelid, Phone = request.Mobile, UserID = Guid.NewGuid().ToString(), Activity = true, UserType = "AA", EmployeeID = 0, DepartmentID = string.Empty, Password = request.Pwd, Email = string.Empty, Sex = request.Gender , Style = 0, TrueName = request.TureName, UserName = request.AccountName });

            generateService.AddAccounts_UserRoles(new Accounts_UserRolesDto { RoleID = request.RoleId, UserID = userid });

            return new NewJsonResult(new Baseresponse { Message = "添加成功", Success = 1 });
        }

        public ActionResult GetEditUserView(int id)
        {
            var model = generateService.GetAccounts_UsersById(id);
            if (!UserInfo.hotelid.HasValue)
            {
                PrepareHotelList(null, null, null, 0, null, false);
            }

            PrepareRoleList(UserInfo.hotelid, false);
            return PartialView("EditUser", model);
        }

        [HttpPost]
        public JsonResult EditUser(EditUserRequest request)
        {
            if (request == null)
                return new NewJsonResult(new Baseresponse { Message = "参数不能为空", Success = 0 });

            if (string.IsNullOrEmpty(request.AccountName))
                return new NewJsonResult(new Baseresponse { Message = "名字不能为空", Success = 0 });

            if (string.IsNullOrEmpty(request.Pwd))
                return new NewJsonResult(new Baseresponse { Message = "密码不能为空", Success = 0 });

            if (request.Pwd != request.ConfirmPwd)
                return new NewJsonResult(new Baseresponse { Message = "密码不匹配", Success = 0 });

            var model = generateService.GetAccounts_UsersByName(UserInfo.hotelid, request.AccountName);

            if (model != null)
                return new NewJsonResult(new Baseresponse { Message = "名字不能重复", Success = 0 });

            int? hotelid = null;

            if (UserInfo.hotelid.HasValue)
            {
                hotelid = UserInfo.hotelid;
            }
            else if (request.HotelId.HasValue && request.HotelId.Value != 0)
            {
                hotelid = request.HotelId.Value;
            }

            model = generateService.GetAccounts_UsersById(request.Id);
            model.Password = request.Pwd;
            model.Phone = request.Mobile;
            model.Sex = request.Gender;
            model.TrueName = request.TureName;
            model.hotelid = hotelid;

            var userrolemodel = generateService.GetAccounts_UserRolesByUserId(UserInfo.Id);
            userrolemodel.RoleID = request.RoleId;
            generateService.UpdateAccounts_UserRoles(userrolemodel);

            generateService.UpdateAccounts_Users(model);

            return new NewJsonResult(new Baseresponse { Message = "修改成功", Success = 1 });

        }

        [HttpGet]
        public JsonResult DeleteUser(int id)
        {

            var model = generateService.GetAccounts_UsersById(id);
            if (model != null)
                generateService.DeleteAccounts_Users(id);

            return new NewJsonResult(new Baseresponse { Message = "删除成功", Success = 1 });

        }


    }
}