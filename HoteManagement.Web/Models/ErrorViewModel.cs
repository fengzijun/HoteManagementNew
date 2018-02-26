
using System;


namespace HoteManagement.Web.Models
{
    public class ErrorViewModel
    {
        public ErrorInfo ErrorInfo { get; set; }

        public Exception Exception { get; set; }

        public ErrorViewModel()
        {
            
        }

        public ErrorViewModel(Exception exception)
        {
            Exception = exception;
       
        }
    }
}
