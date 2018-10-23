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


        public ActionResult CreateBusiness(int? userid)
        {
            GetProjectType();
            CreateOrgBusinessRequest createOrgBusinessRequest = new CreateOrgBusinessRequest { UserId = userid ?? 0 };
            return View(createOrgBusinessRequest);
        }

        public ActionResult EditBusiness(int id,int? userid)
        {
            var model = generateService.GetBusiness(id);
            GetProjectType();
            model.UserId = userid;
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

            if(request == null)
            {
                ModelState.AddModelError("", "参数不能为空");
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

            UserInfoDto user = null;
            if(request.UserId.HasValue && request.UserId.Value!=0)
            {
                user = generateService.GetUserById(request.UserId.Value);
            }
            else
            {
                user = UserInfo;
            }

            Org_BusinessDto business = new Org_BusinessDto
            {
                auditunit = request.auditunit,
                buildunit = request.buildunit,
                compileunit = request.compileunit,
                createtime = DateTime.Now,
                creator = UserInfo?.LoginName,
                creatorid = UserInfo?.LoginID,
                orgname = UserInfo?.OrgName??string.Empty,
                projectname = request.projectname??string.Empty,
                projectsummary = request.projectsummary??string.Empty,
                projecttype = request.projecttype??string.Empty,
                statues = 0,
                updatetime = DateTime.Now,
                contract = contract,
                other = other,
                price = price,
                report = report
            };

            generateService.CreateBusiness(business);
            if(request.UserId.HasValue && request.UserId.Value !=0)
            {
                return Redirect("/sys/OperationResult?returnurl=/Admin/getBusiness?loginid=" + user.LoginID);
            }
            else
            {
                return Redirect("/sys/OperationResult?returnurl=/Admin/getBusiness");
            }
           

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
            if(request.UserId.HasValue && request.UserId.Value!=0)
            {
                return Redirect("/sys/OperationResult?returnurl=/Admin/getBusiness?login=" + request.UserId.Value);
            }
            else
            {
                return Redirect("/sys/OperationResult?returnurl=/Admin/getBusiness");
            }
            

        }


        public ActionResult GetBusiness(int? pageindex,int? loginid,string name,string compileunit,string auditunit, int? approvalstatues,string unitname,DateTime? time)
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

                if (user !=null && !string.IsNullOrEmpty(user.OrgName) && user.OrgName == "管理员")
                {
                    accountid = (int?)null;
                }
                else
                {
                    accountid = user.LoginID;
                }

                ViewBag.UserId = loginid.Value;

            }
            else
            {
                accountid = UserInfo.OrgName == "管理员" ? (int?)null : UserInfo.LoginID;
            }

            //int? loginid = loginid.HasValue : loginid.Value: ( UserInfo.UserType == "管理用户" ? (int?)null : UserInfo.LoginID );
            var models = generateService.GetBusiness(accountid, null, name, approvalstatues, unitname, compileunit, auditunit, time, (pageindex.HasValue ? pageindex.Value : 1) - 1, out pagecount);
            
            string url = $"/Admin/GetBusiness?loginid={loginid}&approvalstatues={approvalstatues}&name={name}&unitname={unitname}&compileunit={compileunit}&auditunit={auditunit}&time={time}";
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


        public ActionResult AuditBusiness(int id,int? userid)
        {
            var model = generateService.GetBusiness(id);
            GetProjectType();
            AuditBusinessRequest auditBusinessRequest = new AuditBusinessRequest { Id = id, ApprovalStatues = 0, Model = model, UserId = userid };
            return View(auditBusinessRequest);

        }

        [HttpPost]
        public ActionResult AuditBusiness(AuditBusinessRequest request)
        {
            var model = generateService.GetBusiness(request.Id);
            //GetProjectType();
            model.statues = request.ApprovalStatues == 1 ? 1 : -1;
            generateService.UpdateBusiness(model);
            if(request.UserId.HasValue && request.UserId.Value!=0)
            {
                return Redirect("/sys/OperationResult?returnurl=/Admin/getBusiness?loginid=" + request.UserId.Value);
            }
            else
            {
                return Redirect("/sys/OperationResult?returnurl=/Admin/getBusiness");
            }


        }

        public ActionResult EditProjectSettlement(int id, int? userid)
        {
            var model = generateService.GetProjectSettlement(id);
            GetProjectType();
            model.UserId = userid.HasValue ? userid.Value : 0;
            ViewBag.UserId = model.UserId;
            CreateProjectSettlementRequest createProjectSettlementRequest = new CreateProjectSettlementRequest
            {
                id = id,
                auditendtime = model.auditendtime,
                auditstarttime = model.auditstarttime,
                contact = model.contact,
                contact2 = model.contact2,
                contact3 = model.contact3,
                cprice = model.cprice,
                createid = model.UserId == 0? UserInfo.LoginID : model.UserId,
                idcard = model.idcard,
                idcard2 = model.idcard2,
                idcard3 = model.idcard3,
                level = model.unitlevel,
                mobile = model.mobile,
                mobile2 = model.mobile2,
                mobile3 = model.mobile3,
                orgcode = model.orgcode,
                orgcode3 = model.orgcode3,
                orgname2 = model.orgname2,
                projectaddress = model.projectaddress,
                projectfeature = model.projectfeature,
                projectname = model.projectname,
                projectsope = model.projectsope,
                projecttype = model.projecttype,
                sdprice = model.sdprice,
                sprice = model.sprice,
                timeoutreasion = model.timeoutreasion,
                unitaddress = model.unitaddress,
                unitaddress2 = model.unitaddress2,
                unitaddress3 = model.unitaddress3,
                unitname = model.unitname,
                unitname2 = model.unitname2,
                unitname3 = model.unitname3,
                unitphone = model.unitphone,
                unitphone2 = model.unitphone2,
                unitphone3 = model.unitphone3,
                unittype = model.unittype,
                unitzip = model.unitzip,
                unitzip3 = model.unitzip3,
                zprice = model.zprice,
                approvalstatues = model.approvalstatues,
                createtime = model.createtime,
                major = model.major,
                sauser = model.sauser,
                unitprojectname = model.unitprojectname,
                suser = model.suser,
                updatetime = model.updatetime,
                UserId = model.UserId,
                certificate = model.certificate,
                reasion = model.reasion,
                qualification = model.qualification,
                applyfile = model.applyfile,
                certificate2 = model.certificate2,
                qualification2 = model.qualification2,
                recordfile = model.recordfile,
                reportfile = model.reportfile,
                pricefile = model.pricefile,
                otherfile = model.otherfile
            };
            return View(createProjectSettlementRequest);
        }

        public ActionResult AuditProjectSettlement(int id, int? userid)
        {
            var model = generateService.GetProjectSettlement(id);
            GetProjectType();
            model.UserId = userid.HasValue ? userid.Value : 0;
            ViewBag.UserId = userid;
            CreateProjectSettlementRequest createProjectSettlementRequest = new CreateProjectSettlementRequest
            {
                id = id,
                auditendtime = model.auditendtime,
                auditstarttime = model.auditstarttime,
                contact = model.contact,
                contact2 = model.contact2,
                contact3 = model.contact3,
                cprice = model.cprice,
                createid = model.createid,
                idcard = model.idcard,
                idcard2 = model.idcard2,
                idcard3 = model.idcard3,
                level = model.unitlevel,
                mobile = model.mobile,
                mobile2 = model.mobile2,
                mobile3 = model.mobile3,
                orgcode = model.orgcode,
                orgcode3 = model.orgcode3,
                orgname2 = model.orgname2,
                projectaddress = model.projectaddress,
                projectfeature = model.projectfeature,
                projectname = model.projectname,
                projectsope = model.projectsope,
                projecttype = model.projecttype,
                sdprice = model.sdprice,
                sprice = model.sprice,
                timeoutreasion = model.timeoutreasion,
                unitaddress = model.unitaddress,
                unitaddress2 = model.unitaddress2,
                unitaddress3 = model.unitaddress3,
                unitname = model.unitname,
                unitname2 = model.unitname2,
                unitname3 = model.unitname3,
                unitphone = model.unitphone,
                unitphone2 = model.unitphone2,
                unitphone3 = model.unitphone3,
                unittype = model.unittype,
                unitzip = model.unitzip,
                unitzip3 = model.unitzip3,
                zprice = model.zprice,
                approvalstatues = model.approvalstatues,
                createtime = model.createtime,
                major = model.major,
                sauser = model.sauser,
                unitprojectname = model.unitprojectname,
                suser = model.suser,
                updatetime = model.updatetime,
                UserId = model.UserId,
                qualification = model.qualification,
                reasion = model.reasion,
                certificate = model.certificate,
                certificate2 = model.certificate2,
                qualification2 = model.qualification2,
                otherfile = model.otherfile,
                pricefile = model.pricefile,
                reportfile = model.reportfile,
                recordfile = model.recordfile,
                applyfile = model.applyfile
            };
            return View(createProjectSettlementRequest);
        }


        public ActionResult CreateProjectSettlement(int? userid)
        {
            CreateProjectSettlementRequest createProjectSettlementRequest = new CreateProjectSettlementRequest { UserId = userid.HasValue? userid.Value:0, auditendtime = DateTime.Now, auditstarttime = DateTime.Now   };
            ViewBag.UserId = userid.HasValue ? userid.Value : 0;
            return View(createProjectSettlementRequest);
        }

        [HttpPost]
        public ActionResult CreateProjectSettlement(CreateProjectSettlementRequest createProjectSettlementRequest)
        {

            ProjectSettlementDto projectSettlement = new ProjectSettlementDto
            {
                approvalstatues = 0,
                auditendtime = createProjectSettlementRequest.auditendtime,
                auditstarttime = createProjectSettlementRequest.auditstarttime,
                contact = createProjectSettlementRequest.contact,
                contact2 = createProjectSettlementRequest.contact2,
                contact3 = createProjectSettlementRequest.contact3,
                cprice = createProjectSettlementRequest.cprice,
                createid = createProjectSettlementRequest.UserId == 0 ? UserInfo.LoginID: createProjectSettlementRequest.UserId,
                createtime = DateTime.Now,
                idcard = createProjectSettlementRequest.idcard,
                idcard2 = createProjectSettlementRequest.idcard2,
                idcard3 = createProjectSettlementRequest.idcard3,
                unitlevel = createProjectSettlementRequest.level,
                mobile = createProjectSettlementRequest.mobile,
                mobile2 = createProjectSettlementRequest.mobile2,
                mobile3 = createProjectSettlementRequest.mobile3,
                orgcode = createProjectSettlementRequest.orgcode,
                orgcode3 = createProjectSettlementRequest.orgcode3,
                orgname2 = createProjectSettlementRequest.orgname2,
                projectaddress = createProjectSettlementRequest.projectaddress,
                projectfeature = createProjectSettlementRequest.projectfeature,
                projectname = createProjectSettlementRequest.projectname,
                projectsope = createProjectSettlementRequest.projectsope,
                projecttype = createProjectSettlementRequest.projecttype,
                sdprice = createProjectSettlementRequest.sdprice,
                sprice = createProjectSettlementRequest.sprice,
                timeoutreasion = createProjectSettlementRequest.timeoutreasion,
                unitaddress = createProjectSettlementRequest.unitaddress,
                unitaddress2 = createProjectSettlementRequest.unitaddress2,
                unitaddress3 = createProjectSettlementRequest.unitaddress3,
                unitname = createProjectSettlementRequest.unitname,
                unitname2 = createProjectSettlementRequest.unitname2,
                unitname3 = createProjectSettlementRequest.unitname3,
                unitphone = createProjectSettlementRequest.unitphone,
                unitphone2 = createProjectSettlementRequest.unitphone2,
                unitphone3 = createProjectSettlementRequest.unitphone3,
                unittype = createProjectSettlementRequest.unittype,
                unitzip = createProjectSettlementRequest.unitzip,
                unitzip3 = createProjectSettlementRequest.unitzip3,
                updatetime = DateTime.Now,
                zprice = createProjectSettlementRequest.zprice,
                major = createProjectSettlementRequest.major,
                sauser = createProjectSettlementRequest.sauser,
                suser = createProjectSettlementRequest.suser,
                unitprojectname = createProjectSettlementRequest.unitprojectname,
                certificate = createProjectSettlementRequest.certificate,
                reasion = createProjectSettlementRequest.reasion,
                qualification = createProjectSettlementRequest.qualification,
                qualification2 = createProjectSettlementRequest.qualification2,
                certificate2 = createProjectSettlementRequest.certificate2,
                applyfile = createProjectSettlementRequest.applyfile,
                recordfile = createProjectSettlementRequest.recordfile,
                reportfile = createProjectSettlementRequest.reportfile,
                pricefile = createProjectSettlementRequest.pricefile,
                otherfile = createProjectSettlementRequest.otherfile,

            };

            string path = Server.MapPath("~/upload");
            if (!string.IsNullOrEmpty(Request.Files[0].FileName))
            {
                var id = Guid.NewGuid().ToString();
                string ext = Request.Files[0].FileName.GetFileExt();
                if (!string.IsNullOrEmpty(ext))
                {
                    Request.Files[0].SaveAs(path + "/" + id + "." + ext);
                    projectSettlement.applyfile = id + "." + ext;
                }
            }

            if (!string.IsNullOrEmpty(Request.Files[1].FileName))
            {
                var id = Guid.NewGuid().ToString();
                string ext = Request.Files[1].FileName.GetFileExt();
                if (!string.IsNullOrEmpty(ext))
                {
                    Request.Files[1].SaveAs(path + "/" + id + "." + ext);
                    projectSettlement.recordfile = id + "." + ext;
                }
            }

            if (!string.IsNullOrEmpty(Request.Files[2].FileName))
            {
                var id = Guid.NewGuid().ToString();
                string ext = Request.Files[2].FileName.GetFileExt();
                if (!string.IsNullOrEmpty(ext))
                {
                    Request.Files[2].SaveAs(path + "/" + id + "." + ext);
                    projectSettlement.reportfile = id + "." + ext;
                }
            }

            if (!string.IsNullOrEmpty(Request.Files[3].FileName))
            {
                var id = Guid.NewGuid().ToString();
                string ext = Request.Files[3].FileName.GetFileExt();
                if (!string.IsNullOrEmpty(ext))
                {
                    Request.Files[3].SaveAs(path + "/" + id + "." + ext);
                    projectSettlement.pricefile = id + "." + ext;
                }
            }

            if (!string.IsNullOrEmpty(Request.Files[4].FileName))
            {
                var id = Guid.NewGuid().ToString();
                string ext = Request.Files[4].FileName.GetFileExt();
                if (!string.IsNullOrEmpty(ext))
                {
                    Request.Files[4].SaveAs(path + "/" + id + "." + ext);
                    projectSettlement.otherfile = id + "." + ext;
                }
            }


            generateService.CreateProjectSettlement(projectSettlement);
            if(createProjectSettlementRequest.UserId!=0)
            {
                return Redirect("/sys/OperationResult?returnurl=/Admin/GetProjectSettlement?loginid=" + createProjectSettlementRequest.UserId);
            }
            else
            {
                return Redirect("/sys/OperationResult?returnurl=/Admin/GetProjectSettlement");
            }
           

        }


        [HttpPost]
        public ActionResult EditProjectSettlement(CreateProjectSettlementRequest createProjectSettlementRequest)
        {
            var orginmodel = generateService.GetProjectSettlement(createProjectSettlementRequest.id);
            var model = createProjectSettlementRequest;
            ProjectSettlementDto project = new ProjectSettlementDto
            {
                auditendtime = model.auditendtime,
                auditstarttime = model.auditstarttime,
                contact = model.contact,
                contact2 = model.contact2,
                contact3 = model.contact3,
                cprice = model.cprice,
                createid = model.UserId == 0? UserInfo.LoginID : model.UserId,
                idcard = model.idcard,
                idcard2 = model.idcard2,
                idcard3 = model.idcard3,
                unitlevel = model.level,
                mobile = model.mobile,
                mobile2 = model.mobile2,
                mobile3 = model.mobile3,
                orgcode = model.orgcode,
                orgcode3 = model.orgcode3,
                orgname2 = model.orgname2,
                projectaddress = model.projectaddress,
                projectfeature = model.projectfeature,
                projectname = model.projectname,
                projectsope = model.projectsope,
                projecttype = model.projecttype,
                sdprice = model.sdprice,
                sprice = model.sprice,
                timeoutreasion = model.timeoutreasion,
                unitaddress = model.unitaddress,
                unitaddress2 = model.unitaddress2,
                unitaddress3 = model.unitaddress3,
                unitname = model.unitname,
                unitname2 = model.unitname2,
                unitname3 = model.unitname3,
                unitphone = model.unitphone,
                unitphone2 = model.unitphone2,
                unitphone3 = model.unitphone3,
                unittype = model.unittype,
                unitzip = model.unitzip,
                unitzip3 = model.unitzip3,
                zprice = model.zprice,
                approvalstatues = model.approvalstatues,
                createtime = model.createtime,
                id = model.id,
                major = model.major,
                sauser = model.sauser,
                suser = model.suser,
                updatetime = DateTime.Now,
                UserId = model.UserId,
                unitprojectname = model.unitprojectname,
                qualification = model.qualification,
                reasion = model.reasion,
                certificate = model.certificate,
                certificate2 = model.certificate2,
                qualification2 = model.qualification2,
                applyfile = orginmodel.applyfile,
                otherfile = orginmodel.otherfile,
                pricefile = orginmodel.pricefile,
                reportfile = orginmodel.reportfile,
                recordfile = orginmodel.recordfile

            };


            string path = Server.MapPath("~/upload");
            if (!string.IsNullOrEmpty(Request.Files[0].FileName))
            {
                var id = Guid.NewGuid().ToString();
                string ext = Request.Files[0].FileName.GetFileExt();
                if (!string.IsNullOrEmpty(ext))
                {
                    Request.Files[0].SaveAs(path + "/" + id + "." + ext);
                    project.applyfile = id + "." + ext;
                }
            }

            if (!string.IsNullOrEmpty(Request.Files[1].FileName))
            {
                var id = Guid.NewGuid().ToString();
                string ext = Request.Files[1].FileName.GetFileExt();
                if (!string.IsNullOrEmpty(ext))
                {
                    Request.Files[1].SaveAs(path + "/" + id + "." + ext);
                    project.recordfile = id + "." + ext;
                }
            }

            if (!string.IsNullOrEmpty(Request.Files[2].FileName))
            {
                var id = Guid.NewGuid().ToString();
                string ext = Request.Files[2].FileName.GetFileExt();
                if (!string.IsNullOrEmpty(ext))
                {
                    Request.Files[2].SaveAs(path + "/" + id + "." + ext);
                    project.reportfile = id + "." + ext;
                }
            }

            if (!string.IsNullOrEmpty(Request.Files[3].FileName))
            {
                var id = Guid.NewGuid().ToString();
                string ext = Request.Files[3].FileName.GetFileExt();
                if (!string.IsNullOrEmpty(ext))
                {
                    Request.Files[3].SaveAs(path + "/" + id + "." + ext);
                    project.pricefile = id + "." + ext;
                }
            }

            if (!string.IsNullOrEmpty(Request.Files[4].FileName))
            {
                var id = Guid.NewGuid().ToString();
                string ext = Request.Files[4].FileName.GetFileExt();
                if (!string.IsNullOrEmpty(ext))
                {
                    Request.Files[4].SaveAs(path + "/" + id + "." + ext);
                    project.otherfile = id + "." + ext;
                }
            }

            generateService.UpdateProjectSettlement(project);
            if(createProjectSettlementRequest.UserId!=0)
            {
                return Redirect("/sys/OperationResult?returnurl=/Admin/GetProjectSettlement?loginid=" + createProjectSettlementRequest.UserId);
            }
            else
            {
                return Redirect("/sys/OperationResult?returnurl=/Admin/GetProjectSettlement");
            }
          
        }

        [HttpPost]
        public JsonResult AuditProjectSettlement(AuditProjectSettlementRequest auditProjectSettlementRequest)
        {
            //var orginmodel = generateService.GetProjectSettlement(createProjectSettlementRequest.id);
            var model = generateService.GetProjectSettlement(auditProjectSettlementRequest.id);
            model.approvalstatues = auditProjectSettlementRequest.approvalstatues;
            model.reasion = auditProjectSettlementRequest.reasion??string.Empty;

            generateService.UpdateProjectSettlement(model);
            return Json(new { success = 1, message = string.Empty });
        }

        public ActionResult GetProjectSettlement(int? pageindex, int? loginid,int? approvalstatus, string unitname,string unitname2,string unitname3, string projectname, DateTime? starttime,string auditunitname)
        {
          
            int pagecount = 0;
            int? accountid = 0;
            if (loginid.HasValue)
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

                if (user != null && !string.IsNullOrEmpty(user.OrgName) && user.OrgName == "管理员")
                {
                    accountid = (int?)null;
                }
                else
                {
                    accountid = user.LoginID;
                }

                ViewBag.UserId = loginid.Value;

            }
            else
            {
                accountid = UserInfo.OrgName == "管理员" ? (int?)null : UserInfo.LoginID;
            }

            //int? loginid = loginid.HasValue : loginid.Value: ( UserInfo.UserType == "管理用户" ? (int?)null : UserInfo.LoginID );
            var models = generateService.GetProjectSettlements(accountid, (pageindex.HasValue ? pageindex.Value : 1) - 1, approvalstatus, unitname, unitname2, unitname3, projectname, starttime, out pagecount);
            string url = $"/Admin/GetProjectSettlement?loginid={loginid}&approvalstatus={approvalstatus}&unitname={unitname}&unitname2={unitname2}&unitname3={unitname3}&projectname={projectname}&starttime={starttime}";
            ViewBag.PageInfo = new PageModel { PageCount = pagecount, PageIndex = pageindex.HasValue ? pageindex.Value : 1, Url = url };
            return View(models);
        }


        public ActionResult AccessProjectSettlement(int? id ,int? userid)
        {
            var model = generateService.GetProjectSettlement(id.Value);
            model.approvalstatues = 2;
            generateService.UpdateProjectSettlement(model);

            if(userid.HasValue && userid.Value !=0)
            {
                return Redirect("/sys/OperationResult?returnurl=/Admin/GetProjectSettlement?loginid=" + userid.Value);
            }
            else
            {
                return Redirect("/sys/OperationResult?returnurl=/Admin/GetProjectSettlement");
            }
        
        }

        public ActionResult DelProjectSettlement(int? id, int? userid)
        {
            generateService.DeleteProjectSettlement(id.Value);

            if(userid.HasValue && userid.Value != 0)
            {
                return Redirect("/sys/OperationResult?returnurl=/Admin/GetProjectSettlement?loginid=" + userid.Value);
            }
            else
            {
                return Redirect("/sys/OperationResult?returnurl=/Admin/GetProjectSettlement");
            }
        }
    }
}