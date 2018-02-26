using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HoteManagement.Web.Models.Api
{
    public class CreateMenuRequst
    {
        public int ParentId { get; set; }

        [Required(ErrorMessage = "请填写名称")]
        public string MenuName { get; set; }

        public bool Isabled { get; set; }



        public string Url { get; set; }

        public HttpPostedFileBase File { get; set; }

    }
}