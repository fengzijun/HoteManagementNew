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
                return "<font color='blue'>未审核</font>";
            else if (model.statues == 1)
                return "<font color='green'>审核通过</font>";
            else
                return "<font color='red'>审核不通过</font>";
        }

        public static string GetDisplayText(this HoteManagement.Service.Model.ProjectSettlementDto model)
        {
            if (model.approvalstatues == 0)
                return "<font color='black'>未上报</font>";
            else if (model.approvalstatues == 2)
                return "<font color='blue'>已上报</font>";
            else if (model.approvalstatues == 1)
                return "<font color='green'>审核通过</font>";
            else 
                return "<font color='red'>审核不通过</font>";
        }

    }
}