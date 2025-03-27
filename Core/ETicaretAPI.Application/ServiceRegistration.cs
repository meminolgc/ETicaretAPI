using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ETicaretAPI.Application
{
	public static class ServiceRegistration
	{
		public static void AddApplicationServices(this IServiceCollection collection)
		{
			collection.AddMediatR(typeof(ServiceRegistration));

			// FluentValidation entegrasyonu
			collection.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
			collection.AddFluentValidationAutoValidation();

		}
	}
}
