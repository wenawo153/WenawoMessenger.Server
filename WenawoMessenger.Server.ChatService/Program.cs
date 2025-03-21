using Microsoft.EntityFrameworkCore;
using WenawoMessenger.Server.ChatService.DBService;
using WenawoMessenger.Server.ChatService.Services.ChatService;
using WenawoMessenger.Server.ChatService.Services.MessageServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Services

builder.Services.AddScoped<IChatService, ChatService>();
builder.Services.AddScoped<IMessegeService, MessegeService>();

#endregion

#region DB

var UserKeysDBSettings = builder.Configuration.GetSection("ConnectionStrings").GetSection("Chats").Value;

builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseNpgsql(UserKeysDBSettings));

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
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
