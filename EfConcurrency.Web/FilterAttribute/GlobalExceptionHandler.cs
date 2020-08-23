using System.Net;
using System.Net.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;
using EfConcurrency.Common;
using EfConcurrency.ServicesLayer.ViewModels.PublicViewModel;

namespace EfConcurrency.Web.FilterAttribute
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            LogWriter.LogException(context.Exception);
            var response = context.Request.CreateResponse(HttpStatusCode.OK, ResponseObject<string>.Error());
            response.Headers.Add("X-Error", ConstantSettings.Error);
            context.Result = new ResponseMessageResult(response);
        }
    }
}