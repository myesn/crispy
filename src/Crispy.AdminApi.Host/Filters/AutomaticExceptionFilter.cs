namespace Crispy.AdminApi.Host
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class AutomaticExceptionFilter : ExceptionFilterAttribute
    {
        public override Task OnExceptionAsync(ExceptionContext context)
        {
            var exception = context.Exception;

            var code = (int)HttpStatusCode.BadRequest;
            if (exception is UnauthorizedAccessException)
                code = (int)HttpStatusCode.Unauthorized;

            context.Result = new JsonResult(new { exception.Message/*, exception.StackTrace*/ });
            context.HttpContext.Response.StatusCode = code;

            return Task.CompletedTask;
        }
    }
}
