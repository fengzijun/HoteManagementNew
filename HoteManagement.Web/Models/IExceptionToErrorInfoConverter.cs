using HoteManagement.Web.Models;
using System;

namespace SSO.Infratructure.Web.Models
{
   
    public interface IExceptionToErrorInfoConverter
    {
     
        IExceptionToErrorInfoConverter Next { set; }

    
        ErrorInfo Convert(Exception exception);
    }
}