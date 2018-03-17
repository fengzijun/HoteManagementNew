using HoteManagement.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HoteManagement.Web.Core
{
    public class HotelAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            HttpCookie authCookie = httpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {

                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                if (authTicket == null || string.IsNullOrEmpty(authTicket.UserData))
                    return false;
                UserInfoDto user = Newtonsoft.Json.JsonConvert.DeserializeObject<UserInfoDto>(authTicket.UserData);

                if (user != null)
                    return true;
                return false;

            }

            return false;

            //return base.AuthorizeCore(httpContext);
        }
    }
}