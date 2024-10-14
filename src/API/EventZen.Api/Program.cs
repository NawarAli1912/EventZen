using EventZen.Api.Extensions;
using EventZen.Api.Middleware;
using EventZen.Modules.Events.Infrastructure;
using EventZen.Modules.Ticketing.Infrastructure;
using EventZen.Modules.Users.Infrastructure;
using EventZen.Shared.Application;
using EventZen.Shared.Infrastructure;
using EventZen.Shared.Presentation.ApiResults;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Serilog;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Enable serilog
builder.Host.UseSerilog((context, loggerConfiguration) =>
{
    loggerConfiguration.ReadFrom.Configuration(context.Configuration);
});

// Enable global exception handling
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(t => t.FullName?.Replace("+", "."));
});

// shared dependencies registration
string dbConnectionString = builder.Configuration.GetConnectionString("Database")!;
string redisConnectionString = builder.Configuration.GetConnectionString("Redis")!;

builder.Services.AddApplication([
    EventZen.Modules.Events.Application.AssemblyReference.Assembly,
    EventZen.Modules.Users.Application.AssemblyReference.Assembly,
    EventZen.Modules.Ticketing.Application.AssemblyReference.Assembly
    ]);
builder.Services.AddInfrastructure(
    [TicketingModule.ConfigureConsumers],
    dbConnectionString,
    redisConnectionString
    );

builder.Configuration.AddModuleConfiguration(["events", "users", "ticketing"]);


builder.Services.AddHealthChecks()
    .AddNpgSql(dbConnectionString)
    .AddRedis(redisConnectionString)
    .AddUrlGroup(
        new Uri(builder.Configuration.GetValue<string>("KeyCloak:HealthUrl")!), HttpMethod.Get, "Keycloak");

// modules registration
builder.Services.AddEventModules(builder.Configuration);
builder.Services.AddUsersModule(builder.Configuration);
builder.Services.AddTicketingModule(builder.Configuration);

WebApplication app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigration();
}

app.MapEndpoints();

app.MapHealthChecks("health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseSerilogRequestLogging();

app.UseExceptionHandler();

app.UseAuthentication();

app.UseAuthorization();

app.Run();
