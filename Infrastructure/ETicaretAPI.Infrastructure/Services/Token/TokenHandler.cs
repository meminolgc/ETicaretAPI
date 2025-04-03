using ETicaretAPI.Application.Abstractions.Token;
using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Domain.Entities.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ETicaretAPI.Infrastructure.Services.Token
{
	public class TokenHandler : ITokenHandler
	{
		readonly IConfiguration _configuration;

		public TokenHandler(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public TokenDto CreateAccessToken(int minute, AppUser user)
		{
			TokenDto token = new();

			//Security Key'in simetriği alınıyor.
			SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

			//Şifrelenmiş kimlik oluşturuluyor.
			SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

			//Oluşturulacak token ayarları veriliyor.
			token.Expiration = DateTime.UtcNow.AddMinutes(minute);
			JwtSecurityToken securityToken = new(
				audience: _configuration["Token:Audience"],
				issuer: _configuration["Token:Issuer"],
				expires: token.Expiration,
				notBefore: DateTime.UtcNow,
				signingCredentials: signingCredentials,
				claims: new List<Claim> { new(ClaimTypes.Name, user.UserName) }
				);

			//Token oluşturucu sınıfından bir örnek alıyoruz.
			JwtSecurityTokenHandler tokenHandler = new();
			token.AccessToken = tokenHandler.WriteToken(securityToken);
			return token;

		}
	}
}
