using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoteManagement.Web.Models.Api
{
    public class PageModel
    {
        public int PageIndex { get; set; }

        public string Url { get; set; }

        public int PageCount { get; set; }

        public string GenerateUrl(int pageindex)
        {
            if(Url.Contains("?"))
               return Url + "&pageindex=" + pageindex;
            return Url + "?pageindex=" + pageindex;
        }

    }
}