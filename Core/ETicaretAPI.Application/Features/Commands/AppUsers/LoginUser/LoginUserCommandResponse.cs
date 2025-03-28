using ETicaretAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.AppUsers.LoginUser
{
	public class LoginUserCommandResponse
	{
		public TokenDto Token { get; set; }
		public string Message { get; set; }
	}
}
