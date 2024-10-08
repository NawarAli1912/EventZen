using EventZen.Api.Extensions;
using EventZen.Modules.Events.Infrastructure;
using EventZen.Shared.Application;
using EventZen.Shared.Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(t => t.FullName?.Replace("+", "."));
});

builder.Services.AddApplication([
    EventZen.Modules.Events.Application.AssemblyReference.Assembly,
    ]);

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddEventModules(builder.Configuration);


WebApplication app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigration();
}

EventsModule.MapEndpoints(app);

app.Run();
