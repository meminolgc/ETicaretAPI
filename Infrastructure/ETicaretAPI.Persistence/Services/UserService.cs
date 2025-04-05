﻿using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Application.DTOs.User;
using ETicaretAPI.Application.Exceptions;
using ETicaretAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace ETicaretAPI.Persistence.Services
{
	public class UserService : IUserService
	{
		readonly UserManager<AppUser> _userManager;

		public UserService(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		public async Task<CreateUserResponseDto> CreateAsync(CreateUserDto model)
		{
			IdentityResult result = await _userManager.CreateAsync(new()
			{
				UserName = model.Username,
				Email = model.Email,
				NameSurname = model.NameSurname
			}, model.Password);

			CreateUserResponseDto response = new() { Succeeded = result.Succeeded };

			if (result.Succeeded)
				response.Message = "Kullanıcı başarıyla oluşturulmuştur.";
			else
				foreach (var error in result.Errors)
					response.Message += $"{error.Code} - {error.Description}\n";
			return response;
		}

		public async Task UpdateRefreshTokenAsync(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate)
		{
			if(user != null)
			{
				user.RefreshToken = refreshToken;
				user.RefreshTokenEndDate = accessTokenDate.AddSeconds(addOnAccessTokenDate);
				await _userManager.UpdateAsync(user);
			}
			else
			throw new NotFoundUserException();

		}
	}
}
