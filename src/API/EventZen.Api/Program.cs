using EventZen.Api.Extensions;
using EventZen.Modules.Events.Infrastructure;
using EventZen.Shared.Application;
using EventZen.Shared.Infrastructure;
using Serilog;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Enable serilog
builder.Host.UseSerilog((context, loggerConfiguration) =>
{
    loggerConfiguration.ReadFrom.Configuration(context.Configuration);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(t => t.FullName?.Replace("+", "."));
});

builder.Services.AddApplication([
    EventZen.Modules.Events.Application.AssemblyReference.Assembly,
    ]);

builder.Services.AddInfrastructure(builder.Configuration);

builder.Configuration.AddModuleConfiguration(["events"]);

builder.Services.AddEventModules(builder.Configuration);


WebApplication app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigration();
}

EventsModule.MapEndpoints(app);

app.UseSerilogRequestLogging();

app.Run();
