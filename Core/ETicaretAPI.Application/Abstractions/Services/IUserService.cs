using ETicaretAPI.Application.DTOs.User;
using ETicaretAPI.Domain.Entities.Identity;

namespace ETicaretAPI.Application.Abstractions.Services
{
	public interface IUserService
	{
		Task<CreateUserResponseDto> CreateAsync(CreateUserDto model);
		Task UpdateRefreshTokenAsync(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate);
	}
}
 