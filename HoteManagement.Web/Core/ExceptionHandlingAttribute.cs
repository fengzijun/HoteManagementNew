using HoteManagement.Infrastructure;
using HoteManagement.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HoteManagement.Web.Core
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class ExceptionHandlingAttribute : HandleErrorAttribute
    {
        public ILogger Logger { get; set; }

      
        public ExceptionHandlingAttribute()
        {
            Logger = EngineContext.Current.Resolve<ILogger>();
        }

        /// <summary>
        /// Called when an exception occurs.
        /// </summary>
        /// <param name="context">The exception context.</param>
        public override void OnException(ExceptionContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            if (context.Exception != null)
                Logger?.WriteErrorLog(context.Exception);

            //If exception handled before, do nothing.
            //If this is child action, exception should be handled by main action.
            if (context.ExceptionHandled || context.IsChildAction)
            {
                return;
            }

            //Always log exception
            //LogHelper.LogException(Logger, context.Exception);

            //var logger = IocManager.Instance.Resolve<ILogAppService>();
            //var session = IocManager.Instance.IocContainer.Resolve<ISession>();
            //var webprovider = IocManager.Instance.IocContainer.Resolve<IAuditInfoProvider>();

            //var auditInfo = new AuditInfo();
            //webprovider.Fill(auditInfo);

            //logger.Info(new AuditInfo { Exception = context.Exception, ExecutionTime = DateTime.Now, ServiceName = context.Controller.ControllerContext.RouteData.Values["controller"].ToString(), MethodName = context.Controller.ControllerContext.RouteData.Values["action"].ToString(), UserId = session.UserId });
            //// If custom errors are disabled, we need to let the normal ASP.NET exception handler
            // execute so that the user can see useful debugging information.
            if (!context.HttpContext.IsCustomErrorEnabled)
            {
                return;
            }

            // If this is not an HTTP 500 (for example, if somebody throws an HTTP 404 from an action method),
            // ignore it.
            if (new HttpException(null, context.Exception).GetHttpCode() != 500)
            {
                return;
            }

            //Do not handle exceptions for attributes configured for special exception types and this exceptiod does not fit condition.
            if (!ExceptionType.IsInstanceOfType(context.Exception))
            {
                return;
            }


            //We handled the exception!
            context.ExceptionHandled = true;

            //Return a special error response to the client.
            context.HttpContext.Response.Clear();
            context.Result = IsAjaxRequest(context)
                ? GenerateAjaxResult(context)
                : GenerateNonAjaxResult(context);

            // Certain versions of IIS will sometimes use their own error page when
            // they detect a server error. Setting this property indicates that we
            // want it to try to render ASP.NET MVC's error page instead.
            context.HttpContext.Response.TrySkipIisCustomErrors = true;

            //Trigger an event, so we can register it.
            //EventBus.Trigger(this, new HandledExceptionData(context.Exception));


        }

        private static bool IsAjaxRequest(ExceptionContext context)
        {
            return context.HttpContext.Request.IsAjaxRequest();
        }

        private static ActionResult GenerateAjaxResult(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = 200;
            return new NewJsonResult(context.Exception);
        }

        private ActionResult GenerateNonAjaxResult(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = 500;
            return new ViewResult
            {
                ViewName = View,
                MasterName = Master,
                ViewData = new ViewDataDictionary<ErrorViewModel>(new ErrorViewModel(context.Exception)),
                TempData = context.Controller.TempData
            };
        }
    }
}