
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Filter;
public class FluentValidationFilter : IActionFilter
{
    private readonly IServiceProvider _serviceProvider;

    public FluentValidationFilter(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public void OnActionExecuted(ActionExecutedContext context) { }


    /* public void OnActionExecuting(ActionExecutingContext context)
     {
         foreach (var argument in context.ActionArguments.Values)
         {
             if (argument == null) continue;

             var validatorType = typeof(IValidator<>).MakeGenericType(argument.GetType());
             var validator = _serviceProvider.GetService(validatorType);

             if (validator == null) continue;

             var validationResult = (ValidationResult)validatorType
                 .GetMethod("Validate", new[] { argument.GetType() })!
                 .Invoke(validator, new[] { argument });

             if (!validationResult.IsValid)
             {
                 var errors = validationResult.Errors.Select(e => new
                 {
                     e.PropertyName,
                     e.ErrorMessage
                 });

                 context.Result = new BadRequestObjectResult(errors);
                 return;
             }
         }
     }*/

    public void OnActionExecuting(ActionExecutingContext context)
    {
        foreach (var argument in context.ActionArguments.Values)
        {
            if (argument == null) continue;

            var validatorType = typeof(IValidator<>).MakeGenericType(argument.GetType());
            var validator = _serviceProvider.GetService(validatorType);

            if (validator == null) continue;

            var validateMethod = validatorType.GetMethod("Validate", new[] { argument.GetType() });
            if (validateMethod == null) continue;

            var validationResult = validateMethod.Invoke(validator, new[] { argument }) as ValidationResult;
            if (validationResult == null) continue;

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => new
                {
                    e.PropertyName,
                    e.ErrorMessage
                });

                context.Result = new BadRequestObjectResult(errors);
                return;
            }
        }
    }


}


