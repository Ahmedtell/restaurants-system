using Restaurants.API.Restaurants.Application.Extensions;
using Restaurants.API.Restaurants.Infrastructure.Extensions;
using Restaurants.Infrastructure.Seeders;

var builder = WebApplication.CreateBuilder(args);

// Add services FIRST
builder.Services.AddControllers();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

// build app AFTER services
var app = builder.Build();

// Seed database (before run)
using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>();
    await seeder.Seed();
}

// Middleware pipeline
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();