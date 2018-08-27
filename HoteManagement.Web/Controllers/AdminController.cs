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
    //[HotelAuthorize]
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            logger.WriteWarn("start login");
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
                logger.WriteWarn("end login");
                return RedirectToAction("getbusiness");
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

        public ActionResult EditBusiness(int id)
        {
            var model = generateService.GetBusiness(id);
            GetProjectType();

            return View(model);
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


            if (!string.IsNullOrEmpty(Request.Files[0].FileName))
            {
                contract = Guid.NewGuid().ToString();
                Request.Files[0].SaveAs(path + "/" + contract + ".doc");
            }

            if (!string.IsNullOrEmpty(Request.Files[1].FileName))
            {
                report = Guid.NewGuid().ToString();
                Request.Files[1].SaveAs(path + "/" + report + ".doc");
            }

            if (!string.IsNullOrEmpty(Request.Files[2].FileName))
            {
                price = Guid.NewGuid().ToString();
                Request.Files[2].SaveAs(path + "/" + price + ".doc");
            }

            if (!string.IsNullOrEmpty(Request.Files[3].FileName))
            {
                other = Guid.NewGuid().ToString();
                Request.Files[3].SaveAs(path + "/" + other + ".doc");
            }

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

            return Redirect("/sys/OperationResult?returnurl=/Admin/getBusiness");

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
               
            if (!string.IsNullOrEmpty(Request.Files[0].FileName))
            {
                contract = Guid.NewGuid().ToString();
                Request.Files[0].SaveAs(path + "/" + contract + ".doc");
            }
                
            if (!string.IsNullOrEmpty(Request.Files[1].FileName))
            {
                report = Guid.NewGuid().ToString();
                Request.Files[1].SaveAs(path + "/" + report + ".doc");
            }
               
            if (!string.IsNullOrEmpty(Request.Files[2].FileName))
            {
                price = Guid.NewGuid().ToString();
                Request.Files[2].SaveAs(path + "/" + price + ".doc");
            }
               
            if (!string.IsNullOrEmpty(Request.Files[3].FileName))
            {
                other = Guid.NewGuid().ToString();
                Request.Files[3].SaveAs(path + "/" + other + ".doc");
            }
               

            Org_BusinessDto business = generateService.GetBusiness(request.Id);
            business.auditunit = request.auditunit;
            business.compileunit = request.compileunit;
            if (!string.IsNullOrEmpty(contract))
                business.contract = contract;
            if (!string.IsNullOrEmpty(other))
                business.other = other;
            if (!string.IsNullOrEmpty(price))
                business.price = price;
            if (!string.IsNullOrEmpty(report))
                business.price = report;

            business.projectname = request.projectname;
            business.projectsummary = request.projectsummary;
            business.projecttype = request.projecttype;
            business.updatetime = DateTime.Now;
            business.buildunit = request.buildunit;
            

            generateService.UpdateBusiness(business);

            return Redirect("/sys/OperationResult?returnurl=/Admin/getBusiness");

        }


        public ActionResult GetBusiness(int? pageindex,int? loginid)
        {
            logger.WriteWarn("start getbusiness");
            int pagecount = 0;
            int? accountid = 0;
            if(loginid.HasValue)
            {
                var user = generateService.GetUserById(loginid.Value);
                if (user != null)
                {

                    FormsAuthenticationTicket authTicket =
                        new FormsAuthenticationTicket(
                 1,
                 user.LoginName,
                 DateTime.Now,
                 DateTime.Now.AddDays(30),
                 false, //pass here true, if you want to implement remember me functionality
                 Newtonsoft.Json.JsonConvert.SerializeObject(user));

                    string encTicket = FormsAuthentication.Encrypt(authTicket);
                    HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                    Response.Cookies.Add(faCookie);
   
                }

                accountid = user.OrgName == "管理员" ? (int?)null : user.LoginID; ;
                ViewBag.loginid = loginid.Value;
            }
            else
            {
                accountid = UserInfo.OrgName == "管理员" ? (int?)null : UserInfo.LoginID;
            }

            //int? loginid = loginid.HasValue : loginid.Value: ( UserInfo.UserType == "管理用户" ? (int?)null : UserInfo.LoginID );
            var models = generateService.GetBusiness(accountid, null, false ,( pageindex.HasValue ? pageindex.Value : 1)-1, out pagecount);
            string url = "/Admin/GetBusiness";
            ViewBag.PageInfo = new PageModel { PageCount = pagecount, PageIndex = pageindex.HasValue ? pageindex.Value : 1, Url = url };
            return View(models);
        }

        public ActionResult filedownload(string id)
        {
            if (string.IsNullOrEmpty(id))
                return HttpNotFound();

            string path = Server.MapPath("~/upload");
            string filename = System.IO.Path.Combine(path, id + ".doc");
            if(System.IO.File.Exists(filename))
            {
                return File(filename, "application/msword");
            }

            return HttpNotFound();
        }


        public ActionResult AuditBusiness(int id)
        {
            var model = generateService.GetBusiness(id);
            GetProjectType();
            AuditBusinessRequest auditBusinessRequest = new AuditBusinessRequest { Id = id, ApprovalStatues = 0, Model = model };
            return View(auditBusinessRequest);

        }

        [HttpPost]
        public ActionResult AuditBusiness(AuditBusinessRequest request)
        {
            var model = generateService.GetBusiness(request.Id);
            //GetProjectType();
            model.statues = request.ApprovalStatues == 1 ? 1 : -1;
            generateService.UpdateBusiness(model);
            return Redirect("/sys/OperationResult?returnurl=/Admin/getBusiness");

        }
    }
}