using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

public class ErrorsController : ControllerBase
{
    [Route("/error")]
    [HttpPost]
    public IActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        var path = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Path.ToString();
        int statusCode = exception switch
        {
            ArgumentNullException => 400,  // Bad Request
            UnauthorizedAccessException => 401,  // Unauthorized
            KeyNotFoundException => 404,  // Not Found
            _ => 500  // Internal Server Error
        };

        return Problem(title: exception?.Message, statusCode: statusCode, detail: path);
    }

}

