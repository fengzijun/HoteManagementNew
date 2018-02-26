using System;

namespace HoteManagement.Web.Models
{
  
    [Serializable]
    public class AjaxResponse<TResult>
    {
      
        public bool Success { get; set; }

     
        public TResult Result { get; set; }

     
        public ErrorInfo Error { get; set; }

     
        public bool UnAuthorizedRequest { get; set; }

     
        public AjaxResponse(TResult result)
        {
            Result = result;
            Success = true;
        }

    
        public AjaxResponse()
        {
            Success = true;
        }

       
        public AjaxResponse(bool success)
        {
            Success = success;
        }

        public AjaxResponse(ErrorInfo error, bool unAuthorizedRequest = false)
        {
            Error = error;
            UnAuthorizedRequest = unAuthorizedRequest;
            Success = false;
        }
    }
}