using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using QuickBite.GatewaySolution.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.AddAppAuthetication();
if (builder.Environment.EnvironmentName.ToString().ToLower().Equals("production"))
{
    builder.Configuration.AddJsonFile("ocelot.Production.json", optional: false, reloadOnChange: true);
}
else
{
    builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
}
builder.Services.AddOcelot(builder.Configuration);//Adding Ocelot to the service

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.UseOcelot().GetAwaiter().GetResult(); //Using Ocelot
app.Run();
