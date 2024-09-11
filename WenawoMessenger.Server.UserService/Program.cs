using MessengerClassLibraly.User;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using WenawoMessenger.Server.UserService.DBService;
using WenawoMessenger.Server.UserService.HttpServices;
using WenawoMessenger.Server.UserService.HttpServices.Services.AuthService;
using WenawoMessenger.Server.UserService.Models;
using WenawoMessenger.Server.UserService.Services.AuthorizationService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Services

builder.Services.AddScoped<IAuthorizationService, AuthorizationService>();
builder.Services.AddScoped<HashPasswordService>();

#endregion

#region MicroServices

builder.Services.AddScoped<IAuthService, AuthService>();

#endregion

#region DB

var mongoDBSettings = builder.Configuration.GetSection("MongoDBSettings").Get<MongoDBSettings>();

builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseMongoDB(
    mongoDBSettings?.AtlasURI ?? "", mongoDBSettings?.DatabaseName ?? ""));

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

app.UseAuthorization();

app.MapControllers();

app.Run();
