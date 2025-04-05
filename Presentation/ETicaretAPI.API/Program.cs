using ETicaretAPI.API.Configurations.ColumnWriters;
using ETicaretAPI.API.Extensions;
using ETicaretAPI.Application;
using ETicaretAPI.Infrastructure;
using ETicaretAPI.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Context;
using Serilog.Core;
using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;
using System.Security.Claims;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistenceServices();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();

builder.Services.AddControllers();

SqlColumn sqlColumn = new SqlColumn
{
	ColumnName = "UserName",
	DataType = System.Data.SqlDbType.NVarChar,
	PropertyName = "UserName",
	DataLength = 50,
	AllowNull = true
};
ColumnOptions columnOpt = new ColumnOptions();
columnOpt.Store.Remove(StandardColumn.Properties);
columnOpt.Store.Add(StandardColumn.LogEvent);
columnOpt.AdditionalColumns = new Collection<SqlColumn> { sqlColumn };

Logger log = new LoggerConfiguration()
	.WriteTo.Console()
	.WriteTo.File("logs/log.txt")
	.WriteTo.MSSqlServer(
	connectionString: builder.Configuration.GetConnectionString("DefaultConnection"),
	 sinkOptions: new MSSqlServerSinkOptions
	 {
		 AutoCreateSqlTable = true,
		 TableName = "logs"
	 },
	 columnOptions: columnOpt
	)
	.Enrich.FromLogContext()
	.Enrich.With<UsernameColumnWriter>()
	.MinimumLevel.Information()
	.CreateLogger();

builder.Host.UseSerilog(log);

builder.Services.AddHttpLogging(logging =>
{
	logging.LoggingFields = HttpLoggingFields.All;
	logging.RequestHeaders.Add("sec-ch-ua");
	logging.MediaTypeOptions.AddText("application/javascript");
	logging.RequestBodyLogLimit = 4096;
	logging.ResponseBodyLogLimit = 4096;
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer("Admin", options =>
	{
		options.TokenValidationParameters = new()
		{
			ValidateAudience = true,  //Oluþturulacak token deðerini hangi originlerin/sitelerin kullanacaðýný belirler.
			ValidateIssuer = true,    //Oluþturulacak token deðerini kimin daðýttýðýný ifade eder.
			ValidateLifetime = true,  //Oluþturulan token deðerinin süresini kontrol eden doðrulama.
			ValidateIssuerSigningKey = true, //Üretilecek token deðerinin uygulamaya ait bir deðer olduðunu ifade eden security key verisinin doðrulanmasý.

			//Hangi deðerlerle doðrulanacaðýnýn bildirimi.
			ValidAudience = builder.Configuration["Token:Audience"],
			ValidIssuer = builder.Configuration["Token:Issuer"],
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
			LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null ? expires > DateTime.UtcNow : false,

			NameClaimType = ClaimTypes.Name // JWT üzerinde Name claimine karþýlýk gelen deðeri User.Identity.Name propertysinden elde edebiliriz.

		};
	});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.ConfigureExceptionHandler<Program>(app.Services.GetRequiredService<ILogger<Program>>());


app.UseHttpLogging();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.Use(async (context, next) =>
{
	var username = context.User?.Identity?.IsAuthenticated != null || true ? context.User.Identity.Name : null;
	LogContext.PushProperty("user_name", username);
	await next();
});

app.MapControllers();

app.Run();
