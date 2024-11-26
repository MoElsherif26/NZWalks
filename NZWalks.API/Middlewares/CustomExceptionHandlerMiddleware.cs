using System.Net;

namespace NZWalks.API.Middlewares
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly ILogger<CustomExceptionHandlerMiddleware> logger;
        private readonly RequestDelegate next;

        public CustomExceptionHandlerMiddleware(ILogger<CustomExceptionHandlerMiddleware> logger, 
            RequestDelegate next)
        {
            this.logger = logger;
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                var errorId = Guid.NewGuid();

                // log this exception
                logger.LogError(ex, $"{errorId} : {ex.Message}");

                // return a custom eror response
                httpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json";

                var erorr = new 
                {
                    Id = errorId,
                    ErorrMessage = "Something went wrong! We are looking into resolving this."
                };
                await httpContext.Response.WriteAsJsonAsync(erorr);
            }
        }
    }
}
