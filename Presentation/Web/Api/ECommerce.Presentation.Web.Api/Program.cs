using ECommerce.Core.Application;
using ECommerce.Infrastructure.Persistence.EFCore;
using ECommerce.Infrastructure.Persistence.EFCore.Abstractions;
using ECommerce.Infrastructure.Persistence.EFCore.Data;
using ECommerce.Infrastructure.Persistence.EFCore.Options;
using ECommerce.Presentation.Web.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var configuration = builder.Configuration;

builder.Services.AddScoped<IDbInitializer, DbInitializer>();
builder.Services.Configure<DefaultRolesAndUserConfigurationOptions>(
    configuration.GetSection(DefaultRolesAndUserConfigurationOptions.DefaultUserAndRole));

builder.Services.AddAuthorization();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddPresentation();
builder.Services.AddApplicationDependencies();
builder.Services.AddInfrastructure(connectionString, configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

SeedDatabase();

app.Run();

void SeedDatabase()
{
    using var scope = app.Services.CreateScope();
    var dbInitlializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
    dbInitlializer.Initialize();
}
