using Microsoft.EntityFrameworkCore;
using QuickBite.Services.EmailAPI.Data;
using QuickBite.Services.EmailAPI.Extension;
using QuickBite.Services.EmailAPI.Messaging;
using QuickBite.Services.EmailAPI.Services;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<EmailDBContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("sqlServerEmailConnectionString"));
});

/*We want to send email in AzureServiceBusConsumer which is singleton service.db context is scoped service. 
 * Injecting a scoped service into a singleton constructor is not allowed
 * Scoped services are meant to live only within the lifespan of a request (or a scope). 
 * If a singleton holds on to it, it outlives its valid scope leading to memory leak, Unexpected behavior
 * 115
*/

var optionBuilder = new DbContextOptionsBuilder<EmailDBContext>();
optionBuilder.UseSqlServer(builder.Configuration.GetConnectionString("sqlServerEmailConnectionString"));
builder.Services.AddSingleton(new EmailService(optionBuilder.Options));


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

app.UseAzureServiceBusConsumer(); //This is created to listen to azure message bus at start of lifeCycle and will stop at the end of life cycle. The method present in Messaging is invoked by the class present in extention folder

app.Run();
