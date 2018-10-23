using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HoteManagement.Caching;
using HoteManagement.Infrastructure;
using HoteManagement.Service.Model;

using System.Web.Security;
using HoteManagement.Service.Core;

namespace HoteManagement.Web.Core
{
    public abstract class BaseWebViewPage<TModel> : WebViewPage<TModel>
    {

        protected readonly ILogger logger;
        protected readonly IWebHelper webHelper;
        protected readonly ICacheManager cacheManager;
        protected readonly IGenerateService generateService;

        public BaseWebViewPage()
        {

            logger = EngineContext.Current.Resolve<ILogger>();
            webHelper = EngineContext.Current.Resolve<IWebHelper>();
            cacheManager = EngineContext.Current.Resolve<ICacheManager>();
            generateService = EngineContext.Current.Resolve<IGenerateService>();
        }

        public UserInfoDto UserInfo
        {
            get
            {
                try
                {
                    var userid = System.Web.HttpContext.Current.Request.QueryString["loginid"] ?? System.Web.HttpContext.Current.Request.QueryString["userid"];
                    if (string.IsNullOrEmpty(userid))
                    {

                        HttpCookie authCookie = System.Web.HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                        if (authCookie != null)
                        {

                            FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                            if (authTicket == null || string.IsNullOrEmpty(authTicket.UserData))
                                return null;
                            UserInfoDto user = Newtonsoft.Json.JsonConvert.DeserializeObject<UserInfoDto>(authTicket.UserData);

                            return user;

                        }
                    }
                    else
                    {
                        var user = generateService.GetUserById(int.Parse(userid));
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