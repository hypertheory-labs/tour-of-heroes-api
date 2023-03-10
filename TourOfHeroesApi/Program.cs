using Microsoft.EntityFrameworkCore;
using TourOfHeroesApi;
using TourOfHeroesApi.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<HeroDataContext>(options =>
{
    options.UseSqlite($"data source=heroes.db");
});
var app = builder.Build();

using(var scope = app.Services.CreateScope()) {

    var context = scope.ServiceProvider.GetRequiredService<HeroDataContext>();
    context.Database.Migrate();
}
// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.MapGroup("/api/heroes").MapHeroRoutes();


app.Run();

