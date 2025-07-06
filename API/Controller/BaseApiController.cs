using API.Extentions;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseApiController : ControllerBase
{
    protected IActionResult FromResult(Result result) => result.ToActionResult(this);

    protected IActionResult FromResult<T>(Result<T> result) => result.ToActionResult(this);
}
