using HoteManagement.Data;
using HoteManagement.Infrastructure;
using HoteManagement.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Infrastructure.Interception;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace HoteManagement.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            EngineContext.Initialize(false);

            EntityFrameworkGenerateViews();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            log4net.Config.XmlConfigurator.Configure(new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4net.xml"));


            DbInterception.Add(new EFIntercepterLogging());
            DbInterception.Add(new DbMasterSlaveCommandInterceptor());
            DbInterception.Add(new DbMasterSlaveConnectionInterceptor());
            DbInterception.Add(new WithNoLockInterceptor());
        }

        protected void EntityFrameworkGenerateViews()
        {
            var dbcontext = EngineContext.Current.Resolve<IDbContext>();
            var objectContext = ((IObjectContextAdapter)dbcontext).ObjectContext;
            var mappingCollection = (StorageMappingItemCollection)objectContext.MetadataWorkspace.GetItemCollection(DataSpace.CSSpace);
            mappingCollection.GenerateViews(new List<EdmSchemaError>());
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var logger = EngineContext.Current.Resolve<ILogger>();
           

            var httpContext = ((MvcApplication)sender).Context;

            var currentRouteData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
            var currentController = "";
            var currentAction = "";
            if (currentRouteData != null)
            {
                if (currentRouteData.Values["controller"] != null &&
                    !string.IsNullOrEmpty(currentRouteData.Values["controller"].ToString()))
                {
                    currentController = currentRouteData.Values["controller"].ToString();
                }

                if (currentRouteData.Values["action"] != null &&
                    !string.IsNullOrEmpty(currentRouteData.Values["action"].ToString()))
                {
                    currentAction = currentRouteData.Values["action"].ToString();
                }
            }


            var ex = Server.GetLastError();
        
            logger.WriteErrorLog(ex);
            var controller = new ErrorController();
            var routeData = new RouteData();
            var action = "Index";
            if (ex is HttpException)
            {
                var httpEx = ex as HttpException;
                switch (httpEx.GetHttpCode())
                {
                    case 404:
                        action = "NotFound";
                        break;
                    case 403:
                        action = "NotAccess";
                        break;
                    default:
                        action = "Index";
                        break;
                }
            }

            httpContext.ClearError();
            httpContext.Response.Clear();
            httpContext.Response.StatusCode = ex is HttpException ? ((HttpException)ex).GetHttpCode() : 500;
            httpContext.Response.TrySkipIisCustomErrors = true;
            routeData.Values["controller"] = "Error";
            routeData.Values["action"] = action;

            controller.ViewData.Model = new HandleErrorInfo(ex, currentController, currentAction);
            ((IController)controller).Execute(new RequestContext(new HttpContextWrapper(httpContext), routeData));
        }
    }
}
