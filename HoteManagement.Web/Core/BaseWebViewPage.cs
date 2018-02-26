using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HoteManagement.Caching;
using HoteManagement.Infrastructure;
using HoteManagement.Service.Model;
using HoteManagement.Service.Pay;
using HoteManagement.Service.Room;
using HoteManagement.Service.Sys;
using HoteManagement.Service.User;
using System.Web.Security;

namespace HoteManagement.Web.Core
{
    public abstract class BaseWebViewPage<TModel> : WebViewPage<TModel>
    {
        protected readonly IPayService payService;
        protected readonly IRoomService roomService;
        protected readonly ISysService sysService;
        protected readonly IUserService userService;
        protected readonly ILogger logger;
        protected readonly IWebHelper webHelper;
        protected readonly ICacheManager cacheManager;

        public BaseWebViewPage()
        {
            payService = EngineContext.Current.Resolve<IPayService>();
            roomService = EngineContext.Current.Resolve<IRoomService>();
            sysService = EngineContext.Current.Resolve<ISysService>();
            userService = EngineContext.Current.Resolve<IUserService>();
            logger = EngineContext.Current.Resolve<ILogger>();
            webHelper = EngineContext.Current.Resolve<IWebHelper>();
            cacheManager = EngineContext.Current.Resolve<ICacheManager>();
        }

        public Accounts_UsersDto UserInfo
        {
            get
            {
                try
                {

                    HttpCookie authCookie = System.Web.HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                    if (authCookie != null)
                    {

                        FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                        if (authTicket == null || string.IsNullOrEmpty(authTicket.UserData))
                            return null;
                        Accounts_UsersDto user = Newtonsoft.Json.JsonConvert.DeserializeObject<Accounts_UsersDto>(authTicket.UserData);

                        return user;

                    }

                    return null;
                }
                catch
                {
                    return null;
                }


            }
        }
    }

    public abstract class BaseWebViewPage : BaseWebViewPage<dynamic>
    {

    }
}