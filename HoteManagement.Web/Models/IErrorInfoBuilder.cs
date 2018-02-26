using System;

namespace HoteManagement.Web.Models
{
    
    public interface IErrorInfoBuilder
    {
       
        ErrorInfo BuildForException(Exception exception);

      
    }
}