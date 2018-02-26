using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HoteManagement.Web.Core
{
    public class ErrorModelFilterAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(!filterContext.Controller.ViewData.ModelState.IsValid && filterContext.Controller.ViewData.ModelState.Count > 0)
            {
                var model = filterContext.Controller.ViewData.ModelState.ToDictionary(s => s.Key, s => s.Value);
                filterContext.Controller.TempData["error"] = model;
            }
            else
            {
                filterContext.Controller.TempData["error"] = null;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}