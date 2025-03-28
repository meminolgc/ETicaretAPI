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
			ValidateAudience = true,  //Oluþturulacak token deðerini hangi originlerin/sitelerin kullanacaðýný belirler.
			ValidateIssuer = true,	  //Oluþturulacak token deðerini kimin daðýttýðýný ifade eder.
			ValidateLifetime = true,  //Oluþturulan token deðerinin süresini kontrol eden doðrulama.
			ValidateIssuerSigningKey = true, //Üretilecek token deðerinin uygulamaya ait bir deðer olduðunu ifade eden security key verisinin doðrulanmasý.

			//Hangi deðerlerle doðrulanacaðýnýn bildirimi.
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
