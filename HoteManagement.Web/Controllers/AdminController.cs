using HoteManagement.Service.Model;
using HoteManagement.Web.Core;
using HoteManagement.Web.Models;
using HoteManagement.Web.Models.Api;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HoteManagement.Web.Controllers
{
    public class AdminController : BaseController
    {

        public AdminController()
        {

        }

        [HotelAuthorize]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = generateService.GetUserinfoByUsernameAndPwd(model.UserName, model.Password);
            if(user!=null)
            {

                FormsAuthenticationTicket authTicket =
                    new FormsAuthenticationTicket(
             1,
             model.UserName,
             DateTime.Now,
             DateTime.Now.AddDays(30),
             false, //pass here true, if you want to implement remember me functionality
             Newtonsoft.Json.JsonConvert.SerializeObject(user));

                string encTicket = FormsAuthentication.Encrypt(authTicket);
                HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                Response.Cookies.Add(faCookie);

                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "用户名密码错误。");
            return View(model);

        }


        public async Task<ActionResult> Loginout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        public ActionResult ValidateCode()
        {
            string[] str = new string[4];
            string serverCode = "";
            //生成随机生成器 
            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                str[i] = random.Next(10).ToString().Substring(0, 1);
            }
             byte[] bytes = CreateCheckCodeImage(str);
            foreach (string s in str)
            {
                serverCode += s;
            }
            Session["CheckCode"] = serverCode;
            return File(bytes, @"image/jpeg");
        }

        public ActionResult CreateBusiness()
        {
            GetProjectType();

            return View();
        }

        public ActionResult EditBusiness()
        {
            GetProjectType();

            return View();
        }

        public void GetProjectType()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            //编制、审计
            list.Add(new SelectListItem { Text = "编制", Value = "编制" });
            list.Add(new SelectListItem { Text = "审计", Value = "审计" });
            ViewBag.ProjectList = list;
        }

        [HttpPost]
        public ActionResult CreateBusiness(CreateOrgBusinessRequest request)
        {
            if (!ModelState.IsValid)
            {
                GetProjectType();
                return View();
            }
               

            if(Request.Files.Count<3)
            {
                ModelState.AddModelError("","请上传制定的附件");
                GetProjectType();
                return View();
            }

            string contract = string.Empty;
            string report = string.Empty;
            string price = string.Empty;
            string other = string.Empty;
            string path = Server.MapPath("~/upload");
            contract = Guid.NewGuid().ToString();
            report = Guid.NewGuid().ToString();
            price = Guid.NewGuid().ToString();

            if(Request.Files.Count == 4)
                other = Guid.NewGuid().ToString();
            
            Request.Files[0].SaveAs(path + "/" + contract + ".doc");
            Request.Files[1].SaveAs(path + "/" + report + ".doc");
            Request.Files[2].SaveAs(path + "/" + price + ".doc");

            if (Request.Files.Count == 4)
                Request.Files[3].SaveAs(path + "/" + other + ".doc");

            Org_BusinessDto business = new Org_BusinessDto
            {
                auditunit = request.auditunit,
                buildunit = request.buildunit,
                compileunit = request.compileunit,
                createtime = DateTime.Now,
                creator = UserInfo.LoginName,
                creatorid = UserInfo.LoginID,
                orgname = UserInfo.OrgName,
                projectname = request.projectname,
                projectsummary = request.projectsummary,
                projecttype = request.projecttype,
                statues = 0,
                updatetime = DateTime.Now,
                contract = contract,
                other = other,
                price = price,
                report = report
            };

            generateService.CreateBusiness(business);

            return Redirect("/sys/OperationResult?returnurl=/Admin/CreateBusiness");

        }

        [HttpPost]
        public ActionResult EditBusiness(EditOrgBusinessRequest request)
        {
            if (!ModelState.IsValid)
            {
                GetProjectType();
                return View();
            }


            if (Request.Files.Count < 3)
            {
                ModelState.AddModelError("", "请上传制定的附件");
                GetProjectType();
                return View();
            }

            string contract = string.Empty;
            string report = string.Empty;
            string price = string.Empty;
            string other = string.Empty;
            string path = Server.MapPath("~/upload");
            contract = Guid.NewGuid().ToString();
            report = Guid.NewGuid().ToString();
            price = Guid.NewGuid().ToString();

          

            if (Request.Files.Count == 4)
                other = Guid.NewGuid().ToString();

            Request.Files[0].SaveAs(path + "/" + contract + ".doc");
            Request.Files[1].SaveAs(path + "/" + report + ".doc");
            Request.Files[2].SaveAs(path + "/" + price + ".doc");

            if (Request.Files.Count == 4)
                Request.Files[3].SaveAs(path + "/" + other + ".doc");

            Org_BusinessDto business = new Org_BusinessDto
            {
                auditunit = request.auditunit,
                buildunit = request.buildunit,
                compileunit = request.compileunit,
                createtime = DateTime.Now,
                creator = UserInfo.LoginName,
                creatorid = UserInfo.LoginID,
                orgname = UserInfo.OrgName,
                projectname = request.projectname,
                projectsummary = request.projectsummary,
                projecttype = request.projecttype,
                statues = 0,
                updatetime = DateTime.Now,
                contract = contract,
                other = other,
                price = price,
                report = report
            };

            generateService.CreateBusiness(business);

            return Redirect("/sys/OperationResult?returnurl=/Admin/CreateBusiness");

        }
    }
}