using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoteManagement.Web.Models.Api
{
    public class ModelDelete
    {
        public string Title { get; set; }

        public string Name { get; set; }

        public string DeleteButtonId { get; set; }

        public string BatchDeleteButtonId { get; set; }
    }
}