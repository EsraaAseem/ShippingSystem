using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using ShippingSystem.Utility;
using System.Net;


namespace ShippingSystem.Service.Exceptions.FilterExceptions
{
    public class ModelValidationFilterAttribute : IActionFilter
    {
        public ModelValidationFilterAttribute()
        {
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var httpContext = context.HttpContext;
                httpContext.Response.ContentType = "application/json";
                var errorResponse = new BaseResponse
                {
                    Message = context.ModelState.Values
                     .SelectMany(v => v.Errors)
                     .Select(e => e.ErrorMessage).ToList().FirstOrDefault(),
                    Result = null,
                    Status = HttpStatusCode.BadRequest,
                    IsSuccess = false

                };
                context.Result = new ObjectResult(errorResponse)
                {
                    StatusCode = (int)HttpStatusCode.OK,

                };
            }
        }
        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}

