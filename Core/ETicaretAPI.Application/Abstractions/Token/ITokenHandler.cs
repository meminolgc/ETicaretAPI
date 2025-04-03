using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Domain.Entities.Identity;

namespace ETicaretAPI.Application.Abstractions.Token
{
	public interface ITokenHandler
	{
		TokenDto CreateAccessToken(int minute, AppUser appUser);
	}
}
