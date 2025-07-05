using Microsoft.AspNetCore.Diagnostics;

namespace API.Middlewares
{
    public class ExceptionHandler(IProblemDetailsService problemDetailsService, IHostEnvironment hostEnvironment) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var problemContext = new ProblemDetailsContext
            {
                HttpContext = httpContext,
                Exception = exception,
                ProblemDetails = new Microsoft.AspNetCore.Mvc.ProblemDetails
                {
                    Title = "Internal Server Error",
                    Detail = exception.Message
                }
            };

            if (hostEnvironment.IsDevelopment())
                problemContext.ProblemDetails.Extensions.Add("stackTrace", exception.StackTrace);

            await problemDetailsService.TryWriteAsync(problemContext);
            return true;
        }
    }
}