using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QuickBite.MessageBus;
using QuickBite.Services.AuthAPI.Data;
using QuickBite.Services.AuthAPI.Models;
using QuickBite.Services.AuthAPI.Service;
using QuickBite.Services.AuthAPI.Service.IService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AuthDBContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("sqlServerAuthConnectionString"));
});
builder.Services.Configure<JWTOptios>(builder.Configuration.GetSection("APISettings:JWTOptios"));
builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<AuthDBContext>().AddDefaultTokenProviders();


builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IJWTTokenGenerator, JWTTokenGenerator>();
builder.Services.AddScoped<IMessageBus, MessageBus>();
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
