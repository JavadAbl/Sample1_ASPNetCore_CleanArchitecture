using System.Collections.ObjectModel;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace API.Filter;

public class FluentValidationFilterAsync : IAsyncActionFilter
{
    private readonly IServiceProvider _serviceProvider;

    public FluentValidationFilterAsync(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        foreach (var argument in context.ActionArguments.Values)
        {
            if (argument is null) continue;

            var validatorType = typeof(IValidator<>).MakeGenericType(argument.GetType());
            var validator = _serviceProvider.GetService(validatorType);

            if (validator is null) continue;

            var validateMethod = validatorType.GetMethod(nameof(IValidator.ValidateAsync), new[] { argument.GetType(), typeof(CancellationToken) });

            if (validateMethod is null) continue;

            var task = (Task)validateMethod.Invoke(validator, new object[] { argument, CancellationToken.None })!;
            await task.ConfigureAwait(false);

            var resultProperty = task.GetType().GetProperty("Result");
            var validationResult = (ValidationResult)resultProperty!.GetValue(task)!;

            /* if (!validationResult.IsValid)
             {
                 var errors = validationResult.Errors.Select(e => new
                 {
                     e.PropertyName,
                     e.ErrorMessage
                 });

                 context.Result = new BadRequestObjectResult(errors);

                 return;
             }*/

            /* if (!validationResult.IsValid)
             {
                 var modelState = new ModelStateDictionary();
                 foreach (var error in validationResult.Errors)
                 {
                     modelState.AddModelError(error.PropertyName, error.ErrorMessage);
                 }

                 var validationProblemDetails = new ValidationProblemDetails(modelState);
                 *//* {
                      Title = "One or more validation errors occurred.",
                      Status = StatusCodes.Status400BadRequest,
                      Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                  };*//*

                 context.Result = new BadRequestObjectResult(validationProblemDetails);

                 return;
             }*/

            if (!validationResult.IsValid)
            {
                var validationFailures = new Collection<ValidationFailure>();

                foreach (var error in validationResult.Errors)
                    validationFailures.Add(new ValidationFailure(error.PropertyName, error.ErrorMessage));

                throw new ValidationException("Validation failed", validationFailures);
            }


        }

        await next();
    }
}
