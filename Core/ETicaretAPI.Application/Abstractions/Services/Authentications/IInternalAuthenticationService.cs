using ETicaretAPI.Application.DTOs;

namespace ETicaretAPI.Application.Abstractions.Services.Authentications
{
	public interface IInternalAuthenticationService
	{
		Task<TokenDto> LoginAsync(string usernameOrEmail, string password, int accessTokenLifeTime);
		Task<TokenDto> RefreshTokenLoginAsync(string refreshToken);

	}
}
