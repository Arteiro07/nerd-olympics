using NerdOlympics.Data.Models.ErrorHandling;
using Newtonsoft.Json;

namespace NerdOlympics.API.Services.ErrorHandling
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                ErrorResponse errorResponse;
                // Set the response status code based on the exception type
                if (ex is CustomException)
                {
                    // Map the exception to an error response
                    errorResponse = new ErrorResponse
                    {
                        ErrorCode = ((CustomException)ex).ErrorCode,
                        ErrorMessage = ((CustomException)ex).ErrorMessage,
                    };                    
                    context.Response.StatusCode = errorResponse.ErrorCode; // Internal Server Error
                }
                else
                {
                    errorResponse = new ErrorResponse
                    {
                        ErrorCode = 500,
                        ErrorMessage = "Unexpected error, please contact support.",
                    };
                    context.Response.StatusCode = 500; // Internal Server Error
                }

                // Serialize the error response to JSON and write it to the response body
                var json = JsonConvert.SerializeObject(errorResponse);
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(json);
            }
        }
    }
}
