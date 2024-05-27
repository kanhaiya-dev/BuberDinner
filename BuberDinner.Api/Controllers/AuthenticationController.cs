using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public AuthenticationController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            //var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);
            var command = _mapper.Map<RegisterCommand>(request);

            var authResult = await _mediator.Send(command);
            //var response = new AuthenticationResult(authResult.user, authResult.Token);
            var response = _mapper.Map<AuthenticationResult>(authResult);

            return Ok(response);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            //var query = new LoginQuery(
            //   request.Email,
            //   request.Password);
            var query = _mapper.Map<LoginQuery>(request);

            var authResult = await _mediator.Send(query);

            //var response = new AuthenticationResult(authResult.user, authResult.Token);
            var response = _mapper.Map<AuthenticationResult>(authResult);

            return Ok(response);
        }

    }
}
