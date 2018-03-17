using HoteManagement.Web.Core;
using HoteManagement.Web.Models;
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

            //if(model.Code !=Session["CheckCode"].ToString())
            //{
            //    ModelState.AddModelError("", "验证码错误。");
            //    return View(model);
            //}

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
    }
}