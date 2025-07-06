using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace API.Middlewares
{
    public class ValidationExceptionHandler(IProblemDetailsService problemDetailsService) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is not ValidationException validationException)
                return false;


            var errors = validationException.Errors.GroupBy(e => e.PropertyName).ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage).ToArray());

            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            var problemContext = new ProblemDetailsContext
            {
                HttpContext = httpContext,
                Exception = exception,
                ProblemDetails = new ProblemDetails
                {
                    Title = validationException.Message,
                    Detail = "One or more validation errors occurred.",
                }
            };

            problemContext.ProblemDetails.Extensions.Add("errors", errors);

            await problemDetailsService.TryWriteAsync(problemContext);
            return true;
        }
    }
}
