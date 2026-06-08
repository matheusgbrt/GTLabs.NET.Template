using Gtlabs.Authentication.Extensions;
using Gtlabs.Api.Extensions;
using Gtlabs.AspNet.Extensions;
using Gtlabs.AppRegistration.Extensions;
using Gtlabs.Consul.Extensions;
using Gtlabs.Logging.Extensions;
using GTLabs.NET.Template.Infrastructure.Contexts;
using Gtlabs.Persistence.Extensions;
using Gtlabs.Redis.Extensions;
using Gtlabs.ServiceBus.ServiceBus.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterApp("GTLabs.NET.Template");
await builder.Configuration.AddConsulConfigurationAsync();

builder.Host.AddBasicFeatures();
builder.ConfigureKestrelWithNetworkHelper();

builder.Services.AddBasicFeatures(builder.Configuration);
builder.Services.AddGtlabsTracing(builder.Configuration);
builder.Services.AddGtlabsAuthentication(options =>
{
    options.AllowAppAndUserTokens();
});
builder.Services.AddConsulRegistration(builder.Configuration);
builder.Services.RegisterServiceBus(builder.Configuration);
builder.Services.AddRedisCache(builder.Configuration);
builder.Services.AddPersistence<TemplateDbcontext>(builder.Configuration);

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
