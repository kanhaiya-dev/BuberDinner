using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    
    public class ErrorsController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error()
        {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
            var path = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Endpoint.ToString();
            return Problem(title: exception?.Message, statusCode: 500, detail: path);
        }

    }
}
