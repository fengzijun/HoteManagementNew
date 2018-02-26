using HoteManagement.Web.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HoteManagement.Web.Controllers
{
    public class SysController : BaseController
    {
        // GET: Sys
        public ActionResult OperationResult(string returnurl)
        {
            ViewBag.returnurl = returnurl;
            return View();
        }
    }
}