using ECommerce.Core.Application.Mapping;
using ECommerce.Core.Application.Services.Abstractions;
using ECommerce.Core.Application.Services.Implementations;
using ECommerce.Infrastructure.Persistance.EFCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddHttpContextAccessor();
//builder.Services.
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MappingConfig>());
builder.Services.AddScoped<ILoggedInUserService, LoggedInUserService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IBrandService, BrandService>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddInfrastructure(connectionString);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
