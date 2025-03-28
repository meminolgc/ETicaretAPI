using ETicaretAPI.Application;
using ETicaretAPI.Infrastructure;
using ETicaretAPI.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistenceServices();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();

builder.Services.AddControllers();
	
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer("Admin", options =>
	{
		options.TokenValidationParameters = new()
		{
			ValidateAudience = true,  //Oluşturulacak token değerini hangi originlerin/sitelerin kullanacağını belirler.
			ValidateIssuer = true,	  //Oluşturulacak token değerini kimin dağıttığını ifade eder.
			ValidateLifetime = true,  //Oluşturulan token değerinin süresini kontrol eden doğrulama.
			ValidateIssuerSigningKey = true, //Üretilecek token değerinin uygulamaya ait bir değer olduğunu ifade eden security key verisinin doğrulanması.

			//Hangi değerlerle doğrulanacağının bildirimi.
			ValidAudience = builder.Configuration["Token:Audience"],
			ValidIssuer = builder.Configuration["Token:Issuer"],
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"]))

		};
	});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
