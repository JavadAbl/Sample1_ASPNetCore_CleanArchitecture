using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Extentions;


public static class ResultExtensions
{
    public static IActionResult ToActionResult<T>(this Result<T> result, ControllerBase controller)
    {
        if (result.Success)
        {
            return result.StatusCode switch
            {
                StatusCodes.Status201Created => controller.Created(string.Empty, result.Data),
                StatusCodes.Status204NoContent => controller.NoContent(),
                _ => result.Data is not null ? controller.Ok(result.Data) : controller.Ok()
            };
        }

        return controller.Problem(
            statusCode: result.StatusCode ?? StatusCodes.Status500InternalServerError,
            detail: result.Error
        );
    }
}