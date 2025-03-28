using ETicaretAPI.Application.Abstractions.Token;
using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Application.Exceptions;
using ETicaretAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ETicaretAPI.Application.Features.Commands.AppUsers.LoginUser
{
	public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
	{
		readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;
		readonly SignInManager<Domain.Entities.Identity.AppUser> _signInManager;
		readonly ITokenHandler _tokenHandler;

		public LoginUserCommandHandler(
			UserManager<AppUser> userManager,
			SignInManager<AppUser> signInManager,
			ITokenHandler tokenHandler)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_tokenHandler = tokenHandler;
		}

		public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
		{
			var user = await _userManager.FindByNameAsync(request.UserNameOrEmail);
			if (user == null)
				user = await _userManager.FindByEmailAsync(request.UserNameOrEmail);

			if (user == null)
				throw new NotFoundUserException();

			SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
			if (result.Succeeded) //Authentication başarılı.
			{
				TokenDto token = _tokenHandler.CreateAccessToken(5);
				return new()
				{
					Token = token
				};
			}
			throw new AuthenticationErrorException();

		}
	}
}
