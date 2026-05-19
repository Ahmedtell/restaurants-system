using FluentValidation;
using Restaurants.API.Restaurants.Application.Extensions;
using Restaurants.API.Restaurants.Infrastructure.Extensions;
using Restaurants.Application.Restaurants.DTOs;
using Restaurants.Application.Restaurants.Validators;
using Restaurants.Infrastructure.Seeders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Configuration.GetConnectionString("RestaurantsDb");

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);


var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>();
await seeder.Seed();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
