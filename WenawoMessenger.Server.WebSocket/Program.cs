
using MessengerHttpServiceLibraly;
using MessengerHttpServiceLibraly.HttpServices.AuthenticationService;
using MessengerHttpServiceLibraly.HttpServices.ChatService;
using MessengerHttpServiceLibraly.HttpServices.UserService.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WenawoMessenger.Server.UserInterface.Hubs.UserHub;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();

#region MicroServices

var httpConfig = builder.Configuration.GetSection("MicroServicesUrl").Get<HttpConfig>() 
    ?? throw new Exception("No microservices url's");

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>(_ => new AuthenticationService(
	httpConfig));
builder.Services.AddScoped<IAuthorizationService, AuthorizationService>(_ => new AuthorizationService(
	httpConfig));
builder.Services.AddScoped<IChatService, ChatService>(_ => new ChatService(
	httpConfig));
builder.Services.AddScoped<IMessegeService, MessegeService>(_ => new MessegeService(
	httpConfig));

#endregion

#region Authentification

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
    AddJwtBearer(option =>
    {
        option.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = "WenawoMessenger.Server",
            ValidateAudience = true,
            ValidAudience = "WenawoMessenger.Client",
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Heu7WOR5/UFUIADGx+vPp3fz6GtEek5Sz5Fw3j/ykYDuaI5TvI9kXZ0qi80UH9Xl"))
        };
    });

#endregion

#region Configuration

builder.Services.Configure<HttpConfig>(builder.Configuration.GetSection("MicroServicesUrl"));

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapHub<AuthHub>("/auth");

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
