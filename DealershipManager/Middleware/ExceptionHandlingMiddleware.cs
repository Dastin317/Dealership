using DealershipManager.Models;
using Newtonsoft.Json;
using System.Runtime.ExceptionServices;
using System.Text.Json.Serialization;

namespace SecondHandDealership.Middleware
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private static async Task HandleException(HttpContext context, Exception ex)
        {
            var exceptionType = ex.GetType();

            context.Response.ContentType = "application/json";

            var errorMessage = new ErrorMessage();  
            errorMessage.Message = ex.Message;

            if (exceptionType == typeof(NotFoundException)) 
            {
                errorMessage.ErrorCode = 404;
            }
            else if (exceptionType == typeof(ValidationException)) 
            {
                errorMessage.ErrorCode = 400;
            }

            context.Response.StatusCode = errorMessage.ErrorCode;

            var error = new
            {
                Message = "An error occured while processing your request.",
                ExceptionMessage = ex.Message,
            };

            // Serializarea(convertirea din obiect in json)

            var jsonResponse = JsonConvert.SerializeObject(error);
            await context.Response.WriteAsync(jsonResponse);
        }
    }
}
