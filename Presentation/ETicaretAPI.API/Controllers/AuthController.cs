using ETicaretAPI.Application.Features.Commands.AppUsers.LoginUser;
using ETicaretAPI.Application.Features.Commands.AppUsers.RefreshTokenLogin;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		readonly IMediator _mediator;

		public AuthController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost("[action]")]
		public async Task<IActionResult> Login(LoginUserCommandRequest loginUserCommandRequest)
		{
			LoginUserCommandResponse response = await _mediator.Send(loginUserCommandRequest);
			return Ok(response);
		}

		[HttpPost("[action]")]
		public async Task<IActionResult> RefreshTokenLogin([FromBody] RefreshTokenLoginCommandRequest refreshTokenLoginCommandRequest)
		{
			RefreshTokenLoginCommandResponse response = await _mediator.Send(refreshTokenLoginCommandRequest);
			return Ok(response);
		}
	}
}
