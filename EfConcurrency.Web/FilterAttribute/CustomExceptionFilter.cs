using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using EfConcurrency.Common;
using EfConcurrency.ServicesLayer.ViewModels.PublicViewModel;
using Newtonsoft.Json;

namespace EfConcurrency.Web.FilterAttribute
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            LogWriter.LogException(actionExecutedContext.Exception);
            var apiClientResult = JsonConvert.SerializeObject(ResponseObject<string>.Error());
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(apiClientResult),
            };
            actionExecutedContext.Response = response;
        }
    }
}