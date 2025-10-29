using Gtlabs.Api.Extensions;
using Gtlabs.AppRegistration.Extensions;
using Gtlabs.Consul.Extensions;
using Gtlabs.DependencyInjections.DependencyInjectons.Extensions;
using Gtlabs.Redis.Extensions;
using Gtlabs.ServiceBus.ServiceBus.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterApp("GTLabs.NET.Template");
builder.Services.RegisterAllDependencies();
await builder.Configuration.AddConsulConfigurationAsync();
builder.Services.AddConsulRegistration(builder.Configuration);
builder.ConfigureKestrelWithNetworkHelper();
builder.Services.RegisterServiceBus(builder.Configuration);
builder.Services.AddRedisCache();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.AddConsulHealthCheck();

app.UseAuthorization();

app.MapControllers();

app.Run();