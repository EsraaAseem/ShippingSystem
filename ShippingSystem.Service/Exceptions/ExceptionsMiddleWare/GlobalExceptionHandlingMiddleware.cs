using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using ShippingSystem.Service.Exceptions.RequestExceptions;
using ShippingSystem.Utility;
using System.Net;
using System.Text.Json;
namespace ShippingSystem.Service.Exceptions.ExceptionsMiddleWare
{
    public class GlobalExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);

                if (httpContext.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
                {

                    var response = new BaseResponse();
                    response.IsSuccess = false;
                    response.Message ="Un authorized";
                    response.Status = HttpStatusCode.Unauthorized;

                    var exceptionResult = JsonSerializer.Serialize(response);
                    httpContext.Response.ContentType = "application/json";
                    httpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                    await httpContext.Response.WriteAsync(exceptionResult);

                    return;
                }
            }
            catch (Exception ex)
            {
                await HandlingExceptionsAsync(httpContext, ex);
            }
        }
        private static Task HandlingExceptionsAsync(HttpContext httpContext, Exception ex)
        {
            var response = new BaseResponse();
            response.IsSuccess = false;
            var exceptionType = ex.GetType();
            if (exceptionType == typeof(BadRequestException))
            {
                response.Message = ex.Message;
                response.Status = HttpStatusCode.BadRequest;
            }
            else if (exceptionType == typeof(NotFoundException))
            {
                response.Message = ex.Message;
                response.Status = HttpStatusCode.NotFound;
            }
            else if (exceptionType == typeof(UnauthorizedException))
            {
                response.Message = ex.Message;
                response.Status = HttpStatusCode.Unauthorized;
            }
            else
            {
                response.Message = ex.Message;
                response.Status = HttpStatusCode.InternalServerError;
            }
            var exceptionResault = JsonSerializer.Serialize(response);
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.OK;
            return httpContext.Response.WriteAsync(exceptionResault);
        }
    }
}
