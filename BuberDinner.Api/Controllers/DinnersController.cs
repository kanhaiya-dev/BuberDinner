using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DinnersController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public ActionResult ListDinners()
        {
            return Ok(Array.Empty<string>());
        }
    }
}
