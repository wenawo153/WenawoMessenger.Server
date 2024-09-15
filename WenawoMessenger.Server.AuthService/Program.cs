using Microsoft.EntityFrameworkCore;
using WenawoMessenger.Server.AuthenticationService.DBService;
using WenawoMessenger.Server.AuthenticationService.Models;
using WenawoMessenger.Server.AuthenticationService.Services.CreateTokenService;
using WenawoMessenger.Server.AuthenticationService.Services.RefreshTokenService;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region DB

var UserKeysDBSettings = builder.Configuration.GetSection("ConnectionStrings").GetSection("UserKeys").Value;

builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseNpgsql(UserKeysDBSettings));

#endregion

#region Services

builder.Services.AddScoped<ICreateTokenService, CreateTokenService>();
builder.Services.AddScoped<IRefreshTokenService, RefreshTokenService>();

#endregion

#region Configuration

builder.Services.Configure<SecurityOptions>(builder.Configuration.GetSection("SecurityOptions"));

#endregion


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
