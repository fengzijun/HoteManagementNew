using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HoteManagement.Web.Models.Api
{
    public class CreateOrgBusinessRequest
    {
        [Required(ErrorMessage = "项目名称不能为空")]
        public string projectname { get; set; }

        public string buildunit { get; set; }

        public string compileunit { get; set; }
     
        public string auditunit { get; set; }

        public string projecttype { get; set; }
  
        public string projectsummary { get; set; }

        public string contract { get; set; }
        public string report { get; set; }
        public string price { get; set; }
        public string other { get; set; }

        public int? UserId { get; set; }
    }


    public class EditOrgBusinessRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "项目名称不能为空")]
        public string projectname { get; set; }
        [Required(ErrorMessage = "建设单位不能为空")]
        public string buildunit { get; set; }
        [Required(ErrorMessage = "编制单位不能为空")]
        public string compileunit { get; set; }
        [Required(ErrorMessage = "审计单位不能为空")]
        public string auditunit { get; set; }

        public string projecttype { get; set; }

        public string projectsummary { get; set; }

        public string contract { get; set; }
        public string report { get; set; }
        public string price { get; set; }
        public string other { get; set; }

        public int? UserId { get; set; }

    }
}