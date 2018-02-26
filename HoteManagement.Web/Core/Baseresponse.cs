using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoteManagement.Web.Core
{
    public class Baseresponse
    {
        public int Success { get; set; }

        public int ErrorCode { get; set; }

        public string Message { get; set; }

        public int Id { get; set; }
    }

    public class Baseresponse<T> : Baseresponse
    {
        public T Data { get; set; }
    }

    public class Pageresponse:Baseresponse
    {

        public int PageCount { get; set; }
        public int PageIndex { get; set; }

        public int TotalPages { get; set; }
    }

    public class Pageresponse<T>:Pageresponse
    {
        public T Data { get; set; }
    }
}