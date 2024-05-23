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
            return Problem(title: exception?.Message, statusCode: 500, detail: path);
        }

    }

