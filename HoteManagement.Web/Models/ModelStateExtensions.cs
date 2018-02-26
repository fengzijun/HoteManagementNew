using SSO.Infratructure.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;


namespace HoteManagement.Web.Models
{

    /// <summary>
    /// TODO: THIS CLASS IS NOT FINISHED AND TESTED YET!
    /// </summary>
    public static class ModelStateExtensions
    {
        public static MvcAjaxResponse ToMvcAjaxResponse(ModelStateDictionary modelState)
        {
            if (modelState.IsValid)
            {
                return new MvcAjaxResponse();
            }

            var validationErrors = new List<ValidationErrorInfo>();

            //foreach (var state in modelState)
            //{
            //    foreach (var error in state.Value.Errors)
            //    {
            //        validationErrors.Add(new ValidationErrorInfo(error.ErrorMessage, state.Key));
            //    }
            //}

            var errorInfo = new ErrorInfo();

            return new MvcAjaxResponse(errorInfo);
        }
    }
}
