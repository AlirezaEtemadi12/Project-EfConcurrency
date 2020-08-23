using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using EfConcurrency.Common;
using EfConcurrency.ServicesLayer.ViewModels.PublicViewModel;
using EfConcurrency.Web.WebHelper;

namespace EfConcurrency.Web.FilterAttribute
{
    public class ModelValidatorAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var modelState = actionContext.ModelState;
            foreach (var argument in actionContext.ActionArguments)
            {
                if (argument.Value == null)
                    modelState.AddModelError(argument.Key, "Argument is null.");
            }

            if (modelState.IsValid) return;
            actionContext.Response = actionContext.ControllerContext.Request
                .CreateResponse(HttpStatusCode.OK,
                    new ResponseObject<string>
                    {
                        Errors = modelState.GetErrors(),
                        StatusEnum = MessageType.Error
                    });
        }
    }
}