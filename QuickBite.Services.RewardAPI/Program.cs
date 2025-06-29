using Microsoft.EntityFrameworkCore;
using QuickBite.Services.RewardAPI.Data;
using QuickBite.Services.RewardAPI.Extension;
using QuickBite.Services.RewardAPI.Messaging;
using QuickBite.Services.RewardAPI.Services;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<RewardDBContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("sqlServerRewardConnectionString"));
});

var optionBuilder = new DbContextOptionsBuilder<RewardDBContext>();
optionBuilder.UseSqlServer(builder.Configuration.GetConnectionString("sqlServerRewardConnectionString"));
builder.Services.AddSingleton(new RewardService(optionBuilder.Options));

builder.Services.AddSingleton<IAzureServiceBusConsumer, AzureServiceBusConsumer>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
app.UseAzureServiceBusConsumer();
app.Run();
