using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoteManagement.Web.Core
{
    public static class ModelExtenstion
    {
        public static string GetUploadUrl(this HoteManagement.Service.Model.Org_BusinessDto model,string val)
        {
            return "~/upload/" + val + ".doc";
        }


        public static string GetDisplayText(this HoteManagement.Service.Model.Org_BusinessDto model)
        {
            if (model.statues == 0)
                return "未审核";
            else if (model.statues == 1)
                return "审核通过";
            else
                return "审核不通过";
        }
    }
}